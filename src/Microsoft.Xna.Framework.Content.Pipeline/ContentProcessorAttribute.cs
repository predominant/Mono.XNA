// ContentProcessorAttribute.cs created with MonoDevelop
// User: lars at 08.22 28.02.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace Microsoft.Xna.Framework.Content.Pipeline
{
	
	
	public class ContentProcessorAttribute : Attribute
	{
		
#region Constructor
		
		public ContentProcessorAttribute()
		{
		}
		
#endregion
		
#region Properties
		
		private string displayName;
		public virtual string DisplayName 
		{ 
			get { return displayName; }
			set { displayName = value; }
		}

#endregion
		
	}
}
