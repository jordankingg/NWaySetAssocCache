# N-Way, Set-Associative Cache Implementation
***
#### Jordan King  
&nbsp;

## Introduction
***
This document is intended to be an overview and explanation of my implementation of a N-Way, Set-Associative Cache in C\#. The code was produced using a mixture of Visual Studio Code and Visual Studio for Mac.

## Requirements
***
1. The cache itself is entirely in memory (i.e.  it does not communicate with a backing store).
2.  The client interface should be type-safe for keys and values and allow for both the keys and values to be of an arbitrary type (e.g., strings, integers, classes, etc.). For a given instance of a cache all keys must be the same type and all values must be the same type.
3. Design  the  interface  as  a  library  to  be  distributed  to  clients.   Assume  that  the  client doesn’t have source code to your library.
4. Provide LRU and MRU replacement algorithms.
5. Provide a way for any alternative replacement algorithm to be implemented by the client and used by the cache.

Please see the NWaySetAssocCache.pdf for more documentation details.