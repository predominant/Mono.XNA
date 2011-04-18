using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Tests.Microsoft.Xna.Framework
{
    public class TestGraphicsDeviceManager : GraphicsDeviceManager
    {
        bool _clearDevices;

        public TestGraphicsDeviceManager(Game game) : base(game)
        {
        }

        public TestGraphicsDeviceManager(Game game, bool clearDevices) : base(game)
        {
            _clearDevices = clearDevices;
        }

        protected override void RankDevices(List<GraphicsDeviceInformation> foundDevices)
        {
            if (_clearDevices)
                foundDevices.Clear();

            base.RankDevices(foundDevices);
        }
    }

    public class DummyGame : Game
    {
        TestGraphicsDeviceManager gdm;

        public DummyGame(bool clearDevices)
            //: base(TestClock.Instance, new NullEventSource())
        {
            gdm = new TestGraphicsDeviceManager(this, clearDevices);
        }


        protected override void BeginRun()
        {
            Exit();
        }
    }
}