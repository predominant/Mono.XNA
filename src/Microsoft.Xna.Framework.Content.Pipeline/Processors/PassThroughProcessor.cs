// PassThroughProcessor.cs created with MonoDevelop
// User: lars at 03.10 20.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace Microsoft.Xna.Framework.Content.Pipeline.Processors
{
	
	[ContentProcessor]
	public class PassThroughProcessor : ContentProcessor<Object, Object>
	{

#region Constructor
		
		public PassThroughProcessor()
		{
		}

#endregion
		
#region Public Methods

		public override Object Process(Object input, ContentProcessorContext context)
		{
			throw new NotImplementedException();
		}
		
#endregion 
		
	}
}
