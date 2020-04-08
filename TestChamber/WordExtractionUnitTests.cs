using System;
using System.Collections.Generic;
using NUnit.Framework;
using Search;
using ClassLibrary;

namespace TestChamber
{
    public class WordExtractionUnitTests //Patrik
    {
        List<Word> wordList;
        WordExtractor testExtractor = new WordExtractor();
        [Test]
        public void ExtractWordsFromTextFile_WordsAreExtractedCorrectly_WhiteSpace()
        {
            string filePath = @"C:/";
            string words = "hej! hejsan; hallå, tjena: sm-guld 2020.";
            wordList = testExtractor.ExtractWordsFromTextFile(words, filePath);
            for (int i = 0; i < wordList.Count - 1; i++)
            {
                Assert.AreEqual("hej", wordList[0].Value);
                Assert.AreEqual("hejsan", wordList[1].Value);
                Assert.AreEqual("hallå", wordList[2].Value);
                Assert.AreEqual("tjena", wordList[3].Value);
                Assert.AreEqual("smguld", wordList[4].Value);
                Assert.AreEqual("2020", wordList[5].Value);
            }
        }
        [Test]
        public void ExtractWordsFromTextFile_WordsAreExtractedCorrectly_NewLine()
        {
            string filePath = @"C:/";
            string words = "hej!\nhejsan;\nhallå,\ntjena:\nsm-guld\n2020.";
            wordList = testExtractor.ExtractWordsFromTextFile(words, filePath);
            for (int i = 0; i < wordList.Count - 1; i++)
            {
                Assert.AreEqual("hej", wordList[0].Value);
                Assert.AreEqual("hejsan", wordList[1].Value);
                Assert.AreEqual("hallå", wordList[2].Value);
                Assert.AreEqual("tjena", wordList[3].Value);
                Assert.AreEqual("smguld", wordList[4].Value);
                Assert.AreEqual("2020", wordList[5].Value);
            }
        }
        [Test]
        public void ExtractWordsFromTextFile_WordsAreExtractedCorrectly_NewLineAndWhiteSpace()
        {
            string filePath = @"C:/";
            string words = "hej! \nhejsan;\n hallå,\n tjena:\n sm-guld\n 2020.";
            wordList = testExtractor.ExtractWordsFromTextFile(words, filePath);
            for (int i = 0; i < wordList.Count - 1; i++)
            {
                Assert.AreEqual("hej", wordList[0].Value);
                Assert.AreEqual("hejsan", wordList[1].Value);
                Assert.AreEqual("hallå", wordList[2].Value);
                Assert.AreEqual("tjena", wordList[3].Value);
                Assert.AreEqual("smguld", wordList[4].Value);
                Assert.AreEqual("2020", wordList[5].Value);
            }
        }
        [Test]
        public void ExtractWordsFromTextFile_FilePathIsCorrect()
        {
            string filePath = @"C:/";
            string words = "hej hejsan hallå, tjena sm-guld 2020.";
            wordList = testExtractor.ExtractWordsFromTextFile(words, filePath);
            foreach (var word in wordList)
            {
                Assert.AreEqual(filePath, word.File);
            }
        }

