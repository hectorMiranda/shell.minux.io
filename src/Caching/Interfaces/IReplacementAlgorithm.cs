using System;
using System.Collections.Generic;


namespace Marcetux.Caching.Interfaces
{
    /// <summary>
    /// Define the required components for a replacement algorithm, it provides a collection of evictables, their handling 
    /// </summary>
    public interface IReplacementAlgorithm<TKey, TValue> 
    {

        ICollection<TKey> Evictables { get; set; }
        ICollection<TKey> CreateEvictableCollection();
        Type GetType();

        CacheAccessCallback<TKey, TValue> OnGet { get; set; }
        CacheAccessCallback<TKey, TValue> OnAdd { get; set; }
        CacheAccessCallback<TKey, TValue> OnPut { get; set; }
        CacheEvictionCallback<TKey, TValue> OnEvict { get; set; }

        bool Handle(CacheAccessOperation access, TKey key, ref TValue value, bool isGetOrPut);
        bool Evict(TKey key);
        bool Evict();
        bool GetNextEvictedKey(out TKey key);
    }
}