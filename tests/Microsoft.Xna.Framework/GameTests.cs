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

#if !MSXNAONLY

using System;
using System.Diagnostics;
using NUnit.Framework;

namespace Tests.Microsoft.Xna.Framework
{
    [TestFixture]
    public class GameTests
    {
        #region Setup

        [SetUp]
        public void Setup()
        {
            // Reset clock before each test
            TestClock.Instance.Reset();
        }

        #endregion

        #region Public Constructors

        [Test]
        public void Constructors()
        {
            TestGame game = new TestGame();
            Assert.IsNotNull(game, "Failed to create TestGame");
        }

        #endregion

        #region Public Fields Tests

        #endregion

        #region Protected Fields Tests

        #endregion

        #region Public Properties Tests

        [Test]
        public void GameWindowSetTest()
        {
            TestGame game = new TestGame();
            Assert.IsNotNull(game.Window, "Window is not set");
            Assert.IsInstanceOfType(typeof (TestGameWindow), game.Window);
        }

        [Test]
        public void IsActiveDefaultTrueTest()
        {
            TestGame game = new TestGame();
            Assert.IsTrue(game.IsActive, "IsActive should be true");
        }

        [Test]
        public void IsFixedTimeStepDefaultTrueTest()
        {
            TestGame game = new TestGame();
            Assert.IsTrue(game.IsFixedTimeStep, "IsFixedTimeStep should be true");
        }

        #endregion Public Properties Tests

        #region Protected Properties Tests

        #endregion

        #region Public Methods Tests

        [Test]
        public void InitializeCalledOnceTest()
        {
            TestGame game = new TestGame(new NullEventSource());
            game.Run();
            Assert.AreEqual(1, game.CountInitialize, "Initialize was called an incorrect number of times.");
        }

        [Test]
        public void BeginRunCalledOnceTest()
        {
            TestGame game = new TestGame(new NullEventSource());
            game.Run();
            Assert.AreEqual(1, game.CountBeginRun, "BeginRun was called an incorrect number of times.");
        }

        [Test]
        public void EndRunCalledOnceTest()
        {
            TestGame game = new TestGame(new NullEventSource());
            game.Run();
            Assert.AreEqual(1, game.CountEndRun, "EndRun was called an incorrect number of times.");
        }

        [Test]
        public void UpdateCalledOnceTest()
        {
            TestGame game = new TestGame(new NullEventSource());
            game.Run();
            Assert.AreEqual(1, game.CountUpdate, "Update was called an incorrect number of times.");
        }

        [Test]
        public void BeginDrawCalledOnceTest()
        {
            DelegateBasedEventSource evt = new DelegateBasedEventSource(delegate(DelegateBasedEventSource e) { e.Game.Tick(); });
            TestGame game = new TestGame(evt);
            ((TestGameWindow)game.Window).RaiseVisibleChanged(true);

            game.Run();
            Assert.AreEqual(1, game.CountBeginDraw, "BeginDraw was called an unexpected number of times.");
        }

        [Test]
        public void DrawCalledOnceTest()
        {
            DelegateBasedEventSource evt = new DelegateBasedEventSource(delegate(DelegateBasedEventSource e) { e.Game.Tick(); });
            TestGame game = new TestGame(evt);
            ((TestGameWindow)game.Window).RaiseVisibleChanged(true);

            game.Run();
            Assert.AreEqual(1, game.CountDraw, "Draw was called an unexpected number of times.");
        }

        [Test]
        public void DrawNotCalledIfBeginDrawReturnsFalseTest()
        {
            DelegateBasedEventSource evt = new DelegateBasedEventSource(delegate(DelegateBasedEventSource e) { e.Game.Tick(); });
            TestGame game = new TestGame(evt);
            ((TestGameWindow)game.Window).RaiseVisibleChanged(true);
            DummyGraphicsDeviceManager gdm = (DummyGraphicsDeviceManager)game.GraphicsDeviceManager;
            gdm.BeginDrawResult = false;

            game.Run();
            Assert.AreEqual(0, game.CountDraw, "Draw was called an unexpected number of times.");
        }

