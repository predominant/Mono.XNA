using System;
using System.Runtime.InteropServices;
using Tao.Sdl;
using Microsoft.Xna.Framework;
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
		private Sdl.SDL_Surface sdlSurface;
		private Game game;
		        
        #endregion Private Fields
		
		#region Constructors
		
		public SdlGameWindow(Game game)
			: base()
		{
			this.game = game;
		}

        #endregion Constructors
		
		#region Internal Methods
		
		/// <summary>
		/// Create the window
		/// </summary>
		internal void Create(string screenDeviceName, int clientWidth, int clientHeight, bool fullscreen)
		{
			BeginScreenDeviceChange(fullscreen);
			EndScreenDeviceChange("", clientWidth, clientHeight);			
		}
		
		#endregion Internal Methods
		
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
				// Check OS
				int p = (int) Environment.OSVersion.Platform;				
            	if ((p == 4) || (p == 128)) // Running UNIX
                   	return IntPtr.Zero; 
				else { 						// Running something else
					Sdl.SDL_SysWMinfo_Windows info;						
					if (Sdl.SDL_GetWMInfo(out info) != 0)
						return new IntPtr(info.window);
					else 
						return IntPtr.Zero;
            	}
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
			OnScreenDeviceNameChanged();
			
			int flags = Sdl.SDL_OPENGL;
			if (willBeFullScreen)
				flags |= Sdl.SDL_FULLSCREEN;
			
			int bitsPerPixel = 0;
			SurfaceFormat format;
			if (game.GraphicsDevice == null)
			{
				// TODO This cast should be tested against MS XNA
				GraphicsDeviceManager graphicsManager = (GraphicsDeviceManager)game.Services.GetService(typeof (IGraphicsDeviceManager));
				format = graphicsManager.PreferredBackBufferFormat;
			}
			else 
				format = game.GraphicsDevice.PresentationParameters.BackBufferFormat;
			
			if (format == SurfaceFormat.Color || format == SurfaceFormat.Bgr32 || format == SurfaceFormat.Rgba32)
				bitsPerPixel = 32;
			// TODO add support for other surface formats
			
			IntPtr sdlSurfacePtr = Sdl.SDL_SetVideoMode(clientWidth, clientHeight, bitsPerPixel, flags);
			if (sdlSurfacePtr != IntPtr.Zero)
				sdlSurface = (Sdl.SDL_Surface)Marshal.PtrToStructure(sdlSurfacePtr, typeof(Sdl.SDL_Surface));
			
#warning SDL 1.2 doesn't support getting the window position, only the dimensions
			clientBounds.Width = clientWidth;
			clientBounds.Height = clientHeight;
			
			OnClientSizeChanged();
			
			inTransition = false;
        }

        protected override void SetTitle(string title)
        {
            Sdl.SDL_WM_SetCaption(title, "");
        }        

        #endregion GameWindow Overrides

    }
}