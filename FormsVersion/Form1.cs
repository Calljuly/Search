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
        public Form1()
        {
            InitializeComponent();
        }

        // Essential variables
        List<string> fileList = new List<string>();
        List<Word> unsortedWordsList = new List<Word>();
        List<Word> sortedWordsList = new List<Word>();

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialogue.Filter = "Text files (*.txt)|*.txt";
            openFileDialogue.FileName = "";

            if (openFileDialogue.ShowDialog() != DialogResult.Cancel)
            {
                fileList.Add(openFileDialogue.FileName);
                //lbxFileList.DataSource = fileList;
                lbxFileList.Items.Add(openFileDialogue.FileName);
                //try
                //{
                    
                //}
                //catch (ArgumentException)
                //{
                //    MessageBox.Show("File is not an acceptable format", "EditImages",
                //                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //// Starta i mappen som filen låg i och föreslå namn och format på den nya filen.
            //string fileName = Path.GetFileName(pathToImage);
            //saveFileDialogue.FileName = PathManipulations.EditFileName(fileName, currentManipulation);
            //saveFileDialogue.InitialDirectory = pathToDirectory;
            //saveFileDialogue.DefaultExt = ".png";
            //saveFileDialogue.Filter = "PNG | *.png | JPG |*.jpg";

            if (saveFileDialogue.ShowDialog() != DialogResult.Cancel)
            {

            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            fileList.RemoveAt(fileList.Count - 1);
            lbxFileList.DataSource = fileList;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            WordExtractor extractor = new WordExtractor();

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

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, int> word in Engine.BinarySearch(sortedWordsList, true, tbxSearch.Text))
            {
                lbxSearchResult.Items.Add($"{tbxSearch.Text} was found {word.Value} times in {word.Key}");
            }
         
        }

        // Common.InsertText(rtbAbout, "TextSwe\\Omappen.rtf");
        // Eller varför inte bara skriva ut listan med ord i ny listbox?
        //static public void InsertText(RichTextBox tbx, string file)
        //{

        //    tbx.Rtf = File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}{file}");
        //    tbx.SelectAll();
        //    tbx.SelectionIndent += 20;
        //    tbx.SelectionRightIndent += 20;
        //    tbx.SelectionLength = 0;
        //    tbx.DeselectAll();
        //}
    }
}
