// FontDescription.cs created with MonoDevelop
// User: lars at 08.33 28.02.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Collections.Generic;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	public class FontDescription : ContentItem
	{

#region Constructors
		
		public FontDescription(string fontName, float size, float spacing)
		{
			
		}

		public FontDescription(string fontName, float size, float spacing, FontDescriptionStyle fontStyle)
		{
			
		}
		
#endregion 
		
#region Properties

		private List<char> characters;		
		[ContentSerializerIgnore]
		public ICollection<char> Characters 
		{ 
			get { return characters; }
		}
		
		private string fontName;		
		[ContentSerializer]
		public string FontName 
		{ 
			get { return fontName; }
			set { fontName = value; }
		}
		
		private float size;
		public float Size 
		{ 
			get { return size; }
			set { size = value; }
		}

		private float spacing;
		public float Spacing 
		{ 
			get { return spacing; }
			set { spacing = value; }
		}
		
		private FontDescriptionStyle style;
		public FontDescriptionStyle Style 
		{ 
			get { return style; }
			set { style = value; }
		}
		
#endregion
		
	}
}
