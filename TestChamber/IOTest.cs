using NUnit.Framework;
using Search;

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
            Assert.Pass();
        }

    }
}
