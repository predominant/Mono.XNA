#region License

/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.
 
Authors:
 * Stuart Carnie (stuart.carnie@gmail.com)

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
using System.Diagnostics;

namespace Microsoft.Xna.Framework
{
    /// <summary>
    /// Gamer Timer that tracks game and real time
    /// </summary>
#if NUNITTESTS
    public
#else
    internal 
#endif
        class GameClock : IGameClock
    {
        // Specifies the maximum elapsed milliseconds between ticks, to limit how far 'behind' the game can get.
        public const long MAX_ELAPSED = 500;

        Stopwatch _timer;
        long _elapsedMilliseconds;
        long _lastTick;

        public GameClock()
        {
            _timer = new Stopwatch();
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Tick()
        {
            long tick = _timer.ElapsedMilliseconds;
            _elapsedMilliseconds = tick - _lastTick;
            _elapsedMilliseconds = Math.Min(MAX_ELAPSED, _elapsedMilliseconds);
            _lastTick = tick;
        }

        /// <summary>
        /// Gets the number of milliseconds elapsed since the last tick
        /// </summary>
        public long ElapsedMilliseconds
        {
            get { return _elapsedMilliseconds; }
        }

        /// <summary>
        /// Gets the total game time in elapsed milliseconds since <see cref="Start"/> was called.
        /// </summary>
        public long TotalElapsedMilliseconds
        {
            get { return _timer.ElapsedMilliseconds; }
        }
    }
}