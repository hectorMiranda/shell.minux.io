using System.Collections.Generic;


namespace Marcetux.Caching.Interfaces
{
    public interface ICache<TKey, TValue> : IEnumerable<TKey>
    {

        TValue this[TKey key] { get; set; }
        int Capacity { get; }
        int Count { get; }

        bool Contains(TKey key);
        bool TryGet(TKey key, out TValue value);

        TValue Get(TKey key);
        TValue GetOrAdd(TKey key, TValue value);

        bool Add(TKey key, TValue value);
        void Put(TKey key, TValue value);
        bool Remove(TKey key);
    }
}