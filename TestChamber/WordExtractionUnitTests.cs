using System;
using System.Collections.Generic;
using NUnit.Framework;
using Search;

namespace TestChamber
{
    public class WordExtractionUnitTests //Patrik
    {
        List<Word> wordList;
        WordExtractor testExtractor = new WordExtractor();
        [Test]
        public void ExtractWordsFromString_WordsAreExtractedCorrectly()
        {
            string filePath = @"C:/";
            string words = "hej! hejsan; hallå, tjena: sm-guld 2020.";
            wordList = testExtractor.ExtractWordsFromTextFile(words, filePath);
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
            string filePath = @"C:/";
            string words = "hej hejsan hallå, tjena sm-guld 2020.";
            wordList = testExtractor.ExtractWordsFromTextFile(words, filePath);
            foreach (var word in wordList)
            {
                Assert.AreEqual(filePath, word.file);
            }
        }

        [Test]
        public void ExtractWordsFromString_FilePathNotEmpty()
        {
            wordList = testExtractor.ExtractWordsFromTextFile("yes yes yes", @"C:/");
            foreach (var word in wordList)
            {
                Assert.IsNotEmpty(word.file);
            }
        }
        [Test]
        public void ExtractWordsFromString_WordsWithSeparatorsAreSameWord()
        {
            wordList = testExtractor.ExtractWordsFromTextFile("yes yes, yes.", @"C:/");
            foreach (var word in wordList)
            {
                Assert.AreEqual("yes", word.word);
            }
        }
        [Test]
        public void ExtractWordsFromString_ExtractFromEmptyStrings()
        {
            wordList = testExtractor.ExtractWordsFromTextFile("", "");
            Assert.IsEmpty(wordList);
        }
        [Test]
        public void ExtractWordsFromString_ExtractFromEmptyFilePath()
        {
            wordList = testExtractor.ExtractWordsFromTextFile("Filepath is empty", "");
            Assert.IsEmpty(wordList);

        }
        [Test]
        public void ExtractWordsFromString_ExtractFromEmptyText()
        {
            wordList = testExtractor.ExtractWordsFromTextFile("", "Text document is empty");
            Assert.IsEmpty(wordList);
        }
        [Test]
        public void ExtractWordsFromString_TextAndFilePathIsNull_ListIsEmpty()
        {
            wordList = testExtractor.ExtractWordsFromTextFile(null, null);
            Assert.IsEmpty(wordList);
        }
        [Test]
        public void ExtractWordsFromString_TextAndFilePathIsNull_ListIsNotNull()
        {
            wordList = testExtractor.ExtractWordsFromTextFile(null, null);
            Assert.IsNotNull(wordList);
        }
        [Test]
        public void ExtractWordsFromString_TextIsNull_ListIsEmpty()
        {
            wordList = testExtractor.ExtractWordsFromTextFile(null, "C");
            Assert.IsEmpty(wordList);
        }
        [Test]
        public void ExtractWordsFromString_TextIsNull_ListIsNotNull()
        {
            wordList = testExtractor.ExtractWordsFromTextFile(null, "C");
            Assert.IsNotNull(wordList);
        }
        [Test]
        public void ExtractWordsFromString_FilePathIsNull_WordFileIsNull()
        {
            wordList = testExtractor.ExtractWordsFromTextFile("mjauuuu kss kss", null);
            foreach (var word in wordList)
            {
                Assert.IsNull(word.file);
            }
        }
        [Test]
        public void ExtractWordsFromString_FilePathIsNull_ListIsNotNull()
        {
            wordList = testExtractor.ExtractWordsFromTextFile("mjauuuu kss kss", null);
            Assert.IsNotNull(wordList);
        }
        [Test]
        public void ReplaceSpecialCharacter_HappyDays()
        {
            string s = "hej, hej. hej! hej=hej( hej[i] / hej&hej%hej hej'hej\n hej: hej; @hej$hej kram\\kram* ja? #är det sant\"-+{}";
            s = testExtractor.ReplaceSpecialCharacters(s);
            Assert.AreEqual("hej hej hej hejhej heji  hejhejhej hej'hej hej hej hejhej kramkram ja är det sant", s);
        }
        [Test]
        public void ReplaceSpecialCharacter_InsertEmptyString()
        {
            string s = string.Empty;
            s = testExtractor.ReplaceSpecialCharacters(s);
            Assert.IsEmpty(s);
        }
        [Test]
        public void ReplaceSpecialCharacter_InsertNull()
        {
            Assert.IsNull(testExtractor.ReplaceSpecialCharacters(null));
            //Assert.Throws<NullReferenceException>(() => testExtractor.ReplaceSpecialCharacter(null));
        }
        /// <summary>
        /// Testet behöver göras om. Är inte alls bra i nuläget.
        /// </summary>
        [Test]
        public void AppendWordListsToCompoundedList_HappyDays()
        {
            testExtractor.ExtractWordsFromTextFile("yes hello", "a");
            testExtractor.ExtractWordsFromTextFile("yes hello", "b");
            Assert.AreEqual("a", testExtractor.GetCompoundedList()[0].file);
            Assert.AreEqual("a", testExtractor.GetCompoundedList()[1].file);
            Assert.AreEqual("b", testExtractor.GetCompoundedList()[2].file);
            Assert.AreEqual("b", testExtractor.GetCompoundedList()[3].file);
        }
        [Test]
        public void AppendWordListsToCompoundedList_AddsCorrectNumberOfWords()
        {
            testExtractor.ExtractWordsFromTextFile("yes hello", "a");
            testExtractor.ExtractWordsFromTextFile("yes hello", "b");
            Assert.AreEqual(4, testExtractor.GetCompoundedList().Count);
        }
    }
}