using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Marcetux.Caching
{
    using Interfaces;

    public class SubCache<TKey, TValue> : Dictionary<TKey, TValue>, IEnumerable<TKey>
    {
        protected IReplacementAlgorithm<TKey, TValue> ReplacementAlgorithm { get; private set; }

        public SubCache(int capacity, IReplacementAlgorithm<TKey, TValue> replacementAlgorithm )
        { 
            this.Capacity = capacity;
            Initialize(replacementAlgorithm);
        }

        protected readonly object SyncRoot = new object();

        protected bool IsEvicting;


        protected virtual void Forget(TKey key)
        {
            ReplacementAlgorithm.Evictables.Remove(key);
        }

        protected void Initialize(IReplacementAlgorithm<TKey, TValue> replacementAlgorithm)
        {
            var type = replacementAlgorithm.GetType();

            ReplacementAlgorithm = (IReplacementAlgorithm<TKey, TValue>)Activator.CreateInstance(type, this, Capacity);
        }

        protected IDictionary<TKey, TValue> GetSnapshot()
        {
            lock (SyncRoot)
            {
                return new Dictionary<TKey, TValue>(Eviction);
            }
        }

        protected bool InternalTryGet(TKey key, out TValue value)
        {
            value = default(TValue);
            return Eviction.Handle(CacheAccessOperation.Get, key, ref value, true);
        }

        protected bool InternalSet(TKey key, TValue value, bool isPut)
        {
            if (Capacity <= Eviction.Count && !Eviction.ContainsKey(key))
            {
                try
                {
                    if (!IsEvicting)
                    {
                        IsEvicting = true;
                        if (!Eviction.Evict())
                        {
                            throw new InvalidOperationException("could not evict");//TODO: test this more
                        }
                    }
                    else
                    {
                        throw new NotSupportedException("reentrant evictions are not supported");
                    }
                }
                finally
                {
                    IsEvicting = false;
                }
            }
            return Eviction.Handle(CacheAccessOperation.Set, key, ref value, isPut);
        }



        public bool Contains(TKey key)
        {
            lock (SyncRoot)
            {
                return Eviction.ContainsKey(key);
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





        public IEnumerator<TKey> GetEnumerator()
        {
            return GetSnapshot().Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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



        protected virtual ICollection<TKey> CreateEvictableCollection()
        {
            var type = GetEvictableCollectionType();
            return type != null ? (ICollection<TKey>)Activator.CreateInstance(type, Capacity > 0 ? new object[] { Capacity } : null) : null;
        }



        public bool Evict()
        {
            TKey key;
            var toEvict = GetEvictionSize();
            var evicted = 0;
            while (evicted < toEvict && GetNextEvictedKey(out key))
            {
                evicted++;
            }

            return evicted == toEvict;
        }

        Type ICacheState<TKey, TValue>.GetEvictableCollectionType()
        {
            throw new NotImplementedException();
        }





        public bool Handle(CacheAccessOperation access, TKey key, ref TValue value, bool isGetOrPut)
        {
            bool found = ContainsKey(key);
            if (!found || isGetOrPut)
            {
                if (!found && access == CacheAccessOperation.Get)
                {
                    return false; //key not found
                }
                if (TracksChanges())
                {
                    Before(access, key, value);
                }
                try
                {
                    var onAccess =
                        Policy != null ?
                        access == CacheAccessOperation.Get ? Policy.OnGet :
                        access == CacheAccessOperation.Set ? isGetOrPut ? Policy.OnPut : Policy.OnAdd : null : null;
                    if (access == CacheAccessOperation.Get)
                    {
                        value = this[key]; //get
                    }
                    else
                    {
                        if (!isGetOrPut)
                        {
                            Add(key, value); //add
                        }
                        else
                        {
                            this[key] = value; //put
                        }
                    }
                    switch (access)
                    {
                        case CacheAccessOperation.Get:
                        case CacheAccessOperation.Set:
                            if (onAccess != null)
                            {
                                onAccess(Source, key, value);
                            }
                            break;
                        default:
                            throw new NotSupportedException(access.ToString());
                    }
                }
                finally
                {

                    After(access, key, value);

                }
                // Success; could Get, Add, or Put
                return true;
            }
            // Failure; can't Add (key already in use)
            return false;
        }


        public bool Evict(TKey key)
        {
            TValue value;
            if (Evictables.TryGetValue(key, out value))
            {
                Forget(key);

                return true;
            }
            return false;
        }


    }
}
