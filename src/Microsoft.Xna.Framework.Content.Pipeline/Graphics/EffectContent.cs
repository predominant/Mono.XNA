// EffectContent.cs created with MonoDevelop
// User: lars at 06.59 07.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public class EffectContent : ContentItem
	{

#region Constructor
		
		public EffectContent()
		{
		}
		
#endregion
		
#region Properties

		private string effectCode;
		public string EffectCode 
		{ 
			get { return effectCode; }
			set { effectCode = value; } 
		}
		
#endregion
	
	}
}
