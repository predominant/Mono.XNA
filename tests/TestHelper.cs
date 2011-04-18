using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Tests
{
    public static class TestHelper
    {		
		/// <summary>
		/// This method should in theory remove the specified number of decimals, but
		/// some issues remain with large float numbers, causing more than the specified
		/// number of decimals to be removed.
		/// </summary>
		public static float Approximate(float value, int trim)
		{	
			string valueString = value.ToString();
			int decimalIndex = valueString.IndexOf('.');
			int powerIndex = valueString.IndexOf('E');
			float ret = value;
			if (powerIndex != -1)
				ret = float.Parse(valueString.Substring(0, powerIndex - 1) + valueString.Substring(powerIndex));
			else if (decimalIndex != -1)
				ret = float.Parse(valueString.Substring(0, valueString.Length - trim));
			
			return ret;
		}
		
		public static float Approximate(float value)
		{
			return Approximate(value, 1);	
		}

		public static Vector3 Approximate(Vector3 value)
		{
			return new Vector3(Approximate(value.X), Approximate(value.Y), Approximate(value.Z));	
		}
		
		public static Vector4 Approximate(Vector4 value)
		{
			return new Vector4(Approximate(value.X), Approximate(value.Y), Approximate(value.Z), Approximate(value.W));	
		}
		
		public static Quaternion Approximate(Quaternion value)
		{
			return new Quaternion(Approximate(value.X), Approximate(value.Y), Approximate(value.Z), Approximate(value.W));	
		}
		
		public static Matrix Approximate(Matrix value)
		{
			return new Matrix(Approximate(value.M11), Approximate(value.M12), Approximate(value.M13), Approximate(value.M14),
			                  Approximate(value.M21), Approximate(value.M22), Approximate(value.M23), Approximate(value.M24),
			                  Approximate(value.M31), Approximate(value.M32), Approximate(value.M33), Approximate(value.M34),
			                  Approximate(value.M41), Approximate(value.M42), Approximate(value.M43), Approximate(value.M44));	
		}
		
		public static Plane Approximate(Plane value)
		{
			return new Plane(Approximate(value.Normal), Approximate(value.D));
		}
		
        /// <summary>
        /// Used to check if two floating point values are approximately the same.
        /// </summary>
        /// <param name="value1">First value to compare</param>
        /// <param name="value2">Second value to compare</param>
        /// <returns></returns>
        public static bool ApproximatelyEquals(float value1, float value2)
        {
            return ApproximatelyEquals(value1, value2, value1/10f);
        }

        public static bool ApproximatelyEquals(float? value1, float? value2)
        {
            if (value1 == null)
                return value2 == null;

            if (value2 == null)
                return value1 == null;

            if (value1.Equals(float.NaN) && value2.Equals(float.NaN))
                return true;

            return ApproximatelyEquals((float)value1, (float)value2);
        }

        public static bool ApproximatelyEquals(float value1, float value2, float tolerance)
        {
            float epsilon = tolerance;

            float result = Math.Abs(value1 / value2);
            Console.WriteLine("Value1: " + value1 + ". Value2: " + value2 + ". Epsilon: " + epsilon + ". Result: " + result);

            //If both numbers are NaN, return true
            if (value1.Equals(float.NaN) && value2.Equals(float.NaN))
                return true;

            if (value1 == 0 && value2 == 0)
                return true;

            if (value1 == 0)
                return Math.Abs(value2) < epsilon;

            if (value2 == 0)
                return Math.Abs(value1) < epsilon;

            return (result > 0.98 && result < 1.02);
        }

        public static bool ApproximatelyEquals(Plane value1, Plane value2)
        {
            if (!ApproximatelyEquals(value1.D, value2.D))
                return false;

            return ApproximatelyEquals(value1.Normal, value2.Normal);
        }

        public static bool ApproximatelyEquals(Vector2 value1, Vector2 value2)
        {
            if(!ApproximatelyEquals(value1.X, value2.X))
                return false;

            return ApproximatelyEquals(value1.Y, value2.Y);
        }

        public static bool ApproximatelyEquals(Vector3 value1, Vector3 value2)
        {
            if (!ApproximatelyEquals(value1.X, value2.X))
                return false;

            if (!ApproximatelyEquals(value1.Y, value2.Y))
                return false;

            if (!ApproximatelyEquals(value1.Z, value2.Z))
                return false;

            return true;
        }

        public static bool ApproximatelyEquals(Vector4 value1, Vector4 value2)
        {
            if (!ApproximatelyEquals(value1.X, value2.X))
                return false;

            if (!ApproximatelyEquals(value1.Y, value2.Y))
                return false;

            if (!ApproximatelyEquals(value1.Z, value2.Z))
                return false;

            if (!ApproximatelyEquals(value1.W, value2.W))
                return false;
            return true;
        }
		
		public static bool ApproximatelyEquals(Matrix value1, Matrix value2)
        {
            if (!ApproximatelyEquals(value1.M11, value2.M11))
                return false;

            if (!ApproximatelyEquals(value1.M12, value2.M12))
                return false;

            if (!ApproximatelyEquals(value1.M13, value2.M13))
                return false;

            if (!ApproximatelyEquals(value1.M14, value2.M14))
                return false;
			
			if (!ApproximatelyEquals(value1.M21, value2.M21))
                return false;

            if (!ApproximatelyEquals(value1.M22, value2.M22))
                return false;

            if (!ApproximatelyEquals(value1.M23, value2.M23))
                return false;

            if (!ApproximatelyEquals(value1.M24, value2.M24))
                return false;
			
			if (!ApproximatelyEquals(value1.M31, value2.M31))
                return false;

            if (!ApproximatelyEquals(value1.M32, value2.M32))
                return false;

            if (!ApproximatelyEquals(value1.M33, value2.M33))
                return false;

            if (!ApproximatelyEquals(value1.M34, value2.M34))
                return false;
			
			if (!ApproximatelyEquals(value1.M41, value2.M41))
                return false;

            if (!ApproximatelyEquals(value1.M42, value2.M42))
                return false;

            if (!ApproximatelyEquals(value1.M43, value2.M43))
                return false;

            if (!ApproximatelyEquals(value1.M44, value2.M44))
                return false;
            return true;
        }
    }
}
