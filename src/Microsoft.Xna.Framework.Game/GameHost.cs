
using System;

namespace Microsoft.Xna.Framework
{	
	
	internal abstract class GameHost
	{	
		#region Fields
		
		protected Game game;
		protected GameWindow window;
		
		#endregion 
		
		#region Properties
		
		public GameWindow Window {
			get { return window; }	
		}
		
		protected Game Game {
			get { return game; }
		}
		
		#endregion
		
		#region Constructor
		
		public GameHost(Game game)
		{
			this.game = game;
		}
		
		#endregion Constructor
		
		#region Methods
		
		public abstract void EnsureHost();
		
		public abstract void Initialize();
		
		public abstract void Run();
		
		public abstract void Exit();
		
		#endregion Methods
	}
}
