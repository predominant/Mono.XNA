#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team
http://www.taoframework.com
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
using System.ComponentModel;
using Microsoft.Xna.Framework.Design;

namespace Microsoft.Xna.Framework
{
    [Serializable]
    [TypeConverter(typeof(Vector4Converter))]
    public struct Vector4 : IEquatable<Vector4>
    {
        public float X;
        public float Y;
        public float Z;
        public float W;

        private static Vector4 zeroVector = new Vector4();
        private static Vector4 unitVector = new Vector4(1f, 1f, 1f, 1f);
        private static Vector4 unitXVector = new Vector4(1f, 0f, 0f, 0f);
        private static Vector4 unitYVector = new Vector4(0f, 1f, 0f, 0f);
        private static Vector4 unitZVector = new Vector4(0f, 0f, 1f, 0f);
        private static Vector4 unitWVector = new Vector4(0f, 0f, 0f, 1f);


        public static Vector4 Zero
        {
            get { throw new NotImplementedException(); }
        }

        public static Vector4 One
        {
            get { throw new NotImplementedException(); }
        }

        public static Vector4 UnitX
        {
            get { throw new NotImplementedException(); }
        }

        public static Vector4 UnitY
        {
            get { throw new NotImplementedException(); }
        }
        
        public static Vector4 UnitZ
        {
            get { throw new NotImplementedException(); }
        }

        public static Vector4 UnitW
        {
            get { throw new NotImplementedException(); }
        }

        public Vector4(float x, float y, float z, float w)
        {
            throw new NotImplementedException();
        }

        public Vector4(Vector2 value, float z, float w)
        {
            throw new NotImplementedException();
        }

        public Vector4(Vector3 value, float w)
        {
            throw new NotImplementedException();
        }

        public Vector4(float value)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public bool Equals(Vector4 other)
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

        public float Length()
        {
            throw new NotImplementedException();
        }

        public float LengthSquared()
        {
            throw new NotImplementedException();
        }

        public static float Distance(Vector4 value1, Vector4 value2)
        {
            throw new NotImplementedException();
        }

        public static void Distance(ref Vector4 value1, ref Vector4 value2, out float result)
        {
            throw new NotImplementedException();
        }

        public static float DistanceSquared(Vector4 value1, Vector4 value2)
        {
            throw new NotImplementedException();
        }

        public static void DistanceSquared(ref Vector4 value1, ref Vector4 value2, out float result)
        {
            throw new NotImplementedException();
        }

        public static float Dot(Vector4 vector1, Vector4 vector2)
        {
            throw new NotImplementedException();
        }

        public static void Dot(ref Vector4 vector1, ref Vector4 vector2, out float result)
        {
            throw new NotImplementedException();
        }

        public void Normalize()
        {
            throw new NotImplementedException();
        }

        public static Vector4 Normalize(Vector4 vector)
        {
            throw new NotImplementedException();
        }

        public static void Normalize(ref Vector4 vector, out Vector4 result)
        {
            throw new NotImplementedException();
        }

        public static Vector4 Min(Vector4 value1, Vector4 value2)
        {
            throw new NotImplementedException();
        }

        public static void Min(ref Vector4 value1, ref Vector4 value2, out Vector4 result)
        {
            throw new NotImplementedException();
        }

        public static Vector4 Max(Vector4 value1, Vector4 value2)
        {
            throw new NotImplementedException();
        }

        public static void Max(ref Vector4 value1, ref Vector4 value2, out Vector4 result)
        {
            throw new NotImplementedException();
        }

        public static Vector4 Clamp(Vector4 value1, Vector4 min, Vector4 max)
        {
            throw new NotImplementedException();
        }

        public static void Clamp(ref Vector4 value1, ref Vector4 min, ref Vector4 max, out Vector4 result)
        {
            throw new NotImplementedException();
        }

        public static Vector4 Lerp(Vector4 value1, Vector4 value2, float amount)
        {
            throw new NotImplementedException();
        }

        public static void Lerp(ref Vector4 value1, ref Vector4 value2, float amount, out Vector4 result)
        {
            throw new NotImplementedException();
        }

        public static Vector4 Barycentric(Vector4 value1, Vector4 value2, Vector4 value3, float amount1, float amount2)
        {
            throw new NotImplementedException();
        }

        public static void Barycentric(ref Vector4 value1, ref Vector4 value2, ref Vector4 value3, float amount1, float amount2, out Vector4 result)
        {
            throw new NotImplementedException();
        }

        public static Vector4 SmoothStep(Vector4 value1, Vector4 value2, float amount)
        {
            throw new NotImplementedException();
        }

