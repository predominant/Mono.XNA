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
    public class GameComponentCollectionEventArgsTests
    {
        #region Setup
        #endregion

        #region Public Constructors

        [Test]
        public void Constructors()
        {
            GameComponentCollectionEventArgs args = new GameComponentCollectionEventArgs(null);
            Assert.IsNotNull(args, "Failed to create type");
        }

        #endregion

        #region Public Fields Tests
        #endregion
        
        #region Protected Fields Tests
        #endregion

        #region Public Properties Tests

        [Test]
        public void GameComponent()
        {
            MyComponent c = new MyComponent(new TestGame());
            GameComponentCollectionEventArgs args = new GameComponentCollectionEventArgs(c);
            Assert.AreSame(c, args.GameComponent);
        }

        #endregion
        
        
    }
     
}
