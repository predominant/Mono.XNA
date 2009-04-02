// IndirectPositionCollection.cs created with MonoDevelop
// User: lars at 07.25 07.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public sealed class IndirectPositionCollection : IList<Vector3>, ICollection<Vector3>, IEnumerable<Vector3>, IEnumerable
	{

#region Constructor
		
		public IndirectPositionCollection()
		{
		}

#endregion
		
#region Properties
		
		public Vector3 this[int index] 
		{ 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}


		public int Count 
		{ 
			get { throw new NotImplementedException(); }
		}
		
#endregion
		
#region Public Methods
		
		public bool Contains(Vector3 item)
		{
			throw new NotImplementedException();
		}
		
		public void CopyTo(Vector3[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}
		
		public IEnumerator<Vector3> GetEnumerator()
		{
			throw new NotImplementedException();
		}

		public int IndexOf(Vector3 item)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
#region Explicit Implementations

		bool ICollection<Vector3>.IsReadOnly 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		void ICollection<Vector3>.Add(Vector3 item)
		{
			throw new NotImplementedException();
		}
		
		void ICollection<Vector3>.Clear()
		{
			throw new NotImplementedException();
		}
		
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
		
		void IList<Vector3>.Insert(int index, Vector3 item)
		{
			throw new NotImplementedException();
		}
		
		void IList<Vector3>.RemoveAt(int index)
		{
			throw new NotImplementedException();
		}
		
		bool ICollection<Vector3>.Remove(Vector3 item)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
	}
}
