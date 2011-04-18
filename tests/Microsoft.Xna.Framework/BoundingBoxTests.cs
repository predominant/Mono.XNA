#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.

Authors: Alan McGovern

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
using Microsoft.Xna.Framework;
using NUnit.Framework;

namespace Tests.Microsoft.Xna.Framework
{
    [TestFixture]
    public class BoundingBoxTests
    {
        #region Setup

        private BoundingBox b;
        private BoundingBox c;

        [SetUp]
        public void Setup()
        {
            b = new BoundingBox(new Vector3(0, 0, 0), new Vector3(10, 10, 10));
            c = new BoundingBox(new Vector3(12.34562f, 12.43745754f, 128.1364574f), new Vector3(15.2473473f, 18.247356325f, 150.23532523f));
        }

        #endregion Setup

        #region Public Methods Tests

        [Test]
        public void Constructor()
        {
            // Overloaded constructor, normal use
            b = new BoundingBox(new Vector3(-5, 3, 1),new Vector3(8, -10, 0));
            Assert.AreEqual(new Vector3(-5, 3, 1), b.Min, "Constructor#1.Min");
            Assert.AreEqual(new Vector3(8, -10, 0), b.Max, "Constructor#1.Max");

            // Overloaded constructor, when Min = Max
            b = new BoundingBox(new Vector3(0, 0, 1), new Vector3(0, 0, 1));
            Assert.AreEqual(new Vector3(0, 0, 1), b.Min, "Constructor#2.Min");
            Assert.AreEqual(new Vector3(0, 0, 1), b.Max, "Constructor#2.Max");

            // Overloaded constructor, when Min is the minimum value and Max the maximum
            b = new BoundingBox(new Vector3(float.MinValue), new Vector3(float.MaxValue));
            Assert.AreEqual(new Vector3(float.MinValue), b.Min, "Constructor#3.Min");
            Assert.AreEqual(new Vector3(float.MaxValue), b.Max, "Constructor#3.Max");

            // Overloaded constructor, changing passing Max first and Min afterwards
            // As stupid as it seems, MS's XNA doesn't check, just assumes first is Min
            // and second is Max
            b = new BoundingBox(new Vector3(10, 10, 10), new Vector3(0, 0, 0));
            Assert.AreEqual(new Vector3(10, 10, 10), b.Min, "Constructor#4.Min");
            Assert.AreEqual(new Vector3(0, 0, 0), b.Max, "Constructor#4.Max");

            // Overloaded constructor, using other Vector3
            // As before, MS's XNA does not check what's the minimum and maximum
            b = new BoundingBox(new Vector3(0, 5, 10), new Vector3(10, 5, 0));
            Assert.AreEqual(new Vector3(0, 5, 10), b.Min, "Constructor#5.Min");
            Assert.AreEqual(new Vector3(10, 5, 0), b.Max, "Constructor#5.Max");

            // Default constructor
            b = new BoundingBox();
            Assert.AreEqual(new Vector3(0, 0, 0), b.Min, "Constructor#6.Min");
            Assert.AreEqual(new Vector3(0, 0, 0), b.Max, "Constructor#6.Max");
        }

