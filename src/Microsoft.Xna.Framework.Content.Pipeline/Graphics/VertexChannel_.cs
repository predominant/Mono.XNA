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

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public sealed class VertexChannel<T> : VertexChannel, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
    {
#region Constructors
        internal VertexChannel(string name)
            : base(name)
        {
            //this.internalData = new List<T>();
        }
#endregion
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
