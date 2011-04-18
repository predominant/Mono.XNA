#region License
/*
MIT License
Copyright © 2006 - 2007 The Mono.Xna Team

All rights reserved.

Authors:
 * Rob Loach

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
using Microsoft.Xna.Framework.Graphics;
using NUnit.Framework;

namespace Tests.Microsoft.Xna.Framework.Graphics
{
    [TestFixture]
    public class PresentationParametersTests
    {
        #region Fields
        private PresentationParameters a;
        #endregion Fields


        #region Setup
        [SetUp]
        public void Setup()
        {
            a = new PresentationParameters();
            a.AutoDepthStencilFormat = DepthFormat.Depth32;
            a.BackBufferCount = 2;
            a.BackBufferFormat = SurfaceFormat.Vector2;
            a.BackBufferHeight = 1000;
            a.BackBufferWidth = 400;
            a.EnableAutoDepthStencil = true;
            a.FullScreenRefreshRateInHz = 32;
            a.IsFullScreen = true;
            a.MultiSampleQuality = 32;
            a.MultiSampleType = MultiSampleType.NonMaskable;
            a.PresentationInterval = PresentInterval.Four;
            a.PresentOptions = PresentOptions.Video;
            a.SwapEffect = SwapEffect.Flip;
        }
        #endregion Setup


        #region Equals
        [Test]
        public void EqualsTest()
        {
            PresentationParameters b = new PresentationParameters();
            Assert.IsFalse(b == a, "#1");
            Assert.IsTrue(b != a, "#2");
            Assert.IsFalse(b == null, "#3");
            Assert.IsTrue(b.Equals(b), "#4");
        }
        #endregion Equals


        #region ToStringTest
        [Test]
        public void ToStringTest()
        {
            Assert.AreEqual(a.ToString(), "Microsoft.Xna.Framework.Graphics.PresentationParameters", "#1");
        }
        #endregion ToStringTest


        #region CloneTest
        [Test]
        public void CloneTest()
        {
            Assert.IsTrue(a.Clone() == a, "#1");
        }
        #endregion CloneTest
    }
}
