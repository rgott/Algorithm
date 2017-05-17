using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm.CSharp
{
    /// <summary>
    /// Doubly Linked Dictionary. Dictionary where both keys and values can be searched for efficiently.
    /// 
    /// Pros: Faster searching
    /// Cons: Uses atleast twice the memory
    /// </summary>
    /// <typeparam name="K">Key</typeparam>
    /// <typeparam name="V">Value</typeparam>
    public class Map<K, V> : IDictionary<K, V>
    {
        public Map()
        {
            Forward = new Dictionary<K, V>();
            Reverse = new Dictionary<V, K>();
        }

        protected Dictionary<K, V> Forward { get; set; }
        protected Dictionary<V, K> Reverse { get; set; }

        public V this[K key]
        {
            get
            {
                return Forward[key];
            }
            set
            {
                var tmpRevKey = Forward[key];
                var tmpRevVal = Reverse[tmpRevKey];
                Reverse.Remove(tmpRevKey);
                Reverse.Add(tmpRevKey, tmpRevVal);

                Forward[key] = value;
            }
        }

        public K this[V key]
        {
            get
            {
                return Reverse[key];
            }
            set
            {
                var tmpFwdKey = Reverse[key];
                var tmpFwdVal = Forward[tmpFwdKey];
                Forward.Remove(tmpFwdKey);
                Forward.Add(tmpFwdKey, tmpFwdVal);

                Reverse[key] = value;
            }
        }

        public ICollection<K> Keys => Forward.Keys;

        public ICollection<V> Values => Forward.Values;

        public int Count => Forward.Count;

        public bool IsReadOnly => false;

        public void Add(K key, V value)
        {
            Forward.Add(key, value);
            Reverse.Add(value, key);
        }
        public void Add(V key, K value)
        {
            Reverse.Add(key, value);
            Forward.Add(value, key);
        }

        public void Add(KeyValuePair<K, V> item)
        {
            Forward.Add(item.Key, item.Value);
            Reverse.Add(item.Value, item.Key);
        }

        public void Add(KeyValuePair<V, K> item)
        {
            Reverse.Add(item.Key, item.Value);
            Forward.Add(item.Value, item.Key);
        }

        public void Clear()
        {
            Forward.Clear();
            Reverse.Clear();
        }

        public bool Contains(KeyValuePair<K, V> item)
        {
            return Forward.Contains(item);
        }
        public bool Contains(KeyValuePair<V, K> item)
        {
            return Reverse.Contains(item);
        }

        public bool ContainsKey(K key)
        {
            return Forward.ContainsKey(key);
        }

        public bool ContainsValue(V value)
        {
            return Reverse.ContainsKey(value);
        }


        public void CopyTo(KeyValuePair<K, V>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        public void CopyTo(KeyValuePair<V, K>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(K key)
        {
            return Remove(Forward, Reverse, key);
        }
        public bool Remove(V value)
        {
            return Remove(Reverse, Forward, value);
        }

        protected static bool Remove<M,N>(IDictionary<M,N> Forward, IDictionary<N, M> Reverse, M key)
        {
            var reverseRemoval = false;
            if (Forward.TryGetValue(key, out var value))
            {
                reverseRemoval = Reverse.Remove(value);
            }
            return Forward.Remove(key) && reverseRemoval;
        }

        public bool Remove(KeyValuePair<K, V> item)
        {
            return Forward.Remove(item.Key) && Reverse.Remove(item.Value);
        }
        public bool Remove(KeyValuePair<V, K> item)
        {
            return Forward.Remove(item.Value) && Reverse.Remove(item.Key);
        }

        public bool TryGetValue(K key, out V value)
        {
            return Forward.TryGetValue(key, out value);
        }

        public bool TryGetKey(V value, out K key)
        {
            return Reverse.TryGetValue(value, out key);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Forward.GetEnumerator();
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            return Forward.GetEnumerator();
        }

        public IEnumerator<KeyValuePair<V, K>> GetEnumeratorReversed()
        {
            return Reverse.GetEnumerator();
        }
    }
}