        [Test]
        public void DrawNotCalledIfWindowIsNotVisibleTest()
        {
            DelegateBasedEventSource evt = new DelegateBasedEventSource(delegate(DelegateBasedEventSource e) { e.Game.Tick(); });
            TestGame game = new TestGame(evt);
            ((TestGameWindow)game.Window).RaiseVisibleChanged(false);
            DummyGraphicsDeviceManager gdm = (DummyGraphicsDeviceManager)game.GraphicsDeviceManager;
            gdm.BeginDrawResult = false;

            game.Run();
            Assert.AreEqual(0, game.CountDraw, "Draw was called an unexpected number of times.");
        }

        [Test]
        public void EndDrawNotCalledIfWindowIsNotVisibleTest()
        {
            DelegateBasedEventSource evt = new DelegateBasedEventSource(delegate(DelegateBasedEventSource e) { e.Game.Tick(); });
            TestGame game = new TestGame(evt);
            ((TestGameWindow)game.Window).RaiseVisibleChanged(false);
            DummyGraphicsDeviceManager gdm = (DummyGraphicsDeviceManager)game.GraphicsDeviceManager;
            gdm.BeginDrawResult = false;

            game.Run();
            Assert.AreEqual(0, game.CountEndDraw, "EndDraw was called an unexpected number of times.");
        }

        [Test]
        public void EndDrawNotCalledIfBeginDrawReturnsFalseTest()
        {
            DelegateBasedEventSource evt = new DelegateBasedEventSource(delegate(DelegateBasedEventSource e) { e.Game.Tick(); });
            TestGame game = new TestGame(evt);
            ((TestGameWindow)game.Window).RaiseVisibleChanged(true);
            DummyGraphicsDeviceManager gdm = (DummyGraphicsDeviceManager)game.GraphicsDeviceManager;
            gdm.BeginDrawResult = false;

            game.Run();
            Assert.AreEqual(0, game.CountEndDraw, "EndDraw was called an unexpected number of times.");
        }

        [Test]
        public void EndDrawCalledOnceTest()
        {
            DelegateBasedEventSource evt = new DelegateBasedEventSource(delegate(DelegateBasedEventSource e) { e.Game.Tick(); });
            TestGame game = new TestGame(evt);
            ((TestGameWindow)game.Window).RaiseVisibleChanged(true);

            game.Run();
            Assert.AreEqual(1, game.CountEndDraw, "EndDraw was called an unexpected number of times.");
        }

        /// <summary>
        /// This test verifies that Update is called 1 + LOOP_COUNT * STEP_RATE(ms) / Game.TargetElapsedTime.Milliseconds
        /// where STEP_RATE less than TargetElapsedTime, so no catchup calls are made
        /// </summary>
        [Test]
        public void UpdateLoopForFixedTimeStepGameTest()
        {
            const int LOOP_COUNT = 5;
            const int STEP_RATE = 50; // milliseconds per step
            const int TARGET_UPDATE_RATE = 100; // update called every 100 ms

            DelegateBasedEventSource evt = new DelegateBasedEventSource(delegate(DelegateBasedEventSource e)
                                                                            {
                                                                                int i = LOOP_COUNT;
                                                                                while (i-- > 0)
                                                                                {
                                                                                    TestClock.Instance.Step(STEP_RATE);
                                                                                    e.Game.Tick();
                                                                                }
                                                                            });
            TestGame gd = new TestGame(evt, true);
            gd.TargetElapsedTime = TimeSpan.FromMilliseconds(TARGET_UPDATE_RATE);

            gd.Run();
            Assert.AreEqual(1 + LOOP_COUNT*STEP_RATE/TARGET_UPDATE_RATE, gd.CountUpdate);
        }

