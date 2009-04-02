// EffectMaterialContent.cs created with MonoDevelop
// User: lars at 07.01 07.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public class EffectMaterialContent : MaterialContent
	{
		
#region Constructor
		
		public EffectMaterialContent()
		{
		}
		
#endregion

#region Public Fields

		public const string CompiledEffectKey = "CompiledEffectKey";
		public const string EffectKey = "EffectKey";
		
#endregion
		
#region Properties

		public ExternalReference<CompiledEffect> CompiledEffect 
		{ 
			get; 
			set; 
		}
		
		public ExternalReference<EffectContent> Effect 
		{ 
			get; 
			set; 
		}
		
#endregion
		
	}
}
