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
#endregion License

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NUnit.Framework;

namespace Tests.Microsoft.Xna.Framework.Graphics
{
    [TestFixture]
    public class TextureInformationTests
    {
        #region Fields

        private TextureInformation a;

        #endregion Fields


        [SetUp]
        public void Setup()
        {
            a = new TextureInformation();
            a.Depth = 32;
            a.Format = SurfaceFormat.Bgr444;
            a.Height = 500;
            a.MipLevels = 3;
            a.Width = 400;
        }

        [Test]
        public void ConstructorTest()
        {
            a = new TextureInformation();
            Assert.AreEqual(a.Depth, 0, "#1");
            Assert.AreEqual(a.Format, (SurfaceFormat)0, "#2");
            Assert.AreEqual(a.Height, 0, "#3");
            Assert.AreEqual(a.ImageFormat, ImageFileFormat.Bmp, "#4");
            Assert.AreEqual(a.MipLevels, 0, "#5");
            Assert.AreEqual(a.ResourceType, (ResourceType)0, "#6");
            Assert.AreEqual(a.Width, 0, "#7");


            a = new TextureInformation(15, 26, 37, 115, SurfaceFormat.Rgba1010102);
            Assert.AreEqual(a.Depth, 37, "#8");
            Assert.AreEqual(a.Format, SurfaceFormat.Rgba1010102, "#9");
            Assert.AreEqual(a.Height, 26, "#10");
            Assert.AreEqual(a.ImageFormat, ImageFileFormat.Jpg, "#11");
            Assert.AreEqual(a.MipLevels, 115, "#12");
            Assert.AreEqual(a.ResourceType, ResourceType.Texture2D, "#13");
            Assert.AreEqual(a.Width, 15, "#14");
        }


        [Test]
        public void EqualsTest()
        {
            TextureInformation b = new TextureInformation();
            Assert.IsFalse(b == a, "#1");
            Assert.IsTrue(b != a, "#2");
            Assert.IsFalse(b.Equals(null), "#3");
            Assert.IsTrue(b.Equals(b), "#4");
            int val = 0;
            Assert.IsFalse(b.Equals(val));
        }


        [Test]
        public void ToStringTest()
        {
            Assert.AreEqual("{Width:400 Height:500 Format:Bgr444 Depth:32 MipLevels:3}", a.ToString(), "#1");
        }
    }
}