        [Test]
        public void CreateFromPoints()
        {
            // Note: Exceptions for this method in CreateFromPointsExceptions()

            // Check with a list of points (normal use)
            List<Vector3> points = new List<Vector3>();
            points.Add(new Vector3(1, 2, 3));
            points.Add(new Vector3(4, 5, 6));
            points.Add(new Vector3(-1, -5, 7));
            points.Add(new Vector3(100, 70, 60));
            BoundingBox b = BoundingBox.CreateFromPoints(points);

            Assert.AreEqual(new Vector3(-1, -5, 3), b.Min, "CreateFromPoints#1.Min");
            Assert.AreEqual(new Vector3(100, 70, 60), b.Max, "CreateFromPoints#1.Max");

            // Check with a list of numbers (all equal)
            points.Clear();
            points.Add(new Vector3(0, 0, 0));
            points.Add(new Vector3(0, 0, 0));
            points.Add(new Vector3(0, 0, 0));
            b = BoundingBox.CreateFromPoints(points);

            Assert.AreEqual(new Vector3(0, 0, 0), b.Min, "CreateFromPoints#2.Min");
            Assert.AreEqual(new Vector3(0, 0, 0), b.Max, "CreateFromPoints#2.Max");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateFromPointsExceptions()
        {
            // Check with a void list of numbers
            List<Vector3> points = new List<Vector3>();
            BoundingBox b = BoundingBox.CreateFromPoints(points);
        }
        
        [Test]
        public void CreateFromSphere()
        {
            // Check (normal use)
            BoundingBox b = BoundingBox.CreateFromSphere(new BoundingSphere(new Vector3(152, 2.32f, 55.1723f), 35.1f));
            Assert.AreEqual(new Vector3(116.9f, -32.78f, 20.0723f), b.Min, "CreateFromSphere#1.Min");
            Assert.AreEqual(new Vector3(187.1f, 37.42f, 90.27229f), b.Max, "CreateFromSphere#1.Max");

            // Check (Sphere with radius = 0)
            b = BoundingBox.CreateFromSphere(new BoundingSphere(new Vector3(152, 2.32f, 55.1723f), 0));
            Assert.AreEqual(new Vector3(152, 2.32f, 55.1723f), b.Min, "CreateFromSphere#2.Min");
            Assert.AreEqual(new Vector3(152, 2.32f, 55.1723f), b.Max, "CreateFromSphere#2.Max");
        }
        
        [Test]
        public void CreateMerged()
        {
            // Check (normal use)
            BoundingBox b1 = new BoundingBox(new Vector3(2, 51, 1), new Vector3(-12, -4, -2));
            BoundingBox b2 = new BoundingBox(new Vector3(35, 35, -1), new Vector3(14, -25, 21));
            BoundingBox b = BoundingBox.CreateMerged(b1, b2);
            Assert.AreEqual(new Vector3(2, 35, -1), b.Min, "CreateMerged#1.Min");
            Assert.AreEqual(new Vector3(14, -4, 21), b.Max, "CreateMerged#1.Max");

            // Check when both boxes contain only one and the same point
            b1 = new BoundingBox(new Vector3(10, 10, 10), new Vector3(10, 10, 10));
            b2 = new BoundingBox(new Vector3(10, 10, 10), new Vector3(10, 10, 10));
            b = BoundingBox.CreateMerged(b1, b2);
            Assert.AreEqual(new Vector3(10, 10, 10), b.Min, "CreateMerged#2.Min");
            Assert.AreEqual(new Vector3(10, 10, 10), b.Max, "CreateMerged#2.Max");
        }

        [Test]
        public void ContainsVector3()
        {
            ContainmentType result;

            result = b.Contains(new Vector3(1, 2, 3));
            Assert.AreEqual(ContainmentType.Contains, result, "ContainsVector3#1");

            result = b.Contains(new Vector3(4, 8, 12));
            Assert.AreEqual(ContainmentType.Disjoint, result, "ContainsVector3#2");

            result = b.Contains(new Vector3(100, 22, 1));
            Assert.AreEqual(ContainmentType.Disjoint, result, "ContainsVector3#3");

            result = b.Contains(new Vector3(3, 4, 5));
            Assert.AreEqual(ContainmentType.Contains, result, "ContainsVector3#4");
        }

        [Test]
        public void ContainsBoundingBox()
        {
            ContainmentType result;

            result = b.Contains(new BoundingBox(new Vector3(-4, -4, -4), new Vector3(0, 0, 0)));
            Assert.AreEqual(ContainmentType.Intersects, result, "ContainsBoundingBox#1");

            result = b.Contains(new BoundingBox(new Vector3(0, 10, 0), new Vector3(3, 4, 5)));
            Assert.AreEqual(ContainmentType.Contains, result, "ContainsBoundingBox#2");

            result = b.Contains(new BoundingBox(new Vector3(-5, -6, -7), new Vector3(-11, -23, -24)));
            Assert.AreEqual(ContainmentType.Disjoint, result, "ContainsBoundingBox#3");

        }

        [Ignore("Not implemented")]
        [Test]
        public void ContainsBoundingFrustum()
        {
            ContainmentType result;

            result = b.Contains(new BoundingFrustum(new Matrix(0, 9, 78, 6, 4, 3, 35, 6, 8, 8, 2, 1, 4, 5, 8, 5)));
            Assert.AreEqual(ContainmentType.Intersects, result, "ContainsBoundingFrustrum#1");

            result = b.Contains(new BoundingFrustum(new Matrix(1, 1, 2, 3, 5, 7, 42, 1243, 12, 55, 3, 22, 35, 346, 73, 5)));
            Assert.AreEqual(ContainmentType.Disjoint, result, "ContainsBoundingFrustrum#2");

            result = b.Contains(new BoundingFrustum(new Matrix(1, 1, 2, 3, 5, 7, 42, 1243, 12, 55, 3, 22, 35, 346, 73, 5)));
            Assert.AreEqual(ContainmentType.Disjoint, result, "ContainsBoundingFrustrum#2");

        }

        [Test]
        public void ContainsBoundingSphere()
        {
            ContainmentType result;

            result = b.Contains(new BoundingSphere(new Vector3(-5, -5, -5), 5));
            Assert.AreEqual(ContainmentType.Disjoint, result, "ContainsBoundingSphere#1");

            result = b.Contains(new BoundingSphere(new Vector3(-5, -5, -5), 4.99f));
            Assert.AreEqual(ContainmentType.Disjoint, result, "ContainsBoundingSphere#2");

            result = b.Contains(new BoundingSphere(new Vector3(-5, -5, -5), 5.5f));
            Assert.AreEqual(ContainmentType.Disjoint, result, "ContainsBoundingSphere#3");

            result = b.Contains(new BoundingSphere(new Vector3(5, 5, 5), 1));
            Assert.AreEqual(ContainmentType.Contains, result, "ContainsBoundingSphere#4");

            result = b.Contains(new BoundingSphere(new Vector3(-1, -1, -1), 19));
            Assert.AreEqual(ContainmentType.Intersects, result, "ContainsBoundingSphere#5");
        }

        [Test]
        public void EqualsTest()
        {
            BoundingBox b2 = new BoundingBox(new Vector3(124, 64, 12), new Vector3(35, 13, 1));
            BoundingBox clone = new BoundingBox(new Vector3(0, 0, 0), new Vector3(10, 10, 10));

            Assert.IsTrue(b.Equals(b), "EqualsTest#1");
            Assert.IsTrue(b.Equals(clone), "EqualsTest#2");

            Assert.IsFalse(b.Equals(null), "EqualsTest#3");
            Assert.IsFalse(b.Equals(b2), "EqualsTest#4");

            Assert.IsTrue(b == b, "EqualsTest#5");
            Assert.IsTrue(b == clone, "EqualsTest#6");
            Assert.IsTrue(b != b2, "EqualsTest#7");
            Assert.IsFalse(b != b, "EqualsTest#8");
            
            int a = 5;
            Assert.IsFalse(b.Equals(a), "EqualsTest#9");
        }
        
        [Test]
        public void GetCorners()
        {
            Vector3[] array = b.GetCorners();
            Assert.AreEqual(8, array.Length, "GetCorners#1");

            Assert.AreEqual(new Vector3(0, 10, 10), array[0], "GetCorners#1[0]");
            Assert.AreEqual(new Vector3(10, 10, 10), array[1], "GetCorners#1[1]");
            Assert.AreEqual(new Vector3(10, 0, 10), array[2], "GetCorners#1[2]");
            Assert.AreEqual(new Vector3(0, 0, 10), array[3], "GetCorners#1[3]");
            Assert.AreEqual(new Vector3(0, 10, 0), array[4], "GetCorners#1[4]");
            Assert.AreEqual(new Vector3(10, 10, 0), array[5], "GetCorners#1[5]");
            Assert.AreEqual(new Vector3(10, 0, 0), array[6], "GetCorners#1[6]");
            Assert.AreEqual(new Vector3(0, 0, 0), array[7], "GetCorners#1[7]");

            BoundingBox b2 = new BoundingBox(new Vector3(1, 1, 1), new Vector3(1, 1, 1));
            array = b2.GetCorners();

            Assert.AreEqual(new Vector3(1, 1, 1), array[0], "GetCorners#2[0]");
            Assert.AreEqual(new Vector3(1, 1, 1), array[1], "GetCorners#2[1]");
            Assert.AreEqual(new Vector3(1, 1, 1), array[2], "GetCorners#2[2]");
            Assert.AreEqual(new Vector3(1, 1, 1), array[3], "GetCorners#2[3]");
            Assert.AreEqual(new Vector3(1, 1, 1), array[4], "GetCorners#2[4]");
            Assert.AreEqual(new Vector3(1, 1, 1), array[5], "GetCorners#2[5]");
            Assert.AreEqual(new Vector3(1, 1, 1), array[6], "GetCorners#2[6]");
            Assert.AreEqual(new Vector3(1, 1, 1), array[7], "GetCorners#2[7]");


            array = c.GetCorners();
            Assert.AreEqual(8, array.Length, "GetCorners#1");

            Vector3 test = new Vector3(12.34562f, 18.24736f, 150.2353f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(test, array[0]), "#1: " + test.ToString() + " VS " + array[0].ToString());
            test = new Vector3(15.24735f, 18.24736f, 150.2353f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(test, array[1]), "#2: " + test.ToString() + " VS " + array[1].ToString());
            test = new Vector3(15.24735f, 12.43746f, 150.2353f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(test, array[2]), "#3: " + test.ToString() + " VS " + array[2].ToString());
            test = new Vector3(12.34562f, 12.43746f, 150.2353f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(test, array[3]), "#4: " + test.ToString() + " VS " + array[3].ToString());
            test = new Vector3(12.34562f, 18.24736f, 128.1365f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(test, array[4]), "#5: " + test.ToString() + " VS " + array[4].ToString());
            test = new Vector3(15.24735f, 18.24736f, 128.1365f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(test, array[5]), "#6: " + test.ToString() + " VS " + array[5].ToString());
            test = new Vector3(15.24735f, 12.43746f, 128.1365f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(test, array[6]), "#7: " + test.ToString() + " VS " + array[6].ToString());
            test = new Vector3(12.34562f, 12.43746f, 128.1365f);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(test, array[7]), "#8: " + test.ToString() + " VS " + array[7].ToString());
        }

