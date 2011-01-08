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
using Tao.OpenGl;

namespace Microsoft.Xna.Framework.Graphics
{
    public class RenderTarget2D : RenderTarget
    {
		#region Fields
		
		private Texture2D texture;
		private int renderBufferObjectIdentifier;
		
		#endregion Fields
		
		#region Constructors
		
        public RenderTarget2D(GraphicsDevice graphicsDevice, int width, int height, int numberLevels, SurfaceFormat format)
			: this(graphicsDevice, width, height, numberLevels, format, 
			       MultiSampleType.None, 0, RenderTargetUsage.DiscardContents) { }

        public RenderTarget2D(GraphicsDevice graphicsDevice, int width, int height, int numberLevels, 
		                      SurfaceFormat format, MultiSampleType multiSampleType, int multiSampleQuality)
			: this(graphicsDevice, width, height, numberLevels, format, multiSampleType, multiSampleQuality, 
			       RenderTargetUsage.DiscardContents) { }
			
		public RenderTarget2D(GraphicsDevice graphicsDevice, int width, int height, int numberLevels, 
		                      SurfaceFormat format, RenderTargetUsage usage)
			: this(graphicsDevice, width, height, numberLevels, format, MultiSampleType.None, 0, usage) { }
		
        public RenderTarget2D(GraphicsDevice graphicsDevice, int width, int height, int numberLevels, SurfaceFormat format,
                              MultiSampleType multiSampleType, int multiSampleQuality, RenderTargetUsage usage)
        {
            this.graphicsDevice = graphicsDevice;
			this.width = width;
			this.height = height;
			this.multiSampleType = multiSampleType;
			this.multiSampleQuality = multiSampleQuality;
			this.renderTargetUsage = usage;
			this.numLevels = numberLevels;
			
			texture = new Texture2D(graphicsDevice, width, height, numberLevels, TextureUsage.None, format);
			
			initGL();
        }
		
		#endregion Constructors
		
		#region Methods
		
		public Texture2D GetTexture()
        {
            return texture;
        }
		
		private void initGL()
		{
			// Allocate the space needed for the texture
			Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture.textureId);
			Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA8, width, height, 0, Gl.GL_BGRA, 
			                Gl.GL_UNSIGNED_BYTE, null);
			Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);
			
			// Create the render buffer that will hold depth information.
			Gl.glGenRenderbuffersEXT(1, out renderBufferObjectIdentifier);
			Gl.glBindRenderbufferEXT(Gl.GL_RENDERBUFFER_EXT, renderBufferObjectIdentifier);
			Gl.glRenderbufferStorageEXT(Gl.GL_RENDERBUFFER_EXT, Gl.GL_DEPTH_COMPONENT, width, height);
			Gl.glBindRenderbufferEXT(Gl.GL_RENDERBUFFER_EXT, 0);
		}
		
		private void finishGL()
		{
			Gl.glDeleteRenderbuffersEXT(1, ref renderBufferObjectIdentifier);
		}
		
		#endregion Methods
		
		#region RenderTarget Overrides
		
		protected override void Dispose (bool disposeManaged)
		{
			if (!IsDisposed)
			{
				if (!disposeManaged)
					finishGL();
			}
			base.Dispose (disposeManaged);
		}
		
		#endregion RenderTarget Overrides
	}
}