using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Marcetux.Caching
{
    /// <summary>
    /// Represents a doubly linked list of unique values, with O(1) random access (to n-th item).
    /// </summary>
    /// <typeparam name="TUnique">The type of unique values in the list</typeparam>
    public class DoublyLinkedListUniqueCollection<TUnique> : ICollection<TUnique>
    {
        private LinkedList<TUnique> items;
        private IDictionary<TUnique, LinkedListNode<TUnique>> hooks;

        public DoublyLinkedListUniqueCollection()
            : this(0)
        {
        }

        public DoublyLinkedListUniqueCollection(int capacity)
        {
            items = new LinkedList<TUnique>();
            hooks = new Dictionary<TUnique, LinkedListNode<TUnique>>(capacity);
        }

        public TUnique First
        {
            get
            {
                if (items.First == null)
                {
                    throw new InvalidOperationException("list is empty");
                }
                return items.First.Value; //head
            }
        }

        public TUnique Last
        {
            get
            {
                if (items.Last == null)
                {
                    throw new InvalidOperationException("list is empty");
                }
                return items.Last.Value; //tail
            }
        }
       

        public void Add(TUnique value)
        {
            var item = new LinkedListNode<TUnique>(value);
            hooks.Add(value, item);
            items.AddLast(item);
        }

        public void Clear()
        {
            items.Clear();
            hooks.Clear();
        }

        public bool Contains(TUnique value)
        {
            return hooks.ContainsKey(value);
        }

        public void CopyTo(TUnique[] array, int index)
        {
            var values = items.ToArray();
            values.CopyTo(array, index);
        }

        public bool Remove(TUnique value)
        {
            LinkedListNode<TUnique> item;
            bool found;
            if (found = hooks.TryGetValue(value, out item))
            {
                items.Remove(item);
                hooks.Remove(value);
            }
            return found;
        }

        public int Count => items.Count;

        public bool IsReadOnly => false;

        public IEnumerator<TUnique> GetEnumerator()
        {
            return ((IEnumerable<TUnique>)items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
