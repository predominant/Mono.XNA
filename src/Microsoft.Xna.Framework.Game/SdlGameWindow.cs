using System;
using System.Runtime.InteropServices;
using Tao.Sdl;
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework
{
    internal class SdlGameWindow : GameWindow
    {
        #region Private Fields

        private bool allowUserResizing;
        private Rectangle clientBounds;
        private string screenDeviceName;
		
		private bool willBeFullScreen;		
		private bool inTransition;
		private Game game; // Needed for the GraphicsDevice references
		private Sdl.SDL_Surface sdlSurface;
        
        #endregion Private Fields
		
		#region Constructors
		
		public SdlGameWindow(Game game)
		{
			this.game = game;
		}

        #endregion Constructors
		
		#region Public Methods
		
		public void Create(string screenDeviceName, int clientWidth, int clientHeight, bool fullscreen)
		{
			BeginScreenDeviceChange(fullscreen);
			EndScreenDeviceChange(screenDeviceName, clientWidth, clientHeight);
		}
		
		#endregion
		
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
            inTransition = true;
			this.willBeFullScreen = willBeFullScreen;
        }

        public override void EndScreenDeviceChange(string screenDeviceName, int clientWidth, int clientHeight)
        {
            this.screenDeviceName = screenDeviceName;
			
			// Ideally this could be removed, but the SDL_SetVideoMode require the bits per pixel
			int bpp = 32;
			if (game.GraphicsDevice.PresentationParameters.BackBufferFormat == SurfaceFormat.Color || 
			    game.GraphicsDevice.PresentationParameters.BackBufferFormat == SurfaceFormat.Bgr32 ||
			    game.GraphicsDevice.PresentationParameters.BackBufferFormat == SurfaceFormat.Rgba32)
				bpp = 32;
			
			int flags = Sdl.SDL_OPENGL;
			if (willBeFullScreen)
				flags |= Sdl.SDL_FULLSCREEN;
			
			IntPtr sdlSurfacePtr = Sdl.SDL_SetVideoMode(clientWidth, clientHeight, bpp, flags);
			if (sdlSurfacePtr != IntPtr.Zero)
				sdlSurface = (Sdl.SDL_Surface)Marshal.PtrToStructure(sdlSurfacePtr, typeof(Sdl.SDL_Surface));
        }

        protected override void SetTitle(string title)
        {
            Sdl.SDL_WM_SetCaption(title, "");
        }        

        #endregion GameWindow Overrides

    }
}