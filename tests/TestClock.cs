#if !MSXNAONLY

using System;

namespace Tests
{
    internal class TestClock : IGameClock
    {
        public const long MAX_ELAPSED = 500;

        TestClock()
        {
        }

        long _elapsedMilliseconds;
        long _totalElapsedMilliseconds;
        long _lastTick;

        #region Counters

        int _startCount;
        int _tickCount;

        #endregion Counters

        #region IGameClock Members

        public void Start()
        {
            Reset();
            _startCount++;
        }

        public void Tick()
        {
            _tickCount++;
            long tick = _totalElapsedMilliseconds;
            _elapsedMilliseconds = tick - _lastTick;
            _elapsedMilliseconds = Math.Min(MAX_ELAPSED, _elapsedMilliseconds);
            _lastTick = tick;
        }

        public void Step(long stepInMilliseconds)
        {
            _totalElapsedMilliseconds += stepInMilliseconds;
        }

        public void Reset()
        {
            _totalElapsedMilliseconds = 0;
            _elapsedMilliseconds = 0;
            _lastTick = 0;
        }

        public long ElapsedMilliseconds
        {
            get { return _elapsedMilliseconds; }
            set { _elapsedMilliseconds = value; }
        }

        public long TotalElapsedMilliseconds
        {
            get { return _totalElapsedMilliseconds; }
            set { _totalElapsedMilliseconds = value; }
        }

        #endregion

        #region Counters

        public int StartCount
        {
            get { return _startCount; }
        }

        public int TickCount
        {
            get { return _tickCount; }
        }

        #endregion Counters

        #region Static Members

        static TestClock s_testClock = new TestClock();

        public static TestClock Instance
        {
            get { return s_testClock; }
        }

        #endregion Static Members
    }
}

#endif