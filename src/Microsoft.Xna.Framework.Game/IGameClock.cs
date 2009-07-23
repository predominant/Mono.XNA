namespace Microsoft.Xna.Framework
{
    internal interface IGameClock
    {
        void Start();
        void Tick();

        /// <summary>
        /// Gets the number of milliseconds elapsed since the last tick
        /// </summary>
        long ElapsedMilliseconds { get; }

        /// <summary>
        /// Gets the total game time in elapsed milliseconds since <see cref="GameClock.Start"/> was called.
        /// </summary>
        long TotalElapsedMilliseconds { get; }
    }
}