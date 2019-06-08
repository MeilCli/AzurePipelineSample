using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AzurePipelineSample.NETStandard.Lib.Test
{
    [TestClass]
    public class LibraryTest
    {
        [TestMethod]
        public void TestVersion()
        {
            var library = new Library();
            Assert.AreEqual("1.0", library.Version);
        }
    }
}
