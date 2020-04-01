using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TestChamber")]

namespace ClassLibrary
{
    public class WordExtractor
    {
        private List<Word> compoundedList; // ändra private/internal, endast public för tester
        public WordExtractor()
        {
            compoundedList = new List<Word>();
        }
        /// <summary>
        /// Replaces a non word- or digit character with an empty string(exceptions made for space and ').
        /// </summary>
        /// <param name="text"></param>
        /// <returns>String without special characters</returns>
        internal string ReplaceSpecialCharacters(string text) //enkapsulera till internal/private
        {
            try
            {
                var stringBuilder = new StringBuilder();
                foreach (char character in text)
                {
                    if (char.IsLetterOrDigit(character) || (character == ' ') || (character == '\''))
                    {
                        stringBuilder.Append(character);
                    }
                }
                return stringBuilder.ToString();
            }
            catch (NullReferenceException)
            {
                return null;
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
                if (!(fileContent == "") && !(filePath == ""))
                {
                    var textWithoutSpecialCharacters = this.ReplaceSpecialCharacters(fileContent);

                    //Upon space splits the string into a piece of string.
                    var splittedText = textWithoutSpecialCharacters.Split(' ');

                    //Adds all words in the text in to a list of words.
                    foreach (var word in splittedText)
                    {
                        wordList.Add(new Word(word, filePath));
                    }
                }
                this.AppendWordListsToCompoundedList(wordList);
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
        internal List<Word> AppendWordListsToCompoundedList(List<Word> wordList) // ändra till internal 
        {
            foreach (var word in wordList)
            {
                compoundedList.Add(word);
            }
            return compoundedList;
        }
        public List<Word> GetCompoundedList()
        {
            List<Word> publicCompoundedList = this.compoundedList;
            return publicCompoundedList;
        }
        public string BuildStringFromListOfWords(List<Word> wordList)
        {
            StringBuilder fileContent = new StringBuilder();
            fileContent.Append($"Word: \t\t\t File Path: {Environment.NewLine}");
            foreach (var wordObject in wordList)
            {
                fileContent.Append(wordObject.Value + "\t\t\t(" + wordObject.File + ")" + Environment.NewLine);
            }
            return fileContent.ToString();
        }
    }
}
