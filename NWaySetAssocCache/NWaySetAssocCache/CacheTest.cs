using System;
using NUnit.Framework;

namespace NWaySetAssocCache
{
    [TestFixture]
    public class CacheTest
    {
        [Test]
        public void testGet()
        {
            Cache<char, int> cache = new Cache<char, int>(4, 4, Algorithm.LRU);

            cache.put('A', 1);
            cache.put('B', 2);
            cache.put('C', 3);
            cache.put('D', 4);
            cache.get('A');

            Assert.IsTrue(cache.getCache()[0].cacheAlgo.getHead().key == 'A');
        }

        [Test]
        public void testReplacement()
        {
            Cache<char, int> cache = new Cache<char, int>(4, 4, Algorithm.LRU);

            cache.put('A', 1);
            cache.put('B', 2);
            cache.put('C', 3);
            cache.put('D', 4);
            cache.put('E', 5);

            Assert.IsFalse(cache.getCache()[0].cacheAlgo.getSetData().ContainsKey('A'));
        }

        [Test]
        public void testDuplicateReplacement()
        {
            Cache<char, int> cache = new Cache<char, int>(4, 4, Algorithm.LRU);

            cache.put('A', 1);
            cache.put('B', 2);
            cache.put('C', 3);
            cache.put('D', 4);
            cache.put('E', 5);
            cache.put('A', 65);


            Assert.IsTrue(cache.getCache()[0].cacheAlgo.get('A') == 65);
        }

        [Test]
        public void returnNull()
        {
            Cache<char, int> cache = new Cache<char, int>(4, 4, Algorithm.LRU);

            cache.put('A', 1);
            cache.put('B', 2);
            cache.put('C', 3);
            cache.put('D', 4);
            cache.put('E', 5);
            cache.put('A', 65);


            Assert.IsTrue(cache.getCache()[0].cacheAlgo.get('F') == null);
        }

    }
}

