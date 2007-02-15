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
    public sealed partial class GraphicsDeviceCapabilities : IDisposable
    {
        public struct PixelShaderCaps
        {
            public const int MaxDynamicFlowControlDepth = 24;
            public const int MaxNumberInstructionSlots = 512;
            public const int MaxNumberTemps = 32;
            public const int MaxStaticFlowControlDepth = 4;
            public const int MinDynamicFlowControlDepth = 0;
            public const int MinNumberInstructionSlots = 96;
            public const int MinNumberTemps = 12;
            public const int MinStaticFlowControlDepth = 0;

            public int DynamicFlowControlDepth
            {
                get { throw new NotImplementedException(); }
            }

            public int NumberInstructionSlots
            {
                get { throw new NotImplementedException(); }
            }

            public int NumberTemps
            {
                get { throw new NotImplementedException(); }
            }

            public int StaticFlowControlDepth
            {
                get { throw new NotImplementedException(); }
            }

            public bool SupportsArbitrarySwizzle
            {
                get { throw new NotImplementedException(); }
            }

            public bool SupportsGradientInstructions
            {
                get { throw new NotImplementedException(); }
            }

            public bool SupportsNoDependentReadLimit
            {
                get { throw new NotImplementedException(); }
            }

            public bool SupportsNoTextureInstructionLimit
            {
                get { throw new NotImplementedException(); }
            }

            public bool SupportsPredication
            {
                get { throw new NotImplementedException(); }
            }

            public override string ToString()
            {
                throw new NotImplementedException();
            }
        }
    }
}
