using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SearchLibrary;

namespace FormsVersion
{
    public partial class Form1 : Form
    {
        // Essential variables
        List<string> fileList = new List<string>();
        List<Word> unsortedWordsList = new List<Word>();
        List<Word> sortedWordsList = new List<Word>();
        WordExtractor extractor = new WordExtractor();
        public static Form1 form;

        public Form1()
        {
            InitializeComponent();

            // Disable buttons the user shouldn't click on at this point. 
            SetInterractionButtonsOn(false);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("se-SE");
        }

        public void btnBrowse_Click(object sender, EventArgs e)
        {
            // The dialogue should only accept .txt files. 
            openFileDialogue.Filter = "Text files (*.txt)|*.txt";
            openFileDialogue.FileName = "";

            openFileDialogue.Multiselect = true;

            if (openFileDialogue.ShowDialog() != DialogResult.Cancel)
            {
                bool allFilesAdded = true;

                for (int i = 0; i < openFileDialogue.FileNames.Length; i++)
                {
                    // Go trhrough all and then give 
                    if (!fileList.Contains(openFileDialogue.FileNames[i]))
                    {
                        // Add files to list and show added files in lbxFileList. 
                        fileList.Add(openFileDialogue.FileNames[i]);
                        lbxFileList.Items.Add(openFileDialogue.FileNames[i]);

                        // Interraction buttons disabled because added files means the user needs to load the files first. 
                        SetInterractionButtonsOn(false);
                    }
                    else
                    {
                        allFilesAdded = false;
                    }
                    
                }

                Task.Run(() => LoadContent());
                lblSortedList.Text = "Sorted list of words";
                lblUnsortedList.Text = "Unsorted list of words";

                if (!allFilesAdded)
                {
                    MessageBox.Show("One or more files were skipped because they were already added before.");
                }

                // Now things have been loaded and the user can search or save. 
                SetInterractionButtonsOn(true);

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveViaSaveDialogue(sortedWordsList);
                     
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            fileList.Clear();
            lbxFileList.Items.Clear();

            sortedWordsList.Clear();
            unsortedWordsList.Clear();

            lbxSortedWords.DataSource = null;
            lbxUnsortedWords.DataSource = null;
            dataSearchResults.Rows.Clear();
            SetInterractionButtonsOn(false);

            lblSortedList.Text = "Sorted list of words";
            lblUnsortedList.Text = "Unsorted list of words";
            lblFiles.Text = "Added Files";
        }

        private void LoadContent()
        {
            // Reset info to clear way for new info. 
            dataSearchResults.Invoke((MethodInvoker)delegate { dataSearchResults.Rows.Clear(); });
            lblFiles.Invoke((MethodInvoker)delegate
            {
                lblFiles.Text = "Added Files (Analyzing files...)";
            });
            
            extractor = new WordExtractor();

            DateTime start = DateTime.Now;
            for (int i = 0; i < fileList.Count; i++)
            {
                string fileContent = IO.ReadFile(fileList[i]);
                extractor.ExtractWordsFromTextFile(fileContent, fileList[i]);

            }

            // Create one sorted list and one unsorted. 
            unsortedWordsList = extractor.GetCompoundedList();
            List<Word> tmp = extractor.GetCompoundedList();
            Engine.QuickSort(tmp, 0, tmp.Count - 1);
            sortedWordsList = tmp;
            
            TimeSpan span = DateTime.Now - start;

            // Since LoadContent() is loaded in a new thread, we need to tell the thread to start the controllers in the main thread
            // otherwise it doesn't work. 
            lblSortedList.Invoke((MethodInvoker)delegate {
                lblSortedList.Text = "Sorted list of words (Loading... This might take a while)";

            });

            lblUnsortedList.Invoke((MethodInvoker)delegate {
                lblUnsortedList.Text = "Unsorted list of words (Loading... This might take a while)";

            });

            lblFiles.Invoke((MethodInvoker)delegate {
                
                lblFiles.Text = $"Files analyzed and sorted... It took {span.TotalSeconds.ToString("F")} seconds";
                
            });


            lblFiles.Invoke((MethodInvoker)delegate {
                // We only ever want the listboxes to show the value property of a Word object. 
                lbxSortedWords.DisplayMember = "Value";
                lbxUnsortedWords.DisplayMember = "Value";

                // Show items in each list in each listBox
                lbxSortedWords.BeginUpdate();
                lbxUnsortedWords.BeginUpdate();
                lbxSortedWords.DataSource = sortedWordsList;
                lbxUnsortedWords.DataSource = unsortedWordsList;
                lbxSortedWords.EndUpdate();
                lbxUnsortedWords.EndUpdate();
                lblSortedList.Text = "Sorted list of words (Done)";
                lblUnsortedList.Text = "Unsorted list of words (Done)";
            });
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, int> word in Engine.BinarySearch(sortedWordsList, true, tbxSearch.Text))
            {
                dataSearchResults.Rows.Add(tbxSearch.Text, word.Value, word.Key.ToString());
            }
         
        }

        private void SetInterractionButtonsOn(bool on)
        {
            btnSave.Enabled = on;
            btnSearch.Enabled = on;
        }

        private void SaveViaSaveDialogue(List<Word> list)
        {
            // Setting default folder to desktop and file-type to .txt
            saveFileDialogue.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            saveFileDialogue.DefaultExt = ".txt";
            saveFileDialogue.Filter = "TXT | *.txt";

            if (saveFileDialogue.ShowDialog() != DialogResult.Cancel)
            {
                // Create a string out of the sorted list and save it. 
                string stringFromList = extractor.BuildStringFromListOfWords(list);
                string fullFilePath = IO.SaveFile(stringFromList, saveFileDialogue.InitialDirectory, Path.GetFileNameWithoutExtension(saveFileDialogue.FileName));

                if (fullFilePath == "Could not save file.")
                {
                    MessageBox.Show(fullFilePath);
                }
                else
                {
                    MessageBox.Show($"Finished saving file at {fullFilePath}");
                }

            }
        }
    }
}
