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
    public class CurveKeyCollectionTests
    {
        CurveKey k1;
        CurveKey k2;
        CurveKey k3;
        CurveKeyCollection c;

        [SetUp]
        public void Setup()
        {
            k1 = new CurveKey(12, 123);
            k2 = new CurveKey(11, 11);
            k3 = new CurveKey(-1, -11);

            c = new CurveKeyCollection();
            c.Add(k1);
            c.Add(k2);
            c.Add(k3);
        }

        [Test]
        public void ConstructTests()
        {
            Assert.AreEqual(k3, c[0], "#1");
            Assert.AreEqual(k2, c[1], "#2");
            Assert.AreEqual(k1, c[2], "#3");
        }


        [Test]
        public void Add()
        {
            CurveKey k = new CurveKey(123, 123);
            c.Add(k);
            Assert.AreEqual(4, c.Count, "#1");
            Assert.AreEqual(k, c[3], "#2");

            c.Add(k);
            Assert.AreEqual(5, c.Count, "#3");
            Assert.AreEqual(k, c[4], "#4");
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException), "Value cannot be null.")]
        public void AddNull()
        {
            c.Add(null);
        }


        [Test]
        public void Clear()
        {
            c.Add(new CurveKey(123, 123));
            c.Add(new CurveKey(1232, 432));
            c.Add(new CurveKey(11, 11));
            c.Clear();
            Assert.IsTrue(c.Count == 0, "#1");
        }


        [Test]
        public void Clone()
        {
            CurveKeyCollection col = c.Clone();
            Assert.AreNotSame(c, col, "#1");
            Assert.AreEqual(c.Count, col.Count, "#2");
            Assert.AreNotEqual(c, col, "#3");
        }


        [Test]
        public void CopyTo()
        {
            CurveKey[] array = new CurveKey[c.Count];
            c.CopyTo(array, 0);
            Assert.AreEqual(k3.Position, array[0].Position, "#1");
            Assert.AreEqual(k2.Position, array[1].Position, "#2");
            Assert.AreEqual(k1.Position, array[2].Position, "#3");
        }


        [Test]
        public void Count()
        {
            Assert.AreEqual(3, c.Count);
        }


        [Test]
        public void TestEquals()
        {
            CurveKeyCollection clone = c.Clone();

            Assert.AreEqual(c, c, "#1");
            Assert.AreNotEqual(c, clone, "#2");
            Assert.AreNotSame(c, clone, "#3");
            Assert.AreNotEqual(c, new CurveKeyCollection(), "#4");
            Assert.AreNotEqual(c, null, "#5");
            Assert.AreNotSame(c, null, "#6");
        }


        [Test]
        public void Contains()
        {
            Assert.IsTrue(c.Contains(k1), "#1");
            Assert.IsTrue(c.Contains(k2), "#2");
            Assert.IsTrue(c.Contains(k3), "#3");
            Assert.IsFalse(c.Contains(new CurveKey(3, 34)), "#4");

            Assert.IsFalse(c.Contains(null), "#5");
        }


        [Test]
        public void IndexOf()
        {
            Assert.AreEqual(2, c.IndexOf(k1), "#1");
            Assert.AreEqual(1, c.IndexOf(k2), "#2");
            Assert.AreEqual(0, c.IndexOf(k3), "#3");
            Assert.AreEqual(-1, c.IndexOf(null), "#4");
        }


        [Test]
        public void IsReadOnly()
        {
            Assert.IsFalse(c.IsReadOnly);
        }


        [Test]
        public void Remove()
        {
            Assert.IsTrue(c.Remove(k1), "#1");
            Assert.IsTrue(c.Remove(k2), "#2");

            Assert.AreEqual(1, c.Count, "#3");
            Assert.IsFalse(c.Remove(null), "#4");
        }


        [Test]
        public void RemoveAt()
        {
            c.RemoveAt(1);
            Assert.AreEqual(2, c.Count, "#1");

            Assert.IsTrue(c.Contains(k1), "#2");
            Assert.IsTrue(c.Contains(k3), "#3");
        }


        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
                           "Index was out of range. Must be non-negative and less than the size of the collection.\r\nParameter name: index")]
        public void RemoveAtNegative()
        {
            c.RemoveAt(-1);
        }


        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
                           "Index was out of range. Must be non-negative and less than the size of the collection.\r\nParameter name: index")]
        public void RemoveAtInfinity()
        {
            c.RemoveAt(c.Count);
        }


        [Test]
        public void TestToString()
        {
            Assert.AreEqual("Microsoft.Xna.Framework.CurveKeyCollection", c.ToString());
        }

    }
}
