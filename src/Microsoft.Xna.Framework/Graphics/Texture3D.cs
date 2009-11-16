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
using System.IO;

namespace Microsoft.Xna.Framework.Graphics
{
    public class Texture3D : Texture
    {
		#region Constructor
		
        public Texture3D(GraphicsDevice graphicsDevice, int width, int height, int depth,
			int numberLevels, TextureUsage usage, SurfaceFormat format)
        {
            throw new NotImplementedException();
        }
		
		#endregion Constructor
		
		#region Properties
		
		public int Depth { 
			get { throw new NotImplementedException(); } 
		}
		
        public SurfaceFormat Format { 
			get { throw new NotImplementedException(); } 
		}
		
        public int Height { 
			get { throw new NotImplementedException(); } 
		}
		
        public int Width { 
			get { throw new NotImplementedException(); } 
		}
		
		#endregion Properties
		
		#region Operators
		
		public static bool operator ==(Texture3D left, Texture3D right) 
		{ 
			throw new NotImplementedException(); 
		}
        public static bool operator !=(Texture3D left, Texture3D right) 
		{ 
			throw new NotImplementedException(); 
		}
		
		#endregion Operators
		
		#region Texture Overrides

        protected override void Dispose(bool disposing) 
		{ 
			base.Dispose(disposing); 
		}
		
		#endregion Texture Overrides
		
		#region Public Methods

        public new static Texture3D FromFile(GraphicsDevice graphicsDevice, Stream textureStream) 
		{ 
			throw new NotImplementedException(); 
		}
        
		public new static Texture3D FromFile(GraphicsDevice graphicsDevice, string filename) 
		{ 
			throw new NotImplementedException(); 
		}
        
		public new static Texture3D FromFile(GraphicsDevice graphicsDevice, Stream textureStream, TextureCreationParameters creationParameters) 
		{ 
			throw new NotImplementedException(); 
		}
        
		public new static Texture3D FromFile(GraphicsDevice graphicsDevice, Stream textureStream, int numberBytes) 
		{ 
			throw new NotImplementedException(); 
		}
		
        public new static Texture3D FromFile(GraphicsDevice graphicsDevice, string filename, TextureCreationParameters creationParameters) 
		{ 
			throw new NotImplementedException(); 
		}
		
        public new static Texture3D FromFile(GraphicsDevice graphicsDevice, Stream textureStream, int numberBytes, TextureCreationParameters creationParameters) 
		{ 
			throw new NotImplementedException(); 
		}
		
        public new static Texture3D FromFile(GraphicsDevice graphicsDevice, string filename, int width, int height, int depth) 
		{ 
			throw new NotImplementedException(); 
		}

        public void GetData<T>(T[] data) where T : struct 
		{ 
			throw new NotImplementedException(); 
		}
		
        public void GetData<T>(T[] data, int startIndex, int elementCount) where T : struct 
		{ 
			throw new NotImplementedException(); 
		}
		
        public void GetData<T>(int level, int left, int top, int right, int bottom, int front, int back, T[] data, int startIndex, int elementCount) where T : struct 
		{ 
			throw new NotImplementedException(); 
		}

        public void SetData<T>(T[] data) where T : struct 
		{ 
			throw new NotImplementedException(); 
		}
		
        public void SetData<T>(T[] data, int startIndex, int elementCount, SetDataOptions options) where T : struct 
		{ 
			throw new NotImplementedException(); 
		}
		
        public void SetData<T>(int level, int left, int top, int right, int bottom, int front, int back, T[] data, int startIndex, int elementCount, SetDataOptions options) where T : struct 
		{ 
			throw new NotImplementedException(); 
		}
		
		#endregion Public Methods

		#region Object Overrides
		
        public override string ToString() 
		{ 
			throw new NotImplementedException(); 
		}        
		
		#endregion Object Overrides
    }
}
