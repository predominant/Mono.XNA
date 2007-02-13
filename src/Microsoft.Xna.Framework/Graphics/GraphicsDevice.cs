#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team
http://www.taoframework.com
All rights reserved.

Authors: Rob Loach (http://www.robloach.net)

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
using Tao.OpenGl;
using SdlDotNet;
using SdlDotNet.Graphics;

namespace Microsoft.Xna.Framework.Graphics
{

    public class GraphicsDevice : IDisposable
    {

        public GraphicsDevice(GraphicsAdapter adapter, DeviceType deviceType, IntPtr renderWindowHandle, CreateOptions creationOptions, PresentationParameters presentationParameters)
        {
            this.adapter = adapter;
            this.deviceType = deviceType;
            this.renderWindowHandle = renderWindowHandle;
            this.creationOptions = creationOptions;
            this.presentationParameters = presentationParameters;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.isDisposed)
            {
                if (disposing)
                {
                    // Dispose managed resources
                    textures.Dispose();
                }

                // Dispose Unmanaged resources

                this.isDisposed = true;
            }
        }

        ~GraphicsDevice()
        {
            Dispose(false);
        }

        public static bool operator !=(GraphicsDevice left, GraphicsDevice right)
        {
            return !object.Equals(left, right);
        }

        public static bool operator ==(GraphicsDevice left, GraphicsDevice right)
        {
            return object.Equals(left, right);
        }

        public ClipPlaneCollection ClipPlanes
        {
            get { throw new NotImplementedException(); }
        }

        public GraphicsDeviceCreationParameters CreationParameters
        {
            get { throw new NotImplementedException(); }
        }

        public DepthStencilBuffer DepthStencilBuffer
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public DisplayMode DisplayMode
        {
            get { throw new NotImplementedException(); }
        }

        public int DriverLevel
        {
            get { throw new NotImplementedException(); }
        }

        public GraphicsDeviceCapabilities GraphicsDeviceCapabilities
        {
            get { throw new NotImplementedException(); }
        }

        public GraphicsDeviceStatus GraphicsDeviceStatus
        {
            get
            {
                // TODO: See if the device actually needs restarting.
                return GraphicsDeviceStatus.Normal;
            }
        }

        public IndexBuffer Indices
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool IsDisposed
        {
            get { throw new NotImplementedException(); }
        }

        public PixelShader PixelShader
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public PresentationParameters PresentationParameters
        {
            get { throw new NotImplementedException(); }
        }

        public RasterStatus RasterStatus
        {
            get { throw new NotImplementedException(); }
        }

        public RenderState RenderState
        {
            get { throw new NotImplementedException(); }
        }

        public SamplerStateCollection SamplerStates { get { throw new NotImplementedException(); } }

        public Rectangle ScissorRectangle
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool SoftwareVertexProcessing
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public TextureCollection Textures
        {
            get { return textures; }
        }

        public VertexDeclaration VertexDeclaration
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public SamplerStateCollection VertexSamplerStates
        {
            get { throw new NotImplementedException(); }
        }

        public VertexShader VertexShader
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public TextureCollection VertexTextures
        {
            get { throw new NotImplementedException(); }
        }

        public VertexStreamCollection Vertices
        {
            get { throw new NotImplementedException(); }
        }

        public Viewport Viewport
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }


        public event EventHandler DeviceLost;

        public event EventHandler DeviceReset;

        public event EventHandler DeviceResetting;

        public event EventHandler Disposing;

        public event EventHandler<ResourceCreatedEventArgs> ResourceCreated;

        public event EventHandler<ResourceDestroyedEventArgs> ResourceDestroyed;


        public void Clear(Color color)
        {
            if (color != clearColor)
            {
                Gl.glClearColor((float)color.R / 255f, (float)color.G / 255f, (float)color.B / 255f, (float)color.A / 255f);
                clearColor = color;
            }
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
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

        public override bool Equals(object obj)
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

        public override int GetHashCode()
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
            Video.GLSwapBuffers();
        }

        public void Present(IntPtr overrideWindowHandle)
        {
            throw new NotImplementedException();
        }

        public void Present(Rectangle? sourceRectangle, Rectangle? destinationRectangle, IntPtr overrideWindowHandle)
        {
            throw new NotImplementedException();
        }

        protected void raise_DeviceLost(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void raise_DeviceReset(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void raise_DeviceResetting(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void raise_Disposing(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void raise_ResourceCreated(object sender, ResourceCreatedEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void raise_ResourceDestroyed(object sender, ResourceDestroyedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Reset(PresentationParameters presentationParameters)
        {
            throw new NotImplementedException();
        }

        public void ResolveBackBuffer(Texture2D resolveTarget)
        {
            throw new NotImplementedException();
        }

        public void ResolveBackBuffer(Texture2D resolveTarget, int backBufferIndex)
        {
            throw new NotImplementedException();
        }

        public void ResolveRenderTarget(int index)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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

        private GraphicsAdapter adapter;
        private DeviceType deviceType;
        private IntPtr renderWindowHandle;
        private CreateOptions creationOptions;
        private PresentationParameters presentationParameters;
        private bool isDisposed;
        private TextureCollection textures = new TextureCollection();
        private Color clearColor = Color.Black;
    }
}
