using System;
using System.Collections.Generic;
using System.Linq;
using Marcetux.Caching.Interfaces;

namespace Marcetux.Caching
{

    public abstract class FifoReplacementAlgorithm<TKey, TValue> : IReplacementAlgorithm<TKey, TValue>
    {
        public int Capacity { get; set; }
        public ICollection<TKey> Evictables { get; set; }

        protected int GetEvictionSize()
        {
            return 1;
        }


        protected FifoReplacementAlgorithm(int capacity)
        {
            Capacity = capacity;
            Evictables = CreateEvictableCollection();
        }

        public virtual Type GetType()
        {
            throw new NotImplementedException();
        }

        protected void Before(CacheAccessOperation accessOperation, TKey key, TValue value)
        {
            if (accessOperation == CacheAccessOperation.Get)
            {
                Evictables.Remove(key);
            }
        }

        protected void After(CacheAccessOperation accessOperation, TKey key, TValue value)
        {
            Evictables.Add(key);
        }


        public CacheAccessCallback<TKey, TValue> OnGet { get; set; }

        public CacheAccessCallback<TKey, TValue> OnAdd { get; set; }

        public CacheAccessCallback<TKey, TValue> OnPut { get; set; }

        public CacheEvictionCallback<TKey, TValue> OnEvict { get; set; }

        public virtual ICollection<TKey> CreateEvictableCollection()
        {
            throw new NotImplementedException();
        }


        public virtual bool GetNextEvictedKey(out TKey key)
        {
            throw new NotImplementedException();
        }

        public bool Handle(CacheAccessOperation access, TKey key, ref TValue value, bool isGetOrPut)
        {
            throw new NotImplementedException();
        }

        public bool Evict(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool Evict()
        {
            throw new NotImplementedException();
        }
    }
}
