#region License
/*
MIT License
Copyright © 2006-2007 The Mono.Xna Team

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
using System.Text;
using NUnit.Framework;
using Microsoft.Xna.Framework;
using System.Threading;
using System.Globalization;

namespace Tests.Microsoft.Xna.Framework
{
    [TestFixture]
    public class RayTests
    {
        #region Setup

        private Ray r1;
        private Ray r2;
        private Ray r3;
        private Ray r4;

        [SetUp]
        public void Setup()
        {
            r1 = new Ray();
            r2 = new Ray(new Vector3(1, 2, 3), new Vector3(4, 5, 6));
            r3 = new Ray(new Vector3(2.25f, 3.754321f, 4.387f), new Vector3(-1, -1, -1));
            r4 = new Ray(new Vector3(1, 1, 1), new Vector3(1, 1, 1));
        }

        #endregion


        #region Public Methods Test

        [Test]
        public void ConstructorTests()
        {
            Assert.AreEqual(0, r1.Direction.X, "#1");
            Assert.AreEqual(0, r1.Direction.Y, "#2");
            Assert.AreEqual(0, r1.Direction.Z, "#3");

            Assert.AreEqual(0, r1.Position.X, "#4");
            Assert.AreEqual(0, r1.Position.Y, "#5");
            Assert.AreEqual(0, r1.Position.Z, "#6");

            Assert.AreEqual(4, r2.Direction.X, "#7");
            Assert.AreEqual(5, r2.Direction.Y, "#8");
            Assert.AreEqual(6, r2.Direction.Z, "#9");

            Assert.AreEqual(1, r2.Position.X, "#10");
            Assert.AreEqual(2, r2.Position.Y, "#11");
            Assert.AreEqual(3, r2.Position.Z, "#12");    
        }

        [Test]
        public void EqualsTest()
        {
            int a = 6;
            
            Assert.IsTrue(r1.Equals(r1), "#1");
            Assert.IsFalse(r1.Equals(null), "#2");
            Assert.IsFalse(r1.Equals(a), "#3");
            Assert.IsTrue(r1 == r1, "#4");
            Assert.IsFalse(r1.Equals(r2), "#5");
            Assert.IsFalse(r1.Equals(r3), "#6");
            Assert.IsFalse(r2.Equals(r3), "#7");
            Assert.IsTrue(r1 != r2, "#8");

            Ray test = new Ray(new Vector3(1, 2, 3), new Vector3(4, 5, 6));

            Assert.IsTrue(test == r2, "#9");
            Assert.IsTrue(test.Equals(r2), "#10");

            Ray bigger = new Ray(new Vector3(1, 1, 1), new Vector3(2, 2, 2));
            Assert.AreNotEqual(r4, bigger);
        }

        [Test]
        public void IntersectsBoundingBoxTest()
        {
            BoundingBox b1 = new BoundingBox(new Vector3(-1, -1, -1), new Vector3(1, 1, 1));
            BoundingBox b2 = new BoundingBox(new Vector3(2, 2, 2), new Vector3(4, 4, 4));
            BoundingBox b3 = new BoundingBox(new Vector3(-1, -1, -1), new Vector3(0, 0, 0));
            BoundingBox b4 = new BoundingBox(new Vector3(3.5f, 3.5f, 3.5f), new Vector3(77, 77, 77));

            float? result;
            result = r1.Intersects(b1);
            Assert.AreEqual(0, result, "#1");

            result = r1.Intersects(b2);
            Assert.AreEqual(null, result, "#2");

            result = r1.Intersects(b3);
            Assert.AreEqual(0, result, "#3");


            result = r2.Intersects(b1);
            Assert.AreEqual(null, result, "#4");

            result = r2.Intersects(b2);
            Assert.AreEqual(null, result, "#5");

            result = r2.Intersects(b3);
            Assert.AreEqual(null, result, "#6");

            result = r2.Intersects(b4);
            Assert.AreEqual(0.625f, result, "#7");

            result = r4.Intersects(b4);
        }

        [Test]
        [Ignore("Not implemented")]
        public void IntersectsBoundingFrustumTest()
        {
            float? result;
            Ray intersects = new Ray(new Vector3(0, 0, 0), new Vector3(0, 1, 0));

            BoundingFrustum f1 = new BoundingFrustum(new Matrix(100, 2, 3, 1, 5, 3, 7, 21, 2, 5, 1, 5, 4, 4, 2, 1));

            result = r4.Intersects(f1);
            Assert.AreEqual(null, result);

            result = intersects.Intersects(f1);
            Assert.AreEqual(0.1875, result);
        }

        [Test]
        [Ignore("Not implemented")]
        public void IntersectsBoundingSphereTest()
        {
            BoundingSphere s1 = new BoundingSphere();
            BoundingSphere s2 = new BoundingSphere(new Vector3(2, 2, 2), 2);
            BoundingSphere s3 = new BoundingSphere(new Vector3(5, 5, 5), 3);
            float? result;

            result = r1.Intersects(s1);
            Assert.AreEqual(0, result, "#1");

            result = r1.Intersects(s2);
            Assert.AreEqual(null, result, "#2");

            result = r1.Intersects(s3);
            Assert.AreEqual(null, result, "#3");

            result = r2.Intersects(s1);
            Assert.AreEqual(null, result, "#4");

            result = r2.Intersects(s2);
            Assert.AreEqual(0, result, "#5");

            result = r2.Intersects(s3);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(0.233188629f, result), "#6");

            result = r3.Intersects(s1);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(2.05007648f, result), "#7");

            result = r3.Intersects(s2);
            Assert.IsTrue(TestHelper.ApproximatelyEquals(0.590559483f, result), "#8");

            result = r3.Intersects(s3);
            Assert.AreEqual(null, result, "#9");
        }

        [Test]
        public void ToStringTest()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-IE");
            Assert.AreEqual("{Position:{X:0 Y:0 Z:0} Direction:{X:0 Y:0 Z:0}}", r1.ToString(), "#1");
            Assert.AreEqual("{Position:{X:1 Y:2 Z:3} Direction:{X:4 Y:5 Z:6}}", r2.ToString(), "#2");
            Assert.AreEqual("{Position:{X:2.25 Y:3.754321 Z:4.387} Direction:{X:-1 Y:-1 Z:-1}}", r3.ToString(), "#3");
            Assert.AreEqual("{Position:{X:1 Y:1 Z:1} Direction:{X:1 Y:1 Z:1}}", r4.ToString(), "#4");

            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("de-DE");
            Assert.AreEqual("{Position:{X:0 Y:0 Z:0} Direction:{X:0 Y:0 Z:0}}", r1.ToString(), "#1");
            Assert.AreEqual("{Position:{X:1 Y:2 Z:3} Direction:{X:4 Y:5 Z:6}}", r2.ToString(), "#2");
            Assert.AreEqual("{Position:{X:2,25 Y:3,754321 Z:4,387} Direction:{X:-1 Y:-1 Z:-1}}", r3.ToString(), "#4");
            Assert.AreEqual("{Position:{X:1 Y:1 Z:1} Direction:{X:1 Y:1 Z:1}}", r4.ToString(), "#4");
        }

        #endregion
    }
}
