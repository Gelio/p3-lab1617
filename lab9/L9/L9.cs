using System;
using System.Collections;
using System.Collections.Generic;

namespace L9
{
    public class L9<K, V> : IL9<K, V> where K : IComparable
    {
        private List<K> _keys;
        private List<V> _values;
        private int? _limit;

        public L9()
        {
            _keys = new List<K>();
            _values = new List<V>();
            _limit = null;
        }

        public L9(int limit): this()
        {
            _limit = limit;
        }

        public bool Put(K key, V value)
        {
            if (key == null)
                throw new ArgumentNullException();

            int i = 0;
            for (i=0; i < _keys.Count; i++)
            {
                int comparison = key.CompareTo(_keys[i]);
                if (comparison == 0)
                    return false;
                if (comparison < 0)
                    break;
            }

            _keys.Insert(i, key);
            _values.Insert(i, value);

            if (Limit.HasValue && Limit.Value < Count)
            {
                _keys.RemoveAt(0);
                _values.RemoveAt(0);
            }
            return true;
        }

        public V Get(K key)
        {
            if (key == null)
                throw new ArgumentNullException();

            int index = _keys.IndexOf(key);
            if (index >= 0)
                return _values[index];

            return default(V);
        }

        public bool Remove(K key)
        {
            if (key == null)
                throw new ArgumentNullException();

            int index = _keys.IndexOf(key);
            if (index == -1)
                return false;

            _keys.RemoveAt(index);
            _values.RemoveAt(index);
            return true;
        }

        public int Count => _keys.Count;
        public int? Limit
        {
            get
            {
                return _limit;
            }

            set
            {
                _limit = value;
                if (_limit.HasValue)
                {
                    int elementsToRemove = Count - _limit.Value;
                    _keys.RemoveRange(0, elementsToRemove);
                    _values.RemoveRange(0, elementsToRemove);
                }
                
            }
        }

        public bool HasKey(K key)
        {
            return _keys.IndexOf(key) >= 0;
        }

        public V this[K key]
        {
            get
            {
                int index = _keys.IndexOf(key);
                if (index == -1)
                    throw new KeyNotFoundException();

                return _values[index];
            }

            set
            {
                int index = _keys.IndexOf(key);
                if (index == -1)
                    throw new KeyNotFoundException();

                _values[index] = value;
            }
        }

        public IEnumerable<KeyValuePair<K, V>> Elements()
        {
            for (int i=0; i < Count; i++)
                yield return new KeyValuePair<K, V>(_keys[i], _values[i]);
        }

        public IEnumerator<V> GetEnumerator()
        {
            return _values.GetEnumerator();
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(K key, V value)
        {
            Put(key, value);
        }
    }
}