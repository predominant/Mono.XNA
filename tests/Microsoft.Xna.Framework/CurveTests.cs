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
    public class CurveTests
    {
        #region Setup
        private Curve curve1;
        private Curve curve2;

        [SetUp]
        public void TestSetup()
        {
            curve1 = new Curve();
            curve2 = new Curve();
            curve2.PostLoop = CurveLoopType.CycleOffset;
            curve2.PreLoop = CurveLoopType.Oscillate;

            curve2.Keys.Add(new CurveKey(1.5f, 2.5f, 3.0f, -0.3333f, CurveContinuity.Smooth));
            curve2.Keys.Add(new CurveKey(5.5f, 2.5f, 3.0f, -1.3333f, CurveContinuity.Step));
            curve2.Keys.Add(new CurveKey(9.5f, 2.5f, 6.0f, -0.9333f, CurveContinuity.Smooth));
            curve2.Keys.Add(new CurveKey(17.5f, 4.5f, 3.0f, -0.13f, CurveContinuity.Step));
        }
        #endregion Setup

        #region Methods
        [Test]
        public void Clone()
        {
            Curve clone1 = curve1.Clone();
            Curve clone2 = curve2.Clone();

            Assert.AreNotSame(curve1, clone1, "#1");
            Assert.AreNotSame(curve1.Keys, clone1.Keys, "#2");

            Assert.AreNotSame(curve2, clone2, "#3");
            Assert.AreNotSame(curve2.Keys, clone2.Keys, "#4");

            Assert.AreEqual(curve1.Keys.Count, clone1.Keys.Count, "#5");
            Assert.AreEqual(curve2.Keys.Count, clone2.Keys.Count, "#6");

            Assert.AreNotEqual(curve1, clone1, "#7");
            Assert.AreNotEqual(curve2, clone2, "#8");

            for (int i = 0; i < curve1.Keys.Count; i++)
                Assert.AreNotSame(curve1.Keys[i], clone1.Keys[i], "#9." + i.ToString());

            for (int i = 0; i < curve1.Keys.Count; i++)
                Assert.AreNotSame(curve2.Keys[i], clone2.Keys[i], "#10." + i.ToString());
        }


        [Test]
        public void EqualsTest()
        {
            Curve clone1 = new Curve();
            Curve clone2 = new Curve();
            curve2.Keys.Add(new CurveKey(1.5f, 2.5f, 3.0f, -0.3333f, CurveContinuity.Smooth));
            curve2.Keys.Add(new CurveKey(5.5f, 2.5f, 3.0f, -1.3333f, CurveContinuity.Step));
            curve2.Keys.Add(new CurveKey(9.5f, 2.5f, 6.0f, -0.9333f, CurveContinuity.Smooth));
            curve2.Keys.Add(new CurveKey(17.5f, 4.5f, 3.0f, -0.13f, CurveContinuity.Step));

            Assert.AreNotEqual(curve1, curve2, "#1");
            Assert.AreNotEqual(curve1, clone1, "#2");
            Assert.AreNotEqual(curve2, clone2, "#3");

            Assert.IsFalse(curve1 == clone1, "#4");
            Assert.IsTrue(curve1 != clone1, "#5");

            Assert.IsFalse(curve2 == clone2, "#6");
            Assert.IsTrue(curve2 != clone2, "#7");

            int a = 5;
            Assert.AreNotEqual(curve1, a, "#8");
            Assert.AreNotEqual(curve1, null, "#9");
        }


        [Test]
        public void Evaluate()
        {
            Assert.IsTrue(TestHelper.ApproximatelyEquals(2.18750477f, curve2.Evaluate(0)), "#1");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(2.42708659f, curve2.Evaluate(1)), "#2");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(2.379453f, curve2.Evaluate(2.2222f)), "#3");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(2.03125286f, curve2.Evaluate(4)), "#4");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(2.5f, curve2.Evaluate(8)), "#5");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(4.48530245f, curve2.Evaluate(17.64236f)), "#6");
        }


        [Test]
        public void IsConstant()
        {
            Assert.IsTrue(curve1.IsConstant, "#1");
            Assert.IsFalse(curve2.IsConstant, "#2");
        }


        [Test]
        public void Keys()
        {
            Assert.IsTrue(curve1.Keys != null, "#1");
            Assert.IsTrue(curve2.Keys != null, "#2");
        }


        [Test]
        public void PreLoop()
        {
            Assert.AreEqual(CurveLoopType.Constant, curve1.PreLoop, "#1");
            Assert.AreEqual(CurveLoopType.Oscillate, curve2.PreLoop, "#2");
        }


        [Test]
        public void PostLoop()
        {
            Assert.AreEqual(CurveLoopType.Constant, curve1.PostLoop, "#1");
            Assert.AreEqual(CurveLoopType.CycleOffset, curve2.PostLoop, "#2");
        }


        [Test]
        public void ToStringTest()
        {
            Assert.AreEqual("Microsoft.Xna.Framework.Curve", curve1.ToString(), "#1");
            Assert.AreEqual("Microsoft.Xna.Framework.Curve", curve2.ToString(), "#2");
        }
        #endregion Methods
    }
}
