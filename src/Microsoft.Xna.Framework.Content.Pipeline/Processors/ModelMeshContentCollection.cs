// ModelMeshContentCollection.cs created with MonoDevelop
// User: lars at 13.09 16.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Collections.ObjectModel;

namespace Microsoft.Xna.Framework.Content.Pipeline.Processors
{
	
	
	public sealed class ModelMeshContentCollection : ReadOnlyCollection<ModelMeshContent>
	{
		
		public ModelMeshContentCollection()
			: base (null)
		{
		}
	}
}