        /// <summary>
        /// This test verifies that Update is called 1 + Draw times (since Update is called once prior to the main loop beginning
        /// </summary>
        [Test]
        public void UpdateLoopForVariableTimeStepGameTest()
        {
            const int LOOP_COUNT = 5;
            const int STEP_RATE = 50; // milliseconds per step
            const int TARGET_UPDATE_RATE = 100; // update called every 100 ms

            DelegateBasedEventSource evt = new DelegateBasedEventSource(delegate(DelegateBasedEventSource e)
                                                                            {
                                                                                int i = LOOP_COUNT;
                                                                                while (i-- > 0)
                                                                                {
                                                                                    TestClock.Instance.Step(STEP_RATE);
                                                                                    e.Game.Tick();
                                                                                }
                                                                            });
            TestGame gd = new TestGame(evt, true);
            gd.TargetElapsedTime = TimeSpan.FromMilliseconds(TARGET_UPDATE_RATE);
            gd.IsFixedTimeStep = false;
            ((TestGameWindow)gd.Window).RaiseVisibleChanged(true);

            gd.Run();
            Assert.AreEqual(gd.CountUpdate, gd.CountDraw + 1);
        }

        /// <summary>
        /// This test verifies that Update is called 1 + LOOP_COUNT * STEP_RATE(ms) / Game.TargetElapsedTime.Milliseconds
        /// where STEP_RATE less than <see cref="TestClock.MAX_ELAPSED"/>, ensuring all catch-up calls to update are called
        /// </summary>
        [Test]
        public void UpdateLoopCatchupForFixedTimeStepGameTest()
        {
            const int LOOP_COUNT = 5;
            const int STEP_RATE = 200; // milliseconds per step
            const int TARGET_UPDATE_RATE = 100; // update called every 100 ms

            DelegateBasedEventSource evt = new DelegateBasedEventSource(delegate(DelegateBasedEventSource e)
                                                                            {
                                                                                int i = LOOP_COUNT;
                                                                                while (i-- > 0)
                                                                                {
                                                                                    TestClock.Instance.Step(STEP_RATE);
                                                                                    e.Game.Tick();
                                                                                }
                                                                            });
            TestGame gd = new TestGame(evt, true);
            gd.TargetElapsedTime = TimeSpan.FromMilliseconds(TARGET_UPDATE_RATE);
            gd.Run();

            Assert.AreEqual(1 + LOOP_COUNT*STEP_RATE/TARGET_UPDATE_RATE, gd.CountUpdate);
        }

        /// <summary>
        /// This test verifies that Update is called 1 + LOOP_COUNT * TestClock.MAX_ELAPSED (ms) / Game.TargetElapsedTime.Milliseconds
        /// where STEP_RATE is greater than <see cref="TestClock.MAX_ELAPSED"/>, ensuring a maximum of MAX_ELAPSED / Game.TargetElapsedTime.Milliseconds
        /// catch-up calls to Update are called per <see cref="Game.Tick"/>
        /// </summary>
        [Test]
        public void UpdateLoopCatchupForFixedTimeStepGameWhereStepRateExceedsMAX_ELAPSEDTest()
        {
            const int LOOP_COUNT = 5;
            const int STEP_RATE = 1000; // milliseconds per step
            const int TARGET_UPDATE_RATE = 100; // update called every 100 ms

            Assert.Greater((double)STEP_RATE, (double)TestClock.MAX_ELAPSED, "STEP_RATE should be greater than TestClock.MAX_ELAPSED for this test");

            DelegateBasedEventSource evt = new DelegateBasedEventSource(delegate(DelegateBasedEventSource e)
                                                                            {
                                                                                int i = LOOP_COUNT;
                                                                                while (i-- > 0)
                                                                                {
                                                                                    TestClock.Instance.Step(STEP_RATE);
                                                                                    e.Game.Tick();
                                                                                }
                                                                            });
            TestGame gd = new TestGame(evt, true);
            gd.TargetElapsedTime = TimeSpan.FromMilliseconds(TARGET_UPDATE_RATE);
            gd.Run();

            Assert.AreEqual(1 + LOOP_COUNT*TestClock.MAX_ELAPSED/TARGET_UPDATE_RATE, gd.CountUpdate);
        }

        #endregion Public Methods Tests

