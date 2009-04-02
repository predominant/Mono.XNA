// NamedValueDictionary.cs created with MonoDevelop
// User: lars at 03.58 22.02.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

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
