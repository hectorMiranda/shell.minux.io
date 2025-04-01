using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcetux.Caching
{
    using Interfaces;

    public abstract class ReplacementAlgorithm<TKey, TValue> : IReplacementAlgorithm<TKey, TValue>
    {
        public int Capacity { get; set; }
        public ICollection<TKey> Evictables { get; set; }
        public Dictionary<TKey, TValue> State { get; set; }



        protected ReplacementAlgorithm(int capacity)
        {
            State = new Dictionary<TKey, TValue>(capacity);
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
            bool found = State.ContainsKey(key);

            if (!found || isGetOrPut)
            {
                if (!found && access == CacheAccessOperation.Get)
                {
                    return false; //key not found
                }


                   
                if (access == CacheAccessOperation.Get)
                {
                    value = State[key]; //get
                }
                else
                {
                    if (!isGetOrPut)
                    {
                        State.Add(key, value); //add
                    }
                    else
                    {
                        State[key] = value; //put
                    }
                }
                    
                return true;
            }
            // Failure; can't Add (key already in use)
            return false;
        }



        public bool Evict()
        {
            TKey key;
                
            GetNextEvictedKey(out key);

            return State.Remove(key);

        }
    }
}
