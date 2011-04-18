using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NUnit.Framework;

namespace Tests.Microsoft.Xna.Framework
{
    [TestFixture]
    public class GraphicsDeviceManagerTests
    {
        Game game;
        GraphicsDeviceManager gdm;

        [SetUp]
        public void Setup()
        {
            game = new Game();
			gdm = new GraphicsDeviceManager(game);
			//game.Run();
        }
		
		[TearDown]
		public void TearDown()
		{
			//game.Exit();	
		}

        #region Constructor Tests

        [Test]
        public void ConstructorTest()
        {
            Assert.IsNotNull(gdm);
        }

        [Test]
        public void GraphicsDeviceManagerAddsToGameServicesCollectionAsIGraphicsDeviceManagerTest()
        {
            IGraphicsDeviceManager s1 = (IGraphicsDeviceManager)game.Services.GetService(typeof (IGraphicsDeviceManager));
            Assert.IsNotNull(s1);
        }

        [Test]
        public void GraphicsDeviceManagerAddsToGameServicesCollectionAsIGraphicsDeviceServiceTest()
        {
            IGraphicsDeviceService s1 = (IGraphicsDeviceService)game.Services.GetService(typeof(IGraphicsDeviceService));
            Assert.IsNotNull(s1);
        }

        #endregion Constructor Tests

        #region Public Method Tests

        [Test]
        public void BeginDrawDefaultBehaviourTest()
        {
            Assert.AreEqual(game.IsActive, ((IGraphicsDeviceManager)gdm).BeginDraw());
        }

        [ExpectedException(typeof(NoSuitableGraphicsDeviceException))]
        [Test]
        public void TestNoSuitableDeviceExceptionTest()
        {
            DummyGame game = new DummyGame(true);
            game.Run();
        }

        [Test]
        public void DisposedEventRaisedTest()
        {
            bool fired = false;
            gdm.Disposed += delegate { fired = true; };
            ((IDisposable)gdm).Dispose();
            Assert.IsTrue(fired);
        }

        [Test]
        public void PreparingDeviceManagerEventRaisedTest()
        {
            bool fired = false;
            gdm.PreparingDeviceSettings += delegate { fired = true; };
            ((IGraphicsDeviceManager)gdm).CreateDevice();
            Assert.IsTrue(fired);
        }

        #endregion Public Method Tests

    }
}
