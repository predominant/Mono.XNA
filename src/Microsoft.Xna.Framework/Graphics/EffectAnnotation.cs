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
    public sealed class EffectAnnotation
    {
        internal EffectAnnotation()
        {
        }

        public int ColumnCount { get { throw new NotImplementedException(); } }

        public string Name { get { throw new NotImplementedException(); } }

        public EffectParameterClass ParameterClass { get { throw new NotImplementedException(); } }

        public EffectParameterType ParameterType { get { throw new NotImplementedException(); } }

        public int RowCount { get { throw new NotImplementedException(); } }

        public string Semantic { get { throw new NotImplementedException(); } }

        public bool GetValueBoolean() { throw new NotImplementedException(); }

        public int GetValueInt32() { throw new NotImplementedException(); }

        public Matrix GetValueMatrix() { throw new NotImplementedException(); }

        public float GetValueSingle() { throw new NotImplementedException(); }

        public string GetValueString() { throw new NotImplementedException(); }

        public Vector2 GetValueVector2() { throw new NotImplementedException(); }

        public Vector3 GetValueVector3() { throw new NotImplementedException(); }

        public Vector4 GetValueVector4() { throw new NotImplementedException(); }
    }
}
