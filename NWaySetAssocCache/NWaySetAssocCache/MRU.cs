using System.Collections;
using System.Collections.Generic;

namespace NWaySetAssocCache
{
    class MRU<K, V> : ICacheAlgorithms<K, V>
    {
        private Dictionary<K, DNode<K, V>> setData = new Dictionary<K, DNode<K, V>>();
        public DNode<K, V> head, tail = null;
        private int setSize;

        public MRU(int setSize)
        {
            this.setSize = setSize;
        }

        /// <summary>
        /// Getter for the private setData variable  
        /// </summary>
        /// <returns></returns>
        public Dictionary<K, DNode<K, V>> getSetData()
        {
            return setData;
        }

        /// <summary>
        /// Returns the corresponding value to the key(parameter), 
        /// Also sets the pair's corresponding DNode as the head, according to MRU
        /// </summary>
        /// <param name="key">Key to the value to return</param>
        /// <returns></returns>
        public V get(K key)
        {
            DNode<K, V> d = null;
            if (setData.TryGetValue(key, out d))
            {
                if (head == null)
                {
                    head = d;
                    tail = d;
                }

                else
                {
                    head.previous = d;
                    d.next = head;
                    head = d;
                }
            }
            return d.val;
        }

        /// <summary>
        /// Puts key-value pair into setData and sets its DNode to head
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void set(K key, V value)
        {
            DNode<K, V> dNew = new DNode<K, V>(key, value);
            remove(dNew);

            if (setData.Count >= setSize && head != null)
            {
                remove(head);
            }

            setData.Add(key, dNew);
            if (head != dNew)
            {
                head = dNew;
                tail = dNew;
            }

            else
            {
                head.previous = dNew;
                dNew.next = head;
                head = dNew;
            }
        }

        /// <summary>
        /// Removes specified DNode from setData and the doubly-linked list
        /// </summary>
        /// <param name="d">DNode to remove</param>
        public void remove(DNode<K, V> d)
        {
            setData.Remove(d.key);
            removeDNode(d);
        }

        /// <summary>
        /// Removes node from doubly-linked list (DLL)
        /// </summary>
        /// <param name="d">DNode to remove from DLL</param>
        public void removeDNode(DNode<K, V> d)
        {
            if (d == null)
                return;
            if (d.previous != null)
                d.previous.next = d.next;
            if (d.next != null)
                d.next.previous = d.previous;
            if (d == tail)
                tail = d.previous;
            if (d == head)
                head = d.next;
        }

        /// <summary>
        /// Gets the head DNode, for testing purposes
        /// </summary>
        /// <returns>The head DNode</returns>
        public DNode<K, V> getHead()
        {
            return head;
        }

    }

}
