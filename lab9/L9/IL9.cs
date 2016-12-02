using System;
using System.Collections;
using System.Collections.Generic;

namespace L9
{
    public interface IL9<K,V> where K : IComparable
    {
        int Count { get; }
        int? Limit { get; set; }
        //IEnumerable<KeyValuePair<K, V>> Elements();
        V Get(K key);
        bool Put(K key, V value);
        bool Remove(K key);
        bool HasKey(K key);
        V this[K key] { get; set; }
    }
}
