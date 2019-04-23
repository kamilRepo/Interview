using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Interview.Core.Infrastructure;
using Interview.Core.Infrastructure.Interfaces;

namespace Interview.Infrastructure
{
    [TestClass]
    public class GenericRepositoryTests
    {
        [TestMethod]
        public void FindById_ContainId_FindItem()
        {
            //Preparation
            IRepository<Storeable> repository = new GenericRepository<Storeable>();

            Storeable storeableA = new Storeable()
            {
                Id = 1,
                Name = "a"
            };
            Storeable storeableB = new Storeable()
            {
                Id = 2,
                Name = "b"
            };

            repository.Save(storeableA);
            repository.Save(storeableB);

            //Action
            var item = repository.FindById(1);

            //Assertions
            Assert.AreEqual(storeableA.Name, item.Name);
        }

        [TestMethod]
        public void FindById_DontContainId_CantFindItem()
        {
            //Preparation
            IRepository<Storeable> repository = new GenericRepository<Storeable>();

            Storeable storeableA = new Storeable()
            {
                Id = 1,
                Name = "a"
            };
            Storeable storeableB = new Storeable()
            {
                Id = 2,
                Name = "b"
            };

            repository.Save(storeableA);
            repository.Save(storeableB);

            //Action
            var item = repository.FindById(3);

            //Assertions
            Assert.IsNull(item);
        }

        [TestMethod]
        public void Save_ContainId_UpdatedExistItem()
        {
            //Preparation
            IRepository<Storeable> repository = new GenericRepository<Storeable>();

            Storeable storeableA = new Storeable()
            {
                Id = 1,
                Name = "a"
            };
            Storeable storeableB = new Storeable()
            {
                Id = 1,
                Name = "b"
            };

            //Action
            repository.Save(storeableA);
            repository.Save(storeableB);

            //Assertions
            var items = repository.All();
            var item = repository.FindById(1);

            Assert.AreEqual(1, items.Count());
            Assert.AreEqual(storeableB.Name, item.Name);
        }

        [TestMethod]
        public void Save_DontContainId_AddedNewItems()
        {
            //Preparation
            IRepository<Storeable> repository = new GenericRepository<Storeable>();

            Storeable storeableA = new Storeable()
            {
                Id = 1,
                Name = "a"
            };
            Storeable storeableB = new Storeable()
            {
                Id = 2,
                Name = "b"
            };

            //Action
            repository.Save(storeableA);
            repository.Save(storeableB);

            //Assertions
            var items = repository.All();
            var itemA = repository.FindById(1);
            var itemB = repository.FindById(2);

            Assert.AreEqual(2, items.Count());
            Assert.AreEqual(storeableA.Name, itemA.Name);
            Assert.AreEqual(storeableB.Name, itemB.Name);
        }

        public void Save_CheckReturnInstance_CorrectInstance()
        {
            //Preparation
            IRepository<Storeable> repository = new GenericRepository<Storeable>();

            Storeable storeableA = new Storeable()
            {
                Id = 1,
                Name = "a"
            };
            Storeable storeableB = new Storeable()
            {
                Id = 2,
                Name = "b"
            };

            repository.Save(storeableA);
            repository.Save(storeableB);

            //Action
            var itemA = repository.FindById(1);

            //Assertions
            Assert.IsInstanceOfType(itemA, typeof(Storeable));
        }

        [TestMethod]
        public void Delete_DontContainId_NoAction()
        {
            //Preparation
            IRepository<Storeable> repository = new GenericRepository<Storeable>();

            Storeable storeableA = new Storeable()
            {
                Id = 1,
                Name = "a"
            };
            Storeable storeableB = new Storeable()
            {
                Id = 2,
                Name = "b"
            };

            repository.Save(storeableA);
            repository.Save(storeableB);

            //Action
            repository.Delete(3);

            //Assertions
            var items = repository.All();
            var itemA = repository.FindById(1);
            var itemB = repository.FindById(2);
            var itemC = repository.FindById(3);

            Assert.AreEqual(2, items.Count());
            Assert.AreEqual(storeableA.Name, itemA.Name);
            Assert.AreEqual(storeableB.Name, itemB.Name);
            Assert.IsNull(itemC);
        }

        [TestMethod]
        public void Delete_ContainId_RemovedItem()
        {
            //Preparation
            IRepository<Storeable> repository = new GenericRepository<Storeable>();

            Storeable storeableA = new Storeable()
            {
                Id = 1,
                Name = "a"
            };
            Storeable storeableB = new Storeable()
            {
                Id = 2,
                Name = "b"
            };

            repository.Save(storeableA);
            repository.Save(storeableB);

            //Action
            repository.Delete(2);

            //Assertions
            var items = repository.All();
            var itemA = repository.FindById(1);
            var itemB = repository.FindById(2);

            Assert.AreEqual(1, items.Count());
            Assert.AreEqual(storeableA.Name, itemA.Name);
            Assert.IsNull(itemB);
        }

        [TestMethod]
        public void All_ReturnAll_AllReturned()
        {
            //Preparation
            IRepository<Storeable> repository = new GenericRepository<Storeable>();

            Storeable storeableA = new Storeable()
            {
                Id = 1,
                Name = "a"
            };
            Storeable storeableB = new Storeable()
            {
                Id = 2,
                Name = "b"
            };

            repository.Save(storeableA);
            repository.Save(storeableB);

            //Action
            var items = repository.All();

            //Assertions
            Assert.AreEqual(2, items.Count());
        }
    }
}
