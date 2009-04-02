// FontTextureProcessor.cs created with MonoDevelop
// User: lars at 11.07 16.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

namespace Microsoft.Xna.Framework.Content.Pipeline.Processors
{
	
	[ContentProcessor]
	public class FontTextureProcessor : ContentProcessor<Texture2DContent, SpriteFontContent>
	{

#region Constructor
		
		public FontTextureProcessor()
		{
		}

#endregion
		
#region Properties

		public virtual char FirstCharacter 
		{ 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
		public virtual TextureProcessorOutputFormat TextureFormat 
		{ 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
#endregion 
		
#region Public Methods

		public override SpriteFontContent Process(Texture2DContent input, ContentProcessorContext context)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
#region Protected Methods

		protected virtual char GetCharacterForIndex(int index)
		{
			throw new NotImplementedException();
			
		}
		
#endregion
		
	}
}
