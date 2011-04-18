#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.

Authors
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
#endregion License

using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Microsoft.Xna.Framework;
using System.Globalization;

namespace Tests.Microsoft.Xna.Framework
{
    [TestFixture]
    public class Vector2Tests
    {
        private Vector2 v1;
        private Vector2 v2;
        private Vector2 v3;


        [SetUp]
        public void Setup()
        {
            v1 = new Vector2(12.3254f, 15.2513531f);
            v2 = new Vector2(4.54f, -21.251353f);
            v3 = new Vector2(-16.3254f, 65.251353f);
        }

		[Test]
		public void ReflectTest()
		{
			Vector2 v1 = new Vector2(30, 50);
			Vector2 v2 = new Vector2(50, 30);
			Vector2 result = new Vector2();
			Vector2 expected = new Vector2(-299970,-179950);
			
			Vector2.Reflect(ref v1, ref v2, out result);
			Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, result), "#1");
			
			v1 = new Vector2(0.5f, 0.5f);
			v2 = new Vector2(0.0f, 1.0f);
			result = Vector2.Reflect(v1, v2);
			expected = new Vector2(0.5f, -0.5f);
			Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, result), "#2");

			v1 = new Vector2(1.1f, -0.77f);
			v2 = new Vector2(0.33f, -2.04f);
			result = Vector2.Reflect(v1, v2);
			expected = new Vector2(-0.176308f, 7.119904f);
			Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, result), "#3");
			
		}
		
        [Test]
        public void AddTest()
        {
            Vector2 actual;
            Vector2 originalv2 = v2;
            Vector2 expected = new Vector2(16.8654f, -5.999999f);

            actual = v1 + v2;
            Assert.AreEqual(expected, actual, "#1");

            actual = Vector2.Add(v1, v2);
            Assert.AreEqual(expected, actual, "#2");

            Vector2.Add(ref v1, ref v2, out actual);
            Assert.AreEqual(expected, actual, "#3");

            Vector2.Add(ref v1, ref v2, out v1);
            Assert.AreEqual(expected, v1, "#4");
            Assert.AreEqual(v2, originalv2, "#5");
        }

        [Test]
        public void BarycentricTests()
        {
            Vector2 expected = new Vector2(-9.757494f, 46.27595f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector2.Barycentric(this.v1, this.v2, this.v3, 0.15f, 0.73f)), "#1");

            expected = new Vector2(-126.5385f, -501.2646f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector2.Barycentric(this.v1, this.v2, this.v3, 15.15f, 0.73f)), "#2");

            expected = new Vector2(-153.0115f, 296.2759f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector2.Barycentric(this.v1, this.v2, this.v3, 0.15f, 5.73f)), "#3");

            // Check the work of this function according to MathHelper.Barycentric
            Vector2 mathMade = new Vector2();
            mathMade.X = MathHelper.Barycentric(this.v1.X, this.v2.X, this.v3.X, -13.59f, 4.6E13f);
            mathMade.Y = MathHelper.Barycentric(this.v1.Y, this.v2.Y, this.v3.Y, -13.59f, 4.6E13f);
            expected = Vector2.Barycentric(this.v1, this.v2, this.v3, -13.59f, 4.6E13f);
            Assert.IsTrue(mathMade == expected, "#4");

        }

        [Test]
        public void CatmullromTests()
        {
            Vector2 expected;
            Vector2 v4 = new Vector2(12.2352f, -1.23525f);

            expected = new Vector2(63970.55f, -277344.4f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector2.CatmullRom(v1, v2, v3, v4, 13.125123f)), "#1");

            expected = new Vector2(-124.6975f, 198.7086f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector2.CatmullRom(v2, v4, v3, v1, -1.125123f)), "#1");
        }

        [Test]
        public void ClampTest()
        {
            Vector2 actual;
            Vector2 min = new Vector2(2, 2);
            Vector2 max = new Vector2(14, 14);

            actual = Vector2.Clamp(v1, min, max);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(new Vector2(12.3254f, 14), actual), "#1");

            actual = Vector2.Clamp(v2, min, max);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(new Vector2(4.54f, 2), actual), "#2");

            actual = Vector2.Clamp(v3, min, max);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(new Vector2(2, 14), actual), "#3");
        }

        [Test]
        public void ConstructorTest()
        {
            v1 = new Vector2();
            Assert.AreEqual(0, v1.X, "#1");
            Assert.AreEqual(0, v1.Y, "#2");

            v1 = new Vector2(14.125f);
            Assert.AreEqual(14.125f, v1.X, "#3");
            Assert.AreEqual(14.125f, v1.Y, "#4");

            v1 = new Vector2(1252.123f, -12.13536f);
            Assert.AreEqual(1252.123f, v1.X, "#5");
            Assert.AreEqual(-12.13536f, v1.Y, "#6");
        }

        [Test]
        public void DivideTest()
        {
            Vector2 actual;
            Vector2 originalv2 = v2;
            Vector2 expected = new Vector2(2.714846f, -0.7176651f);

            actual = v1 / v2;
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, actual), "#1");

            actual = Vector2.Divide(v1, v2);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, actual), "#2");

            Vector2.Divide(ref v1, ref v2, out actual);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, actual), "#3");

            Vector2.Divide(ref v1, ref v2, out v1);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, v1), "#4");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(v2, originalv2), "#5");

            Vector2 vec = new Vector2(5, 5);
            Vector2 divided = vec / 2;
            Assert.IsTrue(TestHelper.ApproximatelyEquals(new Vector2(2.5f, 2.5f), divided), "#6");

            divided = Vector2.Divide(vec, 2);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(new Vector2(2.5f, 2.5f), divided), "#7");

            Vector2.Divide(ref vec, 2, out divided);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(new Vector2(2.5f, 2.5f), divided), "#8");
        }

        [Test]
        public void DistanceTest()
        {
            float actual;
            Vector2 originalv2 = v2;

            actual = Vector2.Distance(v1, v2);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(37.32372f, actual), "#1");

            Vector2.Distance(ref v1, ref v2, out actual);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(37.32372f, actual), "#2");

            // Test 3
            // Tests the distance between two vectors putting one first, and then the other
            // Useful to see that absolute, positive distances are always returned
            float test3_1 = Vector2.Distance(new Vector2(0f, 0f), new Vector2(1f, 1f));
            float test3_2 = Vector2.Distance(new Vector2(1f, 1f), new Vector2(0f, 0f));
            Assert.IsTrue(test3_1 == test3_2, "Vector2.Distance#3");
        }

        [Test]
        public void DistanceSquaredTest()
        {
            float actual;
            Vector2 originalv2 = v2;

            actual = Vector2.DistanceSquared(v1, v2);
            Console.WriteLine("Actual: " + string.Format("{0:0.00000000}", actual));
            Assert.IsTrue(TestHelper.ApproximatelyEquals(1393.06f, actual), "#1");

            Vector2.DistanceSquared(ref v1, ref v2, out actual);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(1393.06f, actual), "#2");
        }

        [Test]
        public void DotTest()
        {
            float expected = -268.1546f;
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector2.Dot(v1, v2)), "#1");

            expected = -1460.797f;
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector2.Dot(v2, v3)), "#2");
        }

        [Test]
        public void EqualsTest()
        {
            int a = 5;
            Vector2 v = new Vector2(12.3254f, 15.2513531f);

            Assert.AreNotEqual(v1, v2, "#1");
            Assert.AreEqual(v1, v, "#2");
            Assert.IsTrue(v1 == v, "#3");
            Assert.IsTrue(v1 != v2, "#4");
            Assert.IsFalse(v1.Equals(a), "#5");
        }

        [Test]
        public void LengthTest()
        {
            Assert.IsTrue(TestHelper.ApproximatelyEquals(v1.Length(), 19.60916f));
        }

        [Test]
        public void LengthSquaredTest()
        {
            Assert.IsTrue(TestHelper.ApproximatelyEquals(v1.LengthSquared(), 384.5193f));
        }

        [Test]
        public void Lerp()
        {
            Vector2 expected;

            expected = new Vector2(-4.219518f, -62.32132f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector2.Lerp(v1, v2, 2.125121f)), "#1");

            expected = new Vector2(-48.56102f, 121.5074f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector2.Lerp(v1, v3, 2.125121f)), "#2");
        }

        [Test]
        public void MaxTest()
        {
            Vector2 expected = new Vector2(12.3254f, 65.251353f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector2.Max(v1, v3)), "#1");
        }

        [Test]
        public void MinTest()
        {
            Vector2 expected = new Vector2(4.54f, -21.251353f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector2.Min(v1, v2)), "#1");
        }

        [Test]
        public void MultiplyTest()
        {
            Vector2 actual;
            Vector2 originalv2 = v2;
            Vector2 expected = new Vector2(55.95732f, -324.1119f);

            actual = v1 * v2;
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, actual), "#1");

            actual = Vector2.Multiply(v1, v2);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, actual), "#2");

            Vector2.Multiply(ref v1, ref v2, out actual);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, actual), "#3");

            Vector2.Multiply(ref v1, ref v2, out v1);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, v1), "#4");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(v2, originalv2), "#5");
        }

        [Test]
        public void NegateTest()
        {
            Vector2 expected;

            expected = new Vector2(-12.3254f, -15.2513531f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, v1), "#1");

            expected = new Vector2(-4.54f, 21.251353f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, v2), "#2");

            expected = new Vector2(16.3254f, -65.251353f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, v3), "#3");
        }

        [Test]
        public void NormalizeTest()
        {
            v1.Normalize();
            Assert.IsTrue(TestHelper.ApproximatelyEquals(v1, new Vector2(0.6285531f, 0.7777666f)));
        }

        [Test]
        public void SmoothStep()
        {
            Vector2 value0 = new Vector2(0f, 0f);
            Vector2 value1 = new Vector2(1f, 1f);
            Vector2 value2 = new Vector2(-3.567f, 45.2347f);
            Vector2 value3 = new Vector2(1.49987E29f, -4.34889E30f);

            // Simple tests
            // Test the implementation and the results via MathHelper
            // to show that this method uses MatHelper behind
            Vector2 test1 = Vector2.SmoothStep(value0, value3, 0f);
            Assert.IsTrue(test1 == value0, "Vector2.SmoothStep#1");

            Vector2 test2 = Vector2.SmoothStep(value0, value3, 0.5f);
            Assert.IsTrue(test2.X == (float)((value0.X + value3.X) * 0.5) && test2.Y == (float)((value0.Y + value3.Y) * 0.5), "Vector2.SmoothStep#2");

            Vector2 test3a = Vector2.SmoothStep(value1, value2, 0.35f);
            Vector2 test3b = new Vector2(
                MathHelper.SmoothStep(value1.X, value2.X, 0.35f),
                MathHelper.SmoothStep(value1.Y, value2.Y, 0.35f));
            Assert.IsTrue(test3a == test3b, "Vector2.SmoothStep#3");

            float factor = 0.4467E15f;
            Vector2 test4a = Vector2.SmoothStep(value3, value0, factor);
            factor = MathHelper.Clamp(factor, 0f, 1f);
            Vector2 test4b = new Vector2(
                MathHelper.Hermite(value3.X, 0f, value0.X, 0f, factor),
                MathHelper.Hermite(value3.Y, 0f, value0.Y, 0f, factor));
            Assert.IsTrue(test4a == test4b, "Vector2.SmoothStep#4");
        }

        [Test]
        public void SubtractTest()
        {
            Vector2 actual;
            Vector2 originalv2 = v2;
            Vector2 expected = new Vector2(7.7854f, 36.5027f);

            actual = v1 - v2;
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, actual), "#1");

            actual = Vector2.Subtract(v1, v2);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, actual), "#2");

            Vector2.Subtract(ref v1, ref v2, out actual);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, actual), "#3");

            Vector2.Subtract(ref v1, ref v2, out v1);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, v1), "#4");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(v2, originalv2), "#5");
        }

        [Test]
        public void ToStringTest()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-IE");
            Assert.AreEqual("{X:12.3254 Y:15.25135}", v1.ToString());

            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("de-DE");
            Assert.AreEqual("{X:12,3254 Y:15,25135}", v1.ToString());
        }

        [Test]
        public void TransformTest()
        {
            Matrix m = new Matrix(1, 2, 3, 4, 5, 4, 5, 4, 3, 4, 5, 4, 7, 5, 3, 5);

            Vector2 expected = new Vector2(95.58217f, 90.65621f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector2.Transform(v1, m)), "#1");
        }

        [Test]
        public void TransformNormalTest()
        {
            Matrix m = new Matrix(1, 2, 3, 4, 5, 4, 5, 4, 3, 4, 5, 4, 7, 5, 3, 5);

            Vector2 expected = new Vector2(88.58217f, 85.65621f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector2.TransformNormal(v1, m)), "#1");
        }

        [Test]
        public void HermiteTest()
        {
            // Both Hermite methods do the same.
            // Here is using th simple form.
            Vector2 v0 = new Vector2(0f, 0f);
            Vector2 v1 = new Vector2(1f, 1f);
            Vector2 v2 = new Vector2(4.5f, 77.34119f);
            Vector2 v3 = new Vector2(-55.99021f, -1344.22f);
            Vector2 v4 = new Vector2(-2007.0619f, 1985.0604f);

            // Test 1
            // Check values for amount = 0
            Vector2 test1_1 = Vector2.Hermite(v0, v0, v0, v0, 0f);
            Assert.IsTrue(test1_1 == v0, "Vector2.Hermite#1.1");

            Vector2 test1_2 = Vector2.Hermite(v2, v3, v1, v4, 0f);
            Assert.IsTrue(test1_2 == v2, "Vector2.Hermite#1.2");

            // Test 2
            // Check values for amount = 1
            Vector2 test2_1 = Vector2.Hermite(v0, v0, v0, v0, 1f);
            Assert.IsTrue(test2_1 == v0, "Vector2.Hermite#2.1");

            Vector2 test2_2 = Vector2.Hermite(v2, v3, v1, v4, 1f);
            Assert.IsTrue(test2_2 == v1, "Vector2.Hermite#2.2");

            // Test 3
            // Tests against the MS implementation the open implementation
            // Useful to find out whether our implementation does the same than MS's
            Vector2 test3 = Vector2.Hermite(v1, v2, v3, v4, -3.6f);
            Vector2 test3_1 = new Vector2();
            test3_1.X = MathHelper.Hermite(v1.X, v2.X, v3.X, v4.X, -3.6f);
            test3_1.Y = MathHelper.Hermite(v1.Y, v2.Y, v3.Y, v4.Y, -3.6f);
            Assert.IsTrue(test3 == test3_1, "Vector2.Hermite#3");
        }
    }
}
