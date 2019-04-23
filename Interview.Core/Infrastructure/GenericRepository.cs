using System;
using System.Collections.Generic;
using Interview.Core.Infrastructure.Interfaces;

namespace Interview.Core.Infrastructure
{
    public class GenericRepository<T> : IRepository<T> where T : Storeable
    {
        private IEntityManager _entityManager;

        public GenericRepository(IEntityManager entityManager)
        {
            _entityManager = entityManager;
        }

        public IEnumerable<T> All()
        {
            return _entityManager.GetAll<T>();
        }

        public void Delete(IComparable id)
        {
            _entityManager.Delete(id);
        }

        public T FindById(IComparable id)
        {
            return _entityManager.Get<T>(id);
        }

        public void Save(T item)
        {
            _entityManager.Save(item);
        }
    }
}