using System;
using NUnit.Framework;

namespace ExNoSQL.Tests
{
    [TestFixture]
    public class Tests
    {
        [Serializable]
        private class TestContext : Context
        {
            public TestContext() : base("D:/TestSave.exdb")
            {
            }
        }

        [Test]
        public void Create_Context()
        {
            Db<TestContext>.Import();
        }
    }
}
