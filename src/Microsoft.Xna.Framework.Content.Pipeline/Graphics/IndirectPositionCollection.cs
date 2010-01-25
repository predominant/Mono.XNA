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
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public sealed class IndirectPositionCollection : IList<Vector3>, ICollection<Vector3>, IEnumerable<Vector3>, IEnumerable
	{

        private GeometryContent geometry;
        private VertexChannel<int> positionIndices;

#region Constructor

        internal IndirectPositionCollection(GeometryContent geometry, VertexChannel<int> positionIndices)
        {
            this.geometry = geometry;
            this.positionIndices = positionIndices;
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
