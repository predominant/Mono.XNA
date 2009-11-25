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
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Tao.OpenGl;

namespace Microsoft.Xna.Framework.Graphics
{
    public class VertexBuffer : GraphicsResource
    {	
		#region Private Fields
		
		private BufferUsage bufferUsage;
		private int sizeInBytes;
		private int bufferIdentifier;
		
		#endregion Private Fields
		
		#region Constructors 
		
		private VertexBuffer(GraphicsDevice graphicsDevice, BufferUsage usage)
		{
			if(graphicsDevice == null)
				throw new ArgumentNullException("The graphicsDevice parameter cannot be null");
			
			this.graphicsDevice = graphicsDevice;
			this.bufferUsage = usage;
		}
		
        public VertexBuffer(GraphicsDevice graphicsDevice, int sizeInBytes, BufferUsage usage)
			: this(graphicsDevice, usage)
		{
			if(sizeInBytes <= 0)
				throw new ArgumentOutOfRangeException("The sizeInBytes parameter must be larger than 0");
			this.sizeInBytes = sizeInBytes;
			createHostBuffer();
		}
		
		public VertexBuffer(GraphicsDevice graphicsDevice, Type vertexType, int elementCount, BufferUsage usage)
			: this(graphicsDevice, usage)
		{
			sizeInBytes = Marshal.SizeOf(vertexType) * elementCount;
			createHostBuffer();
		}
		
		#endregion Constructors
		
		#region Properties
		
		public BufferUsage BufferUsage { 
			get { return bufferUsage; }
		}
        
		public int SizeInBytes { 
			get { return sizeInBytes; } 
		}
		
		internal int BufferIdentifier {
			get { return bufferIdentifier; }	
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

        public void GetData<T>(int offsetInBytes, T[] data, int startIndex, int elementCount, int vertexStride) 
		{ 
			throw new NotImplementedException(); 
		}

        public void SetData<T>(T[] data) 
		{ 
			Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, bufferIdentifier);
			Gl.glBufferData(Gl.GL_ARRAY_BUFFER, new IntPtr(sizeInBytes), data, Gl.GL_DYNAMIC_DRAW);
		}

        public void SetData<T>(T[] data, int startIndex, int elementCount, SetDataOptions options) 
		{ 
			data = getSubData<T>(data, startIndex, elementCount);				
			Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, bufferIdentifier);
			Gl.glBufferSubData(Gl.GL_ARRAY_BUFFER, IntPtr.Zero, new IntPtr(Marshal.SizeOf(typeof(T)) * elementCount), data);
		}

        public void SetData<T>(int offsetInBytes, T[] data, int startIndex, int elementCount, int vertexStride, SetDataOptions options) 
		{ 
			data = getSubData<T>(data, startIndex, elementCount);				
			Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, bufferIdentifier);
			Gl.glBufferSubData(Gl.GL_ARRAY_BUFFER, new IntPtr(offsetInBytes), new IntPtr(vertexStride * elementCount), data);
		}
		
		#endregion Public Methods
		
		#region Private Methods
		
		private void createHostBuffer()
		{
			Gl.glGenBuffers(1, out bufferIdentifier);
			Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, bufferIdentifier);
			Gl.glBufferData(Gl.GL_ARRAY_BUFFER, new IntPtr(sizeInBytes), IntPtr.Zero, Gl.GL_DYNAMIC_DRAW);
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
			return string.Format("[VertexBuffer: BufferUsage={0}, SizeInBytes={1}]", BufferUsage, SizeInBytes);
		}
		
        protected override void Dispose(bool disposing) 
		{ 
			throw new NotImplementedException(); 
		}
		
		#endregion Overrides
		
    }

}
