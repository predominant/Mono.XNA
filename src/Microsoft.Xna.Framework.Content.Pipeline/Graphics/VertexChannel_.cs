// VertexChannelGeneric.cs created with MonoDevelop
// User: lars at 09.30 20.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public sealed class VertexChannel<T> : VertexChannel, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		
#region Properties
		
		public new T this [int index] 
		{ 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}

		
		public override Type ElementType 
		{ 
			get { throw new NotImplementedException(); }
		}
		
#endregion
		
#region Public Methods

		public bool Contains(T item)
		{
			throw new NotImplementedException();
		}
		
		public void CopyTo(T[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}
		
		public new IEnumerator<T> GetEnumerator()
		{
			throw new NotImplementedException();
		}
		
		public int IndexOf(T item)
		{
			throw new NotImplementedException();
		}
		
		public override IEnumerable<TargetType> ReadConvertedContent<TargetType>()
		{
			throw new NotImplementedException();
		}
		
#endregion
		
#region Explicit Implementations
		
		bool ICollection<T>.IsReadOnly 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		void ICollection<T>.Add(T item)
		{
			throw new NotImplementedException();
		}
		
		void ICollection<T>.Clear()
		{
			throw new NotImplementedException();
		}
		
		void IList<T>.Insert(int index, T item)
		{
			throw new NotImplementedException();
		}
		
		void IList<T>.RemoveAt(int index)
		{
			throw new NotImplementedException();
		}
		
		bool ICollection<T>.Remove(T item)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
	}
}