        public static void SmoothStep(ref Vector4 value1, ref Vector4 value2, float amount, out Vector4 result)
        {
            throw new NotImplementedException();
        }

        public static Vector4 CatmullRom(Vector4 value1, Vector4 value2, Vector4 value3, Vector4 value4, float amount)
        {
            throw new NotImplementedException();
        }

        public static void CatmullRom(ref Vector4 value1, ref Vector4 value2, ref Vector4 value3, ref Vector4 value4, float amount, out Vector4 result)
        {
            throw new NotImplementedException();
        }

        public static Vector4 Hermite(Vector4 value1, Vector4 tangent1, Vector4 value2, Vector4 tangent2, float amount)
        {
            throw new NotImplementedException();
        }

        public static void Hermite(ref Vector4 value1, ref Vector4 tangent1, ref Vector4 value2, ref Vector4 tangent2, float amount, out Vector4 result)
        {
            throw new NotImplementedException();
        }

        public static Vector4 Transform(Vector2 position, Matrix matrix)
        {
            throw new NotImplementedException();
        }

        public static Vector4 Transform(Vector3 position, Matrix matrix)
        {
            throw new NotImplementedException();
        }

        public static Vector4 Transform(Vector4 vector, Matrix matrix)
        {
            throw new NotImplementedException();
        }

        public static void Transform(ref Vector2 position, ref Matrix matrix, out Vector4 result)
        {
            throw new NotImplementedException();
        }

        public static void Transform(ref Vector3 position, ref Matrix matrix, out Vector4 result)
        {
            throw new NotImplementedException();
        }

        public static void Transform(ref Vector4 vector, ref Matrix matrix, out Vector4 result)
        {
            throw new NotImplementedException();
        }

        public static Vector4 Negate(Vector4 value)
        {
            throw new NotImplementedException();
        }

        public static void Negate(ref Vector4 value, out Vector4 result)
        {
            throw new NotImplementedException();
        }

        public static Vector4 Add(Vector4 value1, Vector4 value2)
        {
            throw new NotImplementedException();
        }

        public static void Add(ref Vector4 value1, ref Vector4 value2, out Vector4 result)
        {
            throw new NotImplementedException();
        }

        public static Vector4 Subtract(Vector4 value1, Vector4 value2)
        {
            throw new NotImplementedException();
        }

        public static void Subtract(ref Vector4 value1, ref Vector4 value2, out Vector4 result)
        {
            throw new NotImplementedException();
        }

        public static Vector4 Multiply(Vector4 value1, Vector4 value2)
        {
            throw new NotImplementedException();
        }

        public static Vector4 Multiply(Vector4 value1, float scaleFactor)
        {
            throw new NotImplementedException();
        }

        public static void Multiply(ref Vector4 value1, float scaleFactor, out Vector4 result)
        {
            throw new NotImplementedException();
        }

        public static void Multiply(ref Vector4 value1, ref Vector4 value2, out Vector4 result)
        {
            throw new NotImplementedException();
        }

        public static Vector4 Divide(Vector4 value1, Vector4 value2)
        {
            throw new NotImplementedException();
        }

        public static Vector4 Divide(Vector4 value1, float divider)
        {
            throw new NotImplementedException();
        }

        public static void Divide(ref Vector4 value1, float divider, out Vector4 result)
        {
            throw new NotImplementedException();
        }

        public static void Divide(ref Vector4 value1, ref Vector4 value2, out Vector4 result)
        {
            throw new NotImplementedException();
        }

        public static Vector4 operator -(Vector4 value)
        {
            return new Vector4(-value.X, -value.Y, -value.Z, -value.W);
        }

        public static bool operator ==(Vector4 value1, Vector4 value2)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(Vector4 value1, Vector4 value2)
        {
            throw new NotImplementedException();
        }

        public static Vector4 operator +(Vector4 value1, Vector4 value2)
        {
            throw new NotImplementedException();
        }

        public static Vector4 operator -(Vector4 value1, Vector4 value2)
        {
            throw new NotImplementedException();
        }

        public static Vector4 operator *(Vector4 value1, Vector4 value2)
        {
            throw new NotImplementedException();
        }

        public static Vector4 operator *(Vector4 value1, float scaleFactor)
        {
            throw new NotImplementedException();
        }

        public static Vector4 operator *(float scaleFactor, Vector4 value1)
        {
            throw new NotImplementedException();
        }

        public static Vector4 operator /(Vector4 value1, Vector4 value2)
        {
            throw new NotImplementedException();
        }
        
        public static Vector4 operator /(Vector4 value1, float divider)
        {
            throw new NotImplementedException();
        }
    }
}
