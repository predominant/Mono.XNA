#region License
/*
MIT License
Copyright © 2006 - 2007 The Mono.Xna Team

All rights reserved.

Authors:
 * Rob Loach
 * Dave Hudson
 * Olivier Dufour (Duff)

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
using System.Drawing;
using Tao.OpenGl;
using Tao.DevIl;

namespace Microsoft.Xna.Framework.Graphics
{
    public class Texture2D : Texture
    {
        #region Fields

        private GraphicsDevice device;
        private int height;                                         // The height of the texture before resizing it
        private bool isDisposed;                                    // True when the texture has been disposed
        private int numberOfLevels;                                 // The number of mip levels for the texture
        private TextureUsage textureUsage;
        private SurfaceFormat surfaceFormat;                        // The colour format of the texture
        private int width;                                          // the width of the texture before resizing it

        internal int textureId = -1;                                // The reference ID of the texture in OpenGL memory
		internal int imageId;

        #endregion Fields

        #region Properties

        public int Width {
            get { return this.width; }
        }

        public int Height {
            get { return this.height; }
        }

        public SurfaceFormat Format {
            get { return this.surfaceFormat; }
        }

        public TextureUsage TextureUsage
        {
            get { return this.textureUsage; }
        }

        #endregion Properties

        #region Constructors

        /*FamANDAssem*/
        protected internal Texture2D()
        {
        }

        public Texture2D(GraphicsDevice graphicsDevice, int width, int height)
			: this(graphicsDevice, width, height, 1, TextureUsage.None, SurfaceFormat.Color)
		{
        }       

        public Texture2D(GraphicsDevice graphicsDevice, int width, int height, int numberLevels, 
		                 TextureUsage usage, SurfaceFormat format)
        {
            this.device = graphicsDevice;
            this.width = width;
            this.height = height;
            this.numberOfLevels = numberLevels;
            this.textureUsage = usage;
            this.surfaceFormat = format;
			
			initGL();
        }

        #endregion Constructors

        #region Static Methods

        public new static Texture2D FromFile(GraphicsDevice graphicsDevice, Stream textureStream)
        {
            return (Texture2D)Texture.FromFile(graphicsDevice, textureStream, -1);
        }
		
		public new static Texture2D FromFile(GraphicsDevice graphicsDevice, Stream textureStream, 
		                                     TextureCreationParameters creationParameters)
        {
            return (Texture2D)Texture.FromFile(graphicsDevice, textureStream, -1, creationParameters);
        }
		
		public new static Texture2D FromFile(GraphicsDevice graphicsDevice, Stream textureStream, int numberBytes)
        {
            return (Texture2D)Texture.FromFile(graphicsDevice, textureStream, numberBytes);
        }
		
		public new static Texture2D FromFile(GraphicsDevice graphicsDevice, Stream textureStream, int numberBytes, 
		                                     TextureCreationParameters creationParameters)
        {
            return (Texture2D)Texture.FromFile(graphicsDevice, textureStream, numberBytes, creationParameters);
        }

        public new static Texture2D FromFile(GraphicsDevice graphicsDevice, string filename)
        {
            return (Texture2D)Texture.FromFile(graphicsDevice, filename);
        }
		
        public new static Texture2D FromFile(GraphicsDevice graphicsDevice, string filename, 
		                                     TextureCreationParameters creationParameters)
        {
            return (Texture2D)Texture.FromFile(graphicsDevice, filename, creationParameters);
        }

        public new static Texture2D FromFile(GraphicsDevice graphicsDevice, string filename, int width, int height)
        {
            return (Texture2D)Texture.FromFile(graphicsDevice, filename, width, height, 0);
        }
		
        #endregion Static Methods

        #region Public Methods

        public void GetData<T>(T[] data)
        {
            throw new NotImplementedException("The method or operation is not implemented.");
        }

        public void GetData<T>(T[] data, int startIndex, int elementCount)
        {
            throw new NotImplementedException("The method or operation is not implemented.");
        }

        public void GetData<T>(int level, Nullable<Rectangle> rect, T[] data, int startIndex, int elementCount)
        {
            throw new NotImplementedException("The method or operation is not implemented.");
        }

        public void SetData<T>(T[] data)
        {
            Rectangle? rect = null;
            this.SetData<T>(0, rect, data, 0, data.Length, SetDataOptions.None);
        }

        public void SetData<T>(T[] data, int startIndex, int elementCount, SetDataOptions options)
        {
            Rectangle? rect = null;
            this.SetData<T>(0, rect, data, startIndex, elementCount, options);
        }

        public void SetData<T>(int level, Nullable<Rectangle> rect, T[] data, int startIndex, int elementCount, 
		                       SetDataOptions options)
        {
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureId);	
            switch (this.surfaceFormat)
            {
                case SurfaceFormat.Color:
                    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, level, Gl.GL_RGBA8, this.width, this.height, 0, 
				                Gl.GL_BGRA, Gl.GL_UNSIGNED_BYTE, data);
                    break;
                case SurfaceFormat.Dxt1:
                    Gl.glCompressedTexImage2D(Gl.GL_TEXTURE_2D, level, Gl.GL_COMPRESSED_RGBA_S3TC_DXT1_EXT, 
				                          this.width, this.height, 0, elementCount, data);
                    break;
                case SurfaceFormat.Dxt3:
                    Gl.glCompressedTexImage2D(Gl.GL_TEXTURE_2D, level, Gl.GL_COMPRESSED_RGBA_S3TC_DXT3_EXT, 
				                          this.width, this.height, 0, elementCount, data);
                    break;
                case SurfaceFormat.Dxt5:
                    Gl.glCompressedTexImage2D(Gl.GL_TEXTURE_2D, level, Gl.GL_COMPRESSED_RGBA_S3TC_DXT5_EXT, 
				                          this.width, this.height, 0, elementCount, data);
                    break;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!this.isDisposed)
            {
                if (disposing)
                {
                    // dispose managed objects
                }
                // dispose unmanged objects
                try
                {
                    Gl.glDeleteTextures(1, new int[] { textureId });
                    System.Diagnostics.Debug.WriteLine("Destroyed texture " + this.ToString() + " #" + textureId);
                }
                catch
                {
                    // If an exception is thrown, it's because either the texture failed to
                    // load, or because the OpenGL context already erased it from memory.
                    System.Diagnostics.Debug.WriteLine("Failed to destroy texture " + this.ToString() + " #" + textureId);
                }
                finally
                {
                    if (device != null)
                        if (device.Textures.textures.Contains(this))
                            device.Textures.textures.Remove(this);
                }
            }
            this.isDisposed = true;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        #endregion Public Methods

        #region Private Methods
		
		private void initGL()
		{
			Gl.glGenTextures(1, out textureId);
			
			Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureId);
			Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
			Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);
		}

        #endregion Private Methods
		
		#region OLDCODE
        /*
        private Texture2D(GraphicsDevice graphicsDevice)
        {
            this.device = graphicsDevice;
        }
        
        public Texture2D(GraphicsDevice graphicsDevice, int width, int height, int numberLevels, ResourceUsage usage, SurfaceFormat format)
            : this(graphicsDevice, width, height, numberLevels, usage, format, ResourceManagementMode.Automatic)
        {
        }

        public Texture2D(GraphicsDevice graphicsDevice, int width, int height, int numberLevels, ResourceUsage usage, SurfaceFormat format, ResourceManagementMode resourceManagementMode)
        {
            this.device = graphicsDevice;
            this.width = width;
            this.height = height;
            this.numberOfLevels = numberLevels;
            this.resourceUsage = usage;
            this.surfaceFormat = format;
            this.resourceManagementMode = resourceManagementMode;
        }
        
        private void Load(byte[] buffer)
        {	
			imageId = Il.ilGenImage ();
			Il.ilBindImage (imageId);
			Il.ilLoadL (Il.IL_JPG, buffer, buffer.Length);
			
			int[] texture = new int[1];
			Gl.glGenTextures(1, texture);
			textureId = texture[0];
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureId);			
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Il.ilGetInteger (Il.IL_IMAGE_BYTES_PER_PIXEL), 
			                this.width, this.height, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, Il.ilGetData ());			
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
        }
        */
        #endregion
    }
}
