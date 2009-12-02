#region License
/*
MIT License
Copyright © 2009 The Mono.Xna Team

All rights reserved.

Authors: Lars Magnusson (lavima@gmail.com)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion License

using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Xna.Framework.Content.Pipeline
{
	
	/// <summary>
    /// Base class for dictionaries that map string identifiers to data values
	/// </summary>
	/// <typeparam name="T">the type of data value</typeparam>
	public class NamedValueDictionary<T> : IDictionary<string, T>, ICollection<KeyValuePair<string, T>>, IEnumerable<KeyValuePair<string, T>>, IEnumerable
	{
		#region Private Fields
		
		private Dictionary<string, T> dictionary;
		
		#endregion Private Fields
		
		#region Constructors

        /// <summary>Initializes an instance of NamedValueDictionary.</summary>
        public NamedValueDictionary()
		{
			dictionary = new Dictionary<string,T>();
		}

		#endregion Constructors
		
		#region Properties

        /// <summary>Gets or sets the specified item.</summary>
        public T this[string key] {
			get { return dictionary[key]; }
			set { dictionary[key] = value; }
		}

        /// <summary>Gets the number of items in the dictionary.</summary>
        public int Count { 
			get { return dictionary.Count; }
		}

        /// <summary>Gets all keys contained in the dictionary.</summary>
        public ICollection<string> Keys { 
			get { return dictionary.Keys; }
		}

        /// <summary>Gets all values contained in the dictionary.</summary>
        public ICollection<T> Values { 
			get { return dictionary.Values; }
		}

		protected internal virtual Type DefaultSerializerType { 
			get { return typeof(T); }
		}
		
		#endregion Properties
		
		#region Public Methods

        /// <summary>Adds the specified key and value to the dictionary.</summary>
        /// <param name="key">Identity of the key of the new data pair.</param>
        /// <param name="value">The value of the new data pair.</param>
        public void Add(string key, T value)
		{
            AddItem(key, value);
        }

        /// <summary>Removes all keys and values from the dictionary.</summary>
        public void Clear()
		{
            ClearItems();
		}

        /// <summary>Determines whether the specified key is present in the dictionary.</summary>
        /// <param name="key">A key to look for</param>
        public bool ContainsKey(string key)
		{
            return dictionary.ContainsKey(key);
		}

        /// <summary>Gets an enumerator that iterates through items in a dictionary.</summary>
        public IEnumerator<KeyValuePair<string, T>> GetEnumerator()
		{
            return (IEnumerator<KeyValuePair<string, T>>)dictionary.GetEnumerator();
        }

        /// <summary>Removes the specified key and value from the dictionary.</summary>
        /// <param name="key">A key to be removed.</param>
        public bool Remove(string key)
		{
            return RemoveItem(key);
        }
		
		public bool TryGetValue(string key, out T value)
		{
            return dictionary.TryGetValue(key, out value);
        }
		
		#endregion Public Methods
		
		#region Protected Methods
		
		protected virtual void AddItem(string key, T value)
		{
            if (string.IsNullOrEmpty(key))
                return; // mey be throw an exception here

            dictionary.Add(key, value);
		}
		
        /// <summary>
        /// Removes all elements from the dictionary
        /// </summary>
		protected virtual void ClearItems()
		{
            dictionary.Clear();
		}

		protected virtual bool RemoveItem(string key)
		{
            if (string.IsNullOrEmpty(key))
                return false;

            return dictionary.Remove(key);
        }
		
		protected virtual void SetItem(string key, T value)
		{
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            
            dictionary[key] = value;
		}
		
		#endregion Protected Methods
		
		#region ICollection Explicit		
		
		bool ICollection<KeyValuePair<string, T>>.IsReadOnly
		{ 
			get { return false; } 
		}
		
		void ICollection<KeyValuePair<string,T>>.Add(KeyValuePair<string, T> item)
		{
            AddItem(item.Key, item.Value);
		}
		
		bool ICollection<KeyValuePair<string,T>>.Contains(KeyValuePair<string, T> item)
		{
            return dictionary.ContainsKey(item.Key);
		}
		
		void ICollection<KeyValuePair<string,T>>.CopyTo(KeyValuePair<string, T>[] array, int arrayIndex)
		{
            (dictionary as ICollection<KeyValuePair<string,T>>).CopyTo(array, arrayIndex);
		}
		
		bool ICollection<KeyValuePair<System.String,T>>.Remove(KeyValuePair<string, T> item)
		{
            if (!(dictionary as ICollection<KeyValuePair<string, T>>).Contains(item))
                return false;

            return RemoveItem(item.Key);
        }
		
		#endregion ICollection Explicit
		
		#region IEnumerator Unused
		
		IEnumerator IEnumerable.GetEnumerator()
		{
            return dictionary.GetEnumerator();
		}		
		
		#endregion IEnumerator Unused
		
	}
}
