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
using System.Text;
using NUnit.Framework;
using Microsoft.Xna.Framework;

namespace Tests.Microsoft.Xna.Framework
{
    [TestFixture]
    public class CurveKeyTests
    {
        CurveKey c1;
        CurveKey c2;
        [SetUp]
        public void Setup()
        {
            c1 = new CurveKey(1f, 2f, 3f, -3f, CurveContinuity.Smooth);
            c2 = new CurveKey(2f, 4f, 6f, 6.7f, CurveContinuity.Step);
        }


        [Test]
        public void Clone()
        {
            CurveKey clone1 = c1.Clone();
            CurveKey clone2 = c2.Clone();

            // Make sure they arent the same instance
            Assert.AreNotSame(c1, clone1, "#1");
            Assert.AreNotSame(c2, clone2, "#2");

            Assert.AreEqual(c1, clone1, "#3");
            Assert.AreEqual(c2, clone2, "#4");
        }



        [Test]
        public void Continuity()
        {
            Assert.AreEqual(CurveContinuity.Smooth, c1.Continuity, "#1");
            Assert.AreEqual(CurveContinuity.Step, c2.Continuity, "#2");
        }



        [Test]
        public void CompareTo()
        {
            Assert.IsTrue(c1.CompareTo(c2) < 0, "#1");
            Assert.IsTrue(c2.CompareTo(c1) > 0, "#2");
            Assert.IsTrue(c1.CompareTo(new CurveKey(125, 251)) < 0, "#3");
            Assert.IsTrue(c1.CompareTo(new CurveKey(1, 1)) == 0, "#4");
            Assert.IsTrue(c1.CompareTo(new CurveKey(-12, -15)) > 0, "#5");
        }



        [Test]
        public void TestEquals()
        {
#pragma warning disable 1718
            CurveKey clone1 = new CurveKey(1f, 2f, 3f, -3f, CurveContinuity.Smooth);

            Assert.IsTrue(c1.Equals(c1), "#1");
            Assert.IsTrue(c1.Equals(clone1), "#2");
            Assert.IsFalse(c1.Equals(null), "#3");

            Assert.IsFalse(c1.Equals(c2), "#5");


            Assert.IsTrue(c1 == c1, "#6");
            Assert.IsTrue(c1 == clone1, "#7");
            Assert.IsFalse(c1 != c1, "#8");
            Assert.IsFalse(c1 != clone1, "#9");

            int a = 5;
            Assert.AreNotEqual(c1, a, "#10");
#pragma warning restore 1718
        }



        [Test]
        public void Position()
        {
            Assert.AreEqual(1f, c1.Position, "#1");
            Assert.AreEqual(2f, c2.Position, "#2");
        }



        [Test]
        public void TangentIn()
        {
            Assert.AreEqual(3f, c1.TangentIn, "#1");
            Assert.AreEqual(6f, c2.TangentIn, "#2");

            c1.TangentIn = 155;
            c2.TangentIn = 175;

            Assert.AreEqual(155f, c1.TangentIn, "#3");
            Assert.AreEqual(175f, c2.TangentIn, "#4");
        }



        [Test]
        public void TangentOut()
        {
            Assert.AreEqual(-3f, c1.TangentOut, "#1");
            Assert.AreEqual(6.7f, c2.TangentOut, "#2");

            c1.TangentOut = 45;
            c2.TangentOut = 15;

            Assert.AreEqual(45f, c1.TangentOut, "#3");
            Assert.AreEqual(15f, c2.TangentOut, "#4");
        }



        [Test]
        public void TestToString()
        {
            Assert.AreEqual("Microsoft.Xna.Framework.CurveKey", c1.ToString(), "#1");
            Assert.AreEqual("Microsoft.Xna.Framework.CurveKey", c2.ToString(), "#2");
        }



        [Test]
        public void Value()
        {
            Assert.AreEqual(2f, c1.Value, "#1");
            Assert.AreEqual(4f, c2.Value, "#2");

            c1.Value = 15.5f;
            c2.Value = -12.7f;

            Assert.AreEqual(15.5f, c1.Value, "#3");
            Assert.AreEqual(-12.7f, c2.Value, "#4");
        }
    }
}
