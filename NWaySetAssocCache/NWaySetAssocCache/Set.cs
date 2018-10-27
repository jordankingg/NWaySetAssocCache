using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NWaySetAssocCache
{
    /// <summary>Class <c>Set</c> models a Set in a N-Way Set Associative Cache.</summary>
    public class Set<K, V>
    {
        private int nItems;
        public ICacheAlgorithms<K, V> cacheAlgo;

        /// <summary>
        /// Constructor for Set, instantiates the ICacheAlgorithms interfaced based on which algorithm was supplied
        /// </summary>
        /// <param name="nItems">Number of cache items in a Set</param>
        /// <param name="algorithm">Default replacement algorithm (LRU/MRU)</param>
        public Set(int nItems, Algorithm algorithm)
        {
            this.nItems = nItems;

            if (algorithm == Algorithm.LRU)
            {
                cacheAlgo = new LRU<K, V>(nItems);
            }

            else if (algorithm == Algorithm.MRU)
            {
                cacheAlgo = new MRU<K, V>(nItems);
            }
        }

        /// <summary>
        /// Constructor for Set when a custom cache replacement algorithm is supplied
        /// </summary>
        /// <param name="nItems">Number of cache items in a Set</param>
        /// <param name="algorithm">Custom replacement algorithm</param>
        public Set(int nItems, ICacheAlgorithms<K, V> algorithm)
        {
            this.nItems = nItems;
            cacheAlgo = algorithm;
        }

        /// <summary>
        /// Returns value from cache based on supplied key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public V get(K key)
        {
            return cacheAlgo.get(key);
        }

        /// <summary>
        /// Adds the new key-value pair to the set. Checks if the set already contains the pair.
        /// Also, checks if the set is full.
        /// </summary>
        /// <param name="newKey">Key to add</param>
        /// <param name="newValue">Value to add</param>
        public void add(K newKey, V newValue)
        {
            cacheAlgo.set(newKey, newValue);
        }

        /// <summary>
        /// Returns whether the cache contains the specified key
        /// </summary>
        /// <returns>True if cache contains key, False if cache does not contain key</returns>
        /// <param name="key">Key</param>
        public bool contains(K key)
        {
            return cacheAlgo.contains(key);
        }
    }
}