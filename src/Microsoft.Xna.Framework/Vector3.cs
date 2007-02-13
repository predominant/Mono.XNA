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
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework.Design;
using System.ComponentModel;

namespace Microsoft.Xna.Framework
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    [TypeConverter(typeof(Vector3Converter))]
    public struct Vector3 : IEquatable<Vector3>
    {
        public float X;
        public float Y;
        public float Z;

        private static Vector3 m_Zero = new Vector3(0f, 0f, 0f);
        private static Vector3 m_One = new Vector3(1f, 1f, 1f);
        private static Vector3 m_UnitX = new Vector3(1f, 0f, 0f);
        private static Vector3 m_UnitY = new Vector3(0f, 1f, 0f);
        private static Vector3 m_UnitZ = new Vector3(0f, 0f, 1f);
        private static Vector3 m_Up = new Vector3(0f, 1f, 0f);
        private static Vector3 m_Down = new Vector3(0f, -1f, 0f);
        private static Vector3 m_Right = new Vector3(1f, 0f, 0f);
        private static Vector3 m_Left = new Vector3(-1f, 0f, 0f);
        private static Vector3 m_Forward = new Vector3(0f, 0f, -1f);
        private static Vector3 m_Backward = new Vector3(0f, 0f, 1f);

        public static Vector3 Zero
        {
            get { throw new NotImplementedException(); }
        }


        public static Vector3 One
        {
            get { throw new NotImplementedException(); }
        }


        public static Vector3 UnitX
        {
            get { throw new NotImplementedException(); }
        }

        public static Vector3 UnitY
        {
            get { throw new NotImplementedException(); }
        }

        public static Vector3 UnitZ
        {
            get { throw new NotImplementedException(); }
        }


        public static Vector3 Up
        {
            get { throw new NotImplementedException(); }
        }


        public static Vector3 Down
        {
            get { throw new NotImplementedException(); }
        }


        public static Vector3 Right
        {
            get { throw new NotImplementedException(); }
        }


        public static Vector3 Left
        {
            get { throw new NotImplementedException(); }
        }


        public static Vector3 Forward
        {
            get { throw new NotImplementedException(); }
        }


        public static Vector3 Backward
        {
            get { throw new NotImplementedException(); }
        }


        public Vector3(float x, float y, float z)
        {
            throw new NotImplementedException();
        }


        public Vector3(float value)
        {
            throw new NotImplementedException();
        }


        public Vector3(Vector2 value, float z)
        {
            throw new NotImplementedException();
        }


        public override string ToString()
        {
            throw new NotImplementedException();
        }


        public bool Equals(Vector3 other)
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


        public static float Distance(Vector3 vector1, Vector3 value2)
        {
            throw new NotImplementedException();
        }


        public static void Distance(ref Vector3 value1, ref Vector3 value2, out float result)
        {
            throw new NotImplementedException();
        }


        public static float DistanceSquared(Vector3 value1, Vector3 value2)
        {
            throw new NotImplementedException();
        }


        public static void DistanceSquared(ref Vector3 value1, ref Vector3 value2, out float result)
        {
            throw new NotImplementedException();
        }


        public static float Dot(Vector3 vector1, Vector3 vector2)
        {
            throw new NotImplementedException();
        }


        public static void Dot(ref Vector3 vector1, ref Vector3 vector2, out float result)
        {
            throw new NotImplementedException();
        }

        public void Normalize()
        {
            throw new NotImplementedException();
        }


        public static Vector3 Normalize(Vector3 vector)
        {
            throw new NotImplementedException();
        }


        public static void Normalize(ref Vector3 value, out Vector3 result)
        {
            throw new NotImplementedException();
        }


        public static Vector3 Cross(Vector3 vector1, Vector3 vector2)
        {
            throw new NotImplementedException();
        }


        public static void Cross(ref Vector3 vector1, ref Vector3 vector2, out Vector3 result)
        {
            throw new NotImplementedException();
        }


        public static Vector3 Reflect(Vector3 vector, Vector3 normal)
        {
            throw new NotImplementedException();
        }


        public static void Reflect(ref Vector3 vector, ref Vector3 normal, out Vector3 result)
        {
            throw new NotImplementedException();
        }


        public static Vector3 Min(Vector3 value1, Vector3 value2)
        {
            throw new NotImplementedException();
        }


        public static void Min(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
        {
            throw new NotImplementedException();
        }


        public static Vector3 Max(Vector3 value1, Vector3 value2)
        {
            throw new NotImplementedException();
        }


        public static void Max(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
        {
            throw new NotImplementedException();
        }


        public static Vector3 Clamp(Vector3 value, Vector3 min, Vector3 max)
        {
            throw new NotImplementedException();
        }


        public static void Clamp(ref Vector3 value1, ref Vector3 min, ref Vector3 max, out Vector3 result)
        {
            throw new NotImplementedException();
        }


        public static Vector3 Lerp(Vector3 value1, Vector3 value2, float amount)
        {
            throw new NotImplementedException();
        }


        public static void Lerp(ref Vector3 value1, ref Vector3 value2, float amount, out Vector3 result)
        {
            throw new NotImplementedException();
        }


        public static Vector3 Barycentric(Vector3 value1, Vector3 value2, Vector3 value3, float amount1, float amount2)
        {
            throw new NotImplementedException();
        }


        public static void Barycentric(ref Vector3 value1, ref Vector3 value2, ref Vector3 value3, float amount1, float amount2, out Vector3 result)
        {
            throw new NotImplementedException();
        }


        public static Vector3 SmoothStep(Vector3 value1, Vector3 value2, float amount)
        {
            throw new NotImplementedException();
        }


        public static void SmoothStep(ref Vector3 value1, ref Vector3 value2, float amount, out Vector3 result)
        {
            throw new NotImplementedException();
        }


        public static Vector3 CatmullRom(Vector3 value1, Vector3 value2, Vector3 value3, Vector3 value4, float amount)
        {
            throw new NotImplementedException();
        }


        public static void CatmullRom(ref Vector3 value1, ref Vector3 value2, ref Vector3 value3, ref Vector3 value4, float amount, out Vector3 result)
        {
            throw new NotImplementedException();
        }


        public static Vector3 Hermite(Vector3 value1, Vector3 tangent1, Vector3 value2, Vector3 tangent2, float amount)
        {
            throw new NotImplementedException();
        }


        public static void Hermite(ref Vector3 value1, ref Vector3 tangent1, ref Vector3 value2, ref Vector3 tangent2, float amount, out Vector3 result)
        {
            throw new NotImplementedException();
        }


        public static Vector3 Transform(Vector3 position, Matrix matrix)
        {
            throw new NotImplementedException();
        }


        public static void Transform(ref Vector3 position, ref Matrix matrix, out Vector3 result)
        {
            throw new NotImplementedException();
        }


        public static Vector3 TransformNormal(Vector3 normal, Matrix matrix)
        {
            throw new NotImplementedException();
        }


        public static void TransformNormal(ref Vector3 normal, ref Matrix matrix, out Vector3 result)
        {
            throw new NotImplementedException();
        }


        public static Vector3 Negate(Vector3 value)
        {
            throw new NotImplementedException();
        }


        public static void Negate(ref Vector3 value, out Vector3 result)
        {
            throw new NotImplementedException();
        }


        public static Vector3 Add(Vector3 value1, Vector3 value2)
        {
            throw new NotImplementedException();
        }


        public static void Add(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
        {
            throw new NotImplementedException();
        }


        public static Vector3 Subtract(Vector3 value1, Vector3 value2)
        {
            throw new NotImplementedException();
        }


        public static void Subtract(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
        {
            throw new NotImplementedException();
        }


        public static Vector3 Multiply(Vector3 value1, Vector3 value2)
        {
            throw new NotImplementedException();
        }


        public static Vector3 Multiply(Vector3 value1, float scaleFactor)
        {
            throw new NotImplementedException();
        }


        public static void Multiply(ref Vector3 value1, float scaleFactor, out Vector3 result)
        {
            throw new NotImplementedException();
        }


        public static void Multiply(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
        {
            throw new NotImplementedException();
        }


        public static Vector3 Divide(Vector3 value1, Vector3 value2)
        {
            throw new NotImplementedException();
        }


        public static Vector3 Divide(Vector3 value1, float value2)
        {
            throw new NotImplementedException();
        }


        public static void Divide(ref Vector3 value1, float divisor, out Vector3 result)
        {
            throw new NotImplementedException();
        }


        public static void Divide(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
        {
            throw new NotImplementedException();
        }


        public static Vector3 operator -(Vector3 value)
        {
            throw new NotImplementedException();
        }


        public static bool operator ==(Vector3 value1, Vector3 value2)
        {
            throw new NotImplementedException();
        }


        public static bool operator !=(Vector3 value1, Vector3 value2)
        {
            throw new NotImplementedException();
        }


        public static Vector3 operator +(Vector3 value1, Vector3 value2)
        {
            throw new NotImplementedException();
        }


        public static Vector3 operator -(Vector3 value1, Vector3 value2)
        {
            throw new NotImplementedException();
        }


        public static Vector3 operator *(Vector3 value1, Vector3 value2)
        {
            throw new NotImplementedException();
        }


        public static Vector3 operator *(Vector3 value, float scaleFactor)
        {
            throw new NotImplementedException();
        }


        public static Vector3 operator *(float scaleFactor, Vector3 value)
        {
            throw new NotImplementedException();
        }


        public static Vector3 operator /(Vector3 value1, Vector3 value2)
        {
            throw new NotImplementedException();
        }


        public static Vector3 operator /(Vector3 value, float divider)
        {
            throw new NotImplementedException();
        }
    }
}
