using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace Search
{
    public class WordExtractor
    {
        public string ReplaceSeparators(string text) //enkapsulera till internal/private
        {
            var sb = new StringBuilder();
            //try
            //{
                foreach (char c in text)
                {
                    if (char.IsLetterOrDigit(c) || (c == ' ') || (c == '\''))
                    {
                        sb.Append(c);
                    }
                }
                return sb.ToString();
            //}
            //catch (NullReferenceException)
            //{
            //    return sb.ToString();
            //}
        }
        public List<Word> ExtractWordsFromString(string text, string filePath)
        {
            var extractor = new WordExtractor();
            var wordList = new List<Word>();
            try
            {
                if (!(text == "") && !(filePath == ""))
                {
                    var regexdText = extractor.ReplaceSeparators(text);

                    //Upon space splits the string into a piece of string.
                    var splittedText = regexdText.Split(' ');

                    //Adds all words in the text in to a list of words.
                    foreach (var word in splittedText)
                    {
                        wordList.Add(new Word(word, filePath));
                    }
                }
                return wordList;
            }
            catch (NullReferenceException)
            {
                return wordList;
            }
            //Replaces all characters specified in the regular expression of 'text' with an empty string.
            //var regexdText = Regex.Replace(text, "[.,+{}¤#\"\'*:;<>|?=!_&/\\n\\r\\e\\t]", string.Empty);
            //var regex = new Regex("[\\s\\W\\n\\t]");
            //var test = text.Where(char.IsPunctuation).Distinct().ToArray();
            //var words = text.Split().Select(x => x.Trim(test));
        }
    }
}
