using NUnit.Framework;
using System.Collections.Generic;
using SearchLibrary;
using System;

namespace TestChamber
{
    public class TestSort
    {
        public List<Word> sut;
        public List<Word> testListNotInitalized;


        [Test]
        public void QuickSort_NotInitalized()
        {
            try
            {
                SearchEngine<Word>.QuickSort(testListNotInitalized, 0, 0);
                Assert.Fail();
            }
            catch (NullReferenceException a)
            {
                Assert.Pass();
            }
        }
        [Test]
        public void QuickSort_ListGetSorted()
        {
            sut = new List<Word>();
            sut.Add(new Word("Maja", "TextFile"));
            sut.Add(new Word("Hulda", "TextFile"));

            SearchEngine<Word>.QuickSort(sut,0,1);
            Assert.AreEqual(sut[1].Value, "Maja");
        }

        [Test]
        public void QuickSort_MoreWords_ListGetSorted()
        {
            sut = new List<Word>();
            sut.Add(new Word("Hulda", "TextFile"));
            sut.Add(new Word("Maja", "TextFile"));
            sut.Add(new Word("Sten", "TextFile"));
            sut.Add(new Word("Brygga", "TextFile"));
            sut.Add(new Word("Kanna", "TextFile"));
            sut.Add(new Word("Lama", "TextFile"));

            SearchEngine<Word>.QuickSort(sut, 0,5);

            Assert.AreEqual("Brygga", sut[0].Value);
        }
        [Test]
        public void QuickSort_CheckLastWord_ReturnsLastInOrder()
        {
            sut = new List<Word>();
            sut.Add(new Word("Hulda", "TextFile"));
            sut.Add(new Word("Maja", "TextFile"));
            sut.Add(new Word("Sten", "TextFile"));
            sut.Add(new Word("Brygga", "TextFile"));
            sut.Add(new Word("Kanna", "TextFile"));
            sut.Add(new Word("Lama", "TextFile"));

            SearchEngine<Word>.QuickSort(sut, 0, 5);

            Assert.AreEqual("Sten", sut[5].Value);
        }
        [Test]
        public void QuickSort_WordInMiddle_ReturnsMiddleInOrder()
        {
            sut = new List<Word>();
            sut.Add(new Word("Hulda", "TextFile"));
            sut.Add(new Word("Maja", "TextFile"));
            sut.Add(new Word("Sten", "TextFile"));
            sut.Add(new Word("Brygga", "TextFile"));
            sut.Add(new Word("Kanna", "TextFile"));
            sut.Add(new Word("Lama", "TextFile"));

            SearchEngine<Word>.QuickSort(sut, 0, 5);

            Assert.AreEqual("Lama", sut[3].Value);
        }

        [Test]
        public void QuickSort_ListAlreadySorted_ListUnchanged()
        {
            sut = new List<Word>();
            sut.Add(new Word("Alban", "TextFile"));
            sut.Add(new Word("Bengt", "TextFile"));
            sut.Add(new Word("Cilla", "TextFile"));
            sut.Add(new Word("David", "TextFile"));
            sut.Add(new Word("Emil", "TextFile"));
            sut.Add(new Word("Felicia", "TextFile"));

            SearchEngine<Word>.QuickSort(sut, 0, 5);

            Assert.AreEqual("Alban", sut[0].Value);
            Assert.AreEqual("Bengt", sut[1].Value);
            Assert.AreEqual("Cilla", sut[2].Value);
            Assert.AreEqual("David", sut[3].Value);
            Assert.AreEqual("Emil", sut[4].Value);
            Assert.AreEqual("Felicia", sut[5].Value);

        }
        [Test]
        public void QuickSort_ListContainsSimilarWords_SortsCorretly()
        {
            sut = new List<Word>();

            sut.Add(new Word("Annas", "TextFile"));
            sut.Add(new Word("Anna", "TextFile"));

            SearchEngine<Word>.QuickSort(sut,0,1);
            
            Assert.AreEqual("Anna", sut[0].Value);
        }
    }
}