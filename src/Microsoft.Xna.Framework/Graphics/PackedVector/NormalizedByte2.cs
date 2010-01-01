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

using Microsoft.Xna.Framework;
using System;

namespace Microsoft.Xna.Framework.Graphics.PackedVector
{
    public struct NormalizedByte2 : IPackedVector<ushort>, IPackedVector, IEquatable<NormalizedByte2>
    {
        public NormalizedByte2(Vector2 vector){ throw new NotImplementedException(); }
        
        public NormalizedByte2(float x, float y){ throw new NotImplementedException(); }
        
        public static bool operator !=(NormalizedByte2 a, NormalizedByte2 b){ throw new NotImplementedException(); }
        
        public static bool operator ==(NormalizedByte2 a, NormalizedByte2 b){ throw new NotImplementedException(); }
        
        [CLSCompliant(false)]
        public ushort PackedValue { get{ throw new NotImplementedException(); } set{ throw new NotImplementedException(); } }

        public bool Equals(NormalizedByte2 other){ throw new NotImplementedException(); }
        
        public override bool Equals(object obj){ throw new NotImplementedException(); }
        
        public override int GetHashCode(){ throw new NotImplementedException(); }
        
        public override string ToString(){ throw new NotImplementedException(); }
        
        public Vector2 ToVector2(){ throw new NotImplementedException(); }

        void IPackedVector.PackFromVector4(Vector4 vector)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        Vector4 IPackedVector.ToVector4()
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
