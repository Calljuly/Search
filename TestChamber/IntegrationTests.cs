using NUnit.Framework;
using Search;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using ClassLibrary;

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

            string path1 = $"{AppDomain.CurrentDomain.BaseDirectory}TestFiles\\TextFile1.txt";
            string text1 = IO.ReadFile(path1);
            
            string path2 = $"{AppDomain.CurrentDomain.BaseDirectory}TestFiles\\TextFile2.txt";
            string text2 = IO.ReadFile(path2);

            string path3 = $"{AppDomain.CurrentDomain.BaseDirectory}TestFiles\\TextFile3.txt";
            string text3 = IO.ReadFile(path3);

            string path4 = $"{AppDomain.CurrentDomain.BaseDirectory}TestFiles\\TextFile4.txt";
            string text4 = IO.ReadFile(path4);

            extractor.ExtractWordsFromTextFile(text1, path1);
            extractor.ExtractWordsFromTextFile(text2, path2);
            extractor.ExtractWordsFromTextFile(text3, path3);
            extractor.ExtractWordsFromTextFile(text4, path4);

            List<Word> list = extractor.GetCompoundedList();

            Engine.QuickSort(list, 0, list.Count - 1);
            
            var result = Engine.BinarySearch(list, true, "admit");
            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add(path3, 1);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void BinarySearch_SeveralMatchesExists_FindsAll()
        {
            WordExtractor extractor = new WordExtractor();

            string path1 = $"{AppDomain.CurrentDomain.BaseDirectory}TestFiles\\TextFile1.txt";
            string text1 = IO.ReadFile(path1);

            string path2 = $"{AppDomain.CurrentDomain.BaseDirectory}TestFiles\\TextFile2.txt";
            string text2 = IO.ReadFile(path2);

            string path3 = $"{AppDomain.CurrentDomain.BaseDirectory}TestFiles\\TextFile3.txt";
            string text3 = IO.ReadFile(path3);

            string path4 = $"{AppDomain.CurrentDomain.BaseDirectory}TestFiles\\TextFile4.txt";
            string text4 = IO.ReadFile(path4);

            extractor.ExtractWordsFromTextFile(text1, path1);
            extractor.ExtractWordsFromTextFile(text2, path2);
            extractor.ExtractWordsFromTextFile(text3, path3);
            extractor.ExtractWordsFromTextFile(text4, path4);

            List<Word> list = extractor.GetCompoundedList();

            Engine.QuickSort(list, 0, list.Count - 1);

            var result = Engine.BinarySearch(list, true, "is");
            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add(path1, 1);
            expected.Add(path2, 2);
            expected.Add(path3, 1);
            expected.Add(path4, 1);
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void BinarySearch_LoadsEmptyTextFile_ReturnsEmptyDictionary()
        {
            WordExtractor extractor = new WordExtractor();

            string path1 = $"{AppDomain.CurrentDomain.BaseDirectory}TestFiles\\EmptyTextFile.txt";
            string text1 = IO.ReadFile(path1);

            extractor.ExtractWordsFromTextFile(text1, path1);

            List<Word> list = extractor.GetCompoundedList();

            Engine.QuickSort(list, 0, list.Count - 1);

            var result = Engine.BinarySearch(list, true, "");
            Dictionary<string, int> expected = new Dictionary<string, int>();
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void BinarySearch_LoadsNull_ReturnsEmptyDictionary()
        {
            WordExtractor extractor = new WordExtractor();

            string path1 = null;
            string text1 = IO.ReadFile(path1);

            extractor.ExtractWordsFromTextFile(text1, path1);

            List<Word> list = extractor.GetCompoundedList();

            Engine.QuickSort(list, 0, list.Count - 1);

            var result = Engine.BinarySearch(list, true, "could");
            Dictionary<string, int> expected = new Dictionary<string, int>();
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void GetCompoundedList_SortedAndUnsortedLists_AreNotEqual()
        {
            WordExtractor extractor = new WordExtractor();

            string path1 = $"{AppDomain.CurrentDomain.BaseDirectory}TestFiles\\TextFile1.txt";
            string text1 = IO.ReadFile(path1);

            extractor.ExtractWordsFromTextFile(text1, path1);
            var unsortedList = extractor.GetCompoundedList();
            var sortedList = extractor.GetCompoundedList();

            Engine.QuickSort(sortedList, 0, sortedList.Count - 1);
            
            Assert.AreNotEqual(unsortedList, sortedList);

        }
    }
}