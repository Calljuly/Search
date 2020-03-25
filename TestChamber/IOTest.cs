using NUnit.Framework;
using Search;

namespace TestChamber
{
    public class IOTest
    {
        [Test]
        public void IORead()
        {
            Assert.AreEqual("", IO.ReadFile());
        }

        [Test]
        public void IOSave()
        {
            Assert.Pass();
        }

    }
}
