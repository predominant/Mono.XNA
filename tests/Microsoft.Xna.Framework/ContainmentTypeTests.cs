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
    public class ContainmentTypeTests
    {
        [Test]
        public void UnderlyingValues()
        {
            Type t = Enum.GetUnderlyingType(typeof(ContainmentType));
            Assert.AreEqual(typeof(Int32), t, "#1");

            int val;


            val = (int)ContainmentType.Disjoint;
            Assert.AreEqual(val, 0, "#3");


            val = (int)ContainmentType.Contains;
            Assert.AreEqual(val, 1, "#2");


            val = (int)ContainmentType.Intersects;
            Assert.AreEqual(val, 2, "#4");

            int[] values = (int[])Enum.GetValues(typeof(ContainmentType));
            Assert.AreEqual(3, values.Length, "#5");
        }
    }
}
