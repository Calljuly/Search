using NUnit.Framework;
using System.Collections.Generic;
using Search;
using ClassLibrary;

namespace TestChamber
{
    public class TestSort
    {
        public List<Word> sut;

        [Test]
        public void IfListGetSorted()
        {
            sut = new List<Word>();
            sut.Add(new Word("Maja", "TextFile"));
            sut.Add(new Word("Hulda", "TextFile"));

            Engine.QuickSort(sut,0,1);
            Assert.AreEqual(sut[1].Value, "Maja");
        }

        [Test]
        public void IfListGetSortedMoreWords()
        {
            sut = new List<Word>();
            sut.Add(new Word("Hulda", "TextFile"));
            sut.Add(new Word("Maja", "TextFile"));
            sut.Add(new Word("Sten", "TextFile"));
            sut.Add(new Word("Brygga", "TextFile"));
            sut.Add(new Word("Kanna", "TextFile"));
            sut.Add(new Word("Lama", "TextFile"));

            Engine.QuickSort(sut, 0,5);

            Assert.AreEqual("Brygga", sut[0].Value);
        }
        [Test]
        public void IfListGetSortedCheckLastWord()
        {
            sut = new List<Word>();
            sut.Add(new Word("Hulda", "TextFile"));
            sut.Add(new Word("Maja", "TextFile"));
            sut.Add(new Word("Sten", "TextFile"));
            sut.Add(new Word("Brygga", "TextFile"));
            sut.Add(new Word("Kanna", "TextFile"));
            sut.Add(new Word("Lama", "TextFile"));

            Engine.QuickSort(sut, 0, 5);

            Assert.AreEqual("Sten", sut[5].Value);
        }
        [Test]
        public void IfListGetSortedCheckWordInMiddle()
        {
            sut = new List<Word>();
            sut.Add(new Word("Hulda", "TextFile"));
            sut.Add(new Word("Maja", "TextFile"));
            sut.Add(new Word("Sten", "TextFile"));
            sut.Add(new Word("Brygga", "TextFile"));
            sut.Add(new Word("Kanna", "TextFile"));
            sut.Add(new Word("Lama", "TextFile"));

            Engine.QuickSort(sut, 0, 5);

            Assert.AreEqual("Lama", sut[3].Value);
        }

        [Test]
        public void IfASortedListSendsInNoChange()
        {
            sut = new List<Word>();
            sut.Add(new Word("Alban", "TextFile"));
            sut.Add(new Word("Bengt", "TextFile"));
            sut.Add(new Word("Cilla", "TextFile"));
            sut.Add(new Word("David", "TextFile"));
            sut.Add(new Word("Emil", "TextFile"));
            sut.Add(new Word("Felicia", "TextFile"));

            Engine.QuickSort(sut, 0, 5);

            Assert.AreEqual("Alban", sut[0].Value);
            Assert.AreEqual("Bengt", sut[1].Value);
            Assert.AreEqual("Cilla", sut[2].Value);
            Assert.AreEqual("David", sut[3].Value);
            Assert.AreEqual("Emil", sut[4].Value);
            Assert.AreEqual("Felicia", sut[5].Value);

        }
        [Test]
        public void IfListGetSortedWithSimilarWords()
        {
            sut = new List<Word>();

            sut.Add(new Word("Annas", "TextFile"));
            sut.Add(new Word("Anna", "TextFile"));

            Engine.QuickSort(sut,0,1);
            
            Assert.AreEqual("Anna", sut[0].Value);
        }
    }
}