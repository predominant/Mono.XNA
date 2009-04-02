// VertexChannel.cs created with MonoDevelop
// User: lars at 23.01 09.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Collections;
using System.Collections.Generic;


namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{	
	
	public abstract class VertexChannel : IList, ICollection, IEnumerable
	{

#region Properties
		
		public Object this[int index] 
		{ 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
		public int Count 
		{ 
			get { throw new NotImplementedException(); }
		}

		public abstract Type ElementType
		{ 
			get;
		}

		public string Name 
		{ 
			get { throw new NotImplementedException(); }
		}
		
#endregion
		
#region Public Methods

		public bool Contains(Object value)
		{
			throw new NotImplementedException();
		}
		
		public void CopyTo(Array array, int index)
		{
			throw new NotImplementedException();
		}
		
		public IEnumerator GetEnumerator()
		{
			throw new NotImplementedException();
		}

		public int IndexOf(Object value)
		{
			throw new NotImplementedException();
		}
		
		public abstract IEnumerable<TargetType> ReadConvertedContent<TargetType>();
		
#endregion
		
#region Explicit Implementations

		bool IList.IsFixedSize 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		bool IList.IsReadOnly 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		bool ICollection.IsSynchronized 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		Object ICollection.SyncRoot 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		int IList.Add(Object value)
		{
			throw new NotImplementedException();
		}
		
		void IList.Clear()
		{
			throw new NotImplementedException();
		}
		
		void IList.Insert(int index, Object value)
		{
			throw new NotImplementedException();
		}
		
		void IList.RemoveAt(int index)
		{
			throw new NotImplementedException();
		}
		
		void IList.Remove(Object value)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
	}
	
	
}
