// ModelBoneContentCollection.cs created with MonoDevelop
// User: lars at 13.00 16.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Collections.ObjectModel;

namespace Microsoft.Xna.Framework.Content.Pipeline.Processors
{
	public sealed class ModelBoneContentCollection : ReadOnlyCollection<ModelBoneContent>
	{		

#region Constructor
		
		public ModelBoneContentCollection()
			: base (null)
		{
			
		}
		
#endregion
		
	}
}
