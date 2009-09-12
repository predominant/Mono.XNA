
using System;

namespace Microsoft.Xna.Framework
{	
	
	internal interface IGameHost
	{	
		
		#region Properties
		
		GameWindow Window {
			get;	
		}
		
		#endregion
		
		#region Methods
		
		void EnsureHost();
		
		void Initialize();
		
		void Run();
		
		void Exit();
		
		#endregion Methods
	}
}
