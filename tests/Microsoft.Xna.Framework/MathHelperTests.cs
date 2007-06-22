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
using Microsoft.Xna.Framework.Tests;

namespace Microsoft.Xna.Framework
{
    [TestFixture]
    public class MathHelperTests
    {
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
    }
}
