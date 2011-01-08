#region License

/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.

Authors: 
-Rob Loach (http://www.robloach.net)
-Lars Magnusson (lavima)

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
using Tao.DevIl;
using Tao.Sdl;

namespace Microsoft.Xna.Framework.Graphics
{
    public class GraphicsDevice : IDisposable
    {
        #region Private Fields		
		
        private GraphicsDeviceCapabilities graphicsDeviceCapabilities;
        private GraphicsAdapter adapter;
        private DeviceType deviceType;
        private IntPtr renderWindowHandle;
        private PresentationParameters presentationParameters;
        private bool isDisposed;
        private TextureCollection textures;
		private Color clearColor;
		private Viewport viewport;
		
		private RenderTarget[] renderTargets;
		private int frameBufferIdentifier;
		private int numActiveRenderTargets;
		
        #endregion Private Fields
		
		#region Public Properties
		
		public ClipPlaneCollection ClipPlanes {
            get { throw new NotImplementedException(); }
        }

        public GraphicsDeviceCreationParameters CreationParameters {
            get { throw new NotImplementedException(); }
        }

        public DepthStencilBuffer DepthStencilBuffer {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public DisplayMode DisplayMode {
            get { throw new NotImplementedException(); }
        }

        public int DriverLevel {
            get { throw new NotImplementedException(); }
        }

        public GraphicsDeviceCapabilities GraphicsDeviceCapabilities {
            get { return graphicsDeviceCapabilities; }
        }

        public GraphicsDeviceStatus GraphicsDeviceStatus {
            get { return GraphicsDeviceStatus.Normal; }
        }

        public IndexBuffer Indices {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool IsDisposed {
            get { return isDisposed; }
        }

        public PixelShader PixelShader {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public PresentationParameters PresentationParameters {
            get { return presentationParameters; }
			private set { 
				presentationParameters = value;
				setPresentationParameters();
			}
        }

        public RasterStatus RasterStatus {
            get { throw new NotImplementedException(); }
        }

        public RenderState RenderState {
            get { throw new NotImplementedException(); }
        }

        public SamplerStateCollection SamplerStates {
            get { throw new NotImplementedException(); }
        }

        public Rectangle ScissorRectangle {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool SoftwareVertexProcessing {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public TextureCollection Textures {
            get { return textures; }
        }

        public VertexDeclaration VertexDeclaration {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public SamplerStateCollection VertexSamplerStates {
            get { throw new NotImplementedException(); }
        }

        public VertexShader VertexShader {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public TextureCollection VertexTextures {
            get { throw new NotImplementedException(); }
        }

        public VertexStreamCollection Vertices {
            get { throw new NotImplementedException(); }
        }

        public Viewport Viewport {
            get { return viewport; }
            set {
				viewport = value;
                Gl.glViewport(viewport.X, viewport.Y, viewport.Width, viewport.Height);
            }
        }
		
		#endregion Public Properties
		
		#region Events

        public event EventHandler DeviceLost;

        public event EventHandler DeviceReset;

        public event EventHandler DeviceResetting;

        public event EventHandler Disposing;

        public event EventHandler<ResourceCreatedEventArgs> ResourceCreated;

        public event EventHandler<ResourceDestroyedEventArgs> ResourceDestroyed;		
		
		#endregion Events
		
        #region Operators

        public static bool operator !=(GraphicsDevice left, GraphicsDevice right)
        {
            return !Equals(left, right);
        }

        public static bool operator ==(GraphicsDevice left, GraphicsDevice right)
        {
            return Equals(left, right);
        }
		
		#endregion Operators       

		#region Constructors

        public GraphicsDevice(GraphicsAdapter adapter, DeviceType deviceType, IntPtr renderWindowHandle, PresentationParameters presentationParameters)
        {
			if (adapter == null || presentationParameters == null) 
				throw new ArgumentNullException("adapter or presentationParameters is null.");
            
			graphicsDeviceCapabilities = adapter.GetCapabilities(deviceType);
			numActiveRenderTargets = 0;
			renderTargets = new RenderTarget[graphicsDeviceCapabilities.MaxSimultaneousRenderTargets];
			initGL();
			
			this.adapter = adapter;
			this.deviceType = deviceType;
            this.renderWindowHandle = renderWindowHandle;
			PresentationParameters = presentationParameters; // set through property to ensure OpenGL propagation
            
			this.textures = new TextureCollection();
			this.clearColor = Color.Black;			
        }

        ~GraphicsDevice()
        {
            Dispose(false);
        }

        #endregion Constructors
		
		#region Public Methods

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
		
		public void Clear(Color color)
        {
            if (color != clearColor)
            {
				Gl.glClearColor((float)color.R/255f, (float)color.G/255f, (float)color.B/255f, (float)color.A/255f);
                clearColor = color;
            }
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glLoadIdentity();
        }

        public void Clear(ClearOptions options, Color color, float depth, int stencil)
        {
            throw new NotImplementedException();
        }

        public void Clear(ClearOptions options, Vector4 color, float depth, int stencil)
        {
            throw new NotImplementedException();
        }

        public void Clear(ClearOptions options, Color color, float depth, int stencil, Rectangle[] regions)
        {
            throw new NotImplementedException();
        }

        public void Clear(ClearOptions options, Vector4 color, float depth, int stencil, Rectangle[] regions)
        {
            throw new NotImplementedException();
        }

        public void DrawIndexedPrimitives(PrimitiveType primitiveType, int baseVertex, int minVertexIndex,
                                          int numVertices, int startIndex, int primitiveCount)
        {
            throw new NotImplementedException();
        }

        public void DrawPrimitives(PrimitiveType primitiveType, int startVertex, int primitiveCount)
        {
            throw new NotImplementedException();
        }

        public void DrawUserIndexedPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset,
                                                 int numVertices, int[] indexData, int indexOffset, int primitiveCount)
        {
            throw new NotImplementedException();
        }

        public void DrawUserIndexedPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset,
                                                 int numVertices, short[] indexData, int indexOffset, int primitiveCount)
        {
            throw new NotImplementedException();
        }

        public void DrawUserPrimitives<T>(PrimitiveType primitiveType, T[] vertexData, int vertexOffset, int primitiveCount)
        {
            throw new NotImplementedException();
        }

        public void EvictManagedResources()
        {
            throw new NotImplementedException();
        }

        public GammaRamp GetGammaRamp()
        {
            throw new NotImplementedException();
        }

        public bool[] GetPixelShaderBooleanConstant(int startRegister, int constantCount)
        {
            throw new NotImplementedException();
        }

        public int[] GetPixelShaderInt32Constant(int startRegister, int constantCount)
        {
            throw new NotImplementedException();
        }

        public float[] GetPixelShaderSingleConstant(int startRegister, int constantCount)
        {
            throw new NotImplementedException();
        }

        public RenderTarget GetRenderTarget(int renderTargetIndex)
        {
            throw new NotImplementedException();
        }

        public bool[] GetVertexShaderBooleanConstant(int startRegister, int constantCount)
        {
            throw new NotImplementedException();
        }

        public int[] GetVertexShaderInt32Constant(int startRegister, int constantCount)
        {
            throw new NotImplementedException();
        }

        public float[] GetVertexShaderSingleConstant(int startRegister, int constantCount)
        {
            throw new NotImplementedException();
        }

        public void Present()
        {
            Sdl.SDL_GL_SwapBuffers();
        }

        public void Present(IntPtr overrideWindowHandle)
        {
            throw new NotImplementedException();
        }

        public void Present(Rectangle? sourceRectangle, Rectangle? destinationRectangle, IntPtr overrideWindowHandle)
        {
            throw new NotImplementedException();
        }
		
		public void Reset()
        {
            Reset(PresentationParameters);
        }

        public void Reset(PresentationParameters presentationParameters)
        {
            raise_DeviceResetting(this, EventArgs.Empty);
			PresentationParameters = presentationParameters;
			raise_DeviceReset(this, EventArgs.Empty);
        }

        public void SetGammaRamp(bool calibrate, GammaRamp ramp)
        {
            throw new NotImplementedException();
        }

        public void SetPixelShaderConstant(int startRegister, bool[] constantData)
        {
            throw new NotImplementedException();
        }

        public void SetPixelShaderConstant(int startRegister, float[] constantData)
        {
            throw new NotImplementedException();
        }

        public void SetPixelShaderConstant(int startRegister, int[] constantData)
        {
            throw new NotImplementedException();
        }

        public void SetPixelShaderConstant(int startRegister, Matrix constantData)
        {
            throw new NotImplementedException();
        }

        public void SetPixelShaderConstant(int startRegister, Matrix[] constantData)
        {
            throw new NotImplementedException();
        }

        public void SetPixelShaderConstant(int startRegister, Vector4 constantData)
        {
            throw new NotImplementedException();
        }

        public void SetPixelShaderConstant(int startRegister, Vector4[] constantData)
        {
            throw new NotImplementedException();
        }

        public void SetRenderTarget(int renderTargetIndex, RenderTarget2D renderTarget)
        {
            if (renderTargetIndex < 0 || renderTargetIndex >= renderTargets.Length)
				throw new ArgumentOutOfRangeException("The specified index must be within the supported range.");
			
			Gl.glBindFramebufferEXT(Gl.GL_FRAMEBUFFER_EXT, frameBufferIdentifier);
			
			if (renderTarget == null)
			{
				// Detach the texture and depth buffer
				Gl.glFramebufferTexture2DEXT(Gl.GL_FRAMEBUFFER_EXT, getColorAttachment(renderTargetIndex), 
				                             Gl.GL_TEXTURE_2D, 0, 0);
				Gl.glFramebufferRenderbufferEXT(Gl.GL_FRAMEBUFFER_EXT, Gl.GL_DEPTH_ATTACHMENT_EXT,
				                                Gl.GL_RENDERBUFFER_EXT, 0);
				
				renderTargets[renderTargetIndex] = null;
				
				// Deactivate the frame buffer when no more targets are connected.
				if (--numActiveRenderTargets == 0)
					Gl.glBindFramebufferEXT(Gl.GL_FRAMEBUFFER_EXT, 0);
				
				return;
			}
			
			if (renderTarget.IsDisposed)
				throw new ObjectDisposedException("SetRenderTarget is called after the render target has been disposed.");
			
			// Connect texture and depth buffer
			Gl.glFramebufferTexture2DEXT(Gl.GL_FRAMEBUFFER_EXT, getColorAttachment(renderTargetIndex), Gl.GL_TEXTURE_2D, 
				                             renderTarget.GetTexture().textureId, 0);
			Gl.glFramebufferRenderbufferEXT(Gl.GL_FRAMEBUFFER_EXT, Gl.GL_DEPTH_ATTACHMENT_EXT, 
			                                Gl.GL_RENDERBUFFER_EXT, renderTarget.renderBufferIdentifier);
			
			numActiveRenderTargets++;
			
			int status = Gl.glCheckFramebufferStatusEXT(Gl.GL_FRAMEBUFFER_EXT);
			if (status != Gl.GL_FRAMEBUFFER_COMPLETE_EXT)
				throw new Exception("This should not occur.");
			
			// Leave framebuffer active
        }

        public void SetRenderTarget(int renderTargetIndex, RenderTargetCube renderTarget, CubeMapFace faceType)
        {
            throw new NotImplementedException();
        }

        public void SetVertexShaderConstant(int startRegister, bool[] constantData)
        {
            throw new NotImplementedException();
        }

        public void SetVertexShaderConstant(int startRegister, float[] constantData)
        {
            throw new NotImplementedException();
        }

        public void SetVertexShaderConstant(int startRegister, int[] constantData)
        {
            throw new NotImplementedException();
        }

        public void SetVertexShaderConstant(int startRegister, Matrix constantData)
        {
            throw new NotImplementedException();
        }

        public void SetVertexShaderConstant(int startRegister, Matrix[] constantData)
        {
            throw new NotImplementedException();
        }

        public void SetVertexShaderConstant(int startRegister, Vector4 constantData)
        {
            throw new NotImplementedException();
        }

        public void SetVertexShaderConstant(int startRegister, Vector4[] constantData)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
		
		#endregion Public Methods
		
		#region Protected Methods

        protected virtual void Dispose(bool disposeManaged)
        {
            if (!isDisposed)
            {
                if (disposeManaged)                   
                    textures.Dispose();
                
				// Dispose Unmanaged resources
				finishGL();

                isDisposed = true;
            }
        }
		
		protected void raise_DeviceLost(object sender, EventArgs e)
        {
            if (DeviceLost != null)
                DeviceLost(sender, e);
        }

        protected void raise_DeviceReset(object sender, EventArgs e)
        {
            if (DeviceReset != null)
                DeviceReset(sender, e);
        }

        protected void raise_DeviceResetting(object sender, EventArgs e)
        {
            if (DeviceResetting != null)
                DeviceResetting(sender, e);
        }

        protected void raise_Disposing(object sender, EventArgs e)
        {
            if (Disposing != null)
                Disposing(sender, e);
        }

        protected void raise_ResourceCreated(object sender, ResourceCreatedEventArgs e)
        {
            if (ResourceCreated != null)
                ResourceCreated(sender, e);
        }

        protected void raise_ResourceDestroyed(object sender, ResourceDestroyedEventArgs e)
        {
            if (ResourceDestroyed != null)
                ResourceDestroyed(sender, e);
        }
		
		#endregion Protected Methods

		#region Private Methods
		
		private void initGL()
		{
			Gl.glGenFramebuffersEXT(1, out frameBufferIdentifier);
		}
		
		private void finishGL()
		{
			Gl.glDeleteFramebuffersEXT(1, ref frameBufferIdentifier);
		}
		
		private void setPresentationParameters()
		{
			this.viewport.X = 0; 
			this.viewport.Y = 0;
			this.viewport.Width = presentationParameters.BackBufferWidth;
			this.viewport.Height = presentationParameters.BackBufferHeight;
            
			// Setup the SDL's OpenGL interface based on the attributes specified TODO
			
			if (presentationParameters.BackBufferFormat == SurfaceFormat.Color || 
			    presentationParameters.BackBufferFormat == SurfaceFormat.Bgr32 ||
			    presentationParameters.BackBufferFormat == SurfaceFormat.Rgba32)
			{
				Sdl.SDL_GL_SetAttribute(Sdl.SDL_GL_RED_SIZE, 8);
				Sdl.SDL_GL_SetAttribute(Sdl.SDL_GL_GREEN_SIZE, 8);
				Sdl.SDL_GL_SetAttribute(Sdl.SDL_GL_BLUE_SIZE, 8);
				Sdl.SDL_GL_SetAttribute(Sdl.SDL_GL_ALPHA_SIZE, 8);
			}
			
			if (presentationParameters.EnableAutoDepthStencil)
			{
				if (presentationParameters.AutoDepthStencilFormat == DepthFormat.Depth16)
					Sdl.SDL_GL_SetAttribute(Sdl.SDL_GL_DEPTH_SIZE, 16);
			}
			
			if (presentationParameters.BackBufferCount > 0)
				Sdl.SDL_GL_SetAttribute(Sdl.SDL_GL_DOUBLEBUFFER, 1); // multiple back buffers not supported in SDL 1.2	
			
			
			//Sdl.SDL_GL_SetAttribute(Sdl.SDL_GL_SWAP_CONTROL, 0);
		}
		
		private int getColorAttachment(int index)
		{
			if (index < 0 || index > GraphicsDeviceCapabilities.MaxSimultaneousRenderTargets)
				throw new NotSupportedException("The index is out of range.");
			
			if (index == 0)
				return Gl.GL_COLOR_ATTACHMENT0_EXT;
			else if (index == 1)
				return Gl.GL_COLOR_ATTACHMENT1_EXT;
			else if (index == 2)
				return Gl.GL_COLOR_ATTACHMENT2_EXT;
			else if (index == 3)
				return Gl.GL_COLOR_ATTACHMENT3_EXT;
			else if (index == 4)
				return Gl.GL_COLOR_ATTACHMENT4_EXT;
			else if (index == 5)
				return Gl.GL_COLOR_ATTACHMENT5_EXT;
			else if (index == 6)
				return Gl.GL_COLOR_ATTACHMENT6_EXT;
			else if (index == 7)
				return Gl.GL_COLOR_ATTACHMENT7_EXT;
			else if (index == 8)
				return Gl.GL_COLOR_ATTACHMENT8_EXT;
			else if (index == 9)
				return Gl.GL_COLOR_ATTACHMENT9_EXT;
			else if (index == 10)
				return Gl.GL_COLOR_ATTACHMENT10_EXT;
			else if (index == 11)
				return Gl.GL_COLOR_ATTACHMENT11_EXT;
			else if (index == 12)
				return Gl.GL_COLOR_ATTACHMENT12_EXT;
			else if (index == 13)
				return Gl.GL_COLOR_ATTACHMENT13_EXT;
			else if (index == 14)
				return Gl.GL_COLOR_ATTACHMENT14_EXT;
			else 
				return Gl.GL_COLOR_ATTACHMENT15_EXT;
		}
		
		#endregion Private Methods
		
    }
}