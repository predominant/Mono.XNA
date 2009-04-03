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
	
	
	public class NamedValueDictionary<T> : IDictionary<string, T>, ICollection<KeyValuePair<string, T>>, IEnumerable<KeyValuePair<string, T>>, IEnumerable
	{

		private Dictionary<string, T> dictionary;
		
#region Constructors
		
		public NamedValueDictionary()
		{
			dictionary = new Dictionary<string,T>();
		}

#endregion
		
#region Properties
		
		public T this[string key]
		{
			get { return dictionary[key]; }
			set { dictionary[key] = value; }
		}
		
		public int Count 
		{ 
			get { return dictionary.Count; }
		}

		public ICollection<string> Keys 
		{ 
			get { return dictionary.Keys; }
		}

		public ICollection<T> Values 
		{ 
			get { return dictionary.Values; }
		}

		protected internal virtual Type DefaultSerializerType 
		{ 
			get { throw new NotImplementedException(); }
		}
		
#endregion
		
#region Public Methods

		public void Add(string key, T value)
		{
			
		}
		
		public void Clear()
		{
		}
		
		public bool ContainsKey(string key)
		{
			throw new NotImplementedException();
		}
		
		public IEnumerator<KeyValuePair<string, T>> GetEnumerator()
		{
			throw new NotImplementedException();
		}

		public bool Remove(string key)
		{
			throw new NotImplementedException();
		}
		
		public bool TryGetValue(string key, out T value)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
#region Protected Methods
		
		protected virtual void AddItem(string key, T value)
		{
		}
		
		protected virtual void ClearItems()
		{
		}

		protected virtual bool RemoveItem(string key)
		{
			return true;
		}
		
		protected virtual void SetItem(string key, T value)
		{
			
		}
		
#endregion
		
#region ICollection Explicit
		
		
		bool ICollection<KeyValuePair<string, T>>.IsReadOnly
		{ 
			get { throw new NotImplementedException(); } 
		}
		
		void ICollection<KeyValuePair<string,T>>.Add(KeyValuePair<string, T> item)
		{
			throw new NotImplementedException();
		}
		
		bool ICollection<KeyValuePair<string,T>>.Contains(KeyValuePair<string, T> item)
		{
			throw new NotImplementedException();
		}
		
		void ICollection<KeyValuePair<string,T>>.CopyTo(KeyValuePair<string, T>[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}
		
		bool ICollection<KeyValuePair<System.String,T>>.Remove(KeyValuePair<string, T> item)
		{
			throw new NotImplementedException();
		}
		
#endregion
		

		
#region IEnumerator Unused
		
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}		
		
#endregion
		
	}
}
