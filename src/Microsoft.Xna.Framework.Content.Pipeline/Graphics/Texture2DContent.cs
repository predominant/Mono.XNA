// Texture2DContent.cs created with MonoDevelop
// User: lars at 08.41 07.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public class Texture2DContent : TextureContent
	{

#region Constructor
		
		public Texture2DContent()
			: base (null)
		{

		}
		
#endregion 
		
#region Public Methods

		public MipmapChain Mipmaps 
		{ 
			get; 
			set; 
		}
		
#endregion
		
	}
}
