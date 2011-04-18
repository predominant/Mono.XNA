#region License
/*
MIT License
Copyright © 2006-2007 The Mono.Xna Team

All rights reserved.

Authors: Isaac Llopis (neozack@gmail.com)

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
    public class DrawableGameComponentTests
    {
        DrawableGameComponent component;

        #region Setup

        [SetUp]
        public void Setup()
        {
            component = new DrawableGameComponent(new Game());
        }

        #endregion

        #region Public Constructors

        [Test]
        public void Constructors()
        {
            Assert.IsNotNull(component);
        }

        #endregion

        #region Public Fields Tests
        #endregion

        #region Protected Fields Tests
        #endregion

        #region Public Properties Tests

        /// <summary>
        /// Ensure default for GameComponent.Enabled is true
        /// </summary>
        [Test]
        public void DefaultEnabledIsTrueTest()
        {
            Assert.IsTrue(component.Enabled);
        }

        /// <summary>
        /// Ensure default value for UpdateOrder is 0
        /// </summary>
        [Test]
        public void DefaultUpdateOrderIsZeroTest()
        {
            Assert.AreEqual(0, component.UpdateOrder);
        }        

        /// <summary>
        /// Ensure default value for DrawOrder is 0
        /// </summary>
        [Test]
        public void DefaultDrawOrderIsZeroTest()
        {
            Assert.AreEqual(0, component.DrawOrder);
        }        
        
        /// <summary>
        /// Ensure default value for Visible is true
        /// </summary>
        [Test]
        public void DefaultVisibleIsTrueTest()
        {
            Assert.IsTrue(component.Visible);
        }

        #endregion

        #region Other tests

        [Test]
        public void EnableChangedFiredTest()
        {
            bool fired = false;
            component.Enabled = false;
            component.EnabledChanged += delegate { fired = true; };
            component.Enabled = true;
            Assert.IsTrue(fired);
        }

        [Test]
        public void EnableChangedDoesNotFireWhenValueIsntChangedTest()
        {
            bool fired = false;
            component.EnabledChanged += delegate { fired = true; };
            component.Enabled = component.Enabled;
            Assert.IsFalse(fired, "EnabledChanged should not have fired");
        }

        [Test]
        public void VisibleChangedFiredTest()
        {
            bool fired = false;
            component.Visible = false;
            component.VisibleChanged += delegate { fired = true; };
            component.Visible = true;
            Assert.IsTrue(fired);
        }

        [Test]
        public void VisibleChangedDoesNotFireWhenValueIsntChangedTest()
        {
            bool fired = false;
            component.VisibleChanged += delegate { fired = true; };
            component.Visible = component.Visible;
            Assert.IsFalse(fired, "VisibleChanged should not have fired");
        }

        [Test]
        public void UpdateOrderChangedFiredTest()
        {
            bool fired = false;
            component.UpdateOrderChanged += delegate { fired = true; };
            component.UpdateOrder = 100;
            Assert.IsTrue(fired);
        }

        [Test]
        public void UpdateOrderChangedDoesNotFireWhenValueIsntChangedTest()
        {
            bool fired = false;
            component.UpdateOrder = 10;
            component.UpdateOrderChanged += delegate { fired = true; };
            component.UpdateOrder = 10;
            Assert.IsFalse(fired, "UpdateOrderChanged should not have fired");
        }

        [Test]
        public void DrawOrderChangedFiredTest()
        {
            bool fired = false;
            component.DrawOrderChanged += delegate { fired = true; };
            component.DrawOrder = 100;
            Assert.IsTrue(fired);
        }

        [Test]
        public void DrawOrderChangedDoesNotFireWhenValueIsntChangedTest()
        {
            bool fired = false;
            component.DrawOrder = 10;
            component.DrawOrderChanged += delegate { fired = true; };
            component.DrawOrder = 10;
            Assert.IsFalse(fired, "UpdateOrderChanged should not have fired");
        }

        [Test]
        public void DisposedEventRaisedTest()
        {
            bool fired = false;
            component.Disposed += delegate { fired = true; };
            component.Dispose();
            Assert.IsTrue(fired);
        }

        #endregion
    }
    
}
