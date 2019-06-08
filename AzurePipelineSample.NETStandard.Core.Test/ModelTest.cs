using AzurePipelineSample.NETStandard.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AzurePipelineSample.NETStandard.Core.Test
{
    [TestClass]
    public class ModelTest
    {
        private class MockLibrary : ILibrary
        {
            public string Version { get; private set; }

            public MockLibrary(string version)
            {
                Version = version;
            }
        }

        [TestMethod]
        public void TestName()
        {
            var model = new Model("name", new MockLibrary("1.0"));
            Assert.AreEqual("name", model.Name);
        }

        [TestMethod]
        public void TestGetStatus()
        {
            var model = new Model("name", new MockLibrary("1.0"));
            Assert.AreEqual("Model name: name, version: 1.0", model.GetStatus());
        }
    }
}
