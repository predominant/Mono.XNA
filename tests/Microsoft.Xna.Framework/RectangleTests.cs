#region License
/*
MIT License
Copyright © 2006-2007 The Mono.Xna Team

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

namespace Microsoft.Xna.Framework.Tests
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
    }
}
