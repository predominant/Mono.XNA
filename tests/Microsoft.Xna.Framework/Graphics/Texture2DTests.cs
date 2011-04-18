#region License
/*
MIT License
Copyright © 2006 - 2007 The Mono.Xna Team

All rights reserved.

Authors:
 * Alan McGovern

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
using Microsoft.Xna.Framework.Graphics;
using NUnit.Framework;
using Microsoft.Xna.Framework.Tests;
using Microsoft.Xna.Framework.Content.Tests;
using System.Threading;
using System.IO;

namespace Tests.Microsoft.Xna.Framework.Graphics
{
    [TestFixture]
    public class Texture2DTests
    {
        TestGame game;
        Thread gameThread;
        Texture2D texture;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            this.game = new TestGame();
            this.gameThread = new Thread(new ThreadStart(game.Run));
            this.gameThread.Start();

            // I need to give the game enough time to initialise before letting the tests continue
            System.Threading.Thread.Sleep(100);
        }

        [TestFixtureTearDown]
        public void TestFixtureTeardown()
        {
            game.Exit();
            gameThread.Join(500);
        }

        [Test]
        public void LoadTest()
        {
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
            s.Seek(0, SeekOrigin.Begin);


            GraphicsDevice d = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, DeviceType.Hardware, game.Window.Handle,
                CreateOptions.SoftwareVertexProcessing, new PresentationParameters());

            texture = Texture2D.FromFile(d, s);

            Assert.AreEqual(s.Length, s.Position, "#1");
            Assert.AreEqual(32, texture.Width, "#2");
            Assert.AreEqual(32, texture.Height, "#3");
            try
            {
                Assert.IsTrue(d.Textures[0].Equals(texture), "#4");
                Assert.Fail("Texture was loaded into the device");
            }
            catch (NullReferenceException)
            {
            }
        }
    }
}
