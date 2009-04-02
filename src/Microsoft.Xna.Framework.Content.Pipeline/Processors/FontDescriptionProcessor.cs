// FontDescriptionProcessor.cs created with MonoDevelop
// User: lars at 05.03 16.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

namespace Microsoft.Xna.Framework.Content.Pipeline.Processors
{
	
	[ContentProcessor]
	public class FontDescriptionProcessor : ContentProcessor<FontDescription, SpriteFontContent>
	{

#region Constructor
		
		public FontDescriptionProcessor()
		{
		}

#endregion
		
#region Public Methods

		public override SpriteFontContent Process(FontDescription input, ContentProcessorContext context)
		{
			throw new NotImplementedException();
			
		}
		
#endregion
		
	}
}
