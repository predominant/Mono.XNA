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

namespace Microsoft.Xna.Framework.Tests
{
    [TestFixture]
    public class MatrixTests
    {
        #region Instance methods
        [Test]
        public void Add()
        {
            Matrix m = new Matrix(1, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2);
            Matrix n = new Matrix(9, 8, 7, 6, 5, 4, 3, 2, 1, 2, 3, 4, 5, 6, 7, 8);
            Matrix expected = new Matrix(10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10);

            m = m + n;
            Assert.AreEqual(expected, m, "#1");
            Assert.AreEqual(n, new Matrix(9, 8, 7, 6, 5, 4, 3, 2, 1, 2, 3, 4, 5, 6, 7, 8), "test 1");

            m = new Matrix(1, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2);
            m = Matrix.Add(m, n);
            Assert.AreEqual(expected, m, "test 2");

            m = new Matrix(1, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2);
            Matrix outResult;
            Matrix.Add(ref m, ref n, out outResult);
            Assert.AreEqual(expected, outResult, "Test 3");
        }


        [Test]
        public void Backward()
        {
            Matrix m = new Matrix(9, 8, 7, 6, 5, 4, 3, 2, 1, 2, 3, 4, 5, 6, 7, 8);
            m.Backward = new Vector3(100, 200, 300);
            Matrix expected = new Matrix(9, 8, 7, 6, 5, 4, 3, 2, 100, 200, 300, 4, 5, 6, 7, 8);

            Assert.AreEqual(expected, m);
        }


        [Test]
        public void Determinant()
        {
            Matrix m = new Matrix(1, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2);
            Assert.AreEqual(0, m.Determinant(), "test 1");

            m = new Matrix(1, 2, 3, 2.665f, 3, 2, 31.43234f, 3, 6, 4, 2, 6, 3, 6, 532, 3);
            Assert.AreEqual(-1216.07629f, m.Determinant(), "test 2");
        }


        [Test]
        public void Down()
        {
            Matrix m = new Matrix(9, 8, 7, 6, 5, 4, 3, 2, 1, 2, 3, 4, 5, 6, 7, 8);
            m.Down = new Vector3(100, 200, 300);
            Matrix expected = new Matrix(9, 8, 7, 6, -100, -200, -300, 2, 1, 2, 3, 4, 5, 6, 7, 8);

            Assert.AreEqual(expected, m);
        }


        [Test]
        public void Forward()
        {
            Matrix m = new Matrix(9, 8, 7, 6, 5, 4, 3, 2, 1, 2, 3, 4, 5, 6, 7, 8);
            m.Forward = new Vector3(100, 200, 300);
            Matrix expected = new Matrix(9, 8, 7, 6, 5, 4, 3, 2, -100, -200, -300, 4, 5, 6, 7, 8);
            Assert.AreEqual(expected, m);
        }


        [Test]
        public void Left()
        {
            Matrix m = new Matrix(9, 8, 7, 6, 5, 4, 3, 2, 1, 2, 3, 4, 5, 6, 7, 8);
            m.Left = new Vector3(100, 200, 300);
            Matrix expected = new Matrix(-100, -200, -300, 6, 5, 4, 3, 2, 1, 2, 3, 4, 5, 6, 7, 8);

            Assert.AreEqual(expected, m);
        }


        [Test]
        public void Right()
        {
            Matrix m = new Matrix(9, 8, 7, 6, 5, 4, 3, 2, 1, 2, 3, 4, 5, 6, 7, 8);
            m.Right = new Vector3(100, 200, 300);
            Matrix expected = new Matrix(100, 200, 300, 6, 5, 4, 3, 2, 1, 2, 3, 4, 5, 6, 7, 8);

            Assert.AreEqual(expected, m);
        }


        [Test]
        public void ToStringTest()
        {
            Matrix m = new Matrix(1, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2);
            string expected = "{ {M11:1 M12:2 M13:3 M14:4} {M21:5 M22:6 M23:7 M24:8} {M31:9 M32:8 M33:7 M34:6} {M41:5 M42:4 M43:3 M44:2} }";
            Assert.AreEqual(expected, m.ToString());

        }


        [Test]
        public void Translation()
        {
            Matrix m = new Matrix(9, 8, 7, 6, 5, 4, 3, 2, 1, 2, 3, 4, 5, 6, 7, 8);
            m.Translation = new Vector3(100, 200, 300);
            Matrix expected = new Matrix(9, 8, 7, 6, 5, 4, 3, 2, 1, 2, 3, 4, 100, 200, 300, 8);
            Assert.AreEqual(expected, m);
        }


        [Test]
        public void Up()
        {
            Matrix m = new Matrix(9, 8, 7, 6, 5, 4, 3, 2, 1, 2, 3, 4, 5, 6, 7, 8);
            m.Up = new Vector3(100, 200, 300);
            Matrix expected = new Matrix(9, 8, 7, 6, 100, 200, 300, 2, 1, 2, 3, 4, 5, 6, 7, 8);

            Assert.AreEqual(expected, m);
        }
        #endregion Instance methods
    }
}
