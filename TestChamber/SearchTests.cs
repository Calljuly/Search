using NUnit.Framework;
using Search;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TestChamber
{
    public class SearchTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BinarySearch_OnlyOneMatchExists_FindsTheWord()
        {
            Searching search = new Searching();
            List<Word> wordList = new List<Word> { new Word("aa", "txt"), new Word("bb", "txt"), new Word("cc", "txt"), new Word("dd", "txt"), new Word("ee", "txt") };
            var result = search.BinarySearch(wordList, true, "bb");
            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add("txt", 1);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void BinarySearch_CaseDoesntMatch_FindsTheWord()
        {
            Searching search = new Searching();
            List<Word> wordList = new List<Word> { new Word("aa", "txt"), new Word("bB", "txt"), new Word("cc", "txt"), new Word("dd", "txt"), new Word("ee", "txt") };
            var result = search.BinarySearch(wordList, true, "Bb");
            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add("txt", 1);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void BinarySearch_EnterWeirdCharacters_ReturnsEmptyList()
        {
            Searching search = new Searching();
            List<Word> wordList = new List<Word> { new Word("aa", "txt"), new Word("bb", "txt"), new Word("cc", "txt"), new Word("dd", "txt"), new Word("ee", "txt") };
            var result = search.BinarySearch(wordList, true, "");
            string test = "";
            int count = test.Length;
            Assert.AreEqual(0, result.Count);
            var result2 = search.BinarySearch(wordList, true, null);
            Assert.AreEqual(0, result2.Count);
        }

        [Test]
        public void BinarySearch_SeveralMatchesExists_FindsAll()
        {
            Searching search = new Searching();
            List<Word> wordList = new List<Word> { new Word("aa", "txt"), new Word("bb", "txt"), new Word("bb", "txt"), new Word("bb", "txt"), new Word("bb", "txt"),
                                  new Word("cc", "txt"), new Word("dd", "txt"), new Word("ee", "txt") };
            var result = search.BinarySearch(wordList, true, "bb");

            Assert.AreEqual(4, result["txt"]);
            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add("txt", 4);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void BinarySearch_SearchForNonExistingWord_ReturnsEmptyList()
        {
            Searching search = new Searching();
            List<Word> wordList = new List<Word> { new Word("aa", "txt"), new Word("bb", "txt"), new Word("cc", "txt"), new Word("dd", "txt"), new Word("ee", "txt") };
            var result = search.BinarySearch(wordList, true, "pp");
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void BinarySearch_ListNotSorted_FindsCorrectWord()
        {
            Searching search = new Searching();
            List<Word> wordList = new List<Word> { new Word("jj", "txt"), new Word("ee", "txt"), new Word("pp", "txt"), new Word("aa", "txt"), new Word("bb", "txt") };
            var result = search.BinarySearch(wordList, false, "bb");
            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add("txt", 1);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void BinarySearch_EmptyListInserted_EmptyListReturned()
        {
            Searching search = new Searching();
            List<Word> wordList = new List<Word>();
            var result = search.BinarySearch(wordList, false, "bb");
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void BinarySearch_NullListInserted_EmptyListReturned()
        {
            Searching search = new Searching();
            List<Word> wordList = null;
            var result = search.BinarySearch(wordList, false, "bb");
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void BinarySearch_ListIsBig_ReturnsCorrectList()
        {
            Searching search = new Searching();
            List<Word> wordList = new List<Word>();

            Random rnd = new Random();

            for (int i = 0; i < 100000; i++)
            {
                wordList.Add(new Word($"{(char)rnd.Next('c', 'z')}{(char)rnd.Next('c', 'z')}", "txt"));
            }

            wordList.Add(new Word("bb", "text"));

            for (int i = 0; i < 1000000; i++)
            {
                wordList.Add(new Word($"{(char)rnd.Next('c', 'z')}{(char)rnd.Next('c', 'z')}", "txt"));
            }

            Sorting sort = new Sorting();
            sort.sortAllWords(wordList, 0, wordList.Count - 1); ;

            DateTime start = DateTime.Now;

            var result = search.BinarySearch(wordList, true, "bb");

            TimeSpan span = DateTime.Now - start;

            Debug.WriteLine($"Time of search was {span.TotalMilliseconds} milliseconds");
            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add("text", 1);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void BinarySearch_SeveralMatchesFromDifferentFiles_FindsAllAndPresentsThemSeparately()
        {
            Searching search = new Searching();
            List<Word> wordList = new List<Word> { new Word("aa", "txt1"), new Word("bb", "txt2"), new Word("bb", "txt3"), new Word("bb", "txt4"), new Word("bb", "txt5"),
                                  new Word("cc", "txt7"), new Word("dd", "txt8"), new Word("ee", "txt10") };
            var result = search.BinarySearch(wordList, true, "bb");

            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add("txt2", 1);
            expected.Add("txt3", 1);
            expected.Add("txt4", 1);
            expected.Add("txt5", 1);
            Assert.AreEqual(expected, result);
        }
    }
}