using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Microsoft.Xna.Framework.Tests
{
    public static class TestHelper
    {
        /// <summary>
        /// Used to check if two floating point values are approximately the same.
        /// </summary>
        /// <param name="value1">First value to compare</param>
        /// <param name="value2">Second value to compare</param>
        /// <returns></returns>
        public static bool ApproximatelyEquals(float value1, float value2)
        {
            return ApproximatelyEquals(value1, value2, 1 / 10000.0f);
        }

        public static bool ApproximatelyEquals(float? value1, float? value2)
        {
            if (value1 == null)
                return value2 == null;

            if (value2 == null)
                return value1 == null;

            if (value1.Equals(float.NaN) && value2.Equals(float.NaN))
                return true;

            float epsilon = 1 / 10000.0f;
            Console.WriteLine("Value1: " + value1 + ". Value2: " + value2 + ". Result: " + Math.Abs((float)value1 - (float)value2));
            return ApproximatelyEquals((float)value1, (float)value2);
        }

        public static bool ApproximatelyEquals(float value1, float value2, float tolerance)
        {
            float epsilon = tolerance;

            //If both numbers are NaN, return true
            if (value1.Equals(float.NaN) && value2.Equals(float.NaN))
                return true;

            Console.WriteLine("Value1: " + value1 + ". Value2: " + value2 + ". Result: " + Math.Abs(value1 - value2));
            return Math.Abs(value1 - value2) < epsilon;
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

        public static bool ApproximatelyEquals(Plane value1, Plane value2)
        {
            if (!ApproximatelyEquals(value1.D, value2.D))
                return false;

            return ApproximatelyEquals(value1.Normal, value2.Normal);
        }
    }
}
