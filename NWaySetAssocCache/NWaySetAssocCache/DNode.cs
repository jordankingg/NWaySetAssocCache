namespace NWaySetAssocCache {   /// <summary>
    /// Represents the nodes in a doubly linked list
    /// </summary>
    /// <typeparam name="K">Represents the cache pair's key type</typeparam>
    /// <typeparam name="V">Represents the cache pair's value type</typeparam>
public class DNode<K, V>
    {
        /// <summary>
        /// DLL node's cache pair key
        /// </summary>
        public K key;

        /// <summary>
        /// DLL node's cache pair value
        /// </summary>
        public V val;

        /// <summary>
        /// DLL node's previous node
        /// </summary>
        public DNode<K, V> previous;

        /// <summary>
        /// DLL node's next node
        /// </summary>
        public DNode<K, V> next;

        /// <summary>
        /// Constructor for the DNode class
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>        
        public DNode(K key, V val)
        {
            this.key = key;
            this.val = val;
        }
    }
}