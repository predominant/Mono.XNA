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
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework.Design;

namespace Microsoft.Xna.Framework
{
    [Serializable, StructLayout(LayoutKind.Sequential)]
    [TypeConverter(typeof(Vector2Converter))]
    public struct Vector2 : IEquatable<Vector2>
    {
        public float X;
        public float Y;

        private static Vector2 zeroVector = new Vector2(0f, 0f);
        private static Vector2 unitVector = new Vector2(1f, 1f);
        private static Vector2 unitXVector = new Vector2(1f, 0f);
        private static Vector2 unitYVector = new Vector2(0f, 1f);


        public static Vector2 Zero { get { return zeroVector; } }

        public static Vector2 One { get { return unitVector; } }

        public static Vector2 UnitX { get { return unitXVector; } }

        public static Vector2 UnitY { get { return unitYVector; } }

        public Vector2(float x, float y)
        {
            throw new NotImplementedException();
        }

        public Vector2(float value)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }


        public bool Equals(Vector2 other)
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


        public static float Distance(Vector2 value1, Vector2 value2)
        {
            throw new NotImplementedException();
        }


        public static void Distance(ref Vector2 value1, ref Vector2 value2, out float result)
        {
            throw new NotImplementedException();
        }


        public static float DistanceSquared(Vector2 value1, Vector2 value2)
        {
            throw new NotImplementedException();
        }


        public static void DistanceSquared(ref Vector2 value1, ref Vector2 value2, out float result)
        {
            throw new NotImplementedException();
        }


        public static float Dot(Vector2 value1, Vector2 value2)
        {
            throw new NotImplementedException();
        }


        public static void Dot(ref Vector2 value1, ref Vector2 value2, out float result)
        {
            throw new NotImplementedException();
        }


        public static Vector2 Normalize(Vector2 value)
        {
            throw new NotImplementedException();
        }


        public static void Normalize(ref Vector2 value, out Vector2 result)
        {
            throw new NotImplementedException();
        }


        public void Normalize()
        {
            throw new NotImplementedException();
        }


        public static Vector2 Min(Vector2 value1, Vector2 value2)
        {
            throw new NotImplementedException();
        }


        public static void Min(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            throw new NotImplementedException();
        }


        public static Vector2 Max(Vector2 value1, Vector2 value2)
        {
            throw new NotImplementedException();
        }


        public static void Max(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            throw new NotImplementedException();
        }


        public static Vector2 Clamp(Vector2 value1, Vector2 min, Vector2 max)
        {
            throw new NotImplementedException();
        }


        public static void Clamp(ref Vector2 value1, ref Vector2 min, ref Vector2 max, out Vector2 result)
        {
            throw new NotImplementedException();
        }


        public static Vector2 Lerp(Vector2 value1, Vector2 value2, float amount)
        {
            throw new NotImplementedException();
        }


        public static void Lerp(ref Vector2 value1, ref Vector2 value2, float amount, out Vector2 result)
        {
            throw new NotImplementedException();
        }


        public static Vector2 Barycentric(Vector2 value1, Vector2 value2, Vector2 value3, float amount1, float amount2)
        {
            throw new NotImplementedException();
        }


        public static void Barycentric(ref Vector2 value1, ref Vector2 value2, ref Vector2 value3, float amount1, float amount2, out Vector2 result)
        {
            throw new NotImplementedException();
        }


        public static Vector2 SmoothStep(Vector2 value1, Vector2 value2, float amount)
        {
            throw new NotImplementedException();
        }


        public static void SmoothStep(ref Vector2 value1, ref Vector2 value2, float amount, out Vector2 result)
        {
            throw new NotImplementedException();
        }


        public static Vector2 CatmullRom(Vector2 value1, Vector2 value2, Vector2 value3, Vector2 value4, float amount)
        {
            throw new NotImplementedException();
        }


        public static void CatmullRom(ref Vector2 value1, ref Vector2 value2, ref Vector2 value3, ref Vector2 value4, float amount, out Vector2 result)
        {
            throw new NotImplementedException();
        }


        public static Vector2 Hermite(Vector2 value1, Vector2 tangent1, Vector2 value2, Vector2 tangent2, float amount)
        {
            throw new NotImplementedException();
        }


        public static void Hermite(ref Vector2 value1, ref Vector2 tangent1, ref Vector2 value2, ref Vector2 tangent2, float amount, out Vector2 result)
        {
            throw new NotImplementedException();
        }


        public static Vector2 Transform(Vector2 position, Matrix matrix)
        {
            throw new NotImplementedException();
        }


        public static void Transform(ref Vector2 position, ref Matrix matrix, out Vector2 result)
        {
            throw new NotImplementedException();
        }


        public static Vector2 TransformNormal(Vector2 normal, Matrix matrix)
        {
            throw new NotImplementedException();
        }


        public static void TransformNormal(ref Vector2 normal, ref Matrix matrix, out Vector2 result)
        {
            throw new NotImplementedException();
        }


        public static Vector2 Negate(Vector2 value)
        {
            throw new NotImplementedException();
        }


        public static void Negate(ref Vector2 value, out Vector2 result)
        {
            throw new NotImplementedException();
        }


        public static Vector2 Add(Vector2 value1, Vector2 value2)
        {
            throw new NotImplementedException();
        }


        public static void Add(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            throw new NotImplementedException();
        }


        public static Vector2 Subtract(Vector2 value1, Vector2 value2)
        {
            throw new NotImplementedException();
        }


        public static void Subtract(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            throw new NotImplementedException();
        }


        public static Vector2 Multiply(Vector2 value1, Vector2 value2)
        {
            throw new NotImplementedException();
        }


        public static Vector2 Multiply(Vector2 value1, float scaleFactor)
        {
            throw new NotImplementedException();
        }


        public static void Multiply(ref Vector2 value1, float scaleFactor, out Vector2 result)
        {
            throw new NotImplementedException();
        }


        public static void Multiply(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            throw new NotImplementedException();
        }


        public static Vector2 Divide(Vector2 value1, Vector2 value2)
        {
            throw new NotImplementedException();
        }


        public static Vector2 Divide(Vector2 value1, float divider)
        {
            throw new NotImplementedException();
        }


        public static void Divide(ref Vector2 value1, float divider, out Vector2 result)
        {
            throw new NotImplementedException();
        }


        public static void Divide(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            throw new NotImplementedException();
        }


        public static Vector2 operator -(Vector2 value)
        {
            throw new NotImplementedException();
        }


        public static bool operator ==(Vector2 value1, Vector2 value2)
        {
            throw new NotImplementedException();
        }


        public static bool operator !=(Vector2 value1, Vector2 value2)
        {
            throw new NotImplementedException();
        }


        public static Vector2 operator +(Vector2 value1, Vector2 value2)
        {
            throw new NotImplementedException();
        }

        public static Vector2 operator -(Vector2 value1, Vector2 value2)
        {
            throw new NotImplementedException();
        }


        public static Vector2 operator *(Vector2 value1, Vector2 value2)
        {
            throw new NotImplementedException();
        }


        public static Vector2 operator *(Vector2 value, float scaleFactor)
        {
            throw new NotImplementedException();
        }


        public static Vector2 operator *(float scaleFactor, Vector2 value)
        {
            throw new NotImplementedException();
        }


        public static Vector2 operator /(Vector2 value1, Vector2 value2)
        {
            throw new NotImplementedException();
        }


        public static Vector2 operator /(Vector2 value1, float divider)
        {
            throw new NotImplementedException();
        }
    }
}
