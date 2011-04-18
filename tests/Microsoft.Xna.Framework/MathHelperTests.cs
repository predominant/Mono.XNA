#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.

Authors: Isaac Llopis (neozack@gmail.com)

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
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Microsoft.Xna.Framework;
using System.Globalization;

namespace Tests.Microsoft.Xna.Framework
{
    [TestFixture]
    public class MathHelperTests
    {
        [Test]
        public void BarycentricTest()
        {
            float value0 = 0f;
            float value1 = 1f;
            float value2 = 2f;
            float value3 = 3f;
            float value4 = 45.344399E12f;
            float value5 = -3.33789838787683E29f;

            float amount0 = 0f;
            float amount1 = 1f;
            float amount2 = 3.6f;
            float amount3 = -5f;

            // Test 1
            // Check result against function used in the open implementation
            // Useful to compare results between both implementations
            float result1_1a = MathHelper.Barycentric(value1, value2, value3, amount1, amount2);
            float result1_1b = value1 + (value2 - value1) * amount1 + (value3 - value1) * amount2;
            Assert.IsTrue(result1_1a == result1_1b, "MathHelper.Barycentric#1.1");

            float result1_2a = MathHelper.Barycentric(value3, value4, value5, amount2, amount3);
            float result1_2b = value3 + (value4 - value3) * amount2 + (value5 - value3) * amount3;
            Assert.IsTrue(result1_2a == result1_2b, "MathHelper.Barycentric#1.2");

            // Test 2
            // Test extreme situations
            float result2_1 = MathHelper.Barycentric(float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue);
            Assert.IsTrue(result2_1 == float.MaxValue, "MathHelper.Barycentric#2.1");

            float result2_2 = MathHelper.Barycentric(float.MinValue, float.MinValue, float.MinValue, float.MinValue, float.MinValue);
            Assert.IsTrue(result2_2 == float.MinValue, "MathHelper.Barycentric#2.2");

            float result2_3 = MathHelper.Barycentric(float.PositiveInfinity, float.NegativeInfinity, float.NaN, float.MaxValue, float.MinValue);
            Assert.IsTrue(float.IsNaN(result2_3), "MathHelper.Barycentric#2.3");
        }

