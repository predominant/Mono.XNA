#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.

Authors:
Alan McGovern

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
    public sealed class VertexStream
    {
        #region Properties
        public int OffsetInBytes
        {
            get { throw new NotImplementedException(); }
        }

        public VertexBuffer VertexBuffer
        {
            get { throw new NotImplementedException(); }
        }

        public int VertexStride
        {
            get { throw new NotImplementedException(); }
        }
        #endregion Properties


        #region Methods

        #region Windows Only
        public void SetFrequency(int frequency)
        {
            throw new NotImplementedException();
        }

        public void SetFrequencyOfIndexData(int frequency)
        {
            throw new NotImplementedException();
        }

        public void SetFrequencyOfInstanceData(int frequency)
        {
            throw new NotImplementedException();
        }

        #endregion

        public void SetSource(VertexBuffer vb, int offsetInBytes, int vertexStride)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
