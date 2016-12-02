using System;
using System.Collections.Generic;

namespace L9
{
    static public class IL9Extender
    {
        static public KeyValuePair<K, V> GetAt<V, K>(this IL9<K, V> il9, int index) where K : IComparable
        {
            if (index >= il9.Count || index < 0)
                throw new IndexOutOfRangeException();

            int i = 0;
            foreach (var pair in il9.Elements())
            {
                if (i == index)
                    return pair;
                i++;
            }

            return new KeyValuePair<K, V>();
        }

        static public V Last<V, K>(this IL9<K, V> il9) where K : IComparable
        {
            return il9.GetAt(il9.Count - 1).Value;
        }
    }
}
