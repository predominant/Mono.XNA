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
using SdlDotNet.Graphics;

namespace Microsoft.Xna.Framework.Graphics
{
    public class Texture2D : Texture
    {
        #region Private Fields

        private GraphicsDevice device;
        private int height;                                         // The height of the texture before resizing it
        private bool isDisposed;                                    // True when the texture has been disposed
        private int numberOfLevels;                                 // The number of mip levels for the texture
        private ResourceManagementMode resourceManagementMode;      // The currently active management mode 
        private ResourceUsage resourceUsage;                        // The currently active usage mode
        private SurfaceFormat surfaceFormat;                        // The colour format of the texture
        private int width;                                          // the width of the texture before resizing it

        #endregion Private Fields

        #region Internal Fields

        internal int textureWidth;                                  // The width of the texture in OpenGL memory
        internal int textureHeight;                                 // The height of the texture in OpenGL memory
        internal int textureID;                                     // The reference ID of the texture in OpenGL memory

        #endregion Internal Fields

        #region Public Properties

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

        #endregion Constructors

        #region Static Methods

        public new static Texture2D FromFile(GraphicsDevice graphicsDevice, Stream textureStream)
        {
			Texture2D texture = new Texture2D(graphicsDevice);
			
            byte[] data = new byte[textureStream.Length];
			textureStream.Read(data, 0, (int)textureStream.Length);
            texture.Load(data);
		
            graphicsDevice.Textures.textures.Add(texture);
            return texture;
        }


        public new static Texture2D FromFile(GraphicsDevice graphicsDevice, string filename)
        {
            EnsureDevice();
            Texture2D texture = new Texture2D(graphicsDevice);
            using (Surface surface = new Surface(filename))
            {
                texture.Load(surface);
            }
            graphicsDevice.Textures.textures.Add(texture);
            return texture;
        }


        public new static Texture2D FromFile(GraphicsDevice graphicsDevice, Stream textureStream, TextureCreationParameters creationParameters)
        {
            throw new NotImplementedException("The method or operation is not implemented.");
        }


        public new static Texture2D FromFile(GraphicsDevice graphicsDevice, Stream textureStream, int numberBytes)
        {
            throw new NotImplementedException("The method or operation is not implemented.");
        }


        public new static Texture2D FromFile(GraphicsDevice graphicsDevice, string filename, TextureCreationParameters creationParameters)
        {
            Texture2D output;
            using (FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
                output = FromFile(graphicsDevice, stream, creationParameters);
            return output;
        }


        public new static Texture2D FromFile(GraphicsDevice graphicsDevice, Stream textureStream, int numberBytes, TextureCreationParameters creationParameters)
        {
            // FIXME: Save the stuff from the constructor to the texture
            Texture2D texture = new Texture2D(graphicsDevice);

            texture.Load(textureStream,creationParameters.Width,creationParameters.Height);

            texture.height = creationParameters.Height;
            graphicsDevice.Textures.textures.Add(texture);
            return texture;
        }


        public new static Texture2D FromFile(GraphicsDevice graphicsDevice, string filename, int width, int height)
        {
            EnsureDevice();
            Texture2D texture = new Texture2D(graphicsDevice);
            Surface surface = new Surface(filename);
            if (surface.Size != new Size(width, height))
            {
                surface = surface.CreateStretchedSurface(new Size(width, height));
            }
            texture.Load(surface);
            graphicsDevice.Textures.textures.Add(texture);
            return texture;
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
            throw new NotImplementedException("The method or operation is not implemented.");
        }


        public void SetData<T>(T[] data, int startIndex, int elementCount, SetDataOptions options)
        {
            throw new NotImplementedException("The method or operation is not implemented.");
        }


        public void SetData<T>(int level, Nullable<Rectangle> rect, T[] data, int startIndex, int elementCount, SetDataOptions options)
        {
            throw new NotImplementedException("The method or operation is not implemented.");
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
                    Gl.glDeleteTextures(1, new int[] { textureID });
                    System.Diagnostics.Debug.WriteLine("Destroyed texture " + this.ToString() + " #" + textureID);
                }
                catch
                {
                    // If an exception is thrown, it's because either the texture failed to
                    // load, or because the OpenGL context already erased it from memory.
                    System.Diagnostics.Debug.WriteLine("Failed to destroy texture " + this.ToString() + " #" + textureID);
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
            EnsureDevice();			
            using (Surface surface = new Surface(buffer))
			{
				Load(surface);
				Console.WriteLine ("Test");
			}
			
        }

        /// <summary>
        /// Loads the texture data from a Stream.
        /// </summary>
        /// <param name="buffer">The Stream to load the texture data from.</param>
        private void Load(Stream buffer, int width, int height)
        {
            EnsureDevice();
            BinaryReader BR = new BinaryReader(buffer);

            Bitmap pic = new Bitmap(width, height);
            for(int i = 0;i < width ;i++)
            {
                for (int j = 0; j < height ; j++)
                {
                    System.Drawing.Color color = System.Drawing.Color.FromArgb(BR.ReadInt32());
                    pic.SetPixel(j, i, color);
                }
            }
           using (Surface surface = new Surface(pic))
               Load(surface);
        }

        /// <summary>
        /// Loads the texture data from an SDL Surface.
        /// </summary>
        /// <param name="surface">The surface to load data from.</param>
        private void Load(Surface surface)
        {			
            this.width = surface.Width;
			this.height = surface.Height;
            
			surface = surface.CreateFlippedVerticalSurface();
			
            //surface.Resize();
            this.textureWidth = surface.Width;
            this.textureHeight = surface.Height;
			Console.WriteLine ("Test");

            int[] texture = new int[1];
            Gl.glGenTextures(1, texture);
            textureID = texture[0];
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, textureID);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, surface.BytesPerPixel, this.textureWidth, this.textureHeight, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, surface.Pixels);

            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
        }

        /// <summary>
        /// Ensures that the device is initialized and ready to be used.
        /// </summary>
        private static void EnsureDevice()
        {
            if (!Video.IsInitialized)
                Video.Initialize();
        }

        #endregion Private Methods
    }
}
