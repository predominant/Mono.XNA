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
using NUnit.Framework;
using Microsoft.Xna.Framework;


namespace Tests.Microsoft.Xna.Framework
{
    [TestFixture]
    public class BoundingSphereTests
    {
        #region Setup
        BoundingSphere s;
        [SetUp]
        public void Setup()
        {
            s = new BoundingSphere(new Vector3(2.0f, 3.0f, 4.0f), 5.0f);
        }
        #endregion


        #region Methods
        [Test]
        public void Centre()
        {
            Assert.AreEqual(2, s.Center.X, "#1");
            Assert.AreEqual(3, s.Center.Y, "#2");
            Assert.AreEqual(4, s.Center.Z, "#3");
        }


        [Test]
        public void ContainsBoundingBox()
        {
            ContainmentType r1;
            r1 = s.Contains(new BoundingBox(new Vector3(1, 1, 1), new Vector3(2, 2, 2)));
            Assert.AreEqual(ContainmentType.Contains, r1, "BoundingBox#1");

            r1 = s.Contains(new BoundingBox(new Vector3(7, 8, 9), new Vector3(10, 9, 8)));
            Assert.AreEqual(ContainmentType.Disjoint, r1, "BoundingBox#2");

            r1 = s.Contains(new BoundingBox(new Vector3(2, 2, 7), new Vector3(8, 8, 8)));
            Assert.AreEqual(ContainmentType.Intersects, r1, "BoundingBox#3");

            r1 = s.Contains(new BoundingBox(new Vector3(100, 90, 80), new Vector3(76, 65, 54)));
            Assert.AreEqual(ContainmentType.Disjoint, r1, "BoundingBox#4");

            r1 = s.Contains(new BoundingBox(new Vector3(float.MinValue), new Vector3(float.MaxValue)));
            Assert.AreEqual(ContainmentType.Intersects, r1, "#5");
        }

        [Ignore("Not implemented")]
        [Test]
        public void ContainsBoundingFrustum()
        {
            ContainmentType r1;
            r1 = s.Contains(new BoundingFrustum(new Matrix(1, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2)));
            Assert.AreEqual(ContainmentType.Disjoint, r1, "BoundingFrustum#1");

            r1 = s.Contains(new BoundingFrustum(new Matrix(5, 4, 5, 4, 5, 4, 5, 4, 5, 4, 5, 4, 5, 4, 5, 4)));
            Assert.AreEqual(ContainmentType.Contains, r1, "BoundingFrustum#2");

            r1 = s.Contains(new BoundingFrustum(new Matrix(2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2)));
            Assert.AreEqual(ContainmentType.Contains, r1, "BoundingFrustum#3");
        }


        [Test]
        public void ContainsBoundingSphere()
        {
            ContainmentType r1;
            r1 = s.Contains(new BoundingSphere(new Vector3(2, 3, 4), 5));
            Assert.AreEqual(ContainmentType.Contains, r1, "BoundingSphere#1");

            r1 = s.Contains(new BoundingSphere(new Vector3(2, 2, 2), 2));
            Assert.AreEqual(ContainmentType.Contains, r1, "BoundingSphere#2");

            r1 = s.Contains(new BoundingSphere(new Vector3(22, 35, 41), 17));
            Assert.AreEqual(ContainmentType.Disjoint, r1, "BoundingSphere#3");
        }


        [Test]
        public void ContainsVector3()
        {
            ContainmentType r1;
            r1 = s.Contains(new Vector3(4, 4, 4));
            Assert.AreEqual(ContainmentType.Contains, r1, "Vector3#1");

            r1 = s.Contains(new Vector3(2, 3, 2));
            Assert.AreEqual(ContainmentType.Contains, r1, "Vector3#2");

            r1 = s.Contains(new Vector3(17, 113, 34));
            Assert.AreEqual(ContainmentType.Disjoint, r1, "Vector3#3");
        }


        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void ContainsNull()
        {
            s.Contains(null);
        }

        [Test]
        public void CreateMerged()
        {
            BoundingSphere result = BoundingSphere.CreateMerged(s, new BoundingSphere(new Vector3(2,3,4),6));
            Assert.AreEqual(new BoundingSphere(new Vector3(2,3,4),6), result,"SphereMerge#1");

            result = BoundingSphere.CreateMerged(s, new BoundingSphere(new Vector3(2, 3, 3), 2));
            Assert.AreEqual(new BoundingSphere(new Vector3(2, 3, 4), 5), result, "SphereMerge#2");

            result = BoundingSphere.CreateMerged(s, new BoundingSphere(new Vector3(2, 3, -2), 1));//just hit
            Assert.AreEqual(new BoundingSphere(new Vector3(2, 3, 3), 6), result, "SphereMerge#3");

            result = BoundingSphere.CreateMerged(s, new BoundingSphere(new Vector3(2, 3, -2), 3));//intersect
            Assert.AreEqual(new BoundingSphere(new Vector3(2, 3, 2), 7), result, "SphereMerge#4");

            result = BoundingSphere.CreateMerged(s, new BoundingSphere(new Vector3(2, 3, -4), 1));//disjoint
            Assert.AreEqual(new BoundingSphere(new Vector3(2, 3, 2), 7), result, "SphereMerge#5");


        }
        

