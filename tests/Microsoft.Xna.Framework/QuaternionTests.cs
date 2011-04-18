#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.

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

namespace Tests.Microsoft.Xna.Framework
{
    
    [TestFixture]
    public class QuaternionTests
    {
		Quaternion a;

		[SetUp]
		public void Setup()
		{
			a = new Quaternion(1f, 2f, 3f, 4f);		
		}

        [Test]
        public void ToStringTest()
        {
            Assert.AreEqual("{X:1 Y:2 Z:3 W:4}", a.ToString());
        }

        [Test]
        public void EqualsTest()
        {
			Quaternion a2 = new Quaternion(1f, 2f, 3f, 4f);
			Quaternion a3 = new Quaternion(1f, 5f, 3f, 4f);
			Assert.IsTrue(a.Equals(a), "#1");
			Assert.IsTrue(a.Equals(a2), "#2");
			Assert.IsFalse(a.Equals(null), "#3");
			Assert.IsFalse(a.Equals(a3), "#4");
        }

        [Test]
        public void LengthSquaredTest()
        {
			Assert.AreEqual(a.LengthSquared(), 30, "#1");
        }

        [Test]
        public void LengthTest()
        {
			Assert.AreEqual(a.Length(), 5.47722578f, "#1");
        }

        [Test]
        public void NormalizeTest()
        {
			a.Normalize();
            Quaternion expected = new Quaternion(0.1825742f, 0.3651484f, 0.5477225f, 0.7302967f);

            Assert.IsTrue(TestHelper.ApproximatelyEquals(a.W, expected.W), "#1");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(a.X, expected.X), "#2");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(a.Y, expected.Y), "#3");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(a.Z, expected.Z), "#4");
        }

        [Test]
        public void InverseTest()
        {
			Quaternion actual = Quaternion.Inverse(a);
            Quaternion expected = new Quaternion(-0.03333334f, -0.06666667f, -0.1f, 0.1333333f);

            Assert.IsTrue(TestHelper.ApproximatelyEquals(actual.W, expected.W), "#1");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(actual.X, expected.X), "#2");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(actual.Y, expected.Y), "#3");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(actual.Z, expected.Z), "#4");
        }

        [Test]
        public void CreateFromAxisAngleTest()
        {
            Quaternion actual = Quaternion.CreateFromAxisAngle(new Vector3(1f, 2f, 3f), 4f);
            Quaternion expected = new Quaternion(0.9092974f, 1.818595f, 2.727892f, -0.4161468f);

            Assert.IsTrue(TestHelper.ApproximatelyEquals(actual.W, expected.W), "#1");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(actual.X, expected.X), "#2");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(actual.Y, expected.Y), "#3");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(actual.Z, expected.Z), "#4");

        }

        [Test]
        public void CreateFromRotationMatrixTest()
        {
            Quaternion actual = Quaternion.CreateFromRotationMatrix(new Matrix(1, 2, 3, 1, 2, 1, 2, 3, 4, 5, 6, 7, 8, 0, 1, 3));
            Quaternion expected = new Quaternion(-0.5f, 0.1666667f, 0f, 1.5f);

            Assert.IsTrue(TestHelper.ApproximatelyEquals(actual.W, expected.W), "#1");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(actual.X, expected.X), "#2");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(actual.Y, expected.Y), "#3");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(actual.Z, expected.Z), "#4");
        }

        [Test]
        public void DotTest()
        {
			Assert.AreEqual(Quaternion.Dot(a,a), 30f, "#1");
        }

        [Test]
        public void SlerpTest()
        {
			Assert.AreEqual(Quaternion.Slerp(a, a,2f), a, "#1");
        }

        [Test]
        public void LerpTest()
        {
			Quaternion actual = Quaternion.Lerp(a, a,2f);
            Quaternion expected = new Quaternion(0.1825742f, 0.3651484f, 0.5477225f, 0.7302967f);

            Assert.IsTrue(TestHelper.ApproximatelyEquals(actual.W, expected.W), "#1");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(actual.X, expected.X), "#2");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(actual.Y, expected.Y), "#3");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(actual.Z, expected.Z), "#4");
        }

        [Test]
        public void NegateTest()
        {
			Assert.AreEqual(Quaternion.Negate(a), new Quaternion(-1f, -2f, -3f, -4f), "#1");
        }

        [Test]
        public void AddTest()
        {
			Assert.AreEqual(a + a, new Quaternion(2f, 4f, 6f, 8f), "#1");
        }

        [Test]
        public void SubtractTest()
        {
			Assert.AreEqual(a - a, new Quaternion(0f,0f,0f,0f), "#1");
        }

        [Test]
        public void MultiplyTest()
        {
            Assert.AreEqual(a * a, new Quaternion(8f, 16f, 24f, 2f), "#1");
            Quaternion b = new Quaternion(1, 5.3f, 2.5f, 66);
            Quaternion c = new Quaternion(6, 2, 1, 9.5f);

            Quaternion expected = new Quaternion(405.8f, 196.35f, 59.95f, 607.9f);
            Quaternion actual = b * c;

			Assert.AreEqual(TestHelper.Approximate(expected), TestHelper.Approximate(actual), "#2");
            //Assert.IsTrue(TestHelper.ApproximatelyEquals(expected.X, actual.X), "#1");
            //Assert.IsTrue(TestHelper.ApproximatelyEquals(expected.Y, actual.Y), "#2");
            //Assert.IsTrue(TestHelper.ApproximatelyEquals(expected.Z, actual.Z), "#3");
            //Assert.IsTrue(TestHelper.ApproximatelyEquals(expected.W, actual.W), "#4");
        }

        [Test]
        public void DivideTest()
        {
            Quaternion expected = new Quaternion(0f, 0f, 0f, 1f);
            Quaternion actual = a / a;
			
			Assert.AreEqual(TestHelper.Approximate(expected), TestHelper.Approximate(actual), "#1");
            //Assert.IsTrue(TestHelper.ApproximatelyEquals(expected.W, actual.W), "#1");
            //Assert.IsTrue(TestHelper.ApproximatelyEquals(expected.X, actual.X), "#2");
            //Assert.IsTrue(TestHelper.ApproximatelyEquals(expected.Y, actual.Y), "#3");
            //Assert.IsTrue(TestHelper.ApproximatelyEquals(expected.Z, actual.Z), "#4");
        }
    }
     
}