        [Test]
        public void IntersectsBoundingBox()
        {
            bool result;

            // Intersects a BoundingBox inside
            // True, contains partially (totally indeed) all of its points
            result = b.Intersects(new BoundingBox(new Vector3(0, 1, 2), new Vector3(4, 5, 6)));
            Assert.AreEqual(true, result, "IntersectsBoundingBox#1");

            // Intersects a BoundingBox that is completely disjoint
            // False, they don't share any point
            result = b.Intersects(new BoundingBox(new Vector3(11, 12, 14), new Vector3(21, 2, 1)));
            Assert.AreEqual(false, result, "IntersectsBoundingBox#2");
        }

        [Ignore("Not implemented")]
        [Test]
        public void IntersectsBoundingFrustum()
        {
            bool result;

            result = b.Intersects(new BoundingFrustum(new Matrix(1, 1, 2, 3, 5, 7, 42, 1243, 12, 55, 3, 22, 35, 346, 73, 5)));
			Assert.AreEqual(false, result, "IntersectsBoundingFrustum#1");
        }

        [Test]
        public void IntersectsBoundingSphere()
        {
            bool result;

            // Intersects a BoundingSphere with its center inside the Box
            result = b.Intersects(new BoundingSphere(new Vector3(1, 2, 3), 5.3f));
			Assert.AreEqual(true, result, "IntersectsBoundingSphere#1");

            // Not intersects a BoundingSphere with its center outside the Box and a radius that
            // does not touch the BoundingBox
            result = b.Intersects(new BoundingSphere(new Vector3(151, 3512, 311), 53));
			Assert.AreEqual(false, result, "IntersectsBoundingSphere#2");

            // Not intersects a BoundingSphere with its center in the upper corner o the Max point
            // and which radius is equal to the distance from its center to the Max point
            result = b.Intersects(new BoundingSphere(new Vector3(11, 11, 11),
                Vector3.Distance(new Vector3(11, 11, 11), b.Max)));
            Assert.AreEqual(false, result, "IntersectsBoundingSphere#3");

            // Intersects a BoundingSphere which center is outside the Box and which radius touches
            // the Box
            result = b.Intersects(new BoundingSphere(new Vector3(11, 11, 11), 5));
            Assert.AreEqual(true, result, "IntersectsBoundingShphere#4");
        }

