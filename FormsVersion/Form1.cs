using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;

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
            SetLoadButtonsOn(false);
            SetInterractionButtonsOn(false);

            // We only ever want the listboxes to show the value property of a Word object. 
            lbxSortedWords.DisplayMember = "Value";
            lbxUnsortedWords.DisplayMember = "Value";
        }

        public void btnBrowse_Click(object sender, EventArgs e)
        {
            // The dialogue should only accept .txt files. 
            openFileDialogue.Filter = "Text files (*.txt)|*.txt";
            openFileDialogue.FileName = "";

            if (openFileDialogue.ShowDialog() != DialogResult.Cancel)
            {
                if (!fileList.Contains(openFileDialogue.FileName))
                {
                    // Add files to list and show added files in lbxFileList. 
                    fileList.Add(openFileDialogue.FileName);
                    lbxFileList.Items.Add(openFileDialogue.FileName);

                    // Interraction buttons disabled because added files means the user needs to load the files first. 
                    SetInterractionButtonsOn(false);
                }
                else
                {
                    MessageBox.Show("This file has already been added.");
                }
                
            }


            if (fileList.Count > 0)
            {
                SetLoadButtonsOn(true);
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveViaSaveDialogue(sortedWordsList);
                     
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            fileList.RemoveAt(fileList.Count - 1);
            lbxFileList.Items.RemoveAt(lbxFileList.Items.Count - 1);

            if (fileList.Count < 1)
            {
                // Disable load button if there are no files to load. 
                SetLoadButtonsOn(false);
                
            }

            // If list is changed then the user needs to reload before being able to search or save again. 
            SetInterractionButtonsOn(false);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            // Reset info to clear way for new info. 
            dataSearchResults.Rows.Clear();
            extractor = new WordExtractor();

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

            sortedWordsList.RemoveAll(x => x.Value == "");
            unsortedWordsList.RemoveAll(x => x.Value == "");

            // Show items in each list in each listBox
            lbxUnsortedWords.DataSource = unsortedWordsList;
            lbxSortedWords.DataSource = sortedWordsList;

            // Now things have been loaded and the user can search or save. 
            SetInterractionButtonsOn(true);

            MessageBox.Show("All files loaded and sorted");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, int> word in Engine.BinarySearch(sortedWordsList, true, tbxSearch.Text))
            {
                dataSearchResults.Rows.Add(tbxSearch.Text, word.Value, word.Key.ToString());
            }
         
        }

        private void SetLoadButtonsOn(bool on)
        {
            btnLoad.Enabled = on;
            btnRemove.Enabled = on;
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