        [Test]
        public void CatmullRomTest()
        {
            float value1 = 1f;
            float value2 = 3.6f;
            float value3 = 99.45E12f;
            float value4 = -9.355673E30f;

            double dvalue1 = value1;
            double dvalue2 = value2;
            double dvalue3 = value3;
            double dvalue4 = value4;

            float amount = 3.45f;
            float amountSquared = amount * amount;
            float amountCubed = amountSquared * amount;

            double damount = amount;
            double damountSquared = damount * damount;
            double damountCubed = damountSquared * damount;

            // Test 1
            // Check result against function used in the open implementation
            // Useful to compare results between both implementations
            float result1_1a = MathHelper.CatmullRom(value1, value2, value3, value4, amount);
            float result1_1b = (float)(0.5 * (2.0 * dvalue2 +
                (dvalue3 - dvalue1) * damount +
                (2.0 * dvalue1 - 5.0 * dvalue2 + 4.0 * dvalue3 - dvalue4) * damountSquared +
                (3.0 * dvalue2 - dvalue1 - 3.0 * dvalue3 + dvalue4) * damountCubed));
            Assert.IsTrue(result1_1a == result1_1b, "MathHelper.CatmullRom#1.1");

            // Now the same test with doubles
            float result1_2a = MathHelper.CatmullRom(value1, value2, value3, value4, amount);
            float result1_2b = 0.5f * (2.0f * value2 +
                (value3 - value1) * amount +
                (2.0f * value1 - 5.0f * value2 + 4.0f * value3 - value4) * amountSquared +
                (3.0f * value2 - value1 - 3.0f * value3 + value4) * amountCubed);
            Assert.IsTrue(result1_1a == result1_1b, "MathHelper.CatmullRom#1.2");

            // Test 2
            // Check result against function used in the open implementation in extreme cases
            value4 = float.MaxValue;
            amount = value4;
            amountSquared = amount * amount;
            amountCubed = amountSquared * amount;

            float result2_1a = MathHelper.CatmullRom(value4, value4, value4, value4, value4);
            float result2_1b = 0.5f * (2.0f * value4 +
                (value4 - value4) * amount +
                (2.0f * value4 - 5.0f * value4 + 4.0f * value4 - value4) * amountSquared +
                (3.0f * value4 - value4 - 3.0f * value4 + value4) * amountCubed);
            // This shows that the implementation is made with double precission
            // even though the result is given in single precission
            Assert.IsTrue(result2_1a != result2_1b, "MathHelper.CatmullRom#2.1");

            // Now with doubles
            dvalue4 = value4;
            damount = amount;
            damountSquared = damount * damount;
            damountCubed = damountSquared * damount;

            float result2_2a = MathHelper.CatmullRom(value4, value4, value4, value4, value4);
            float result2_2b = (float)(0.5 * (2.0 * dvalue4 +
                (dvalue4 - dvalue4) * damount +
                (2.0 * dvalue4 - 5.0 * dvalue4 + 4.0 * dvalue4 - dvalue4) * damountSquared +
                (3.0 * dvalue4 - dvalue4 - 3.0 * dvalue4 + dvalue4) * damountCubed));
            Assert.IsTrue(result2_2a == result2_2b, "MathHelper.CatmullRom#2.2");

            // Test 3
            // Value tests
            float result3_1 = MathHelper.CatmullRom(15f, 14f, 13f, 12f, 0.578E12f);
            Assert.IsTrue(result3_1.Equals(-5.78E11f), result3_1 + "MathHelper.CatmullRom#3.1");

            float result3_2 = MathHelper.CatmullRom(0.15f, -14f, -13.456E12f, 12.02f, 0.844578E12f);
            Assert.IsTrue(result3_2.Equals(float.PositiveInfinity), result3_2 + "MathHelper.CatmullRom#3.2");

            float result3_3 = MathHelper.CatmullRom(1f, 1f, 1f, 1f, 2.578E12f);
            Assert.IsTrue(result3_3 == 1f, result3_3 + "MathHelper.CatmullRom#3.3");

            float result3_4 = MathHelper.CatmullRom(-15f, -14f, -13f, -12f, -0.578E12f);
            Assert.IsTrue(result3_4.Equals(result3_1), result3_4 + "MathHelper.CatmullRom#3.4");

            float result3_5 = MathHelper.CatmullRom(15.67E28f, 14.889f, 0.56882390E5f, 0.56E12f, 0.0f);
            Assert.IsTrue(result3_5 == 14.889f, result3_5 + "MathHelper.CatmullRom#3.5");

            float result3_6 = MathHelper.CatmullRom(-4.4E7f, -0.5f, 1.3f, 1.2f, 0.5f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(result3_6, 2750000f), result3_6 + "MathHelper.CatmullRom#3.6");
        }

