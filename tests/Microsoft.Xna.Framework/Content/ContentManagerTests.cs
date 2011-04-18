#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.

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
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System.Threading;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection;
using System.IO;
using Microsoft.Xna.Framework.Tests;

namespace Tests.Microsoft.Xna.Framework.Content
{
    [TestFixture]
    public class ContentManagerTests
    {
        TestGame game;
        Thread gameThread;
        ContentManager manager;
        string modelPath;
        string modelName;
        string modelDirPath;
        string basePath;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            LoadPeaModel();


            this.game = new TestGame();
            this.gameThread = new Thread(new ThreadStart(game.Run));
            this.gameThread.Start();

            // I need to give the game enough time to initialise before letting the tests continue
            System.Threading.Thread.Sleep(100);
        }

        private void LoadPeaModel()
        {
            basePath = Path.Combine(Path.GetTempPath(), "XNANUNIT");
            if (!Directory.Exists(basePath))
                Directory.CreateDirectory(basePath);


            modelDirPath = Path.Combine(basePath, "Models");
            if (!Directory.Exists(modelDirPath))
                Directory.CreateDirectory(modelDirPath);

            // Get the embedded model resource and write it to a temp file so we can test model loading
            byte[] buffer;
            this.modelName = "peaModel";
            using (Stream s = ResourceReader.GetResourceStream(modelName))
            {
                buffer = new byte[s.Length];
                s.Read(buffer, 0, buffer.Length);
            }

            this.modelPath = Path.Combine(modelDirPath, modelName + ".xnb");

            using (FileStream s = new FileStream(modelPath, FileMode.Create))
                s.Write(buffer, 0, buffer.Length);

            using (Stream s = ResourceReader.GetResourceStream("pea_proj~0.xnb"))
            {
                buffer = new byte[s.Length];
                s.Read(buffer, 0, buffer.Length);
            }

            string texturePath = Path.Combine(basePath, "Textures");
            if (!Directory.Exists(texturePath))
                Directory.CreateDirectory(texturePath);

            using (FileStream s = new FileStream(Path.Combine(texturePath, "pea_proj~0.xnb"), FileMode.Create))
                s.Write(buffer, 0, buffer.Length);
        }

        [TestFixtureTearDown]
        public void TestFixtureTeardown()
        {
            Directory.Delete(basePath, true);
            game.Exit();
            gameThread.Join(500);
        }

        [SetUp]
        public void Setup()
        {
            this.manager = new ContentManager(game.Services, modelDirPath);
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(modelPath + ".xnb");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorTest1()
        {
            ContentManager m = new ContentManager(null);
        }

        [Test]
        public void ConstructorTest2()
        {
            ContentManager m = new ContentManager(this.game.Services);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorTest3()
        {
            ContentManager m = new ContentManager(null, null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorTest4()
        {
            ContentManager m = new ContentManager(null, string.Empty);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorTest5()
        {
            ContentManager m = new ContentManager(this.game.Services, null);
        }

        [Test]
        public void ConstructorTest6()
        {
            ContentManager m = new ContentManager(this.game.Services, string.Empty);
            Assert.AreEqual(this.game.Services, m.ServiceProvider);
        }

        [Test]
        public void DisposeThriceTest()
        {
            this.manager.Dispose();
            this.manager.Dispose();
            this.manager.Dispose();
        }

        [Test]
        public void DisposeUseAfterwardsTest()
        {
            this.manager.Dispose();

            try
            {
                this.manager.Unload();
                Assert.Fail("Unload should throw object disposed");
            }
            catch(ObjectDisposedException ex)
            {
                Assert.AreEqual("Microsoft.Xna.Framework.Content.ContentManager", ex.ObjectName, "#1");
                Assert.AreEqual(null, ex.InnerException);
            }

            try
            {
                this.manager.Load<Model>("");
                Assert.Fail("Load should throw an object disposed");
            }
            catch(ObjectDisposedException ex)
            {
                Assert.AreEqual("Microsoft.Xna.Framework.Content.ContentManager", ex.ObjectName, "#1");
                Assert.AreEqual(null, ex.InnerException);
            }
        }

        [Ignore("Not implemented")]
        [Test]
        public void DisposeInternalObjectsTest()
        {
            Texture m = manager.Load<Texture>(Path.Combine(Path.Combine("..","Textures"), "pea_proj~0"));
            this.manager.Dispose();
            Assert.IsTrue(m.IsDisposed);
        }

        [Test]
        public void EqualsTest()
        {
            int a = 1;
            Assert.IsFalse(this.manager.Equals(a), "#1");
            Assert.IsFalse(this.manager.Equals(new object()), "#2");
            Assert.IsFalse(this.manager.Equals(new ContentManager(game.Services)), "#3");
            Assert.IsTrue(this.manager.Equals(this.manager), "#4");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadEmptyTest()
        {
            this.manager.Load<Model>("");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadNullTest()
        {
            this.manager.Load<Model>(null);
        }

        [Test]
        [ExpectedException(typeof(ContentLoadException))]
        public void LoadNonExistantTest()
        {
            this.manager.Load<Model>(Assembly.GetExecutingAssembly().Location + "tttttt");
        }

        [Ignore("Not implemented")]
        [Test]
        public void LoadModelTest()
        {
            Model m = manager.Load<Model>(modelName);
        }

        [Ignore("Not implemented")]
        [Test]
        public void LoadTextureAgainAfterDisposing()
        {
            Texture m1 = manager.Load<Texture>(Path.Combine(Path.Combine("..", "Textures"), "pea_proj~0"));
            m1.Dispose();

            Texture m2 = manager.Load<Texture>(Path.Combine(Path.Combine("..", "Textures"), "pea_proj~0"));
            
            Assert.AreSame(m1, m2);
            Assert.IsTrue(m2.IsDisposed);
        }

        [Ignore("Not implemented")]
        [Test]
        public void LoadSameModelTwiceTest()
        {
            Model m1 = manager.Load<Model>(modelName);
            Model m2 = manager.Load<Model>(modelName);
            Assert.AreSame(m1, m2);
            Assert.AreEqual(m1, m2);
        }

        [Ignore("Not implemented")]
        [Test]
        [ExpectedException(typeof(ContentLoadException),
         ExpectedMessage="Error loading \"peaModel\". File contains Microsoft.Xna.Framework.Graphics.Model but trying to load as System.Int32.")]
        public void LoadInvalidTypeTest()
        {
            this.manager.Load<int>(modelName);
        }

        [Test]
        public void UnloadAllTest()
        {
            this.manager.Unload();
        }
    }
}
