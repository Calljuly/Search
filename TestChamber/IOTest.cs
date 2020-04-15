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
        public void ReadFile_HappyDays()
        {
            string path = $"{AppDomain.CurrentDomain.BaseDirectory}TestFiles\\TextFile3.txt";
            Assert.AreEqual("timmy is the smartest. #admit", InputOutput.ReadFile(path));
        }
        [Test]
        public void ReadFile_EntersEmptyString_CatchesArgumentException()
        {
            string path = string.Empty;
            string expected = "Could not read file";
            Assert.AreEqual(expected, InputOutput.ReadFile(path));
        }
        [Test]
        public void ReadFile_DoesNotEnterCorrectDirectory_CatchesIOException()
        {
            string path = "Trying to enter text";
            string expected = "Could not read file";
            Assert.AreEqual(expected, InputOutput.ReadFile(path));
        }

        [Test]
        public void ReadFile_NullInput_catchexeption()
        {
            try
            {
                InputOutput.ReadFile(null);
                Assert.Fail();
            }
            catch
            {
                Assert.Pass();
            }
        }

        [Test]
        public void SaveFile_HappyDays()
        {
            string fileLocation = $"{AppDomain.CurrentDomain.BaseDirectory}TestFiles\\IOTest1.txt";
            InputOutput.SaveFile(fileLocation, $"{AppDomain.CurrentDomain.BaseDirectory}TestFiles", "IOTest1");

            if (File.Exists(fileLocation))
            {
                Assert.Pass();
            }
        }

        [Test]
        public void SaveFile_NullInput_catchexeption()
        {
            try
            {
                InputOutput.SaveFile(null,null);
                Assert.Fail();
            }
            catch
            {
                Assert.Pass();
            }
        }
        [Test]
        public void SaveFile_NonExistingDirectory_CatchesIOException()
        {
            string directory = "Non existing";
            string expected = "Could not save file.";
            Assert.AreEqual(expected, InputOutput.SaveFile("file content", directory, "name"));
        }

        [Test]
        public void SaveFile_EmptyStringAsDirectory_CatchesUnauthorizedAccessException()
        {
            string directory = string.Empty;
            string expected = "You don't have access, your authority level is to low";
            Assert.AreEqual(expected, InputOutput.SaveFile("file content", directory, "name"));
        }

    }
}
