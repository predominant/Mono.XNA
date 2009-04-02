// BoneWeightCollection.cs created with MonoDevelop
// User: lars at 02.43 07.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Collections.ObjectModel;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public sealed class BoneWeightCollection : Collection<BoneWeight>
	{

#region Constructor
		
		public BoneWeightCollection()
		{
		}
		
#endregion
		
#region Public Methods

		public void NormalizeWeights()
		{
			throw new NotImplementedException();
		}
		
		public void NormalizeWeights(int maxWeights)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
	}
}
