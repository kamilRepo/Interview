using System;
using System.Collections.Generic;

namespace Interview.Core.Infrastructure.Interfaces
{
    // Please create an in memory implementation of IRepository<T> 

    public interface IRepository<T> where T : IStoreable
    {
        IEnumerable<T> All();
        void Delete(IComparable id);
        void Save(T item);
        T FindById(IComparable id);
    }
}
