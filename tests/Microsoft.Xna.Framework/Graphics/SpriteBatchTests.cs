#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team
http://www.taoframework.com
All rights reserved.

Authors:
Olivier Dufour (Duff)

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
#endregion License

using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Tests;
using System.Threading;
using Microsoft.Xna.Framework.Tests;
using System.IO;

namespace Tests.Microsoft.Xna.Framework.Graphics
{
    [TestFixture]
    public class SpriteBatchTests
    {
        TestGame game;
        Thread gameThread;
        SpriteBatch sprite;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            this.game = new TestGame();
            this.gameThread = new Thread(new ThreadStart(game.Run));
            this.gameThread.Start();
            
            // I need to give the game enough time to initialise before letting the tests continue
            System.Threading.Thread.Sleep(200);
        }

        [TestFixtureTearDown]
        public void TestFixtureTeardown()
        {
            game.Exit();
            gameThread.Join(500);
        }

        [SetUp]
        public void Setup()
        {
            sprite = new SpriteBatch(game.GraphicsDeviceManager.GraphicsDevice);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException), "Begin must be called successfully before End can be called.")]
        public void EndTest()
        {
            sprite.End();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException), "Begin must be called successfully before a Draw can be called.")]
        public void DrawTest()
        {
            /*
            byte[] data;
            try
            {
                using (Stream str = ResourceReader.GetResourceStream("texture2d.jpg"))
                {
                    data = new byte[str.Length];
                    str.Read(data, 0, data.Length);
                }
            }

            catch
            {
                throw new Exception("Can't load the game");
            }

            MemoryStream s = new MemoryStream();
            s.Write(data, 0, data.Length);
            s.Write(data, 0, data.Length);
            s.Write(data, 0, data.Length);
            s.Seek(0, SeekOrigin.Begin);*/

			Stream str = ResourceReader.GetResourceStream("texture2d.jpg");
            Texture2D texture = Texture2D.FromFile(game.GraphicsDeviceManager.GraphicsDevice, str);
            sprite.Draw(texture, new Rectangle(), Color.White);
        }


        [Test]
        [ExpectedException(typeof(InvalidOperationException), "Begin cannot be called again until End has been successfully called.")]
        public void BeginTest()
        {
            sprite.Begin();
            sprite.Begin();
        }

    }
}
