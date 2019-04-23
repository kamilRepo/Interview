using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Interview.Core.Infrastructure;
using Interview.Core.Infrastructure.Interfaces;

namespace Interview.Infrastructure
{
    [TestClass]
    public class EntityManagerTests
    {
        [TestMethod]
        public void Generally()
        {
            //Preparation
            IEntityManager entityManager = EntityManager.Instance();

            Storeable storeable1 = new Storeable()
            {
                Id = 1,
                Name = "a"
            };
            Storeable storeable2 = new Storeable()
            {
                Id = 2,
                Name = "b"
            };
            Storeable storeable3 = new Storeable()
            {
                Id = 3,
                Name = "c"
            };
            Storeable storeable4 = new Storeable()
            {
                Id = 1,
                Name = "d"
            };

            //Action
            entityManager.Save(storeable1);
            entityManager.Save(storeable2);
            entityManager.Save(storeable3);
            entityManager.Save(storeable4);


            var a = entityManager.Get<Storeable>(1);
            var b = entityManager.Get<Storeable>(2);
            var c = entityManager.Get<Storeable>(3);
            var d = entityManager.Get<Storeable>(1);

            var all = entityManager.GetAll<Storeable>();

            entityManager.Delete(storeable1);
            a = entityManager.Get<Storeable>(1);

            entityManager.Delete(storeable1);
            a = entityManager.Get<Storeable>(1);

            entityManager.Save(storeable4);
            entityManager.Save(storeable4);

            all = entityManager.GetAll<Storeable>();
            a = entityManager.Get<Storeable>(1);

            //Assertions
            Assert.AreEqual(a.Name, storeable4.Name);
            Assert.AreEqual(b.Name, storeable2.Name);
            Assert.AreEqual(c.Name, storeable3.Name);
            Assert.AreEqual(d.Name, storeable4.Name);

            Assert.AreEqual(all.Count(), 3);
        }
    }
}