        [Test]
        [Ignore("Not implemented")]
        public void IntersectsPlane()
        {
            PlaneIntersectionType planeResult;
            planeResult = b.Intersects(new Plane(new Vector3(-1, -1, -1), new Vector3(-1, -1, -2), new Vector3(-1, -4, -5)));
			Assert.AreEqual(PlaneIntersectionType.Back, planeResult, "IntersectsPlane#1");

            planeResult = b.Intersects(new Plane(new Vector3(-100, -1, 0), new Vector3(-100, -1, 1), new Vector3(-1, -1, -1)));
			Assert.AreEqual(PlaneIntersectionType.Front, planeResult, "IntersectsPlane#2");
        }

        [Test]
        public void IntersectsRay()
        {
            float? rayResult;
            rayResult = b.Intersects(new Ray(new Vector3(-1, -2, -3), new Vector3(-1, -2, -3)));
			Assert.AreEqual(rayResult, null, "IntersectsRay#1");

            rayResult = b.Intersects(new Ray(new Vector3(1, 2, 3), new Vector3(4, 5, 6)));
			Assert.AreEqual(rayResult, 0.0, "IntersectsRay#2");

            rayResult = b.Intersects(new Ray(new Vector3(-1, -1, -1), new Vector3(1, 1, 1)));
			Assert.AreEqual(rayResult, 1.0, "IntersectsRay#3");
        }

