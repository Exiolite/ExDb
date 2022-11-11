using System;

namespace ExNoSQL
{
    [Serializable]
    public abstract class Context
    {
        public string FilePath { get; }


        protected Context(string filePath)
        {
            FilePath = filePath;
        }
    }
}