        #region Game Events

        [Test]
        public void GameRaisesExitingEventTest()
        {
            DelegateBasedEventSource evt = new DelegateBasedEventSource(delegate(DelegateBasedEventSource e)
                                                                            {
                                                                                ((TestGameWindow)e.Game.Window).RaiseExiting();
                                                                            });
            Game gd = new TestGame(evt, true);

            bool fired = false;
            gd.Exiting += delegate { fired = true; };
            gd.Run();

            Assert.IsTrue(fired, "Exiting event was not raised.");
        }

        [Test]
        public void GameRaisesOnActivatedEventTest()
        {
            DelegateBasedEventSource evt = new DelegateBasedEventSource(delegate(DelegateBasedEventSource e)
                                                                            {
                                                                                ((TestGameWindow)e.Game.Window).RaiseActivating();
                                                                            });
            Game gd = new TestGame(evt, true);

            bool fired = false;
            gd.Activated += delegate { fired = true; };
            gd.Run();

            Assert.IsTrue(fired, "Activated event was not raised.");
        }

        [Test]
        public void GameRaisesOnDeactivatedEventTest()
        {
            DelegateBasedEventSource evt = new DelegateBasedEventSource(delegate(DelegateBasedEventSource e) { ((TestGameWindow)e.Game.Window).RaiseDeactivating(); });
            Game gd = new TestGame(evt, true);

            bool fired = false;
            gd.Deactivated += delegate { fired = true; };
            gd.Run();

            Assert.IsTrue(fired, "Deactivated event was not raised.");
        }

        /// <summary>
        /// Verifies that the game loop (Tick) sleeps for the time specified by
        /// <see cref="Game.InactiveSleepTime"/> if <see cref="Game.IsActive"/> = <c>false</c>
        /// </summary>
        [Test]
        public void GameSleepsWhenDeactivatedTest()
        {
            DelegateBasedEventSource evt = new DelegateBasedEventSource(delegate(DelegateBasedEventSource e)
                                                                            {
                                                                                ((TestGameWindow)e.Game.Window).RaiseDeactivating();
                                                                                Assert.IsFalse(e.Game.IsActive, "Game should be inactive.");
                                                                                e.Game.Tick();
                                                                            });
            TestGame gd = new TestGame(evt, true);
            gd.InactiveSleepTime = TimeSpan.FromMilliseconds(500);

            Stopwatch sw = Stopwatch.StartNew();
            gd.Run();
            sw.Stop();
            Assert.IsTrue(sw.ElapsedMilliseconds >= 500, "Time elapsed should be at least 500ms");
        }

        #endregion Game Events

        #region Verifies IGameComponent components are correctly initialized

        /// <summary>
        /// Verifies Update is called on game component where Enabled = true
        /// </summary>
        [Category("Game.IGameComponent")]
        [Test]
        public void InitializeCalledOnIGameComponentTest()
        {
            TestGame game = new TestGame(new NullEventSource());

            GameComponentTestBase gc = new GameComponentTestBase(game);
            game.Components.Add(gc);

            game.Run();

            Assert.AreEqual(1, gc.CountInitialize);
        }

        #endregion Verifies IGameComponent components are correctly initialized

        #region Verfies IUpdatable components are correctly called

        /// <summary>
        /// Verifies Update is called on game component where Enabled = true
        /// </summary>
        [Category("Game.IUpdatable")]
        [Test]
        public void UpdateCalledOnEnabledIUpdatableGameComponent()
        {
            TestGame game = new TestGame(new NullEventSource());

            GameComponentTestBase gc = new GameComponentTestBase(game);
            game.Components.Add(gc);

            game.Run();

            Assert.AreEqual(1, gc.CountUpdate);
        }

        /// <summary>
        /// Verifies Update is not called on game component where Enabled = false
        /// </summary>
        [Category("Game.IUpdatable")]
        [Test]
        public void UpdateNotCalledOnDisabledIUpdatableGameComponent()
        {
            TestGame game = new TestGame(new NullEventSource());

            GameComponentTestBase gc = new GameComponentTestBase(game);
            game.Components.Add(gc);
            gc.Enabled = false;

            game.Run();

            Assert.AreEqual(0, gc.CountUpdate);
        }

