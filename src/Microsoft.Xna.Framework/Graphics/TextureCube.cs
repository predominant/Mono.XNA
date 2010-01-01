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

using Microsoft.Xna.Framework;
using System;
using System.IO;

namespace Microsoft.Xna.Framework.Graphics
{

    public class TextureCube : Texture
    {
		#region Constructor
		
		public TextureCube(GraphicsDevice graphicsDevice, int size, int numberLevels, TextureUsage usage, SurfaceFormat format)
		{
			
		}
		
		#endregion Constructor
		
		#region Properties
		
		public SurfaceFormat Format { 
			get { throw new NotImplementedException(); } 
		}

        public int Size { 
			get { throw new NotImplementedException(); } 
		}
		
		#endregion Properties
		
		#region Operators

        public static bool operator !=(TextureCube left, TextureCube right) { throw new NotImplementedException(); }

        public static bool operator ==(TextureCube left, TextureCube right) { throw new NotImplementedException(); }
		
		#endregion Operators 

		#region Public Methods

        public new static TextureCube FromFile(GraphicsDevice graphicsDevice, Stream textureStream) { throw new NotImplementedException(); }

        public new static TextureCube FromFile(GraphicsDevice graphicsDevice, string filename) { throw new NotImplementedException(); }

        public new static TextureCube FromFile(GraphicsDevice graphicsDevice, Stream textureStream, int numberBytes) { throw new NotImplementedException(); }

        public new static TextureCube FromFile(GraphicsDevice graphicsDevice, Stream textureStream, TextureCreationParameters creationParameters) { throw new NotImplementedException(); }

        public new static TextureCube FromFile(GraphicsDevice graphicsDevice, string filename, int size) { throw new NotImplementedException(); }

        public new static TextureCube FromFile(GraphicsDevice graphicsDevice, string filename, TextureCreationParameters creationParameters) { throw new NotImplementedException(); }

        public new static TextureCube FromFile(GraphicsDevice graphicsDevice, Stream textureStream, int numberBytes, TextureCreationParameters creationParameters) { throw new NotImplementedException(); }

        public void GetData<T>(CubeMapFace faceType, T[] data) { throw new NotImplementedException(); }

        public void GetData<T>(CubeMapFace faceType, T[] data, int startIndex, int elementCount) { throw new NotImplementedException(); }

        public void GetData<T>(CubeMapFace faceType, int level, Rectangle? rect, T[] data, int startIndex, int elementCount) { throw new NotImplementedException(); }

        public override int GetHashCode() { throw new NotImplementedException(); }

        public void SetData<T>(CubeMapFace faceType, T[] data) { throw new NotImplementedException(); }

        public void SetData<T>(CubeMapFace faceType, T[] data, int startIndex, int elementCount, SetDataOptions options) { throw new NotImplementedException(); }

        public void SetData<T>(CubeMapFace faceType, int level, Rectangle? rect, T[] data, int startIndex, int elementCount, SetDataOptions options) { throw new NotImplementedException(); }
		
		#endregion Public Methods

		#region Texture Overrides
		
		protected override void Dispose(bool disposing) 
		{ 
			throw new NotImplementedException(); 
		}

		#endregion Texture Overrides
		
		#region Object Overrides
		
        public override string ToString() 
		{ 
			throw new NotImplementedException(); 
		}
		
		#endregion Object Overrides
    }
}
