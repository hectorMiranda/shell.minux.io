using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Marcetux.Caching
{
    using Interfaces;
    public class Cache<TKey, TValue> : ICache<TKey, TValue>
    { 
        public const int DefaultCapacity = 16;
        public const int DefaultNumberOfWays = 1;
        protected int NumberOfWays { get; set; }
        protected int SubCacheCapacity { get; set; }


        private SubCache<TKey, TValue>[] subCache;

        public int Capacity => NumberOfWays * SubCacheCapacity;

        public Cache(int capacity, int numberOfWays, IReplacementAlgorithm<TKey, TValue> evictionAlgorithmHandler )
        {
            if (numberOfWays <= 0)
            {
                throw new ArgumentOutOfRangeException("the numberOfWays value", "must be strictly greater than zero");
            }

            SubCacheCapacity = capacity / numberOfWays;
            NumberOfWays = numberOfWays;
            subCache = new SubCache<TKey, TValue>[numberOfWays];

            //foreach of the members of the array set the eviction algorithm

        }


        public TValue this[TKey key]
        {
            get
            {
                return Get(key);
            }
            set
            {
                Put(key, value);
            }
        }


        public TValue Get(TKey key)
        {
            return GetSet(key).Get(key);
        }



        protected int Indexer(TKey key)
        {
            return Math.Abs(key.GetHashCode() % NumberOfWays);
        }


        protected SubCache<TKey, TValue> GetSet(TKey key)
        {
            return subCache[NumberOfWays > 1 ? Indexer(key) : 0];
        }



        public int Count
        {
            get
            {
                return subCache.Sum(memorySet => memorySet.Count);
            }
        }


        /// <summary>
        /// Flattens all the elements from all the sets into a single array
        /// </summary>
        /// <returns></returns>
        protected IDictionary<TKey, TValue> GetSnapshot()
        {
            var result = new Dictionary<TKey, TValue>(Capacity);
            foreach (var set in subCache)
            {
                foreach (var key in set)
                {
                    result.Add(key, set[key]);
                }
            }
            return result;
        }

        public bool Contains(TKey key)
        {
            return GetSet(key).Contains(key);
        }

        public bool TryGet(TKey key, out TValue value)
        {
            return GetSet(key).TryGet(key, out value);
        }



        public TValue GetOrAdd(TKey key, TValue value)
        {
            return GetSet(key).GetOrAdd(key, value);
        }



        public bool Add(TKey key, TValue value)
        {
            return GetSet(key).Add(key, value);
        }

        public void Put(TKey key, TValue value)
        {
            GetSet(key).Put(key, value);
        }

        public bool Remove(TKey key)
        {
            return GetSet(key).Remove(key);
        }



        public IEnumerator<TKey> GetEnumerator()
        {
            return GetSnapshot().Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


    public delegate void CacheEvictionCallback<TKey, TValue>(ICache<TKey, TValue> source, TKey key, TValue value);
    public delegate void CacheAccessCallback<TKey, TValue>(ICache<TKey, TValue> source, TKey key, TValue value);
}
