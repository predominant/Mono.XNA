using System;
using System.Reflection;
using Tao.Sdl;

namespace Microsoft.Xna.Framework
{
    internal class SdlGameWindow : GameWindow
    {
        #region Private Fields

        private bool allowUserResizing;
        private Rectangle clientBounds;
        private string screenDeviceName;
        
        #endregion Private Fields
		
		#region Constructors

        #endregion Constructors

        #region GameWindow Overrides
		
		public override bool AllowUserResizing {
            get { return allowUserResizing; }
            set { allowUserResizing = value; }
        }

        public override Rectangle ClientBounds {
            get { return clientBounds; }
        }

        public override IntPtr Handle {
            get {
				Sdl.SDL_SysWMinfo_Windows info;
				if (Sdl.SDL_GetWMInfo(out info) != 0)
					return new IntPtr(info.window);
				else 
					return IntPtr.Zero;
			}
        }

        public override string ScreenDeviceName {
            get { return screenDeviceName; }
        }

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
            Sdl.SDL_WM_SetCaption(title, "");
        }        

        #endregion Public Methods

    }
}