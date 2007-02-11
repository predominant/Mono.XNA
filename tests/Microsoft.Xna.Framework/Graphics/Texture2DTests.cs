using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using NUnit.Framework;
using Microsoft.Xna.Framework.Tests;
using Microsoft.Xna.Framework.Content.Tests;
using System.Threading;
using System.IO;

namespace Microsoft.Xna.Framework.Graphics.Tests
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