        [Test]
        public void ExtractWordsFromTextFile_FilePathNotEmpty()
        {
            wordList = testExtractor.ExtractWordsFromTextFile("yes yes yes", @"C:/");
            foreach (var word in wordList)
            {
                Assert.IsNotEmpty(word.File);
            }
        }
        [Test]
        public void ExtractWordsFromTextFile_WordsWithSeparatorsAreSameWord()
        {
            wordList = testExtractor.ExtractWordsFromTextFile("yes yes, yes.", @"C:/");
            foreach (var word in wordList)
            {
                Assert.AreEqual("yes", word.Value);
            }
        }
        [Test]
        public void ExtractWordsFromTextFile_ExtractFromEmptyStrings()
        {
            wordList = testExtractor.ExtractWordsFromTextFile("", "");
            Assert.IsEmpty(wordList);
        }
        [Test]
        public void ExtractWordsFromTextFile_ExtractFromEmptyFilePath()
        {
            wordList = testExtractor.ExtractWordsFromTextFile("Filepath is empty", "");
            Assert.IsEmpty(wordList);

        }
        [Test]
        public void ExtractWordsFromTextFile_ExtractFromEmptyText()
        {
            wordList = testExtractor.ExtractWordsFromTextFile("", "Text document is empty");
            Assert.IsEmpty(wordList);
        }
        [Test]
        public void ExtractWordsFromTextFile_TextAndFilePathIsNull_ListIsEmpty()
        {
            wordList = testExtractor.ExtractWordsFromTextFile(null, null);
            Assert.IsEmpty(wordList);
        }
        [Test]
        public void ExtractWordsFromTextFile_TextAndFilePathIsNull_ListIsNotNull()
        {
            wordList = testExtractor.ExtractWordsFromTextFile(null, null);
            Assert.IsNotNull(wordList);
        }
        [Test]
        public void ExtractWordsFromTextFile_TextIsNull_ListIsEmpty()
        {
            wordList = testExtractor.ExtractWordsFromTextFile(null, "C");
            Assert.IsEmpty(wordList);
        }
        [Test]
        public void ExtractWordsFromTextFile_TextIsNull_ListIsNotNull()
        {
            wordList = testExtractor.ExtractWordsFromTextFile(null, "C");
            Assert.IsNotNull(wordList);
        }
        [Test]
        public void ExtractWordsFromTextFile_FilePathIsNull_WordFileIsNull()
        {
            wordList = testExtractor.ExtractWordsFromTextFile("mjauuuu kss kss", null);
            foreach (var word in wordList)
            {
                Assert.IsNull(word.File);
            }
        }
        [Test]
        public void ExtractWordsFromTextFile_FilePathIsNull_WordValueIsNotEmpty()
        {
            wordList = testExtractor.ExtractWordsFromTextFile("mjauuuu kss kss", null);
            foreach (var word in wordList)
            {
                Assert.IsNotEmpty(word.Value);
            }
        }
        [Test]
        public void ExtractWordsFromTextFile_FilePathIsNull_ListIsNotNull()
        {
            wordList = testExtractor.ExtractWordsFromTextFile("mjauuuu kss kss", null);
            Assert.IsNotNull(wordList);
        }
        [Test]
        public void ExtractWordsFromTextFile_FilePathIsNull_ListIsEmpty()
        {
            wordList = testExtractor.ExtractWordsFromTextFile("mjauuuu kss kss", null);
            Assert.IsEmpty(wordList);
        }
        [Test]
        public void ReplaceSpecialCharacters_HappyDays()
        {
            string s = "hej, hej. hej! hej=hej( hej[i] / hej&hej%hej hej'hej hej: hej; @hej$hej kram\\kram* ja? #är det sant\"-+{}";
            s = testExtractor.ReplaceSpecialCharacters(s);
            Assert.AreEqual("hej hej hej hejhej heji  hejhejhej hej'hej hej hej hejhej kramkram ja är det sant", s);
        }
        [Test]
        public void ReplaceSpecialCharacters_InsertEmptyString()
        {
            string s = string.Empty;
            s = testExtractor.ReplaceSpecialCharacters(s);
            Assert.IsEmpty(s);
        }
        [Test]
        public void ReplaceSpecialCharacters_InsertNull()
        {
            Assert.IsEmpty(testExtractor.ReplaceSpecialCharacters(null));
        }

        [Test]
        public void AppendWordListsToCompoundedList_HappyDays()
        {
            var wordList1 = new List<Word>();
            wordList1.Add(new Word("yes", "a"));
            wordList1.Add(new Word("hello", "a"));
            var wordList2 = new List<Word>();
            wordList2.Add(new Word("yes", "b"));
            wordList2.Add(new Word("hello", "b"));
            testExtractor.AppendWordListsToCompoundedList(wordList1);
            testExtractor.AppendWordListsToCompoundedList(wordList2);
            Assert.AreEqual("a", testExtractor.GetCompoundedList()[0].File);
            Assert.AreEqual("a", testExtractor.GetCompoundedList()[1].File);
            Assert.AreEqual("b", testExtractor.GetCompoundedList()[2].File);
            Assert.AreEqual("b", testExtractor.GetCompoundedList()[3].File);
        }
        [Test]
        public void AppendWordListsToCompoundedList_AddsCorrectNumberOfWords()
        {
            wordList = new List<Word>();
            testExtractor.ExtractWordsFromTextFile("yes hello", "a");
            wordList.Add(new Word("yes", "b"));
            wordList.Add(new Word("hello", "b"));
            testExtractor.AppendWordListsToCompoundedList(wordList);
            Assert.AreEqual(4, testExtractor.GetCompoundedList().Count);
        }
        [Test]
        public void BuildStringFromListOfWords_HappyDays()
        {
            wordList = new List<Word>();
            wordList.Add(new Word("abc", "a.txt"));
            wordList.Add(new Word("def", "a.txt"));
            wordList.Add(new Word("ghi", "a.txt"));
            wordList.Add(new Word("jkl", "a.txt"));
            var expected = $"Word:\t\t\tFile Path:{Environment.NewLine}abc\t\t\t(a.txt){Environment.NewLine}def\t\t\t(a.txt){Environment.NewLine}ghi\t\t\t(a.txt){Environment.NewLine}jkl\t\t\t(a.txt){Environment.NewLine}";
            var actual = testExtractor.BuildStringFromListOfWords(wordList);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void BuildStringFromListOfWords_EmptyWordList()
        {
            wordList = new List<Word>();
            var expected = $"Word:\t\t\tFile Path:{Environment.NewLine}";
            var actual = testExtractor.BuildStringFromListOfWords(wordList);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void BuildStringFromListOfWords_ListIsNull()
        {
            wordList = new List<Word>();
            var expected = $"Word:\t\t\tFile Path:{Environment.NewLine}";
            var actual = testExtractor.BuildStringFromListOfWords(null);
            Assert.AreEqual(expected, actual);
        }
    }
}