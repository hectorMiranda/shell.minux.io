using System;
using System.Collections.Generic;


namespace Marcetux.Caching
{
    using Interfaces;

    public class MruReplacementAlgorithm<TKey, TValue>: ReplacementAlgorithm<TKey,TValue>
    {
        public MruReplacementAlgorithm(int capacity): base(capacity)
        {
        }


        public override Type GetType()
        {
            return typeof(MruReplacementAlgorithm<TKey, TValue>);
        }

        public override ICollection<TKey> CreateEvictableCollection()
        {
            var type = typeof(DoublyLinkedListUniqueCollection<TKey>);
            return (ICollection<TKey>)Activator.CreateInstance(type, Capacity > 0 ? new object[] { Capacity } : null);
        }


        public override bool GetNextEvictedKey(out TKey key)
        {
            key = ((DoublyLinkedListUniqueCollection<TKey>)Evictables).Last;
            return true;
        }

    }
}
