#if !MSXNAONLY
using System;

namespace Tests
{
    internal class TestGameWindow : ExtendedGameWindow
    {
        bool _allowUserResizing;
        Rectangle _clientBounds;
        IntPtr _handle;
        string _screenDeviceName;
        bool _visible;

        public TestGameWindow(Game game) : base(game)
        {
        }

        public override void BeginScreenDeviceChange(bool willBeFullScreen)
        {
        }

        public override void EndScreenDeviceChange(string screenDeviceName, int clientWidth, int clientHeight)
        {
        }

        protected override void SetTitle(string title)
        {
        }

        public override bool AllowUserResizing
        {
            get { return _allowUserResizing; }
            set { _allowUserResizing = value; }
        }

        public override Rectangle ClientBounds
        {
            get { return _clientBounds; }
        }

        public override IntPtr Handle
        {
            get { return _handle; }
        }

        public override string ScreenDeviceName
        {
            get { return _screenDeviceName; }
        }

        public override bool Visible
        {
            get { return _visible; }
        }

        public override void Initialize()
        {
        }

        public void RaiseActivating()
        {
            OnActivated(this, EventArgs.Empty);
        }

        public void RaiseDeactivating()
        {
            OnDeactivated(this, EventArgs.Empty);
        }

        public void RaiseExiting()
        {
            OnExiting(this, EventArgs.Empty);
        }

        public void RaiseVisibleChanged(bool value)
        {
            _visible = value;
            OnVisibleChanged(this, EventArgs.Empty);
        }
    }
}
#endif