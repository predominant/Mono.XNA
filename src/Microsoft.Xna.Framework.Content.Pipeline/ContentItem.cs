// ContentItem.cs created with MonoDevelop
// User: lars at 03.39 22.02.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace Microsoft.Xna.Framework.Content.Pipeline
{
	
	
	public class ContentItem
	{

#region Constructor
		
		public ContentItem()
		{
			opaqueData = new OpaqueDataDictionary();
		}
		
#endregion
		
#region Properties
		
		private ContentIdentity identity;
		public ContentIdentity Identity 
		{ 
			get { return identity; }
			set { identity = value; }
		}
		
		private OpaqueDataDictionary opaqueData;
		public OpaqueDataDictionary OpaqueData 
		{ 
			get { return opaqueData; }
		}
		
#endregion

	}
}
