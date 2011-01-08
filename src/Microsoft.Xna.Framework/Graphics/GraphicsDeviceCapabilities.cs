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

namespace Microsoft.Xna.Framework.Graphics
{
    public sealed partial class GraphicsDeviceCapabilities : IDisposable
    {
		#region Fields
		
		internal int maxSimultaneousRenderTargets;
		
		#endregion Fields
		
		#region Constructor
		
        ~GraphicsDeviceCapabilities()
        {
        }
		
		#endregion Constructor
		
		#region Properties

        public static bool operator !=(GraphicsDeviceCapabilities left, GraphicsDeviceCapabilities right)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(GraphicsDeviceCapabilities left, GraphicsDeviceCapabilities right)
        {
            throw new NotImplementedException();
        }

        public int AdapterOrdinalInGroup
        {
            get { throw new NotImplementedException(); }
        }

        public GraphicsDeviceCapabilities.CompareCaps AlphaCompareCapabilities
        {
            get { throw new NotImplementedException(); }
        }

        public GraphicsDeviceCapabilities.FilterCaps CubeTextureFilterCapabilities
        {
            get { throw new NotImplementedException(); }
        }

        public GraphicsDeviceCapabilities.CursorCaps CursorCapabilities
        {
            get { throw new NotImplementedException(); }
        }

        public GraphicsDeviceCapabilities.DeclarationTypeCaps DeclarationTypeCapabilities
        {
            get { throw new NotImplementedException(); }
        }

        public GraphicsDeviceCapabilities.CompareCaps DepthBufferCompareCapabilities
        {
            get { throw new NotImplementedException(); }
        }

        public GraphicsDeviceCapabilities.BlendCaps DestinationBlendCapabilities
        {
            get { throw new NotImplementedException(); }
        }

        public GraphicsDeviceCapabilities.DeviceCaps DeviceCapabilities
        {
            get { throw new NotImplementedException(); }
        }

        public DeviceType DeviceType
        {
            get { throw new NotImplementedException(); }
        }

        public GraphicsDeviceCapabilities.DriverCaps DriverCapabilities
        {
            get { throw new NotImplementedException(); }
        }

        public float ExtentsAdjust
        {
            get { throw new NotImplementedException(); }
        }

        public float GuardBandBottom
        {
            get { throw new NotImplementedException(); }
        }

        public float GuardBandLeft
        {
            get { throw new NotImplementedException(); }
        }

        public float GuardBandRight
        {
            get { throw new NotImplementedException(); }
        }

        public float GuardBandTop
        {
            get { throw new NotImplementedException(); }
        }

        public GraphicsDeviceCapabilities.LineCaps LineCapabilities
        {
            get { throw new NotImplementedException(); }
        }

        public int MasterAdapterOrdinal
        {
            get { throw new NotImplementedException(); }
        }

        public int MaxAnisotropy
        {
            get { throw new NotImplementedException(); }
        }

        public int MaxPixelShader30InstructionSlots
        {
            get { throw new NotImplementedException(); }
        }

        public ShaderProfile MaxPixelShaderProfile
        {
            get { return ShaderProfile.Unknown; }
        }

        public float MaxPointSize
        {
            get { throw new NotImplementedException(); }
        }

        public int MaxPrimitiveCount
        {
            get { throw new NotImplementedException(); }
        }

        public int MaxSimultaneousRenderTargets
        {
            get { return maxSimultaneousRenderTargets; }
        }

        public int MaxSimultaneousTextures
        {
            get { throw new NotImplementedException(); }
        }

        public int MaxStreams
        {
            get { throw new NotImplementedException(); }
        }

        public int MaxStreamStride
        {
            get { throw new NotImplementedException(); }
        }

        public int MaxTextureAspectRatio
        {
            get { throw new NotImplementedException(); }
        }

        public int MaxTextureHeight
        {
            get { throw new NotImplementedException(); }
        }

        public int MaxTextureRepeat
        {
            get { throw new NotImplementedException(); }
        }

        public int MaxTextureWidth
        {
            get { throw new NotImplementedException(); }
        }

        public int MaxUserClipPlanes
        {
            get { throw new NotImplementedException(); }
        }

        public int MaxVertexIndex
        {
            get { throw new NotImplementedException(); }
        }

        public int MaxVertexShader30InstructionSlots
        {
            get { throw new NotImplementedException(); }
        }

        public int MaxVertexShaderConstants
        {
            get { throw new NotImplementedException(); }
        }

        public ShaderProfile MaxVertexShaderProfile
        {
            get { throw new NotImplementedException(); }
        }

        public float MaxVertexW
        {
            get { throw new NotImplementedException(); }
        }

        public int MaxVolumeExtent
        {
            get { throw new NotImplementedException(); }
        }

        public int NumberOfAdaptersInGroup
        {
            get { throw new NotImplementedException(); }
        }

        public int NumberSimultaneousRenderTargets
        {
            get { throw new NotImplementedException(); }
        }

        public float PixelShader1xMaxValue
        {
            get { throw new NotImplementedException(); }
        }

        public GraphicsDeviceCapabilities.PixelShaderCaps PixelShaderCapabilities
        {
            get { throw new NotImplementedException(); }
        }

        public Version PixelShaderVersion
        {
            get { throw new NotImplementedException(); }
        }

        public PresentInterval PresentInterval
        {
            get { throw new NotImplementedException(); }
        }

        public GraphicsDeviceCapabilities.PrimitiveCaps PrimitiveCapabilities
        {
            get { throw new NotImplementedException(); }
        }

        public GraphicsDeviceCapabilities.RasterCaps RasterCapabilities
        {
            get { throw new NotImplementedException(); }
        }

        public GraphicsDeviceCapabilities.ShadingCaps ShadingCapabilities
        {
            get { throw new NotImplementedException(); }
        }

        public GraphicsDeviceCapabilities.BlendCaps SourceBlendCapabilities
        {
            get { throw new NotImplementedException(); }
        }

        public GraphicsDeviceCapabilities.StencilCaps StencilCapabilities
        {
            get { throw new NotImplementedException(); }
        }

        public GraphicsDeviceCapabilities.AddressCaps TextureAddressCapabilities
        {
            get { throw new NotImplementedException(); }
        }

        public GraphicsDeviceCapabilities.TextureCaps TextureCapabilities
        {
            get { throw new NotImplementedException(); }
        }

        public GraphicsDeviceCapabilities.FilterCaps TextureFilterCapabilities
        {
            get { throw new NotImplementedException(); }
        }

        public GraphicsDeviceCapabilities.VertexFormatCaps VertexFormatCapabilities
        {
            get { throw new NotImplementedException(); }
        }

        public GraphicsDeviceCapabilities.VertexProcessingCaps VertexProcessingCapabilities
        {
            get { throw new NotImplementedException(); }
        }

        public GraphicsDeviceCapabilities.VertexShaderCaps VertexShaderCapabilities
        {
            get { throw new NotImplementedException(); }
        }

        public Version VertexShaderVersion
        {
            get { throw new NotImplementedException(); }
        }

        public GraphicsDeviceCapabilities.FilterCaps VertexTextureFilterCapabilities
        {
            get { throw new NotImplementedException(); }
        }

        public GraphicsDeviceCapabilities.AddressCaps VolumeTextureAddressCapabilities
        {
            get { throw new NotImplementedException(); }
        }

        public GraphicsDeviceCapabilities.FilterCaps VolumeTextureFilterCapabilities
        {
            get { throw new NotImplementedException(); }
        }
		
		#endregion Properties
		
		#region Methods

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        protected void Dispose(bool disposing)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
		
		#endregion Methods
    }
}
