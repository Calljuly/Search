using System.Collections.Generic;
using NUnit.Framework;
using Search;

namespace TestChamber
{
    public class WordExtractionUnitTests //Patrik
    {
        List<Word> wordList;
        WordExtractor testExtractor;
        [Test]
        public void WordsAreExtractedCorrectly()
        {
            testExtractor = new WordExtractor();
            string filePath = @"C:/";
            string words = "hej hejsan hallå, tjena sm-guld 2020.";
            wordList = testExtractor.ExtractWords(words, filePath);
            for (int i = 0; i < wordList.Count - 1; i++)
            {
                Assert.AreEqual("hej", wordList[0].word);
                Assert.AreEqual("hejsan", wordList[1].word);
                Assert.AreEqual("hallå", wordList[2].word);
                Assert.AreEqual("tjena", wordList[3].word);
                Assert.AreEqual("sm-guld", wordList[4].word);
                Assert.AreEqual("2020", wordList[5].word);
            }
        }
        [Test]
        public void FilePathIsCorrect()
        {
            testExtractor = new WordExtractor();
            string filePath = @"C:/";
            string words = "hej hejsan hallå, tjena sm-guld 2020.";
            wordList = testExtractor.ExtractWords(words, filePath);
            foreach (var word in wordList)
            {
                Assert.AreEqual(filePath, word.file);
            }
        }
        
        [Test]
        public void FilePath_NotEmpty()
        {
            testExtractor = new WordExtractor();
            wordList = testExtractor.ExtractWords("yes yes yes", @"C:/");
            foreach (var word in wordList)
            {
                Assert.IsNotEmpty(word.file);
            }
        }
        [Test]
        public void WordsWithSeparatorsAreSameWord()
        {
            testExtractor = new WordExtractor();
            wordList = testExtractor.ExtractWords("yes yes, yes.", @"C:/");
            foreach (var word in wordList)
            {
                Assert.AreEqual("yes", word.word);
            }
        }
        [Test]
        public void ExtractFromEmptyStrings()
        {
            wordList = new List<Word>();
            testExtractor = new WordExtractor();
            var test = testExtractor.ExtractWords("", "");
            Assert.IsEmpty(test);
        }
        [Test]
        public void ExtractFromEmptyFilePath()
        {
            wordList = new List<Word>();
            testExtractor = new WordExtractor();
            var test = testExtractor.ExtractWords("Filepath is empty", "");
            Assert.IsEmpty(test);

        }
        [Test]
        public void ExtractFromEmptyText()
        {
            wordList = new List<Word>();
            testExtractor = new WordExtractor();
            var test = testExtractor.ExtractWords("", "Text document is empty");
            Assert.IsEmpty(test);
        }
    }
}