// ContentImporter.cs created with MonoDevelop
// User: lars at 11.21 21.02.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace Microsoft.Xna.Framework.Content.Pipeline
{	
	public abstract class ContentImporter<T> : IContentImporter
	{	
		
#region Constructor
		
		public ContentImporter()
		{
			throw new NotImplementedException();
		}
		
#endregion
		
#region Public Methods
		
		public abstract T Import (string filename, ContentImporterContext context);

		
		
#endregion
		
#region Explicit IContentImporter

		object IContentImporter.Import (string filename, ContentImporterContext context)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
	}
}
