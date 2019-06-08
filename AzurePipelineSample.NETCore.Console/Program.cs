using AzurePipelineSample.NETStandard.Core;
using static System.Console;

namespace AzurePipelineSample.NETCore.Console
{
    public class Program
    {
        // comment 2
        public static void Main(string[] args)
        {
            WriteLine("Hello World!");
            var program = new Program("Azure Pipeline");
            WriteLine(program.GetStatus());
        }

        private readonly IModel model;

        public Program(string name) : this(new Model(name)) { }

        public Program(IModel model)
        {
            this.model = model;
        }

        public string GetStatus()
        {
            return model.GetStatus();
        }
    }
}
