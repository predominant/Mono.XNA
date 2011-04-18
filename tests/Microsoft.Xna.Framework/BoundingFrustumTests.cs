#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.

Authors: Alan McGovern
 * Isaac Llopis (neozack@gmail.com)

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
using System.Globalization;
using NUnit.Framework;
using Microsoft.Xna.Framework;

namespace Tests.Microsoft.Xna.Framework
{
    /*
    [TestFixture]
    public class BoundingFrustumTests
    {
        #region Setup
        BoundingFrustum f;

        [SetUp]
        public void Setup()
        {
            f = new BoundingFrustum(new Matrix(1, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2));
        }
        #endregion


        #region Constructor Tests
        [Test]
        public void Constructor()
        {
        }
        #endregion Constructor Tests


        #region Method Tests
        [Test]
        public void Bottom()
        {
            Plane actual = f.Bottom;
            Plane expectedPlane = new Plane(-0.2900209f, -0.6767156f, -0.6767156f, -0.290021f);

            Assert.IsTrue(TestHelper.ApproximatelyEquals(expectedPlane, actual), "#1");
        }

        [Ignore("Not implemented")]
        [Test]
        public void ContainsBoundingBox()
        {
            ContainmentType r1;
            r1 = f.Contains(new BoundingBox(new Vector3(1, 2, 3), new Vector3(4, 5, 6)));
            Assert.AreEqual(ContainmentType.Intersects, r1, "BoundingBox#1");

            r1 = f.Contains(new BoundingBox(new Vector3(3, 3, 3), new Vector3(3.1f, 3.1f, 3.1f)));
            Assert.AreEqual(ContainmentType.Contains, r1, "BoundingBox#2");

            r1 = f.Contains(new BoundingBox(new Vector3(-1, -2, -3), new Vector3(-5, 5, -7)));
            Assert.AreEqual(ContainmentType.Disjoint, r1, "BoundingBox#3");

            r1 = f.Contains(new BoundingBox(new Vector3(-1, -1, -1), new Vector3(-1, -1, -1)));
            Assert.AreEqual(ContainmentType.Disjoint, r1, "BoundingBox#4");

            r1 = f.Contains(new BoundingBox(new Vector3(1, 1, 1), new Vector3(1, 1, 1)));
            Assert.AreEqual(ContainmentType.Intersects, r1, "BoundingBox#5");
        }

        [Ignore("Not implemented")]
        [Test]
        public void ContainsBoundingFrustum()
        {
            ContainmentType r1;

            r1 = f.Contains(new BoundingFrustum(new Matrix(5, 6, 7, 6, 5, 6, 7, 6, 5, 6, 7, 6, 5, 6, 7, 6)));
            Assert.AreEqual(ContainmentType.Contains, r1, "BoundingFrustum#1");

            r1 = f.Contains(new BoundingFrustum(new Matrix(1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1)));
            Assert.AreEqual(ContainmentType.Contains, r1, "BoundingFrustum#2");

            r1 = f.Contains(new BoundingFrustum(new Matrix(45, 23, 1, 7, 45, 2, 6, 2, 45, 8, 23, 8, 13, 79, 1, 2)));
            Assert.AreEqual(ContainmentType.Disjoint, r1, "BoundingFrustum#3");
        }

        [Ignore("Not implemented")]
        [Test]
        public void ContainsBoundingSphere()
        {
            ContainmentType r1;

            r1 = f.Contains(new BoundingSphere(new Vector3(2, 5, 7), 1135));
            Assert.AreEqual(ContainmentType.Intersects, r1, "BoundingSphere#1");

            r1 = f.Contains(new BoundingSphere(new Vector3(312, 53, 124), 11));
            Assert.AreEqual(ContainmentType.Contains, r1, "BoundingSphere#2");

            r1 = f.Contains(new BoundingSphere(new Vector3(5, 5, 5), 5));
            Assert.AreEqual(ContainmentType.Intersects, r1, "BoundingSphere#3");
        }

        [Test]
        public void ContainsPoint()
        {
            ContainmentType r1;

            r1 = f.Contains(new Vector3(2, 3, 5));
            Assert.AreEqual(ContainmentType.Disjoint, r1, "Point#1");

            r1 = f.Contains(new Vector3(245, 3, 121));
            Assert.AreEqual(ContainmentType.Contains, r1, "Point#2");

            r1 = f.Contains(new Vector3(1245, 35, 124));
            Assert.AreEqual(ContainmentType.Contains, r1, "Point#3");
        }

        [Ignore("Not implemented")]
        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void ContainsNull()
        {
            f.Contains(null);
        }


        [Test]
        public void EqualsTest()
        {
            BoundingFrustum clone = new BoundingFrustum(new Matrix(1, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2));
            BoundingFrustum bf = new BoundingFrustum(new Matrix(5, 5, 5, 4, 5, 4, 5, 7, 8, 7, 2, 234, 135, 35, 457, 3));

            Assert.IsTrue(f.Equals(f), "#1");
            Assert.IsFalse(f.Equals(bf), "#2");

            Assert.IsTrue(f == f, "#3");
            Assert.IsFalse(f == bf, "#4");

            Assert.IsTrue(f != bf, "#5");
            Assert.IsFalse(f != f, "#6");

            Assert.IsFalse(f.Equals(null), "#7");
            Assert.IsFalse(f.Equals(new int()), "#8");

            Assert.IsTrue(f.Equals(clone), "#9");
            Assert.IsTrue(f == clone, "#10");

            this.f.Matrix = new Matrix(123, 123, 123, 123, 123, 35, 246, 13, 2642, 315, 236, 357, 134, 246, 468, 2345);
            Assert.AreNotEqual(f.Left, clone.Left, "#11");
        }


        [Test]
        public void Far()
        {
            Plane actual = f.Far;
            Plane expectedPlane = new Plane(-0.5773503f, -0.5773503f, 0.5773503f, 0.577350259f);

            Assert.IsTrue(TestHelper.ApproximatelyEquals(expectedPlane, actual), "#1 Expected: " + expectedPlane.ToString() + ". Actual: " +actual.ToString());
        }

        [Ignore("Not implemented")]
        [Test]
        public void GetCorners()
        {
            Vector3[] actual = f.GetCorners();
            Vector3 expected;

            expected = new Vector3(-0.2035509f, 0.4311078f, -0.7724431f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, actual[0]), "#1 Expected: " + expected.ToString() + ". Actual: " + actual.ToString());


            expected = new Vector3(0.6471122f, -0.1765087f, -0.5293965f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, actual[1]), "#2 Expected: " + expected.ToString() + ". Actual: " + actual.ToString());


            expected = new Vector3(0.4168671f, -0.01204799f, -0.5951808f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, actual[2]), "#3 Expected: " + expected.ToString() + ". Actual: " + actual.ToString());


            expected = new Vector3(2.676686f, -1.626205f, 0.05048257f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, actual[3]), "#4 Expected: " + expected.ToString() + ". Actual: " + actual.ToString());


            expected = new Vector3(-0.5333411f, 0.6666722f, -0.8666689f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, actual[4]), "#5 Expected: " + expected.ToString() + ". Actual: " + actual.ToString());


            expected = new Vector3(float.NaN, float.NaN, float.NaN);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, actual[5]), "#6 Expected: " + expected.ToString() + ". Actual: " + actual.ToString());


            expected = new Vector3(float.NaN, float.NaN, float.NaN);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, actual[6]), "#7 Expected: " + expected.ToString() + ". Actual: " + actual.ToString());


            expected = new Vector3(0.02839667f, 0.2654309f, -0.7061724f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(expected, actual[7]), "#8 Expected: " + expected.ToString() + ". Actual: " + actual.ToString());
        }

        [Ignore("Not implemented")]
        [Test]
        public void IntersectsBoundingBox()
        {
            bool r2;
            r2 = f.Intersects(new BoundingBox(new Vector3(1, 2, 3), new Vector3(4, 5, 6)));
            Assert.AreEqual(false, r2, "BoundingBox#1");
        }

        [Ignore("Not implemented")]
        [Test]
        public void IntersectsBoundingFrustum()
        {
            bool r2;
            r2 = f.Intersects(new BoundingFrustum(new Matrix(5, 6, 7, 6, 5, 6, 7, 6, 5, 6, 7, 6, 5, 6, 7, 6)));
            Assert.AreEqual(true, r2, "BoundingFrustum#1");

            r2 = f.Intersects(new BoundingFrustum(new Matrix(1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1)));
            Assert.AreEqual(true, r2, "BoundingFrustum#2");

            r2 = f.Intersects(new BoundingFrustum(new Matrix(45, 23, 1, 7, 45, 2, 6, 2, 45, 8, 23, 8, 13, 79, 1, 2)));
            Assert.AreEqual(false, r2, "BoundingFrustum#3");
        }

        [Ignore("Not implemented")]
        [Test]
        public void IntersectsBoundingSphere()
        {

            bool r2;
            r2 = f.Intersects(new BoundingSphere(new Vector3(2, 5, 7), 1135));
            Assert.AreEqual(true, r2, "BoundingSphere#1");

            r2 = f.Intersects(new BoundingSphere(new Vector3(312, 53, 124), 11));
            Assert.AreEqual(false, r2, "BoundingSphere#2");

            r2 = f.Intersects(new BoundingSphere(new Vector3(5, 5, 5), 5));
            Assert.AreEqual(false, r2, "BoundingSphere#3");
        }

        [Ignore("Not implemented")]
        [Test]
        public void IntersectsPlane()
        {
            PlaneIntersectionType r3;
            r3 = f.Intersects(new Plane(new Vector4(1, 2, 3, 4)));
            Assert.AreEqual(PlaneIntersectionType.Intersecting, r3, "Plane#1");

            r3 = f.Intersects(new Plane(new Vector4(5, 422, 12, 31)));
            Assert.AreEqual(PlaneIntersectionType.Intersecting, r3, "Plane#2");
        }

        [Ignore("Not implemented")]
        [Test]
        public void IntersectsRay()
        {
            float? r4;
            r4 = f.Intersects(new Ray(new Vector3(24, 2, 2), new Vector3(25, 642, 1)));
            Assert.IsTrue(TestHelper.ApproximatelyEquals(0.0f, r4), "Ray#1");

            r4 = f.Intersects(new Ray(new Vector3(24, -2, 42), new Vector3(5, 2, 1)));
            Assert.IsTrue(TestHelper.ApproximatelyEquals(3.5f, r4), "Ray#2");

            r4 = f.Intersects(new Ray(new Vector3(-24, 42, -2), new Vector3(-65, 2, -1)));
            Assert.IsTrue(TestHelper.ApproximatelyEquals(0.0f, r4), "Ray#3");
        }

        [Ignore("Not implemented")]
        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void IntersectsNull()
        {
            f.Contains(null);
        }


        [Test]
        public void Left()
        {
            Plane actual = f.Left;
            Plane expectedPlane = new Plane(-0.244266f, -0.6350915f, -0.7327979f, -0.3419724f);

            Assert.IsTrue(TestHelper.ApproximatelyEquals(expectedPlane, actual), "#1 Expected: " + expectedPlane.ToString() + ". Actual: " + actual.ToString());
        }


        [Test]
        public void Near()
        {
            Plane actual = f.Near;
            Plane expectedPlane = new Plane(-0.2900209f, -0.6767156f, -0.6767156f, -0.290020972f);

            Assert.IsTrue(TestHelper.ApproximatelyEquals(expectedPlane, actual), "#1 Expected: " + expectedPlane.ToString() + ". Actual: " + actual.ToString());
        }


        [Test]
        public void Right()
        {
            Plane actual = f.Right;
            Plane expectedPlane = new Plane(-0.5773503f, -0.5773503f, 0.5773503f, 0.577350259f);

            Assert.IsTrue(TestHelper.ApproximatelyEquals(expectedPlane, actual), "#1 Expected: " + expectedPlane.ToString() + ". Actual: " + actual.ToString());
        }

        [Test]
        public void Top()
        {
            Plane actual = f.Top;
            Plane expectedPlane = new Plane(-0.5773503f, -0.5773503f, 0.5773503f, 0.577350259f);

            Assert.IsTrue(TestHelper.ApproximatelyEquals(expectedPlane, actual), "#1 Expected: " + expectedPlane.ToString() + ". Actual: " + actual.ToString());
        }

        [Ignore("Broken?")]
        [Test]
        public void ToStringTest()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-IE");

            Assert.AreEqual("{Near:{Normal:{X:-0.290021 Y:-0.6767156 Z:-0.6767156} D:-0.290021}"
                         + " Far:{Normal:{X:-0.5773503 Y:-0.5773503 Z:0.5773503} D:0.5773503}"
                         + " Left:{Normal:{X:-0.244266 Y:-0.6350915 Z:-0.7327979} D:-0.3419724}"
                         + " Right:{Normal:{X:-0.5773503 Y:-0.5773503 Z:0.5773503} D:0.5773503}"
                         + " Top:{Normal:{X:-0.5773503 Y:-0.5773503 Z:0.5773503} D:0.5773503}"
                         + " Bottom:{Normal:{X:-0.290021 Y:-0.6767156 Z:-0.6767156} D:-0.290021}}", f.ToString());


            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("de-DE");
            Assert.AreEqual("{Near:{Normal:{X:-0,290021 Y:-0,6767156 Z:-0,6767156} D:-0,290021}"
                     + " Far:{Normal:{X:-0,5773503 Y:-0,5773503 Z:0,5773503} D:0,5773503}"
                     + " Left:{Normal:{X:-0,244266 Y:-0,6350915 Z:-0,7327979} D:-0,3419724}"
                     + " Right:{Normal:{X:-0,5773503 Y:-0,5773503 Z:0,5773503} D:0,5773503}"
                     + " Top:{Normal:{X:-0,5773503 Y:-0,5773503 Z:0,5773503} D:0,5773503}"
                     + " Bottom:{Normal:{X:-0,290021 Y:-0,6767156 Z:-0,6767156} D:-0,290021}}", f.ToString());

        }
        #endregion Method Tests
    }
    */
}
