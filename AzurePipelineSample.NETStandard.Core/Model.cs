using AzurePipelineSample.NETStandard.Lib;

namespace AzurePipelineSample.NETStandard.Core
{
    public class Model : IModel
    {
        private readonly ILibrary library;

        public string Name { get; }

        public Model(string name) : this(name, new Library()) { }

        public Model(string name, ILibrary library)
        {
            Name = name;
            this.library = library;
        }

        public string GetStatus()
        {
            return $"Model name: {Name}, version: {library.Version}";
        }
    }
}
