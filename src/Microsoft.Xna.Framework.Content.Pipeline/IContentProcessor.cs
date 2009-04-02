// IContentProcessor.cs created with MonoDevelop
// User: lars at 00.53 24.02.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace Microsoft.Xna.Framework.Content.Pipeline
{
	
	
	public interface IContentProcessor
	{

#region Properties
		
		Type InputType 
		{ 
			get; 
		}
		
		Type OutputType 
		{ 
			get; 
		}
		
#endregion
		
#region Methods

		Object Process(Object input, ContentProcessorContext context);
		
#endregion

	}
}
