using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace NWaySetAssocCache
{
    class NWaySetAsssocCacheTests
    {

        [Test]
        public void TestGet()
        {
            Cache<char, int> cacheOneWayLRU = new Cache<char, int>(16, 4, Algorithm.LRU);
            cacheOneWayLRU.put('A', 1);
            cacheOneWayLRU.put('B', 2);
            cacheOneWayLRU.put('C', 3);
            cacheOneWayLRU.put('D', 4);

            Assert.IsTrue(cacheOneWayLRU.get('B') == 2, "Getting an item by key should return its value");
        }

        [Test]
        public void TestHeadSingleSet()
        {
            Cache<char, int> cacheOneWayLRU = new Cache<char, int>(8, 8, Algorithm.LRU);
            char getElement = 'B';
            cacheOneWayLRU.put('A', 1);
            cacheOneWayLRU.put(getElement, 2);
            cacheOneWayLRU.put('C', 3);
            cacheOneWayLRU.put('D', 4);

            int getVal = cacheOneWayLRU.get('B');
            DNode<Char, int> setHead = cacheOneWayLRU.getCache()[cacheOneWayLRU.getSetIndex(getElement)].cacheAlgo.getHead();

            Assert.IsTrue( setHead.key == getElement && setHead.val == getVal, "Getting an item by key should update the DLL's head to the node corresponding to the key");
        }

        //^ODO: Fix this test
        [Test]
        public void TestHeadMultiSet()
        {
            Random rnd = new Random();
            Cache<int, int> cacheFourWayLRU = new Cache<int, int>(1024, 256, Algorithm.LRU);
            for (int i = 0; i < cacheFourWayLRU.cacheSize * 2; i++)
            {
                cacheFourWayLRU.put(rnd.Next(1, 100), i);
            }

            int getVal = cacheFourWayLRU.get(1);
            DNode<int, int> setHead = cacheFourWayLRU.getCache()[cacheFourWayLRU.getSetIndex(1)].cacheAlgo.getHead();

            Assert.IsTrue(setHead.key == 1 && setHead.val == getVal, "Getting an item by key should update the DLL's head to the node corresponding to the key");
        }

        [Test]
        public void TestContainsLRU()
        {
            Cache<int, int> cacheFourWayLRU = new Cache<int, int>(16, 4, Algorithm.LRU);
            int offset = 5;
            for (int i = 0; i < cacheFourWayLRU.cacheSize + offset; i++)
            {
                cacheFourWayLRU.put(i, i + 10);
            }

            bool doesContain = false;
            for (int i = 0; i < offset; i++)
            {
                if (cacheFourWayLRU.contains(i))
                    doesContain = true;
            }

            Assert.IsFalse(doesContain, );
        }

        [Test]
        public void TestContainsMRU()
        {
            Cache<int, int> cacheFourWayLRU = new Cache<int, int>(16, 4, Algorithm.MRU);
            int offset = 5;
            for (int i = 0; i < cacheFourWayLRU.cacheSize + offset; i++)
            {
                cacheFourWayLRU.put(i, i + 10);
            }

            bool doesContain = false;
            for (int i = 0; i < offset; i++)
            {
                if (cacheFourWayLRU.contains(cacheFourWayLRU.cacheSize - i))
                    doesContain = true;
            }

            Assert.IsFalse(doesContain);
        }

    }
}



