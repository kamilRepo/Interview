using System;
using System.Collections.Generic;

namespace Interview.Core.Infrastructure.Interfaces
{
    public interface IEntityManager
    {
        //
        // Summary:
        //     Get object by id
        T Get<T>(IComparable id) where T : class;

        //
        // Summary:
        //     Get all objects of type
        //
        // Type parameters:
        //   T:
        //     The entity class
        //
        // Returns:
        //     An IEnumerable<T> objects
        IEnumerable<T> GetAll<T>() where T : class;

        //
        // Summary:
        //     Remove a persistent instance from the datastore.
        //
        // Parameters:
        //   obj:
        //     The instance to be removed
        //
        void Delete(object obj);

        //
        // Summary:
        //     Save() the given instance and remove old one
        //     if exist
        //
        // Parameters:
        //   obj:
        //     A transient instance containing new state
        //
        void Save(object obj);

        //
        // Summary:
        //     Removed all items
        void Clear();
    }
}
