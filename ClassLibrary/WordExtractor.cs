using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TestChamber")]

namespace SearchLibrary
{
    public class WordExtractor
    {
        private List<Word> compoundedList;
        public WordExtractor()
        {
            compoundedList = new List<Word>();
        }
        /// <summary>
        /// Replaces a non word- or digit character with an empty string(exceptions made for space and ').
        /// </summary>
        /// <param name="text"></param>
        /// <returns>String without special characters</returns>
        internal string ReplaceSpecialCharacters(string text)
        {
            var stringBuilder = new StringBuilder();
            try
            {
                foreach (char character in text)
                {
                    if (char.IsLetterOrDigit(character) || (character == ' ') || (character == '\'') || (character == '\n'))
                    {
                        stringBuilder.Append(character);
                    }
                }
                return stringBuilder.ToString();
            }
            catch (NullReferenceException)
            {
                return stringBuilder.ToString();
            }
        }
        /// <summary>
        /// Extracts all words from a given string and returns a list of word objects containing the actual word and the origin of the text. 
        /// </summary>
        /// <param name="fileContent"></param>
        /// <param name="filePath"></param>
        /// <returns>A list of all words found in the string, non-unique</returns>
        public List<Word> ExtractWordsFromTextFile(string fileContent, string filePath)
        {
            var wordList = new List<Word>();
            try
            {
                if (!(fileContent == "") && !(filePath == "") && fileContent != null && filePath != null)
                {
                    var textWithoutSpecialCharacters = this.ReplaceSpecialCharacters(fileContent);

                    //Upon space or new line splits the string into a piece of string.
                    var splittedText = textWithoutSpecialCharacters.Split(' ', '\n');

                    //Adds all words in the text in to a list of words.
                    foreach (var word in splittedText)
                    {
                        word.Trim('\n');
                        word.Trim();
                        word.TrimStart('\'');
                        if (word != "")
                        {
                            wordList.Add(new Word(word, filePath));
                        }
                    }
                    this.AppendWordListsToCompoundedList(wordList);
                }
                return wordList;
            }
            catch (NullReferenceException)
            {
                return wordList;
            }
        }
        /// <summary>
        /// Adds the words of a single word list to a collection where words from all the current selected wordlists exists.
        /// </summary>
        /// <param name="wordList"></param>
        /// <returns>The WordExtractors compounded list</returns>
        internal List<Word> AppendWordListsToCompoundedList(List<Word> wordList)
        {
            foreach (var word in wordList)
            {
                compoundedList.Add(word);
            }
            return compoundedList;
        }
        /// <summary>
        /// Gets a copy of the compounded list of a WordExtractor.
        /// </summary>
        /// <returns></returns>
        public List<Word> GetCompoundedList()
        {
            List<Word> publicCompoundedList = new List<Word>();
            foreach (var word in this.compoundedList)
            {
                publicCompoundedList.Add(word);
            }
            return publicCompoundedList;
        }
        /// <summary>
        /// From a given list of word objects builds the value of the word objects into a string. Each word separated with a new line.
        /// </summary>
        /// <param name="wordList"></param>
        /// <returns></returns>
        public string BuildStringFromListOfWords(List<Word> wordList)
        {
            StringBuilder fileContent = new StringBuilder();
            try
            {
                foreach (var wordObject in wordList)
                {
                    fileContent.Append(wordObject.Value + Environment.NewLine);
                }
                return fileContent.ToString();
            }
            catch (NullReferenceException)
            {
                return fileContent.ToString();
            }

        }
    }
}
