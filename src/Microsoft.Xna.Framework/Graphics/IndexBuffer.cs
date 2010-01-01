#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.

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
using System.Runtime.InteropServices;
using Tao.OpenGl;

namespace Microsoft.Xna.Framework.Graphics
{
    public class IndexBuffer : GraphicsResource
    {
		#region Private Fields
		
		private BufferUsage bufferUsage;
		private int sizeInBytes;
		private int bufferIdentifier;
		private IndexElementSize indexElementSize;
		
		#endregion Private Fields
		
		#region Constructors
		
		private IndexBuffer(GraphicsDevice graphicsDevice, BufferUsage usage)
		{
			if (graphicsDevice == null)
				throw new ArgumentNullException("The graphicsDevice parameter cannot be null");
			
			this.graphicsDevice = graphicsDevice;
			this.bufferUsage = usage;
		}
		
        public IndexBuffer(GraphicsDevice graphicsDevice, int sizeInBytes, BufferUsage usage, IndexElementSize elementSize)
			: this(graphicsDevice, usage)
		{
			this.sizeInBytes = sizeInBytes;
			this.indexElementSize = elementSize;
			
			createHostBuffer();
		}
		
		public IndexBuffer(GraphicsDevice graphicsDevice, Type indexType, int elementCount, BufferUsage usage)
			: this(graphicsDevice, usage)
		{
			int size = Marshal.SizeOf(indexType);
			if (size == 16)
				indexElementSize = IndexElementSize.SixteenBits;
			else if (size == 32)
				indexElementSize = IndexElementSize.ThirtyTwoBits;
			else
				throw new ArgumentOutOfRangeException("The indexType must be either 16 or 32 bit");
			
			this.sizeInBytes = Marshal.SizeOf(indexType) * elementCount;
			
			createHostBuffer();
		}
		
		#endregion Constructors

		#region Properties
		
        public BufferUsage BufferUsage { 
			get { return bufferUsage; } 
		}
		
        public IndexElementSize IndexElementSize {
            get { return indexElementSize; }
        }

        public int SizeInBytes {
            get { return sizeInBytes; }
        }
		
		#endregion Properties
		
		#region Public Methods
		
		public void GetData<T>(T[] data)
        {
            throw new NotImplementedException();
        }

        public void GetData<T>(T[] data, int startIndex, int elementCount)
        {
            throw new NotImplementedException();
        }

        public void GetData<T>(int offsetInBytes, T[] data, int startIndex, int elementCount)
        {
            throw new NotImplementedException();
        }

        public void SetData<T>(T[] data)
        {
            Gl.glBindBuffer(Gl.GL_ELEMENT_ARRAY_BUFFER, bufferIdentifier);
			Gl.glBufferData(Gl.GL_ELEMENT_ARRAY_BUFFER, new IntPtr(sizeInBytes), data, Gl.GL_DYNAMIC_DRAW);
        }

        public void SetData<T>(T[] data, int startIndex, int elementCount, SetDataOptions options)
        {
            SetData<T>(0, data, startIndex, elementCount, options);
        }

        public void SetData<T>(int offsetInBytes, T[] data, int startIndex, int elementCount, SetDataOptions options)
        {
			int indexSize = indexElementSize == IndexElementSize.SixteenBits ? 2 : 4;
            data = getSubData<T>(data, startIndex, elementCount);				
			Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, bufferIdentifier);
			Gl.glBufferSubData(Gl.GL_ARRAY_BUFFER, new IntPtr(offsetInBytes), new IntPtr(indexSize * elementCount), data);
        }
		
		#endregion Public Methods
		
		#region Private Methods
		
		private void createHostBuffer()
		{
			// Create VBO and allocate memory
			Gl.glGenBuffers(1, out bufferIdentifier);
			Gl.glBindBuffer(Gl.GL_ELEMENT_ARRAY_BUFFER, bufferIdentifier);
			Gl.glBufferData(Gl.GL_ELEMENT_ARRAY_BUFFER, new IntPtr(sizeInBytes), IntPtr.Zero, Gl.GL_DYNAMIC_DRAW);
		}
		
		private T[] getSubData<T>(T[] data, int startIndex, int elementCount)
		{
			if (startIndex != 0 || elementCount != data.Length)
			{
				T[] temp = new T[elementCount];
				for (int i=0; i<elementCount; i++)
					temp[i] = data[i];					
				data = temp;
			}
			return data;
		}
		
		#endregion Private Methods
		
		#region Overrides
		
		public override string ToString ()
		{
			return string.Format("[IndexBuffer: BufferUsage={0}, IndexElementSize={1}, SizeInBytes={2}]", BufferUsage, IndexElementSize, SizeInBytes);
		}

        protected override void Dispose(bool disposing)
        {
            throw new NotImplementedException();
        }
		
		#endregion Overrides
    }
}
