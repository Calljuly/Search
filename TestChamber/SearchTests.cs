using NUnit.Framework;
using Search;
using System.Collections.Generic;

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
            var result = search.BinarySearch(wordList, "bb");
            Assert.AreEqual("bb", result[0].word);
        }

        [Test]
        public void BinarySearch_EnterWeirdCharacters_ReturnsEmptyList()
        {
            Searching search = new Searching();
            List<Word> wordList = new List<Word> { new Word("aa", "txt"), new Word("bb", "txt"), new Word("cc", "txt"), new Word("dd", "txt"), new Word("ee", "txt") };
            var result = search.BinarySearch(wordList, "");
            string test = "";
            int count = test.Length;
            Assert.AreEqual(0, result.Count);
            var result2 = search.BinarySearch(wordList, null);
            Assert.AreEqual(0, result2.Count);
        }

        [Test]
        public void BinarySearch_SeveralMatchesExists_FindsAll()
        {
            Searching search = new Searching();
            List<Word> wordList = new List<Word> { new Word("aa", "txt"), new Word("bb", "txt"), new Word("bb", "txt"), new Word("bb", "txt"), new Word("bb", "txt"),
                                  new Word("cc", "txt"), new Word("dd", "txt"), new Word("ee", "txt") };
            var result = search.BinarySearch(wordList, "bb");

            if (result.Count < 1)
            {
                Assert.Fail();
            }

            for (int i = 0; i < result.Count; i++)
            {
                if (!result[i].word.Equals("bb"))
                {
                    Assert.Fail();
                }
            }

            Assert.Pass();
        }

        [Test]
        public void BinarySearch_SearchForNonExistingWord_ReturnsEmptyList()
        {
            Searching search = new Searching();
            List<Word> wordList = new List<Word> { new Word("aa", "txt"), new Word("bb", "txt"), new Word("cc", "txt"), new Word("dd", "txt"), new Word("ee", "txt") };
            var result = search.BinarySearch(wordList, "pp");
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void BinarySearch_ListNotSorted_FindsCorrectWord()
        {
            Searching search = new Searching();
            List<Word> wordList = new List<Word> { new Word("jj", "txt"), new Word("ee", "txt"), new Word("pp", "txt"), new Word("aa", "txt"), new Word("bb", "txt") };
            var result = search.BinarySearch(wordList, "bb");
            Assert.AreEqual("bb", result[0].word);
        }

        [Test]
        public void BinarySearch_EmptyListInserted_EmptyListReturned()
        {
            Searching search = new Searching();
            List<Word> wordList = new List<Word>();
            var result = search.BinarySearch(wordList, "bb");
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void BinarySearch_NullListInserted_EmptyListReturned()
        {
            Searching search = new Searching();
            List<Word> wordList = null;
            var result = search.BinarySearch(wordList, "bb");
            Assert.AreEqual(0, result.Count);
        }


    }
}