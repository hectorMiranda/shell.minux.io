using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marcetux.Caching
{
    using Interfaces;

    public class LruReplacementAlgorithm<TKey, TValue> : ReplacementAlgorithm<TKey, TValue>
    {
        public LruReplacementAlgorithm(int capacity) : base(capacity)
        {
        }


        public override Type GetType()
        {
            return typeof(LruReplacementAlgorithm<TKey, TValue>);
        }

        public override ICollection<TKey> CreateEvictableCollection()
        {
            var type = typeof(DoublyLinkedListUniqueCollection<TKey>);
            return (ICollection<TKey>)Activator.CreateInstance(type, Capacity > 0 ? new object[] { Capacity } : null);
        }

        public override bool GetNextEvictedKey(out TKey key)
        {
            key = ((DoublyLinkedListUniqueCollection<TKey>)Evictables).First;
            return true;
        }

        
    }
}
