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

namespace Microsoft.Xna.Framework.Graphics
{
    public class VertexBuffer : GraphicsResource
    {
		#region Constructors 
		
        public VertexBuffer(GraphicsDevice graphicsDevice, int sizeInBytes, BufferUsage usage)
        {
            //TODO
        }

        public VertexBuffer(GraphicsDevice graphicsDevice, Type vertexType, int elementCount, BufferUsage usage)
        {
            //TODO
        }
		
		#endregion Constructors
		
		#region Operators

        public static bool operator !=(VertexBuffer left, VertexBuffer right) 
		{ 
			throw new NotImplementedException(); 
		}

        public static bool operator ==(VertexBuffer left, VertexBuffer right) 
		{ 
			throw new NotImplementedException(); 
		}
		
		#endregion Operators
		
		#region Properties
		
        public ResourceManagementMode ResourceManagementMode { 
			get { throw new NotImplementedException(); } 
		}

        public ResourceUsage ResourceUsage { 
			get { throw new NotImplementedException(); } 
		}

        public int SizeInBytes { 
			get { throw new NotImplementedException(); } 
		}
		
		#endregion Properties
		
		#region GraphicsResource Overrides

        protected override void Dispose(bool disposing) 
		{ 
			throw new NotImplementedException(); 
		}
		
		public override bool Equals(object obj) 
		{ 
			throw new NotImplementedException(); 
		}
		
		#endregion GraphicsResource Overrides
		
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

        public override int GetHashCode() 
		{ 
			throw new NotImplementedException(); 
		}

        public void SetData<T>(T[] data) 
		{ 
			 
		}

        public void SetData<T>(T[] data, int startIndex, int elementCount, SetDataOptions options) 
		{ 
			throw new NotImplementedException(); 
		}

        public void SetData<T>(int offsetInBytes, T[] data, int startIndex, int elementCount, int vertexStride, SetDataOptions options) 
		{ 
			throw new NotImplementedException(); 
		}
		
		#endregion Public Methods
    }

}
