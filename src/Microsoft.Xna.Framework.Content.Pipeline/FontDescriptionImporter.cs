// FontDescriptionImporter.cs created with MonoDevelop
// User: lars at 00.33 03.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

namespace Microsoft.Xna.Framework.Content.Pipeline
{
	
	[ContentImporter(".spritefont")]
	public class FontDescriptionImporter : ContentImporter<FontDescription>
	{

#region Constructor
		
		public FontDescriptionImporter()
		{
		}
		
#endregion
		
#region Public Methods
		
		public override FontDescription Import(string filename, ContentImporterContext context)
		{
			return null;
		}
		
#endregion
		
	}
}
