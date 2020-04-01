using NUnit.Framework;
using System.Collections.Generic;
using Search;
using ClassLibrary;

namespace TestChamber
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
    public class TestSort // Julia
    {
        public List<Word> sut;
        public Engine myTestEngine;


        [Test]
        public void ifListGetSorted()
        {
            sut = new List<Word>();
            myTestEngine = new Engine();
            sut.Add(new Word("Maja", "TextFile"));
            sut.Add(new Word("Hulda", "TextFile"));

            Engine.QuickSort(sut,0,1);
            Assert.AreEqual(sut[1].word, "Maja");
        }

        [Test]
        public void ifListGetSortedMoreWords()
        {
            sut = new List<Word>();
            myTestEngine = new Engine();
            sut.Add(new Word("Hulda", "TextFile"));
            sut.Add(new Word("Maja", "TextFile"));
            sut.Add(new Word("Sten", "TextFile"));
            sut.Add(new Word("Brygga", "TextFile"));
            sut.Add(new Word("Kanna", "TextFile"));
            sut.Add(new Word("Lama", "TextFile"));

            Engine.QuickSort(sut, 0,5);

            Assert.AreEqual("Brygga", sut[0].word);
        }
        [Test]
        public void ifListGetSortedWithSimilarWords()
        {
            sut = new List<Word>();
            myTestEngine = new Engine();

            sut.Add(new Word("Annas", "TextFile"));
            sut.Add(new Word("Anna", "TextFile"));

            Engine.QuickSort(sut,0,1);
            
            Assert.AreEqual("Anna", sut[0].word);

        }
    }

}