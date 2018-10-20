using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NWaySetAssocCache
{   /// <summary>Class <c>Set</c> models a Set in a N-Way Set Associative Cache.</summary>
    class Set<K, V>
    {   
        private int setSize;
        public ICacheAlgorithms<K, V> cacheAlgo;

        /// <summary>
        /// Constructor for Set, instantiates the ICacheAlgorithms interfaced based on which algorithm was supplied
        /// </summary>
        /// <param name="setSize"></param>
        /// <param name="algorithm"></param>
        public Set(int setSize, Algorithm algorithm)
        {
            this.setSize = setSize;

            if (algorithm == Algorithm.LRU)
            {
                cacheAlgo = new LRU<K, V>(setSize);
            }

            else if (algorithm == Algorithm.MRU)
            {
                cacheAlgo = new MRU<K, V>(setSize);
            }

            else if (algorithm == Algorithm.CUSTOM)
            {
                //Uncomment line below if client decides to implement Custom caching algorithm

                //cacheAlgo = new Custom<K, V>(setSize);
            } 
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
        /// Checks if setData is NOT full
        /// </summary>
        /// <returns>True if NOT full, False if full</returns>
        public bool isNotFull()
        {
            if (cacheAlgo.getSetData() == null)
                return true;
            return cacheAlgo.getSetData().Count < setSize;
        }

        /// <summary>
        /// Checks if 
        /// </summary>
        /// <param name="key"></param>
        /// <returns>True if set contains key. False if</returns>
        public bool contains(K key)
        {
            if (cacheAlgo.getSetData() == null)
                return false;
            return cacheAlgo.getSetData().ContainsKey(key);
        }
    }
}