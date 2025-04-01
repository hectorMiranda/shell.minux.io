using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Marcetux.Caching
{
    using Interfaces;

    public class SubCache<TKey, TValue> : ICache<TKey, TValue>
    {
        public IReplacementAlgorithm<TKey, TValue> ReplacementAlgorithm { get; private set; }
        protected readonly object SyncRoot = new object();




        public SubCache(int capacity, Type replacementAlgorithm )
        { 
            this.Capacity = capacity;
            ReplacementAlgorithm = CreateInstance(replacementAlgorithm);
        }


        protected virtual void Forget(TKey key)
        {
            ReplacementAlgorithm.Evictables.Remove(key);
        }

        protected IReplacementAlgorithm<TKey, TValue> CreateInstance(Type replacementAlgorithm, params object[] args)
        {
            return (IReplacementAlgorithm<TKey, TValue>)Activator.CreateInstance(replacementAlgorithm, Capacity > 0 ? new object[] { Capacity } : null);

        }



        protected bool InternalTryGet(TKey key, out TValue value)
        {
            value = default(TValue);

            ReplacementAlgorithm.Evictables.Remove(key);

            return ReplacementAlgorithm.Handle(CacheAccessOperation.Get, key, ref value, true);
        }

        protected bool InternalSet(TKey key, TValue value, bool isPut)
        {
            bool success = false;

            if (Capacity <= ReplacementAlgorithm.State.Count && !ReplacementAlgorithm.State.ContainsKey(key))
                ReplacementAlgorithm.Evict();

            success = ReplacementAlgorithm.Handle(CacheAccessOperation.Set, key, ref value, isPut);

            if(success)
                ReplacementAlgorithm.Evictables.Add(key);

            return success;
        }



        public bool Contains(TKey key)
        {
            lock (SyncRoot)
            {
                return ReplacementAlgorithm.State.ContainsKey(key);
            }
        }

        public  bool TryGet(TKey key, out TValue value)
        {
            lock (SyncRoot)
            {
                return InternalTryGet(key, out value);
            }
        }

        public  TValue Get(TKey key)
        {
            lock (SyncRoot)
            {
                TValue cached;
                if (!InternalTryGet(key, out cached))
                {
                    throw new KeyNotFoundException();
                }
                return cached;
            }
        }

        public  TValue GetOrAdd(TKey key, TValue value)
        {
            lock (SyncRoot)
            {
                TValue cached;
                if (!InternalTryGet(key, out cached))
                {
                    InternalSet(key, value, false);
                    return value;
                }
                return cached;
            }
        }





        public int Capacity { get; }



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

        public bool Add(TKey key, TValue value)
        {
            lock (SyncRoot)
            {
                return InternalSet(key, value, false);
            }
        }

        public  void Put(TKey key, TValue value)
        {
            lock (SyncRoot)
            {
                InternalSet(key, value, true);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<TKey> GetEnumerator()
        {
            throw new NotImplementedException();
        }



        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public int Count { get; }
    }
}
