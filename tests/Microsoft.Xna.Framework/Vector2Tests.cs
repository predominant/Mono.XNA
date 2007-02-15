using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Microsoft.Xna.Framework;
using System.Globalization;

namespace Microsoft.Xna.Framework.Tests
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
        public void TransformNormalTest()
        {
            Matrix m = new Matrix(1, 2, 3, 4, 5, 4, 5, 4, 3, 4, 5, 4, 7, 5, 3, 5);
            Vector2 expected = new Vector2(88.58217f, 85.65621f);

            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, Vector2.TransformNormal(v1, m)), "#1");
        }
    }
}
