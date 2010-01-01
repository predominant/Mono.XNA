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
    public sealed class RenderState
    {
        private RenderState()
        {
        }

        public bool AlphaBlendEnable
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public BlendFunction AlphaBlendOperation
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Blend AlphaDestinationBlend
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public CompareFunction AlphaFunction
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Blend AlphaSourceBlend
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool AlphaTestEnable
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Color BlendFactor
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public BlendFunction BlendFunction
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public ColorWriteChannels ColorWriteChannels
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public ColorWriteChannels ColorWriteChannels1
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public ColorWriteChannels ColorWriteChannels2
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public ColorWriteChannels ColorWriteChannels3
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public StencilOperation CounterClockwiseStencilDepthBufferFail
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public StencilOperation CounterClockwiseStencilFail
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public CompareFunction CounterClockwiseStencilFunction
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public StencilOperation CounterClockwiseStencilPass
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public CullMode CullMode
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public float DepthBias
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool DepthBufferEnable
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public CompareFunction DepthBufferFunction
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool DepthBufferWriteEnable
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Blend DestinationBlend
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public FillMode FillMode
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Color FogColor
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public float FogDensity
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool FogEnable
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public float FogEnd
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public float FogStart
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public FogMode FogTableMode
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public FogMode FogVertexMode
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool MultiSampleAntiAlias
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public int MultiSampleMask
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public float PointSize
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public float PointSizeMax
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public float PointSizeMin
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool PointSpriteEnable
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool RangeFogEnable
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public int ReferenceAlpha
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public int ReferenceStencil
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool ScissorTestEnable
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool SeparateAlphaBlendEnabled
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public float SlopeScaleDepthBias
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Blend SourceBlend
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public StencilOperation StencilDepthBufferFail
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool StencilEnable
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public StencilOperation StencilFail
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public CompareFunction StencilFunction
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public int StencilMask
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public StencilOperation StencilPass
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public int StencilWriteMask
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool TwoSidedStencilMode
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public TextureWrapCoordinates Wrap0
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public TextureWrapCoordinates Wrap1
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public TextureWrapCoordinates Wrap10
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public TextureWrapCoordinates Wrap11
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public TextureWrapCoordinates Wrap12
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public TextureWrapCoordinates Wrap13
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public TextureWrapCoordinates Wrap14
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public TextureWrapCoordinates Wrap15
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public TextureWrapCoordinates Wrap2
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public TextureWrapCoordinates Wrap3
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public TextureWrapCoordinates Wrap4
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public TextureWrapCoordinates Wrap5
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public TextureWrapCoordinates Wrap6
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public TextureWrapCoordinates Wrap7
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public TextureWrapCoordinates Wrap8
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public TextureWrapCoordinates Wrap9
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
