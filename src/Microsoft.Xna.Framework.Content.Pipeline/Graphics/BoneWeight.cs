// BoneWeight.cs created with MonoDevelop
// User: lars at 22.58 09.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public struct BoneWeight
	{

		public BoneWeight(string boneName, float weight)
		{
			this.boneName = boneName;
			this.weight = weight;
		}

		private string boneName;
		public string BoneName 
		{ 
			get { return boneName; }
		}

		private float weight;
		public float Weight 
		{ 
			get { return weight; }
		}

	}
}
