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


        public Form1()
        {
            InitializeComponent();
            SetLoadButtonsOn(false);
            SetInterractionButtonsOn(false);
        }

       
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialogue.Filter = "Text files (*.txt)|*.txt";
            openFileDialogue.FileName = "";

            if (openFileDialogue.ShowDialog() != DialogResult.Cancel)
            {
                fileList.Add(openFileDialogue.FileName);
                lbxFileList.Items.Add(openFileDialogue.FileName);
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
                SetLoadButtonsOn(false);
                
            }

            SetInterractionButtonsOn(false);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
           

            for (int i = 0; i < fileList.Count; i++)
            {
                string fileContent = IO.ReadFile(fileList[i]);
                extractor.ExtractWordsFromTextFile(fileContent, fileList[i]);

            }

            unsortedWordsList = extractor.GetCompoundedList();
            sortedWordsList = extractor.GetCompoundedList();
            Engine.QuickSort(sortedWordsList, 0, sortedWordsList.Count - 1);

            for (int i = 0; i < unsortedWordsList.Count; i++)
            {
                lbxUnsortedWords.Items.Add(unsortedWordsList[i].Value);
            }

            for (int i = 0; i < sortedWordsList.Count; i++)
            {
                lbxSortedWords.Items.Add(sortedWordsList[i].Value);
            }

            SetInterractionButtonsOn(true);

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, int> word in Engine.BinarySearch(sortedWordsList, true, tbxSearch.Text))
            {
                lbxSearchResults.Items.Add($"\"{tbxSearch.Text}\" was found {word.Value} times in {word.Key}");
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
            saveFileDialogue.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            saveFileDialogue.DefaultExt = ".txt";
            saveFileDialogue.Filter = "TXT | *.txt";

            if (saveFileDialogue.ShowDialog() != DialogResult.Cancel)
            {
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
