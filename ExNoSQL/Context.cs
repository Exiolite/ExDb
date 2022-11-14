using System;

namespace ExNoSQL
{
    [Serializable]
    public abstract class Context
    {
        public string FilePathWithoutExtension { get; }


        protected Context(string filePathWithoutExtensionWithoutExtension)
        {
            FilePathWithoutExtension = filePathWithoutExtensionWithoutExtension;
        }
    }
}
