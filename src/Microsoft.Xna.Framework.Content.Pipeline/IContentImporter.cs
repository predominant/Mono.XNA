// IContentImporter.cs created with MonoDevelop
// User: lars at 11.21 21.02.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace Microsoft.Xna.Framework.Content.Pipeline
{	
	public interface IContentImporter
	{
		Object Import(string filename, ContentImporterContext context);
	}
}
