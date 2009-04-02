// EffectProcessor.cs created with MonoDevelop
// User: lars at 04.58 16.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;

namespace Microsoft.Xna.Framework.Content.Pipeline.Processors
{
	
	
	[ContentProcessor]
	public class EffectProcessor : ContentProcessor<EffectContent, CompiledEffect>
	{
		
#region Constructor		
		
		public EffectProcessor()
		{
		}
		
#endregion
		
#region Public Methods

		public override CompiledEffect Process(EffectContent input, ContentProcessorContext context)
		{
			throw new NotImplementedException();
			
		}
		
#endregion
		
	}
}
