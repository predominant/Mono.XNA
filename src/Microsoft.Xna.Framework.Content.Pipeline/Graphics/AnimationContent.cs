// AnimationContent.cs created with MonoDevelop
// User: lars at 08.37 04.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public class AnimationContent : ContentItem
	{

#region Constructor
		
		public AnimationContent()
		{
		}

#endregion
		
#region Properties

		public AnimationChannelDictionary Channels 
		{ 
			get { throw new NotImplementedException(); }
		}

		public TimeSpan Duration 
		{ 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
#endregion
		
	}
}
