using NUnit.Framework;
using Search;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TestChamber
{
    public class IntegrationTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BinarySearch_OnlyOneMatchExists_FindsTheWord()
        {
            WordExtractor extractor = new WordExtractor();
            Sorting sort = new Sorting();
            Searching search = new Searching();

            string path1 = $"{AppDomain.CurrentDomain.BaseDirectory}TestFiles\\TextFile1.txt";
            string text1 = IO.ReadFile(path1);
            
            string path2 = $"{AppDomain.CurrentDomain.BaseDirectory}TestFiles\\TextFile2.txt";
            string text2 = IO.ReadFile(path2);

            string path3 = $"{AppDomain.CurrentDomain.BaseDirectory}TestFiles\\TextFile3.txt";
            string text3 = IO.ReadFile(path3);

            string path4 = $"{AppDomain.CurrentDomain.BaseDirectory}TestFiles\\TextFile4.txt";
            string text4 = IO.ReadFile(path4);

            extractor.ExtractWordsFromString(text1, path1);
            extractor.ExtractWordsFromString(text2, path2);
            extractor.ExtractWordsFromString(text3, path3);
            extractor.ExtractWordsFromString(text4, path4);

            List<Word> list = extractor.compoundedList;

            sort.sortAllWords(list, 0, list.Count - 1);
            
            var result = search.BinarySearch(list, true, "admit");
            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add(path3, 1);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void BinarySearch_SeveralMatceshExists_FindsAll()
        {
            WordExtractor extractor = new WordExtractor();
            Sorting sort = new Sorting();
            Searching search = new Searching();

            string path1 = $"{AppDomain.CurrentDomain.BaseDirectory}TestFiles\\TextFile1.txt";
            string text1 = IO.ReadFile(path1);

            string path2 = $"{AppDomain.CurrentDomain.BaseDirectory}TestFiles\\TextFile2.txt";
            string text2 = IO.ReadFile(path2);

            string path3 = $"{AppDomain.CurrentDomain.BaseDirectory}TestFiles\\TextFile3.txt";
            string text3 = IO.ReadFile(path3);

            string path4 = $"{AppDomain.CurrentDomain.BaseDirectory}TestFiles\\TextFile4.txt";
            string text4 = IO.ReadFile(path4);

            extractor.ExtractWordsFromString(text1, path1);
            extractor.ExtractWordsFromString(text2, path2);
            extractor.ExtractWordsFromString(text3, path3);
            extractor.ExtractWordsFromString(text4, path4);

            List<Word> list = extractor.compoundedList;

            sort.sortAllWords(list, 0, list.Count - 1);

            var result = search.BinarySearch(list, true, "is");
            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add(path1, 1);
            expected.Add(path2, 2);
            expected.Add(path3, 1);
            expected.Add(path4, 1);
            Assert.AreEqual(expected, result);
        }


    }
}