        [Test]
        public void TestEquals()
        {
            bool result;
            result = s.Equals(s);
            Assert.AreEqual(true, result, "Equals#1");

            result = s.Equals(new BoundingSphere(new Vector3(53, 3, 21), 253f));
            Assert.AreEqual(false, result, "Equals#2");

            result = s.Equals(null);
            Assert.AreEqual(false, result, "Equals#3");

            result = s.Equals(new int());
            Assert.AreEqual(false, result, "Equals#4");

            result = s.Equals((object)s);
            Assert.AreEqual(true, result, "Equals#5");
        }



        [Test]
        public void IntersectsBoundingBox()
        {
            bool result;
            result = s.Intersects(new BoundingBox(new Vector3(2, 3, 4), new Vector3(55, 44, 32)));
            Assert.AreEqual(true, result, "BoundingBox#1");

            result = s.Intersects(new BoundingBox(new Vector3(53, 2, 14), new Vector3(21, 124, 452)));
            Assert.AreEqual(false, result, "BoundingBox#2");

            result = s.Intersects(new BoundingBox(new Vector3(55, 53, 35), new Vector3(55, 55, 53)));
            Assert.AreEqual(false, result, "BoundingBox#3");
        }

        [Ignore("Not implemented")]
        [Test]
        public void IntersectsBoundingFrustum()
        {
            bool result;
            result = s.Intersects(new BoundingFrustum(new Matrix(1, 2, 3, 2, 1, 2, 3, 2, 1, 2, 3, 2, 1, 2, 3, 1)));
            Assert.AreEqual(true, result, "BoundingFrustum#1");

            result = s.Intersects(new BoundingFrustum(new Matrix(12, 13, 12, 13, 12, 42, 64, 34, 2, 1, 12, 3, 24, 56, 3, 2)));
            Assert.AreEqual(true, result, "BoundingFrustum#2");

            result = s.Intersects(new BoundingFrustum(new Matrix(57, 47, 36, 85, 37, 253, 4587, 457, 34, 457, 347, 246, 458, 5698, 35473, 46)));
            Assert.AreEqual(false, result, "BoundingFrustum#3");
        }


        [Test]
        public void IntersectsBoundingSphere()
        {
            bool result;
            result = s.Intersects(new BoundingSphere(new Vector3(2, 2, 2), 2));
            Assert.AreEqual(true, result, "BoundingSphere#1");

            result = s.Intersects(new BoundingSphere(new Vector3(12, 14, 241), 15));
            Assert.AreEqual(false, result, "BoundingSphere#2");
        }


        [Test]
        [Ignore("Not implemented")]
        public void IntersectsPlane()
        {
            PlaneIntersectionType result2;
            result2 = s.Intersects(new Plane(new Vector4(2, 3, 4, 5)));
            Assert.AreEqual(PlaneIntersectionType.Front, result2, "Plane#1");

            result2 = s.Intersects(new Plane(new Vector4(26, 25, 12, 73)));
            Assert.AreEqual(PlaneIntersectionType.Front, result2, "Plane#2");

            result2 = s.Intersects(new Plane(new Vector4(-1, -2, -3, 0)));
            Assert.AreEqual(PlaneIntersectionType.Back, result2, "Plane#3");
        }


        [Test]
        [Ignore("Not implemented")]
        public void IntersectsRay()
        {
            float? result3;
            result3 = s.Intersects(new Ray(new Vector3(23, 25, 12), new Vector3(12, 13, 13)));
            Assert.AreEqual(null, result3, "Vector3#1");

            result3 = s.Intersects(new Ray(new Vector3(2, 2, 2), new Vector3(-1, -2, -3)));
            Assert.AreEqual(0.0f, result3, "Vector3#2");

            result3 = s.Intersects(new Ray(new Vector3(55, 55, 55), new Vector3(-1, -1, -1)));
            Assert.IsTrue(TestHelper.ApproximatelyEquals(28.5362778f, result3), "Vector3#3");
        }


        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void InteresectsNull()
        {
            s.Intersects(null);
        }



        [Test]
        public void Radius()
        {
            Assert.IsTrue(s.Radius == 5.0f);
        }



        [Test]
        public void TestToString()
        {
            Assert.AreEqual("{Center:{X:2 Y:3 Z:4} Radius:5}", s.ToString());
        }
        #endregion Methods
    }
}
