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
            //Replaces all characters specified in the regular expression of 'text' with an empty string.
            var regexdText = Regex.Replace(text, "[.,{}¤#\"\'*:;<>|?=!_&/\\n\\r\\e\\t]", string.Empty);
            //Upon space splits the string into a piece of string.
            var splittedText = regexdText.Split(' ');
            var wordList = new List<Word>();
            //Adds all words in the text in to a list of words.
            foreach (var word in splittedText)
            {
                wordList.Add(new Word(word, filePath));
            }
            return wordList;
            //var regex = new Regex("[\\s\\W\\n\\t]");
            //var test = text.Where(char.IsPunctuation).Distinct().ToArray();
            //var words = text.Split().Select(x => x.Trim(test));
        }
    }
}
