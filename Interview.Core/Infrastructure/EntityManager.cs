using System;
using System.Collections.Generic;
using Interview.Core.Infrastructure.Interfaces;

namespace Interview.Core.Infrastructure
{
    public class EntityManager : IEntityManager
    {
        private List<object> _entities;
        private static EntityManager _instance;

        protected EntityManager()
        {
            _entities = new List<object>();
        }

        public static EntityManager Instance()
        {
            // Uses lazy initialization.
            // Note: this is not thread safe.

            if (_instance == null)
            {
                _instance = new EntityManager();
            }

            return _instance;
        }

        public void Delete(object obj)
        {
            _entities.Remove(obj);
        }

        public T Get<T>(IComparable id) where T : class
        {
            return _entities.Find(MatchedId(id)) as T;
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            List<T> list = new List<T>();

            foreach (T item in _entities)
                list.Add(item);

            return list;
        }

        public void Save(object obj)
        {
            if (_entities.Contains(obj))
                Delete(obj);

            _entities.Add(obj);
        }

        private Predicate<object> MatchedId(IComparable id)
        {
            return match => match.Equals(id);
        }
    }
}