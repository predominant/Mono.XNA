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
    public class GameServiceContainerTests
    {
        GameServiceContainer services;
        TestGame game;

        #region Setup

        [SetUp]
        public void Init()
        {
            game = new TestGame(true);
            services = game.Services;
        }

        #endregion


        #region Public Constructors

        [Test]
        public void Constructors()
        {
            Assert.IsNotNull(services);
        }

        #endregion

        #region Public Fields Tests
        #endregion
        
        #region Protected Fields Tests
        #endregion

        #region Public Properties Tests
        #endregion
        
        #region Protected Properties Tests
        #endregion

        #region Public Methods Tests

        [Test]
        public void AddServiceAndGetServiceTest()
        {
            string s = "Hello";
            services.AddService(typeof(string), s);

            string s2 = (string)services.GetService(typeof (string));
            Assert.AreSame(s, s2, "Service was not correctly added");
        }

        [Test]
        public void GetServiceThatDoesntExistTest()
        {
            string s = "Hello";
            services.AddService(typeof(string), s);

            IServiceProvider sp = (IServiceProvider)services.GetService(typeof (IServiceProvider));
            Assert.IsNull(sp);
        }

        [Test]
        public void RemoveService()
        {
            string s = "Hello";
            services.AddService(typeof(string), s);

            services.RemoveService(typeof(string));
            string s2 = (string)services.GetService(typeof(string));
            Assert.IsNull(s2);
        }

        [ExpectedException(typeof(ArgumentException))]
        [Test]
        public void AddDuplicateServiceService()
        {
            string s = "Hello";
            services.AddService(typeof(string), s);

            string s2 = "Hello Again";
            services.AddService(typeof(string), s2);
        }

        #endregion Public Methods Tests
    }
     
}
