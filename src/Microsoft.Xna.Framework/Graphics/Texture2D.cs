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
        private ResourceManagementMode resourceManagementMode;      // The currently active management mode 
        private ResourceUsage resourceUsage;                        // The currently active usage mode
        private SurfaceFormat surfaceFormat;                        // The colour format of the texture
        private int width;                                          // the width of the texture before resizing it

        internal int textureId = -1;                                     // The reference ID of the texture in OpenGL memory
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

        public ResourceManagementMode ResourceManagementMode {
            get { return this.resourceManagementMode; }
        }

        public ResourceUsage ResourceUsage {
            get { return this.resourceUsage; }
        }

        #endregion Properties

        #region Constructors

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

        public Texture2D(GraphicsDevice graphicsDevice, int width, int height, int numberLevels, TextureUsage usage, SurfaceFormat format)
        {
        }

        #endregion Constructors

        #region Static Methods

        public new static Texture2D FromFile(GraphicsDevice graphicsDevice, Stream textureStream)
        {
			throw new NotImplementedException("The method or operation is not implemented.");
        }
		
		public new static Texture2D FromFile(GraphicsDevice graphicsDevice, Stream textureStream, TextureCreationParameters creationParameters)
        {
            throw new NotImplementedException("The method or operation is not implemented.");
        }
		
		public new static Texture2D FromFile(GraphicsDevice graphicsDevice, Stream textureStream, int numberBytes)
        {
            throw new NotImplementedException("The method or operation is not implemented.");
        }
		
		public new static Texture2D FromFile(GraphicsDevice graphicsDevice, Stream textureStream, int numberBytes, TextureCreationParameters creationParameters)
        {
            throw new NotImplementedException("The method or operation is not implemented.");
        }

        public new static Texture2D FromFile(GraphicsDevice graphicsDevice, string filename)
        {
            throw new NotImplementedException("The method or operation is not implemented.");
        }
		
        public new static Texture2D FromFile(GraphicsDevice graphicsDevice, string filename, TextureCreationParameters creationParameters)
        {
            int ImgID;
            Il.ilGenImages(1, out ImgID);
            Il.ilBindImage(ImgID);
            Il.ilLoadImage(filename);
            int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
            int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);
            int depth = Il.ilGetInteger(Il.IL_IMAGE_DEPTH);
            int size = Il.ilGetInteger(Il.IL_IMAGE_SIZE_OF_DATA);
            IntPtr pixmap = new IntPtr() ;
            pixmap = Il.ilGetData();
            byte[] pixdata = new byte[size];
            System.Runtime.InteropServices.Marshal.Copy(pixmap, pixdata, 0, size);
            Il.ilBindImage(0);
            //Il.ilDeleteImage(0);
            Texture2D tex = new Texture2D(graphicsDevice, width, height, depth, creationParameters.ResourceUsage, SurfaceFormat.Rgb32, creationParameters.ResourceManagementMode);
            tex.Load(pixdata);
            return tex;
        }

        public new static Texture2D FromFile(GraphicsDevice graphicsDevice, string filename, int width, int height)
        {
            throw new NotImplementedException("The method or operation is not implemented.");
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

        public void SetData<T>(int level, Nullable<Rectangle> rect, T[] data, int startIndex, int elementCount, SetDataOptions options)
        {
            if (textureId == -1)
            {
                int[] texture = new int[1];
                Gl.glGenTextures(1, texture);
                textureId = texture[0];
            }
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureId);	
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, 4, this.Width, this.Height, 0, Gl.GL_BGRA, Gl.GL_UNSIGNED_BYTE, data);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR); //FIXME: Have we to set these parameters ?
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
        }

        public static bool operator !=(Texture2D left, Texture2D right)
        {
            return !(left == right);
        }

        public static bool operator ==(Texture2D left, Texture2D right)
        {
            return object.Equals(left, right);
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

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Loads the texture data from a byte array.
        /// </summary>
        /// <param name="buffer">The byte array to load the texture data from.</param>
        private void Load(byte[] buffer)
        {	
        	imageId = Il.ilGenImage ();
			Il.ilBindImage (imageId);
			Il.ilLoadL (Il.IL_JPG, buffer, buffer.Length);
			
			int[] texture = new int[1];
			Gl.glGenTextures(1, texture);
			textureId = texture[0];
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureId);			
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Il.ilGetInteger (Il.IL_IMAGE_BYTES_PER_PIXEL), this.width, this.height, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, Il.ilGetData ());			
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
        }

        #endregion Private Methods
    }
}
