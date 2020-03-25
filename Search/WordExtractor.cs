using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace Search
{
    public class WordExtractor
    {
        public List<Word> ExtractWords(string text, string filePath)
        {
            var wordList = new List<Word>();
            if (!(text == "") && !(filePath == ""))
            {
                //Replaces all characters specified in the regular expression of 'text' with an empty string.
                var regexdText = Regex.Replace(text, "[.,{}¤#\"\'*:;<>|?=!_&/\\n\\r\\e\\t]", string.Empty); // Dela upp metod i två delar? en för att ta bort specialtecken, en för att splitta ord?
                                                                                                            //Upon space splits the string into a piece of string.
                var splittedText = regexdText.Split(' ');
                //Adds all words in the text in to a list of words.
                foreach (var word in splittedText)
                {
                    wordList.Add(new Word(word, filePath));
                }
            }
            return wordList;
            //var regex = new Regex("[\\s\\W\\n\\t]");
            //var test = text.Where(char.IsPunctuation).Distinct().ToArray();
            //var words = text.Split().Select(x => x.Trim(test));
        }
    }
}
