// VertexChannelCollection.cs created with MonoDevelop
// User: lars at 11.33 14.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public sealed class VertexChannelCollection : IList<VertexChannel>, ICollection<VertexChannel>, IEnumerable<VertexChannel>, IEnumerable
	{
		
#region Properties
		
		public VertexChannel this[int index] 
		{ 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}

		public VertexChannel this[string name] 
		{ 
			get { throw new NotImplementedException(); }
		}

		public int Count 
		{ 
			get { throw new NotImplementedException(); }
		}		
		
#endregion
		
#region Public Methods

		public VertexChannel<ElementType> Add<ElementType>(string name, IEnumerable<ElementType> channelData)
		{
			throw new NotImplementedException();
		}
		
		public VertexChannel Add(string name, Type elementType, IEnumerable channelData)
		{
			throw new NotImplementedException();
		}
		
		public void Clear()
		{
			throw new NotImplementedException();
		}

		public bool Contains(string name)
		{
			throw new NotImplementedException();
		}
		
		public bool Contains(VertexChannel item)
		{
			throw new NotImplementedException();
		}
		
		public VertexChannel<TargetType> ConvertChannelContent<TargetType>(int index)
		{
			throw new NotImplementedException();
		}
		
		public VertexChannel<TargetType> ConvertChannelContent<TargetType>(string name)
		{
			throw new NotImplementedException();
		}
		
		public VertexChannel<T> Get<T>(int index)
		{
			throw new NotImplementedException();
		}
		
		public IEnumerator<VertexChannel> GetEnumerator()
		{
			throw new NotImplementedException();
		}
		
		public VertexChannel<T> Get<T>(string name)
		{
			throw new NotImplementedException();
		}
		
		public int IndexOf(string name)
		{
			throw new NotImplementedException();
		}
		
		public int IndexOf(VertexChannel item)
		{
			throw new NotImplementedException();
		}
		
		public VertexChannel<ElementType> Insert<ElementType>(int index, string name, IEnumerable<ElementType> channelData)
		{
			throw new NotImplementedException();
		}
		
		public VertexChannel Insert(int index, string name, Type elementType, IEnumerable channelData)
		{
			throw new NotImplementedException();
		}
		
		public bool Remove(string name)
		{
			throw new NotImplementedException();
		}
		
		public bool Remove(VertexChannel item)
		{
			throw new NotImplementedException();
		}
		
		public void RemoveAt(int index)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
#region Explicit Implemenatations

		bool ICollection<VertexChannel>.IsReadOnly 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		void ICollection<VertexChannel>.Add(VertexChannel item)
		{
			throw new NotImplementedException();
		}
		
		void ICollection<VertexChannel>.CopyTo(VertexChannel[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}
		
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		void IList<VertexChannel>.Insert(int index, VertexChannel item)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
	}
}
