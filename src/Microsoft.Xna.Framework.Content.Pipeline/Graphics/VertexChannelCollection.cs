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
	
	
	public sealed class VertexChannelCollection : IList<VertexChannel>, ICollection<VertexChannel>, IEnumerable<VertexChannel>, IEnumerable
	{
        private List<VertexChannel> channels;
        private VertexContent parent;
 

#region Constructors
        internal VertexChannelCollection(VertexContent parent)
        {
            this.channels = new List<VertexChannel>();
            this.parent = parent;
        }
#endregion
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
