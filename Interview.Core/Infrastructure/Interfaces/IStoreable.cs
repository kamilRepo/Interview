using System;

namespace Interview.Core.Infrastructure.Interfaces
{
    public interface IStoreable
    {
        IComparable Id { get; set; }
    }
    
}