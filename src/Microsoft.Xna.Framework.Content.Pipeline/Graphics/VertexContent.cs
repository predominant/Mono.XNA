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
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public sealed class VertexContent
    {
        #region Constructors

        internal VertexContent(GeometryContent parent)
        {
            this.positionIndices = new VertexChannel<int>("PositionIndices");
            this.positions = new IndirectPositionCollection(parent, this.positionIndices);
            this.channels = new VertexChannelCollection(this);
        }
        #endregion

        #region Properties

        private VertexChannelCollection channels;
        [ContentSerializer(Optional = true)]
        public VertexChannelCollection Channels
        {
            get
            {
                return this.channels;
            }
        }

        private VertexChannel<int> positionIndices;
        [ContentSerializerIgnore]
        public VertexChannel<int> PositionIndices
        {
            get
            {
                return this.positionIndices;
            }
        }

        private IndirectPositionCollection positions;
        [ContentSerializerIgnore]
        public IndirectPositionCollection Positions
        {
            get
            {
                return this.positions;
            }
        }

        public int VertexCount
        {
            get
            {
                return this.positionIndices.Count;
            }
        }
		
#endregion
		
#region Public Methods

		public int Add(int positionIndex)
		{
			throw new NotImplementedException();
		}
		
		public void AddRange(IEnumerable<int> positionIndexCollection)
		{
			throw new NotImplementedException();
		}
		
		public void CreateVertexBuffer(out VertexBufferContent vertexBuffer, out VertexElement[] vertexElements, TargetPlatform targetPlatform)
		{
			throw new NotImplementedException();
		}
		
		public void Insert(int index, int positionIndex)
		{
			throw new NotImplementedException();
		}
		
		public void InsertRange(int index, IEnumerable<int> positionIndexCollection)
		{
			throw new NotImplementedException();
		}
		
		public void RemoveAt(int index)
		{
			throw new NotImplementedException();
		}
		
		public void RemoveRange(int index, int count)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
	}
}
