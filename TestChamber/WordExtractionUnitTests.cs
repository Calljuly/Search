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
        public void ExtractWordsFromString_WordsAreExtractedCorrectly()
        {
            testExtractor = new WordExtractor();
            string filePath = @"C:/";
            string words = "hej! hejsan; hallå, tjena: sm-guld 2020.";
            wordList = testExtractor.ExtractWordsFromString(words, filePath);
            for (int i = 0; i < wordList.Count - 1; i++)
            {
                Assert.AreEqual("hej", wordList[0].word);
                Assert.AreEqual("hejsan", wordList[1].word);
                Assert.AreEqual("hallå", wordList[2].word);
                Assert.AreEqual("tjena", wordList[3].word);
                Assert.AreEqual("smguld", wordList[4].word);
                Assert.AreEqual("2020", wordList[5].word);
            }
        }
        [Test]
        public void ExtractWordsFromString_FilePathIsCorrect()
        {
            testExtractor = new WordExtractor();
            string filePath = @"C:/";
            string words = "hej hejsan hallå, tjena sm-guld 2020.";
            wordList = testExtractor.ExtractWordsFromString(words, filePath);
            foreach (var word in wordList)
            {
                Assert.AreEqual(filePath, word.file);
            }
        }
        
        [Test]
        public void ExtractWordsFromString_FilePathNotEmpty()
        {
            testExtractor = new WordExtractor();
            wordList = testExtractor.ExtractWordsFromString("yes yes yes", @"C:/");
            foreach (var word in wordList)
            {
                Assert.IsNotEmpty(word.file);
            }
        }
        [Test]
        public void ExtractWordsFromString_WordsWithSeparatorsAreSameWord()
        {
            testExtractor = new WordExtractor();
            wordList = testExtractor.ExtractWordsFromString("yes yes, yes.", @"C:/");
            foreach (var word in wordList)
            {
                Assert.AreEqual("yes", word.word);
            }
        }
        [Test]
        public void ExtractWordsFromString_ExtractFromEmptyStrings()
        {
            testExtractor = new WordExtractor();
            wordList = testExtractor.ExtractWordsFromString("", "");
            Assert.IsEmpty(wordList);
        }
        [Test]
        public void ExtractWordsFromString_ExtractFromEmptyFilePath()
        {
            testExtractor = new WordExtractor();
            wordList = testExtractor.ExtractWordsFromString("Filepath is empty", "");
            Assert.IsEmpty(wordList);

        }
        [Test]
        public void ExtractWordsFromString_ExtractFromEmptyText()
        {
            testExtractor = new WordExtractor();
            wordList = testExtractor.ExtractWordsFromString("", "Text document is empty");
            Assert.IsEmpty(wordList);
        }
        [Test]
        public void ExtractWordsFromString_TextAndFilePathIsNull()
        {
            //wordList = new List<Word>();
            testExtractor = new WordExtractor();
            wordList = testExtractor.ExtractWordsFromString(null, null);
            Assert.IsEmpty(wordList);
            //Assert.AreEqual(null, wordList[0].word);
            //Assert.AreEqual(null, wordList[0].file);
        }
    }
}