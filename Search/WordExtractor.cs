using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace Search
{
    public class WordExtractor
    {
        public List<Word> compoundedList; // ändra private/internal, endast public för tester
        public WordExtractor()
        {
            compoundedList = new List<Word>();
        }
        /// <summary>
        /// Replaces a non word- or digit character with an empty string(exceptions made for space and ').
        /// </summary>
        /// <param name="text"></param>
        /// <returns>String without special characters</returns>
        public string ReplaceSpecialCharacter(string text) //enkapsulera till internal/private
        {
            var sb = new StringBuilder();
            foreach (char c in text)
            {
                if (char.IsLetterOrDigit(c) || (c == ' ') || (c == '\''))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// Extracts all words from a given string and returns a list of word objects containing the actual word and the origin of the text. 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="filePath"></param>
        /// <returns>A list of all words found in the string, non-unique</returns>
        public List<Word> ExtractWordsFromString(string text, string filePath)
        {
            var wordList = new List<Word>();
            try
            {
                if (!(text == "") && !(filePath == ""))
                {
                    var textWithoutSpecialCharacters = this.ReplaceSpecialCharacter(text);

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
        public List<Word> AppendWordListsToCompoundedList(List<Word> wordList) // ändra till internal 
        {
            foreach (var word in wordList)
            {
                compoundedList.Add(word);
            }
            return compoundedList;
        }
    }
}
