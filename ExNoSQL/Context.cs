using System;

namespace ExNoSQL
{
    [Serializable]
    public abstract class Context
    {
        public abstract string GetPath();
    }
}
