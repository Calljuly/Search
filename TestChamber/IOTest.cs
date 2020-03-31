using NUnit.Framework;
using Search;
using System.IO;

namespace TestChamber
{
    public class IOTest
    {
        [Test]
        public void IORead()
        {
            string fileLocation = "C:\\Users\\97yunwon\\Desktop\\IOTest1.txt";
            Assert.AreEqual("text", IO.ReadFile(fileLocation));
        }

        [Test]
        public void IOSave()
        {
            string fileLocation = "C:\\Users\\97yunwon\\Desktop\\IOTest1.txt";
            IO.SaveFile(fileLocation, "text1", "test1");

            if (!File.Exists(fileLocation))
            {
                Assert.Pass();
            }
        }

    }
}
