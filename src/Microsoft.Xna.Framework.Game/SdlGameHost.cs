
using System;
using Tao.Sdl;
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework
{
	
	
	internal class SdlGameHost : GameHost
	{
		#region Fields
		
		private bool isExiting;
		
		#endregion Fields
		
		#region Constructor
		
		public SdlGameHost(Game game)
			: base(game)
		{
			isExiting = false;
		}
		
		#endregion Constructor
		
		#region GameHost Overrides
		
		public override void EnsureHost()
		{
			int result = Sdl.SDL_Init (Sdl.SDL_INIT_TIMER | Sdl.SDL_INIT_VIDEO);
			if (result == 0)
				System.Diagnostics.Debug.WriteLine("SDL initialized");
			else
				System.Diagnostics.Debug.WriteLine("Couldn't initialize SDL");
			
			window = new SdlGameWindow();
		}

		
		public override void Initialize()
		{		
			((SdlGameWindow)window).Create("", game.GraphicsDevice.PresentationParameters.BackBufferWidth, 
				game.GraphicsDevice.PresentationParameters.BackBufferHeight,
			    32,	// Temporary fix. TODO
				game.GraphicsDevice.PresentationParameters.IsFullScreen);
			
			Sdl.SDL_ShowCursor(game.IsMouseVisible ? Sdl.SDL_ENABLE : Sdl.SDL_DISABLE);
		}
		
		public override void Run()
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
					}
				}				
				game.Tick();
			}
		}
		
		public override void Exit()
		{
			isExiting = true;
		}

		#endregion Methods
	}
}
