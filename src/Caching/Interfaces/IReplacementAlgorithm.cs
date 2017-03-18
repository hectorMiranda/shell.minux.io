using System;
using System.Collections.Generic;


namespace Marcetux.Caching.Interfaces
{
    /// <summary>
    /// Define the required components for a replacement algorithm, it provides a collection of evictables, their handling 
    /// </summary>
    public interface IReplacementAlgorithm<TKey, TValue> 
    {

        Type GetType();

        ICollection<TKey> Evictables { get; set; }
        Dictionary<TKey, TValue> State { get; set; }

        ICollection<TKey> CreateEvictableCollection();

        bool Handle(CacheAccessOperation access, TKey key, ref TValue value, bool isGetOrPut);
        bool Evict();
        bool GetNextEvictedKey(out TKey key);
    }
}