        /// <summary>
        /// Verifies Update is called on first iteration but not remaing iterations, where component is enabled for first iteration and disable for rest
        /// </summary>
        [Category("Game.IUpdatable")]
        [Test]
        public void UpdateCalledOnceForIUpdatableGameComponent()
        {
            DelegateBasedEventSource evt = new DelegateBasedEventSource(delegate(DelegateBasedEventSource e)
                                                                            {
                                                                                GameComponentTestBase u = (GameComponentTestBase)e.Game.Components[0];
                                                                                u.Enabled = false;
                                                                                for (int i = 0; i < 5; i++)
                                                                                {
                                                                                    TestClock.Instance.Step(100);
                                                                                    e.Game.Tick();
                                                                                }
                                                                            });
            TestGame game = new TestGame(evt);
            GameComponentTestBase gc = new GameComponentTestBase(game);
            game.Components.Add(gc);

            game.Run();

            Assert.AreEqual(1, gc.CountUpdate);
        }

        #endregion Verfies IUpdatable components are correctly called

        #region Verfies IDrawable components are correctly called

        /// <summary>
        /// Verifies Draw is called, given IDrawable.Visible = true;
        /// </summary>
        [Category("Game.IDrawable")]
        [Test]
        public void DrawCalledOnVisibleIDrawableGameComponent()
        {
            DelegateBasedEventSource evt = new DelegateBasedEventSource(delegate(DelegateBasedEventSource e) { e.Game.Tick(); });
            TestGame game = new TestGame(evt);
            ((TestGameWindow)game.Window).RaiseVisibleChanged(true);

            DrawableGameComponentTestBase gc = new DrawableGameComponentTestBase(game);
            game.Components.Add(gc);

            game.Run();

            Assert.AreEqual(1, gc.CountDraw);
        }

        /// <summary>
        /// Verifies Draw is not called, given IDrawable.Visible = false
        /// </summary>
        [Category("Game.IDrawable")]
        [Test]
        public void DrawNotCalledOnNonVisibleIDrawableGameComponent()
        {
            DelegateBasedEventSource evt = new DelegateBasedEventSource(delegate(DelegateBasedEventSource e) { e.Game.Tick(); });
            TestGame game = new TestGame(evt);
            ((TestGameWindow)game.Window).RaiseVisibleChanged(true);

            DrawableGameComponentTestBase gc = new DrawableGameComponentTestBase(game);
            game.Components.Add(gc);
            gc.Visible = false;

            game.Run();

            Assert.AreEqual(0, gc.CountDraw);
        }

        /// <summary>
        /// Verifies Draw is called only when IDrawable.Visible=true
        /// </summary>
        [Category("Game.IDrawable")]
        [Test]
        public void DrawCalledWhenIDrawableGameComponentIsVisibleTest()
        {
            DelegateBasedEventSource evt = new DelegateBasedEventSource(delegate(DelegateBasedEventSource e)
                                                                            {
                                                                                DrawableGameComponentTestBase u = (DrawableGameComponentTestBase)e.Game.Components[0];
                                                                                for (int i = 1; i < 6; i++)
                                                                                {
                                                                                    TestClock.Instance.Step(100);
                                                                                    e.Game.Tick();
                                                                                    u.Visible = i%2 == 0;
                                                                                }
                                                                            });
            TestGame game = new TestGame(evt);
            ((TestGameWindow)game.Window).RaiseVisibleChanged(true);
            DrawableGameComponentTestBase gc = new DrawableGameComponentTestBase(game);
            game.Components.Add(gc);

            game.Run();

            Assert.AreEqual(3, gc.CountDraw, "Unexpected draw count");
            Assert.AreEqual(6, gc.CountUpdate, "Unexpected update count");
        }

        #endregion Verfies IDrawable components are correctly called
    }
}

#endif
