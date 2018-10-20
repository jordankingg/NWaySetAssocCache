using System;
using System.Collections;
using System.Collections.Generic;

namespace NWaySetAssocCache
{
     interface ICacheAlgorithms<K, V> {

         /// <summary>
         /// Getter for the private setData variable
         /// </summary>
         /// <returns></returns>
        Dictionary<K, DNode<K, V>> getSetData();

        /// <summary>
        /// Returns the corresponding value to the key(parameter)
        /// </summary>
        /// <param name="key">Key to the value to return</param>
        /// <returns></returns>
        V get(K key);

        /// <summary>
        /// Puts key-value pair into setData and sets its DNode to head
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void set(K key, V value);

        /// <summary>
        /// Removes specified DNode from setData and the doubly-linked list
        /// </summary>
        /// <param name="d">DNode to remove</param>
        void remove(DNode<K, V> d);

        /// <summary>
        /// Removes node from doubly-linked list (DLL)
        /// </summary>
        /// <param name="d">DNode to remove from DLL</param>
        void removeDNode(DNode<K, V> d);

    }
}
