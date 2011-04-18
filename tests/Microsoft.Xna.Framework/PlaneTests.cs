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

namespace Tests.Microsoft.Xna.Framework
{
    [TestFixture]
    public class PlaneTests
    {
		#region Setup
		private Plane p;

		[SetUp]
		public void Setup()
		{
			p = new Plane(new Vector3(1f, 2f, 3f), 4f);
		}
		#endregion Setup

        [Test]
        public void ToStringTest()
        {
			Assert.AreEqual("{Normal:{X:1 Y:2 Z:3} D:4}", p.ToString(), "#1");
        }

        [Test]
        public void EqualsTest()
        {
			Assert.IsTrue(p.Equals(p),"#1");
			Assert.IsTrue(p.Equals(new Plane(new Vector3(1f, 2f, 3f), 4f)), "#2");			
        }

		[Test]
		public void NormalizeTest()
		{
			Plane p1 = Plane.Normalize(new Plane(2.2f, 3.3f, -1.1f, -2.2f));
			Plane r1 = new Plane(0.5345225f,  0.8017837f, -0.2672612f, -0.5345225f);
			
			Plane plane = new Plane(-1.33f, 0f, 2.25f, 1.77f);
			Plane p2 = new Plane();
			Plane.Normalize(ref plane, out p2);
			Plane r2 = new Plane(-0.5088582f, 0f, 0.8608503f, 0.6772023f);
			
			Plane p3 = new Plane(0.5f, 1f, 2.25f, 3.3334f);
			Plane r3 = new Plane(0.1990075f, 0.3980149f, 0.8955336f, 1.326743f);
			p3.Normalize();
			
			Assert.AreEqual(TestHelper.Approximate(r1), TestHelper.Approximate(p1), "#1");
			Assert.AreEqual(TestHelper.Approximate(r2), TestHelper.Approximate(p2), "#2");
			Assert.AreEqual(TestHelper.Approximate(r3), TestHelper.Approximate(p3), "#3");
		}
		
		//do not need it all intersect test ever done in other class
		//[Test]
		//public void IntersectsTest()
		//{
		//    throw new NotImplementedException();
		//}
    }
}
