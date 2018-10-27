using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using System.Diagnostics;

namespace NWaySetAssocCache
{
    /// <summary>
    /// Cache
    /// </summary>
    /// <typeparam name="K">Represents the cache pair's key type</typeparam>
    /// <typeparam name="V">Represents the cache pair's value type</typeparam>
    public class Cache<K, V>
    {
        public int cacheSize, nSets, nItems;
        private Algorithm algorithm = Algorithm.LRU;
        public List<Set<K, V>> cache = new List<Set<K, V>>();

        /// <summary>
        /// Cache constructor when no cache replacement algorithm is supplied
        /// </summary>
        /// <param name="cacheSize">Size of the cache</param>
        /// <param name="nItems">Number of cache items in a Set</param>
        public Cache(int cacheSize, int nItems)
        {
            this.cacheSize = cacheSize;
            this.nItems = nItems;
            this.nSets = this.cacheSize / this.nItems;

            for (int i = 0; i < nSets; i++)
            {
                cache.Add(new Set<K, V>(nItems, algorithm));
            }
        }

        /// <summary>
        /// Cache constructor when a default cache replacement algorithm (LRU, MRU) is supplied
        /// </summary>
        /// <param name="cacheSize">Size of the cache</param>
        /// <param name="nItems">Number of cache items in a Set</param>
        /// <param name="algorithm">Caching algorithm</param>
        public Cache(int cacheSize, int nItems, Algorithm algorithm)
        {
            this.cacheSize = cacheSize;
            this.nItems = nItems;
            this.nSets = this.cacheSize / this.nItems;
            this.algorithm = algorithm;

            for (int i = 0; i < nSets; i++)
            {
                cache.Add(new Set<K, V>(nItems, this.algorithm));
            }
        }

        /// <summary>
        /// Cache constructor when a custom cache replacement algorithm is supplied
        /// </summary>
        /// <param name="cacheSize">Size of the cache</param>
        /// <param name="nItems">Number of cache items in a Set</param>
        /// <param name="custAlgorithm">Custom replacement algorithm</param>
        public Cache(int cacheSize, int nItems, ICacheAlgorithms<K, V> custAlgorithm)
        {
            this.cacheSize = cacheSize;
            this.nItems = nItems;
            this.nSets = this.cacheSize / this.nItems;

            for (int i = 0; i < nSets; i++)
            {
                cache.Add(new Set<K, V>(nItems, custAlgorithm));
            }
        }

        /// <summary>
        /// Gets the cache
        /// </summary>
        /// <returns>The cache</returns>
        public List<Set<K, V>> getCache()
        {
            return cache;
        }

        /// <summary>
        /// Gets the index of the set based on the key supplied
        /// </summary>
        /// <returns>The set index</returns>
        /// <param name="key">Key</param>
        public int getSetIndex(K key)
        {
            return Math.Abs(key.GetHashCode() % nSets);
        }

        /// <summary>
        /// Get the value from the cache based on the supplied key
        /// </summary>
        /// <returns>The value, based on supplied key</returns>
        /// <param name="key">Key</param>
        public V get(K key)
        {
            return cache[getSetIndex(key)].get(key);
        }

        /// <summary>
        /// Put the specified key and value into the cache
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        public void put(K key, V value)
        {
            cache[getSetIndex(key)].add(key, value);
        }

        /// <summary>
        /// Returns whether the cache contains the specified key
        /// </summary>
        /// <returns>True if cache contains key, False if cache does not contain key</returns>
        /// <param name="key">Key</param>
        public bool contains(K key)
        {
            return cache[getSetIndex(key)].contains(key);
        }

        public void printCache()
        {
            for (int i = 0; i < nSets; i++)
            {
                foreach (var pair in cache[i].cacheAlgo.getSetData())
                {
                    Debug.WriteLine($"Cache Key: {pair.Key}, Value: {pair.Value.val}");
                }
                Debug.WriteLine("");
            }
        }
    }
}


