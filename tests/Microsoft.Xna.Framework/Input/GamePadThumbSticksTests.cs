#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.

Authors: Rob Loach

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
using Microsoft.Xna.Framework.Input;

namespace Tests.Microsoft.Xna.Framework.Input
{
    [TestFixture]
    public class GamePadThumbSticksTests
    {
        #region Setup
        private GamePadThumbSticks sticks1;
        private GamePadThumbSticks sticks2;

        [SetUp]
        public void Setup()
        {
            sticks1 = new GamePadThumbSticks();
            sticks2 = new GamePadThumbSticks();
        }
        #endregion Setup


        #region EqualsTest
        [Test]
        public void EqualsTest()
        {
            Assert.IsTrue(sticks1 == sticks1, "#1");
            Assert.IsTrue(sticks2.Equals(sticks1), "#2");
        }
        #endregion EqualsTest


        #region ToStringTest
        [Test]
        public void ToStringTest()
        {
            Assert.AreEqual("{Left:{X:0 Y:0} Right:{X:0 Y:0}}", sticks1.ToString());
        }
        #endregion ToStringTestv


        #region PropertiesTest
        [Test]
        public void PropertiesTest()
        {
            Assert.AreEqual(sticks1.Left, sticks1.Right);
        }
        #endregion PropertiesTest
    }
}