        [Test]
        public void ClampTest()
        {
            float value0 = 0f;
            float value1 = -1.45E30f;

            // Test 1
            // Check result against function used in the open implementation
            // Useful to compare results between both implementations
            float result1_1a = MathHelper.Clamp(value0, -50f, 50f);
            float result1_1b = (value0 > 50f) ? 50f : value0;
            result1_1b = (value0 < -50f) ? -50f : value0;
            Assert.IsTrue(result1_1a == result1_1b, "MathHelper.Clamp#1.1");

            float result1_2a = MathHelper.Clamp(value1, -50f, 50f);
            float result1_2b = (value1 > 50f) ? 50f : value1;
            result1_2b = (value1 < -50f) ? -50f : value1;
            Assert.IsTrue(result1_2a == result1_2b, "MathHelper.Clamp#1.2");

            // Test 2
            // Test behavior in extreme situations
            float result2_1 = MathHelper.Clamp(float.MaxValue, float.NaN, float.NaN);
            Assert.IsTrue(result2_1 == float.MaxValue, "MathHelper.Clamp#2.1");

            float result2_2 = MathHelper.Clamp(float.MinValue, float.NaN, float.NaN);
            Assert.IsTrue(result2_2 == float.MinValue, "MathHelper.Clamp#2.2");

            float result2_3 = MathHelper.Clamp(float.NaN, float.NaN, float.NaN);
            Assert.IsNaN(result2_3, "MathHelper.Clamp#2.3");

            float result2_4 = MathHelper.Clamp(float.NegativeInfinity, float.MinValue, float.MaxValue);
            Assert.IsTrue(result2_4 == float.MinValue, "MathHelper.Clamp#2.4");

            float result2_5 = MathHelper.Clamp(float.PositiveInfinity, float.MinValue, float.MaxValue);
            Assert.IsTrue(result2_5 == float.MaxValue, "MathHelper.Clamp#2.5");

            float result2_6 = MathHelper.Clamp(float.NaN, float.MinValue, float.MaxValue);
            Assert.IsNaN(result2_6, "MathHelper.Clamp#2.6");

            // Test 3
            // Test behavior when max < min
            float result3_1 = MathHelper.Clamp(float.MaxValue, float.MaxValue, float.MinValue);
            Assert.IsTrue(result3_1 == float.MaxValue, "MathHelper.Clamp#3.1");

            float result3_2 = MathHelper.Clamp(float.MinValue, float.MaxValue, float.MinValue);
            Assert.IsTrue(result3_2 == float.MaxValue, "MathHelper.Clamp#3.2");

            float result3_3 = MathHelper.Clamp(float.NaN, float.MaxValue, float.MinValue);
            Assert.IsNaN(result3_3, "MathHelper.Clamp#3.3");

            float result3_4 = MathHelper.Clamp(float.PositiveInfinity, float.MaxValue, float.MinValue);
            Assert.IsTrue(result3_4 == float.MaxValue, "MathHelper.Clamp#3.4");

            float result3_5 = MathHelper.Clamp(float.NegativeInfinity, float.MaxValue, float.MinValue);
            Assert.IsTrue(result3_5 == float.MaxValue, "MathHelper.Clamp#3.5");
        }

        [Test]
        public void DistanceTest()
        {
            // Test 1
            // Tests the distance between two floats putting one first, and then the other
            // Useful to see if absolute, positive distances are always returned
            float test1_1 = MathHelper.Distance(0f, 1f);
            float test1_2 = MathHelper.Distance(1f, 0f);
            Assert.IsTrue(test1_1 == test1_2, "MathHelper.Distance#1.1");
            Assert.IsTrue(test1_1 == 1f, "MathHelper.Distance#1.2");
        }

