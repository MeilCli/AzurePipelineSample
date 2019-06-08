using AzurePipelineSample.NETStandard.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AzurePipelineSample.NETCore.Console.Test
{
    [TestClass]
    public class ProgramTest
    {
        private class MockModel : IModel
        {
            public string Name { get; private set; }

            public MockModel(string name)
            {
                Name = name;
            }

            public string GetStatus()
            {
                return $"Status of {Name}";
            }
        }

        [TestMethod]
        public void TestGetStatus()
        {
            var program = new Program(new MockModel("model"));
            Assert.AreEqual("Status of model", program.GetStatus());
        }
    }
}
