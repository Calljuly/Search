using NUnit.Framework;
using Search;
using System;
using System.IO;
using SearchLibrary;

namespace TestChamber
{
    public class IOTest
    {
        [Test]
        public void IORead_HappyDays()
        {
            string path = $"{AppDomain.CurrentDomain.BaseDirectory}TestFiles\\TextFile3.txt";
            Assert.AreEqual("timmy is the smartest. #admit", IO.ReadFile(path));
        }

        //[Test]
        //public void IOSave()
        //{
        //    string fileLocation = "C:\\Users\\97yunwon\\Desktop\\IOTest1.txt";
        //    IO.SaveFile(fileLocation, "text1", "test1");

        //    if (!File.Exists(fileLocation))
        //    {
        //        Assert.Pass();
        //    }
        //}

    }
}