        [Test]
        public void ToStringTest()
        {
            // English-like number formatting
            if (System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator == ".")
            {
                Assert.AreEqual("{Min:{X:0 Y:0 Z:0} Max:{X:10 Y:10 Z:10}}", this.b.ToString());

                // Test float numbers
                b = new BoundingBox(new Vector3(0.0f, 5.0f, 10.0f), new Vector3(10.3f, 20.5f, 30.1f));
                Assert.AreEqual("{Min:{X:0 Y:5 Z:10} Max:{X:10.3 Y:20.5 Z:30.1}}", this.b.ToString());
            }
            // Else-like number formatting
            else
            {
                Assert.AreEqual("{Min:{X:0 Y:0 Z:0} Max:{X:10 Y:10 Z:10}}", this.b.ToString());

                // Test float numbers
                b = new BoundingBox(new Vector3(0.0f, 5.0f, 10.0f), new Vector3(10.3f, 20.5f, 30.1f));
                Assert.AreEqual("{Min:{X:0 Y:5 Z:10} Max:{X:10,3 Y:20,5 Z:30,1}}", this.b.ToString());
            }			
        }

        #endregion

        #region Public Fields Tests

        [Test]
        public void Max()
        {
            Assert.AreEqual(new Vector3(10, 10, 10), b.Max);
        }

        [Test]
        public void Min()
        {
            Assert.AreEqual(new Vector3(0, 0, 0), b.Min);
        }

        #endregion
    }
}