        [Test]
        public void HermiteTest()
        {
            float value0 = 0.0f;
            float value1 = 1.0f;
            float value2 = 2.34478912f;
            float value3 = -5.7f;
            float value4 = 367.2189f;

            // Test 1
            // Test for weighting factor = 0. Must be equal to first param
            float hermiteTest1_1 = MathHelper.Hermite(value0, value0, value0, value0, value0);
            Assert.IsTrue(hermiteTest1_1 == value0, "MathHelper.Hermite#1.1");

            float hermiteTest1_2 = MathHelper.Hermite(value4, value4, value4, value4, value0);
            Assert.IsTrue(hermiteTest1_2 == value4, "MathHelper.Hermite#1.2");

            float hermiteTest1_3 = MathHelper.Hermite(value1, value2, value3, value4, value0);
            Assert.IsTrue(hermiteTest1_3 == value1, "MathHelper.Hermite#1.3");

            // Test 2
            // Check for weighting factor = 1. Must be equal to third param
            float hermiteTest2_1 = MathHelper.Hermite(value1, value2, value3, value4, value1);
            Assert.IsTrue(hermiteTest2_1 == value3, "MathHelper.Hermite#2.1");

            float hermiteTest2_2 = MathHelper.Hermite(value3, value1, value4, value1, value1);
            Assert.IsTrue(hermiteTest2_2 == value4, "MathHelper.Hermite#2.2");

            float hermiteTest2_3 = MathHelper.Hermite(value3, value0, value3, value0, value1);
            Assert.IsTrue(hermiteTest2_3 == value3, "MathHelper.Hermite#2.3");

            float hermiteTest2_4 = MathHelper.Hermite(1f, 12.59938495E12f, -8998.90034E22f, -6.75f, 1f);
            Assert.IsTrue(hermiteTest2_4 == -8998.90034E22f, "MathHelper.Hermite#2.4");

            // Test 3
            // Check result against function used in the open implementation
            // Useful to compare results between both implementations
            float hermiteTest3 = MathHelper.Hermite(value0, value1, value2, value3, value4);
            float hermiteTest3_1 = (2 * value0 - 2 * value2 + value1 + value3) * (float)Math.Pow(value4, 3) +
                (3 * value2 - 3 * value0 - 2 * value1 - value3) * (float)Math.Pow(value4, 2) +
                value1 * value4 +
                value0;
            Assert.IsTrue(TestHelper.ApproximatelyEquals(hermiteTest3, hermiteTest3_1), "MathHelper.Hermite#3");

            // Test 4
            // Test min values
            float hermiteTest4 = MathHelper.Hermite(float.MinValue, float.MinValue, float.MinValue, float.MinValue, float.MinValue);
            Assert.IsTrue(hermiteTest4 == float.PositiveInfinity, "MathHelper.Hermite#4\n" + hermiteTest4.ToString());

            // Test 5
            // Test max values
            float hermiteTest5 = MathHelper.Hermite(float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue);
            Assert.IsTrue(hermiteTest5 == float.PositiveInfinity, "MathHelper.Hermite#5\n" + hermiteTest5.ToString());

            // Test 6
            // Test NaN
            float hermiteTest6 = MathHelper.Hermite(float.NaN, float.NaN, float.NaN, float.NaN, float.NaN);
            Assert.IsNaN(hermiteTest6, "MathHelper.Hermite#6\n" + hermiteTest6.ToString());

            // Test 7
            // Test Infinity
            float hermiteTest7_1 = MathHelper.Hermite(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
            Assert.IsNaN(hermiteTest7_1, "MathHelper.Hermite#7.1\n" + hermiteTest7_1.ToString());

            float hermiteTest7_2 = MathHelper.Hermite(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
            Assert.IsNaN(hermiteTest7_2, "MathHelper.Hermite#7.2\n" + hermiteTest7_2.ToString());
        }

        [Test]
        public void LerpTest()
        {
            // Test 1
            // Check result against function used in the open implementation
            // Useful to compare results between both implementations
            float result1_1 = MathHelper.Lerp(1f, 5f, 3.6f);
            float result1_2 = 1f + (5f - 1f) * 3.6f;
            Assert.IsTrue(result1_1 == result1_2, "MathHelper.Lerp#1");
        }

        [Test]
        public void MaxTest()
        {
            // Test 1
            float result1_1 = MathHelper.Max(float.MaxValue, float.NaN);
            float result1_2 = Math.Max(float.MaxValue, float.NaN);
            Assert.IsTrue(result1_1.Equals(result1_2), "MathHelper.Max#1.1");
            Assert.IsNaN(result1_1, "MathHelper.Max#1.2");

            // Test 2
            float result2_1 = MathHelper.Max(float.MaxValue, float.PositiveInfinity);
            float result2_2 = Math.Max(float.MaxValue, float.PositiveInfinity);
            Assert.IsTrue(result2_1 == result2_2, "MathHelper.Max#2.1");
            Assert.IsTrue(result2_1 == float.PositiveInfinity, "MathHelper.Max#2.2");
        }

        [Test]
        public void MinTest()
        {
            // Test 1
            float result1_1 = MathHelper.Min(float.MaxValue, float.NaN);
            float result1_2 = Math.Min(float.MaxValue, float.NaN);
            Assert.IsTrue(result1_1.Equals(result1_2), "MathHelper.Min#1.1");
            Assert.IsNaN(result1_1, "MathHelper.Min#1.2");

            // Test 2
            float result2_1 = MathHelper.Min(float.MinValue, float.NegativeInfinity);
            float result2_2 = Math.Min(float.MinValue, float.NegativeInfinity);
            Assert.IsTrue(result2_1 == result2_2, "MathHelper.Min#2.1");
            Assert.IsTrue(result2_1 == float.NegativeInfinity, "MathHelper.Min#2.2");
        }

        [Test]
        public void ToDegreesTest()
        {
            const float pi = 3.1415926535897932384626433832795f;
            const double dpi = 3.1415926535897932384626433832795;

            const float factor = 180 / pi;
            const double dfactor = 180 / dpi;

            // Test 1
            // Check that internally it uses double instead of float to transform
            float test1_1 = MathHelper.ToDegrees(2.8756904f);
            float test1_2 = (2.8756904f) * factor;
            float test1_3 = (float)((2.8756904f) * dfactor);
#if MSXNAONLY
            // This test crashes on Mono, maybe because a different treatment to float
            // It is required to have this comparison to check against MSXNA only, though
            Assert.IsTrue(test1_1 != test1_2, "MathHelper.ToDegrees#1.1");
#endif
            Assert.IsTrue(test1_1 == test1_3, "MathHelper.ToDegrees#1.2");

            // Test 2
            // Check that internally it uses a hand-made constant slightly different from
            // factor = 180 / pi
            float test2_1 = MathHelper.ToDegrees(7.9912357f);
            float test2_2 = (7.9912357f) * factor;
            float test2_3 = (float)((7.9912357f) * dfactor);
            // This shows that MS implementation uses a different constant to transform
#if MSXNAONLY
            // This test crashes on Mono, maybe because a different treatment to float
            // It is required to have this comparisons to check against MSXNA only, though
            Assert.IsTrue(test2_1 != test2_2, "MathHelper.ToDegrees#2.1");
            Assert.IsTrue(test2_1 != test2_3, "MathHelper.ToDegrees#2.2");
#endif
            // Yet is very close to the mathematical approach factor = 180 / pi
            Assert.IsTrue(TestHelper.ApproximatelyEquals(test2_1, test2_2), "MathHelper.ToDegrees#2.3");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(test2_1, test2_3), "MathHelper.ToDegrees#2.3");
        }

        [Test]
        public void ToRadiansTest()
        {
            const float pi = 3.1415926535897932384626433832795f;
            const double dpi = 3.1415926535897932384626433832795;

            const float factor = pi / 180;
            const double dfactor = dpi / 180;

            // Test 1
            // Check that internally it uses double instead of float to transform
            float test1 = MathHelper.ToRadians(123.5671f);
            float test1_1 = (float)((123.5671f) * dfactor);
            Assert.IsTrue(test1 == test1_1, "MathHelper.ToRadians#1.1");
        }

        [Test]
        public void SmoothStepTest()
        {
            float v1, v2, w1, w2;

            // Test 1
            // Check result against function used in the open implementation
            // Useful to compare results between both implementations
            v1 = 0f; v2 = 1f; w1 = 0.7f;
            float result1a = MathHelper.SmoothStep(v1, v2, w1);
            // Test that internally uses Hermite method after Clamp
            w2 = MathHelper.Clamp(w1, 0f, 1f);
            float result1b = MathHelper.Hermite(v1, 0f, v2, 0f, w2);
            Assert.IsTrue(result1a == result1b, "MathHelper.SmoothStep#1" + result1a + "#" + result1b);

            // Test 2
            // Test for values > 1 and < 0
            v1 = 30f; v2 = 157.889E30f; w1 = 0.544E13f;
            float result2a = MathHelper.SmoothStep(v1, v2, w1);
            // Test that internally uses Hermite method after Clamp
            w2 = MathHelper.Clamp(w1, 0f, 1f);
            float result2b = MathHelper.Hermite(v1, 0f, v2, 0f, w2);
            Assert.IsTrue(result2a == result2b, "MathHelper.SmoothStep#2");

            // Test 3
            // Value tests
            float result3_1 = MathHelper.SmoothStep(1f, 0.5f, 0.45f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(result3_1, 0.787375f), result3_1 + "MathHelper.SmoothStep#3.1");

            float result3_2 = MathHelper.SmoothStep(01f, 0.05f, 0.045f);
            Assert.IsTrue(result3_2.Equals(0.9944019f), result3_2 + "MathHelper.SmoothStep#3.2");

            float result3_3 = MathHelper.SmoothStep(-71E33f, 0.55f, 0.45f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(result3_3, -4.080725E34f), result3_3 + "MathHelper.SmoothStep#3.3");

            float result3_4 = MathHelper.SmoothStep(1f, -0.5f, 0.45f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(result3_4, 0.362125f), result3_4 + "MathHelper.SmoothStep#3.4");
        }
    }
}
