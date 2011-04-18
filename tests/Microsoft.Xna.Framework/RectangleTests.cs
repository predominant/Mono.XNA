#region License
/*
MIT License
Copyright  2006-2007 The Mono.Xna Team

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
    public class RectangleTests
    {
		Rectangle r;
		[SetUp]
		public void Setup()
		{
			r = new Rectangle(0, 0, 50, 20);
		}

        [Test]
        public void ToStringTest()
        {
			Assert.AreEqual(r.ToString(), "{X:0 Y:0 Width:50 Height:20}","#ToString1");
        }

        [Test]
        public void EqualsTest()
        {
			Assert.IsTrue(r.Equals(r), "#Equals1");
			Assert.IsTrue(r.Equals(new Rectangle(0,0,50,20)), "#Equals2");
			Assert.IsFalse(r.Equals(new Rectangle(0, 1, 50, 20)), "#Equals3");
        }

        [Test]
        public void InflateTest()
        {
			r.Inflate(1, 2);
			Assert.IsTrue(r.Equals(new Rectangle(-1,-2,52,24)), "#Inflate1");
        }

        [Test]
        public void OffsetTest()
        {
			r.Offset(1, 2);
			Assert.IsTrue(r.Equals(new Rectangle(1, 2, 50, 20)), "#Offset1");
        }
		
		[Test]
		public void IntersectsTest()
		{
            Rectangle rect1 = new Rectangle(50, 50, 50, 50);
            Rectangle rect2 = new Rectangle(0, 0, 20, 20);

            // 1 false
			Assert.IsFalse(rect1.Intersects(rect2), "#Intersects1");
            // 2 false
            rect2.X = 20;
            rect2.Y = 20;
            Assert.IsFalse(rect1.Intersects(rect2), "#Intersects2");
            // 3 false      upper left
            rect2.X = 30;
            rect2.Y = 30;
            Assert.IsFalse(rect1.Intersects(rect2), "#Intersects3");
            // 4 false
            rect2.X = 50;
            rect2.Y = 30;
            Assert.IsFalse(rect1.Intersects(rect2), "#Intersects4");
            // 5 false
            rect2.X = 30;
            rect2.Y = 50;
            Assert.IsFalse(rect1.Intersects(rect2), "#Intersects5");
            // 6 true
            rect2.X = 31;
            rect2.Y = 50;
            Assert.IsTrue(rect1.Intersects(rect2), "#Intersects6");
            // 7 true
            rect2.X = 50;
            rect2.Y = 31;
            Assert.IsTrue(rect1.Intersects(rect2), "#Intersects7");
            // 8 true
            rect2.X = 31;
            rect2.Y = 31;
            Assert.IsTrue(rect1.Intersects(rect2), "#Intersects8");
            // 9 false       upper right
            rect2.X = 100;
            rect2.Y = 30;
            Assert.IsFalse(rect1.Intersects(rect2), "#Intersects9");
            // 10 true
            rect2.X = 99;
            rect2.Y = 31;
            Assert.IsTrue(rect1.Intersects(rect2), "#Intersects10");
            // 11 false
            rect2.X = 100;
            rect2.Y = 31;
            Assert.IsFalse(rect1.Intersects(rect2), "#Intersects11");
            // 12 false
            rect2.X = 99;
            rect2.Y = 30;
            Assert.IsFalse(rect1.Intersects(rect2), "#Intersects12");
            // 13 false
            rect2.X = 100;
            rect2.Y = 50;
            Assert.IsFalse(rect1.Intersects(rect2), "#Intersects13");
            // 14 true
            rect2.X = 99;
            rect2.Y = 50;
            Assert.IsTrue(rect1.Intersects(rect2), "#Intersects14");
            // 15 fase      down left
            rect2.X = 100;
            rect2.Y = 100;
            Assert.IsFalse(rect1.Intersects(rect2), "#Intersects15");
            // 16  true
            rect2.X = 99;
            rect2.Y = 99;
            Assert.IsTrue(rect1.Intersects(rect2), "#Intersects16");
            // 17 false
            rect2.X = 99;
            rect2.Y = 100;
            Assert.IsFalse(rect1.Intersects(rect2), "#Intersects17");
            // 18 false
            rect2.X = 100;
            rect2.Y = 99;
            Assert.IsFalse(rect1.Intersects(rect2), "#Intersects18");
		}
    }
}
