#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.

Authors:
 * Alan McGovern

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
    public class Vector4Tests
    {
        Vector4 a;
        Vector4 b;
        Vector4 c;

        [SetUp]
        public void Setup()
        {
            a = new Vector4(1, 2, 3, 4);
            b = new Vector4(4.5f, 6f, 7f, -1.5363f);
            c = new Vector4(-124, 352.234f, 123.123f, -108.32532f);
        }


        [Test]
        public void Constructors()
        {
            // Default constructor
            Vector4 v = new Vector4();
            Assert.AreEqual(0, v.X, "Constructor#1.X");
            Assert.AreEqual(0, v.Y, "Constructor#1.Y");
            Assert.AreEqual(0, v.Z, "Constructor#1.Z");
            Assert.AreEqual(0, v.W, "Constructor#1.W");

            // Overloaded constructor, argument float
            v = new Vector4(1.2f);
            Assert.AreEqual(1.2f, v.X, "Constructor#2.X");
            Assert.AreEqual(1.2f, v.Y, "Constructor#2.Y");
            Assert.AreEqual(1.2f, v.Z, "Constructor#2.Z");
            Assert.AreEqual(1.2f, v.W, "Constructor#2.W");

            // Overloaded constructor, three coordinates float
            v = new Vector4(1.2f, 2.2f, 3.2f, 4.6f);
            Assert.AreEqual(1.2f, v.X, "Constructor#3.X");
            Assert.AreEqual(2.2f, v.Y, "Constructor#3.Y");
            Assert.AreEqual(3.2f, v.Z, "Constructor#3.Z");
            Assert.AreEqual(4.6f, v.W, "Constructor#3.W");

            // Overloaded constructor, a Vector2 and a float
            v = new Vector4(new Vector2(2.0f, -3.5f), 4.0f, 4.6f);
            Assert.AreEqual(2.0f, v.X, "Constructor#6.X");
            Assert.AreEqual(-3.5f, v.Y, "Constructor#6.Y");
            Assert.AreEqual(4.0f, v.Z, "Constructor#6.Z");
            Assert.AreEqual(4.6f, v.W, "Constructor#6.W");

            // Overloaded constructor, a Vector2 and a float
            v = new Vector4(new Vector3(2.0f, -3.5f, 4.0f), 4.6f);
            Assert.AreEqual(2.0f, v.X, "Constructor#6.X");
            Assert.AreEqual(-3.5f, v.Y, "Constructor#6.Y");
            Assert.AreEqual(4.0f, v.Z, "Constructor#6.Z");
            Assert.AreEqual(4.6f, v.W, "Constructor#6.W");
        }

        [Test]
        public void AddTest()
        {
            Vector4 cloneOfA = a;
            Vector4 expected = new Vector4(2, 4, 6, 8);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, a + a), "#1");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector4.Add(a, a)), "#2");

            Vector4.Add(ref a, ref a, out b);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, b), "#3");
            Assert.AreEqual(cloneOfA, a, "#4");
        }

        [Test]
        public void BarycentricTest()
        {
            Vector4 expected;

            expected = new Vector4(174.2175f, -454.0052f, -147.8177f, 141.2125f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector4.Barycentric(a, b, c, 2.124215f, -1.326262f)), "#1");

            expected = new Vector4(-263.8197f, 746.7805f, 258.9753f, -235.7217f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector4.Barycentric(b, c, a, 2.124215f, -1.326262f)), "#2");

            // Test 3
            // Check if its implementation uses MathHelper
            Vector4 v1 = Vector4.Barycentric(a, b, c, -0.5f, 6.78f);
            Vector4 v2 = new Vector4(
                MathHelper.Barycentric(a.X, b.X, c.X, -0.5f, 6.78f),
                MathHelper.Barycentric(a.Y, b.Y, c.Y, -0.5f, 6.78f),
                MathHelper.Barycentric(a.Z, b.Z, c.Z, -0.5f, 6.78f),
                MathHelper.Barycentric(a.W, b.W, c.W, -0.5f, 6.78f));
            Assert.IsTrue(v1 == v2, "Barycentric#3");
        }

        [Test]
        public void CatmullromTests()
        {
            Vector4 expected;
            Vector4 d = new Vector4(12.2352f, -1.23525f, 3.1234f, 51.3415f);

            expected = new Vector4(402160.9f, -1056407f, -353251.4f, 374571.3f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector4.CatmullRom(a, b, c, d, 13.125123f)), "#1");

            expected = new Vector4(-551.6433f, 1464.028f, 505.8189f, -674.8631f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector4.CatmullRom(b, d, c, a, -1.125123f)), "#1");
        }

        [Test]
        public void ClampTest()
        {
            Vector4 cloneOfC = c;
            Vector4 expected;
            Vector4 result;
            Vector4 max = new Vector4(10, 10, 10, 10);
            Vector4 min = new Vector4(-10, -10, -10, -10);

            expected = a;
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector4.Clamp(a, min, max)), "#1");

            expected = new Vector4(-10, 10, 10, -10);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector4.Clamp(c, min, max)), "#2");

            expected = new Vector4(-10, 10, 10, -10);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector4.Clamp(c, max, min)), "#3");

            expected = new Vector4(-10, 10, 10, -10);
            Vector4.Clamp(ref c, ref max, ref min, out result);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, result), "#4");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(new Vector4(10, 10, 10, 10), max), "#5");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(new Vector4(-10, -10, -10, -10), min), "#6");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(cloneOfC, c), "#7");
        }

        [Test]
        public void DistanceTest()
        {
            Vector4 origin = new Vector4(0, 0, 0, 0);

            // Origin as source vector
            Assert.AreEqual(1, Vector4.Distance(Vector4.UnitX, origin), "Distance#1");
            Assert.AreEqual(1, Vector4.Distance(Vector4.UnitY, origin), "Distance#2");
            Assert.AreEqual(1, Vector4.Distance(Vector4.UnitZ, origin), "Distance#3");
            Assert.AreEqual(1, Vector4.Distance(Vector4.UnitW, origin), "Distance#4");

            Assert.IsTrue(TestHelper.ApproximatelyEquals(8.654514f, Vector4.Distance(a, b)), "#5");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(401.5952f, Vector4.Distance(b, c)), "#6");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(406.6145f, Vector4.Distance(c, a)), "#7");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(406.6145f, Vector4.Distance(a, c)), "#8");

            // Test 9
            // Tests the distance between two vectors putting one first, and then the other
            // Useful to see that absolute, positive distances are always returned
            float test9_1 = Vector4.Distance(new Vector4(0f, 0f, 0f, 0f), new Vector4(1f, 1f, 1f, 1f));
            float test9_2 = Vector4.Distance(new Vector4(1f, 1f, 1f, 1f), new Vector4(0f, 0f, 0f, 0f));
            Assert.IsTrue(test9_1 == test9_2, "Vector2.Distance#9");
        }

        [Test]
        public void DistanceSquaredTest()
        {
            Assert.IsTrue(TestHelper.ApproximatelyEquals(74.90062f, Vector4.DistanceSquared(a, b)), "#1");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(161278.7f, Vector4.DistanceSquared(b, c)), "#2");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(165335.4f, Vector4.DistanceSquared(c, a)), "#3");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(165335.4f, Vector4.DistanceSquared(a, c)), "#4");
        }

        [Test]
        public void DivideTest()
        {
            Vector4 cloneOfA = a;
            Vector4 result;
            Vector4 expected = new Vector4(0.5f, 1, 1.5f, 2);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, a / 2), "#1");
            Vector4.Divide(ref a, 2, out result);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, result), "#2");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(cloneOfA, a), "#3");

            expected = new Vector4(0.2222222f, 0.3333333f, 0.4285714f, -2.603658f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, a / b), "#4");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector4.Divide(a, b)), "#5");
        }

        [Test]
        public void DotTest()
        {
            float expected = 31.3548f;
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector4.Dot(a, b)), "#1");

            expected = 2583.685f;
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector4.Dot(b, c)), "#2");
        }

        [Test]
        public void LengthTest()
        {
            Assert.IsTrue(TestHelper.ApproximatelyEquals(5.477226f, a.Length()), "#1");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(10.37353f, b.Length()), "#2");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(407.8461f, c.Length()), "#3");
        }

        [Test]
        public void LengthSquaredTest()
        {
            Assert.IsTrue(TestHelper.ApproximatelyEquals(30, a.LengthSquared()), "#1");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(107.6102f, b.LengthSquared()), "#2");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(166338.4f, c.LengthSquared()), "#3");
        }

        [Test]
        public void Lerp()
        {
            Vector4 expected;

            expected = new Vector4(8.437923f, 10.50048f, 11.50048f, -7.765308f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector4.Lerp(a, b, 2.125121f)), "#1");

            expected = new Vector4(-264.6401f, 746.2897f, 258.2759f, -234.7049f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector4.Lerp(a, c, 2.125121f)), "#2");
        }

        [Test]
        public void MaxTest()
        {
            Vector4 expected;

            expected = new Vector4(4.5f, 6f, 7f, 4f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector4.Max(a, b)), "#1");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector4.Max(b, a)), "#2");

            expected = new Vector4(4.5f, 352.234f, 123.123f, -1.5363f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector4.Max(c, b)), "#3");
        }

        [Test]
        public void MinTest()
        {
            Vector4 expected;

            expected = new Vector4(1, 2, 3, -1.5363f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector4.Min(a, b)), "#1");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector4.Min(b, a)), "#2");

            expected = new Vector4(-124, 6f, 7f, -108.3253f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector4.Min(c, b)), "#3");
        }

        [Test]
        public void NegateTest()
        {
            Vector4 expected = new Vector4(-1, -2, -3, -4);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, -a), "#1");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector4.Negate(a)), "#1");
        }

        [Test]
        public void NormalizeTest()
        {
            Vector4 expected = new Vector4(0.1825742f, 0.3651484f, 0.5477225f, 0.7302967f);
            Vector4 cloneOfA = a;
            cloneOfA.Normalize();

            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, cloneOfA), "#1");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector4.Normalize(a)), "#2");

            Vector4.Normalize(ref a, out a);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, a), "#3");
        }

        [Test]
        public void SmoothStepTest()
        {
            Vector4 value0 = new Vector4(0f, 0f, 0f, 0f);
            Vector4 value1 = new Vector4(1f, 1f, 1f, 1f);
            Vector4 value2 = new Vector4(-3.567f, 45.2347f, 33.67E4f, 25.66901256723f);
            Vector4 value3 = new Vector4(1.49987E29f, -4.34889E30f, -12.6E30f, 6.33903762E-30f);

            // Simple tests
            // Test the implementation and the results via MathHelper
            // to show that this method uses MatHelper behind
            Vector4 test1 = Vector4.SmoothStep(value0, value3, 0f);
            Assert.IsTrue(test1 == value0, "Vector4.SmoothStep#1");

            Vector4 test2 = Vector4.SmoothStep(value0, value3, 0.5f);
            Assert.IsTrue(test2.X == (float)((value0.X + value3.X) * 0.5) && test2.Y == (float)((value0.Y + value3.Y) * 0.5), "Vector4.SmoothStep#2");

            Vector4 test3a = Vector4.SmoothStep(value1, value2, 0.35f);
            Vector4 test3b = new Vector4(
                MathHelper.SmoothStep(value1.X, value2.X, 0.35f),
                MathHelper.SmoothStep(value1.Y, value2.Y, 0.35f),
                MathHelper.SmoothStep(value1.Z, value2.Z, 0.35f),
                MathHelper.SmoothStep(value1.W, value2.W, 0.35f));
            Assert.IsTrue(test3a == test3b, "Vector4.SmoothStep#3");

            float factor = 0.4467E15f;
            Vector4 test4a = Vector4.SmoothStep(value3, value0, factor);
            factor = MathHelper.Clamp(factor, 0f, 1f);
            Vector4 test4b = new Vector4(
                MathHelper.Hermite(value3.X, 0f, value0.X, 0f, factor),
                MathHelper.Hermite(value3.Y, 0f, value0.Y, 0f, factor),
                MathHelper.Hermite(value3.Z, 0f, value0.Z, 0f, factor),
                MathHelper.Hermite(value3.W, 0f, value0.W, 0f, factor));
            Assert.IsTrue(test4a == test4b, "Vector4.SmoothStep#4");
        }

        [Test]
        public void ToStringTest()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-IE");
            Assert.AreEqual("{X:-124 Y:352.234 Z:123.123 W:-108.3253}", c.ToString(), "#1");

            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("de-DE");
            Assert.AreEqual("{X:-124 Y:352,234 Z:123,123 W:-108,3253}", c.ToString(), "#2");

            Vector4 v = new Vector4(1324.2353252353223f, 1324.2353252353223f, 1324.2353252353223f, -108.325345f);
            Assert.AreEqual("{X:1324,235 Y:1324,235 Z:1324,235 W:-108,3253}", v.ToString(), "#3");
        }

        [Test]
        public void TransformTest()
        {
            Matrix m = new Matrix(135, 11, 53, 1, 6, 1, 47, 2, 51, 36, 743, 2, 15, 35, 6, 2);

            Vector4 expected = new Vector4(1338.455f, 79.3959f, -5015.873f, -230.9282f);
            //Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector4.Transform(new Vector2(15.32f, -124.1241f), m)), "#1");
			Assert.AreEqual(TestHelper.Approximate(expected), TestHelper.Approximate(Vector4.Transform(new Vector2(15.32f, -124.1241f), m)), "#1");
			
            expected = new Vector4(2619.779f, 983.8599f, 13651.26f, -180.6802f);
            Assert.AreEqual(TestHelper.Approximate(expected), TestHelper.Approximate(Vector4.Transform(new Vector3(15.32f, -124.1241f, 25.124f), m)), "#2");

            expected = new Vector4(4041.455f, 1987.396f, 34363.13f, -124.9282f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector4.Transform(new Vector4(15.32f, -124.1241f, 53, 1), m)), "#3");
        }

        [Test]
        public void HermiteTest()
        {
            // Both Hermite methods do the same.
            // Here is using th simple form.
            Vector4 v0 = new Vector4(0f, 0f, 0f, 0f);
            Vector4 v1 = new Vector4(1f, 1f, 1f, 1f);
            Vector4 v2 = new Vector4(4.5f, 77.34119f, 345.445f, 12.59938495E12f);
            Vector4 v3 = new Vector4(-55.99021f, -1344.22f, -67798f, -8998.90034E22f);
            Vector4 v4 = new Vector4(-2007.0619f, 1985.0604f, 0f, -6.75f);

            // Test 1
            // Check values for amount = 0
            Vector4 test1_1 = Vector4.Hermite(v0, v0, v0, v0, 0f);
            Assert.IsTrue(test1_1 == v0, "Vector4.Hermite#1.1");

            Vector4 test1_2 = Vector4.Hermite(v2, v3, v1, v4, 0f);
            Assert.IsTrue(test1_2 == v2, "Vector4.Hermite#1.2");

            // Test 2
            // Check values for amount = 1
            Vector4 test2_1 = Vector4.Hermite(v0, v0, v0, v0, 1f);
            Assert.IsTrue(test2_1 == v0, "Vector4.Hermite#2.1");

            Vector4 test2_2 = Vector4.Hermite(v2, v3, v1, v4, 1f);
            Assert.IsTrue(test2_2 == v1, "Vector4.Hermite#2.2");

            // Test 3
            // Tests against the MS implementation the open implementation
            // Useful to find out whether our implementation does the same than MS's
            Vector4 test3 = Vector4.Hermite(v1, v2, v3, v4, -3.6f);
            Vector4 test3_1 = new Vector4();
            test3_1.X = MathHelper.Hermite(v1.X, v2.X, v3.X, v4.X, -3.6f);
            test3_1.Y = MathHelper.Hermite(v1.Y, v2.Y, v3.Y, v4.Y, -3.6f);
            test3_1.Z = MathHelper.Hermite(v1.Z, v2.Z, v3.Z, v4.Z, -3.6f);
            test3_1.W = MathHelper.Hermite(v1.W, v2.W, v3.W, v4.W, -3.6f);
            Assert.IsTrue(test3 == test3_1, "Vector4.Hermite#3");
        }
    }
}
