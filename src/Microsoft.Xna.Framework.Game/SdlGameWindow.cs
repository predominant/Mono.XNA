using System;
using System.Reflection;
using SdlDotNet.Core;
using SdlDotNet.Graphics;
using SdlDotNet.Input;

namespace Microsoft.Xna.Framework
{
    internal class SdlGameWindow : ExtendedGameWindow
    {
        const Focus ACTIVE_STATE = Focus.Application | Focus.Keyboard;

        #region Private Fields

        bool _allowUserResizing;
        Rectangle _clientBounds;
        string _screenDeviceName;
        bool _visible;


        #endregion Private Fields
        
        #region Constructors

        public SdlGameWindow(Game game)
            : base(game)
        {
            _visible = true;
        }

        #endregion Constructors

        #region Public Methods

        public override void BeginScreenDeviceChange(bool willBeFullScreen)
        {
            throw new NotImplementedException();
        }

        public override void EndScreenDeviceChange(string screenDeviceName, int clientWidth, int clientHeight)
        {
            throw new NotImplementedException();
        }

        protected override void SetTitle(string title)
        {
            Video.WindowCaption = title;
        }

        public override bool AllowUserResizing
        {
            get { return _allowUserResizing; }
            set { _allowUserResizing = value; }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="SdlGameWindow"/> is visible.
        /// </summary>
        public override bool Visible
        {
            get { return _visible; }
        }

        public override Rectangle ClientBounds
        {
            get { return _clientBounds; }
        }

        public override IntPtr Handle
        {
            get { return Video.WindowHandle; }
        }

        public override string ScreenDeviceName
        {
            get { return _screenDeviceName; }
        }

        #endregion Public Methods

        #region Internal Methods

        public override void Initialize()
        {
            Events.Quit += new EventHandler<QuitEventArgs>(Events_Quit);
            Events.AppActive += new EventHandler<ActiveEventArgs>(Events_AppActive);
            Events.VideoResize += new EventHandler<VideoResizeEventArgs>(Events_VideoResize);
            _clientBounds = new Rectangle(0, 0, Video.Screen.Width, Video.Screen.Height);

            SetDefaultTitle();
        }

        void SetDefaultTitle()
        {
            AssemblyTitleAttribute[] attrs = (AssemblyTitleAttribute[])Assembly.GetEntryAssembly().GetCustomAttributes(typeof (AssemblyTitleAttribute), true);
            if (attrs.Length > 0)
                Title = attrs[0].Title;
            else
                Title = "Xna Application";
        }

        #endregion Internal Methods        

        #region Abstract Members

        void Events_VideoResize(object sender, VideoResizeEventArgs e)
        {
            OnClientSizeChanged();
        }

        void Events_AppActive(object sender, ActiveEventArgs e)
        {
            if ((e.State & ACTIVE_STATE) > 0)
            {
                if ((e.State & Focus.Application) > 0)
                {
                    _visible = e.GainedFocus;
                    OnVisibleChanged(this, EventArgs.Empty);
                }

                if (e.GainedFocus)
                    OnActivated(this, EventArgs.Empty);
                else
                    OnDeactivated(this, EventArgs.Empty);
            }
        }

        void Events_Quit(object sender, QuitEventArgs e)
        {
            OnExiting(sender, EventArgs.Empty);
            Events.QuitApplication();
        }

        #endregion Abstract Members

    }
}