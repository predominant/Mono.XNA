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

using System.Threading;
using NUnit.Framework;

namespace Tests.Microsoft.Xna.Framework
{
    [TestFixture]
    public class GameClockTests
    {
        GameClock clock;

        #region Setup

        [SetUp]
        public void Setup()
        {
            clock = new GameClock();
        }

        #endregion

        #region Public Constructors

        [Test]
        public void Constructors()
        {
            Assert.IsNotNull(clock);
        }

        #endregion

        #region Public Methods

        [Test]
        public void TickUpdatesElapsedMillisecondsTest()
        {
            clock.Start();
            long before = clock.ElapsedMilliseconds;
            Thread.Sleep(50);
            clock.Tick();
            long after = clock.ElapsedMilliseconds;

            Assert.AreNotEqual((uint)before, (uint)after);
        }

        /// <summary>
        /// This test ensures the ElapsedMilliseconds value does not exceed the MAX_ELAPSED constant
        /// </summary>
        [Test]
        public void ElapsedMillisecondsMaximum()
        {
            clock.Start();
            Thread.Sleep((int)(GameClock.MAX_ELAPSED + 100));
            clock.Tick();

            Assert.AreEqual((uint)GameClock.MAX_ELAPSED, (uint)clock.ElapsedMilliseconds);
        }

        /// <summary>
        /// This test is based on timing, so in theory could fail it the test process is delayed for any reason
        /// </summary>
        [Test]
        public void ElapsedMillisecondsTimesEachTick()
        {
            clock.Start();
            Thread.Sleep(50);
            clock.Tick();
            Assert.Less((uint)clock.ElapsedMilliseconds, 100);

            Thread.Sleep(50);
            clock.Tick();
            Assert.Less((uint)clock.ElapsedMilliseconds, 100);
        }

        [Test]
        public void TotalElapsedMillisecondsIncrementsEachTick()
        {
            clock.Start();
            long lastValue = clock.TotalElapsedMilliseconds;
            for (int i = 1; i < 5; i++)
            {
                Thread.Sleep(50);
                clock.Tick();
                Assert.Greater((uint)clock.TotalElapsedMilliseconds, (uint)lastValue);
            }
        }

        #endregion Public Methods
    }
}

#endif