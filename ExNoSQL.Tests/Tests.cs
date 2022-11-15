using System;
using NUnit.Framework;
using NUnit.Framework.Internal;

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

        private class TestClass : Entity
        {

        }


        [Test]
        public void Create_Context()
        {
            Db<TestContext>.CreateNewContext();
            Db<TestContext>.Import();
        }

        [Test]
        public void CREATE_THAN_GET()
        {
            Repository<TestClass> repository = new Repository<TestClass>();

            TestClass entity = new TestClass()
            {
                Id = Guid.NewGuid()
            };
            
            repository.Add(entity);
            TestClass getEntity = repository.Get(entity);
            
            Assert.IsNotNull(getEntity);
        }
    }
}
