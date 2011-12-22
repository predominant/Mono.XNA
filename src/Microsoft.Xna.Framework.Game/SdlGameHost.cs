
using System;
using Tao.Sdl;
using Tao.DevIl;
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework
{
	
	
	internal class SdlGameHost : IGameHost
	{
		#region Fields
		
		private bool isExiting;
		private Game game;
		private SdlGameWindow window;
		
		#endregion Fields
		
		#region Constructor
		
		public SdlGameHost(Game game)
		{
			this.game = game;
			isExiting = false;
		}
		
		#endregion Constructor
		
		#region IGameHost Implementations
		
		public GameWindow Window {
			get { return window; }	
		}
		
		public void EnsureHost()
		{
			int result = Sdl.SDL_Init(Sdl.SDL_INIT_TIMER | Sdl.SDL_INIT_VIDEO | Sdl.SDL_INIT_JOYSTICK);
			if (result == 0)
				System.Diagnostics.Debug.WriteLine("SDL initialized");
			else
				System.Diagnostics.Debug.WriteLine("Couldn't initialize SDL");
			
			Il.ilInit();
			
			window = new SdlGameWindow(game);
		}

		
		public void Initialize()
		{		
			// TODO This must be tested against MS XNA. The reason for the cast is that we
			// need to get a hold of the proper window dimensions. Alternately this could be
			// read from the graphics device after it has been created.
			GraphicsDeviceManager graphicsManager = (GraphicsDeviceManager)game.Services.GetService(typeof (IGraphicsDeviceManager));
				
			window.Create("", graphicsManager.PreferredBackBufferWidth, graphicsManager.PreferredBackBufferHeight,
			    graphicsManager.IsFullScreen);
			
			Sdl.SDL_ShowCursor(game.IsMouseVisible ? Sdl.SDL_ENABLE : Sdl.SDL_DISABLE);
		}
		
		public void Run()
		{	
			while (!isExiting)
			{
				Sdl.SDL_Event sdlEvent;
				if (Sdl.SDL_PollEvent(out sdlEvent) != 0)
				{
					switch (sdlEvent.type)
					{
					case Sdl.SDL_QUIT:
						Exit();
						break;
						
					case Sdl.SDL_MOUSEBUTTONDOWN:
						
						break;
					}
				}				
				game.Tick();
			}
			Sdl.SDL_Quit();
		}
		
		public void Exit()
		{
			isExiting = true;
		}

		#endregion IGameHost Implementation
	}
}
