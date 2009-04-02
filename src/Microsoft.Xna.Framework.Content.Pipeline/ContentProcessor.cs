// ContentProcessor.cs created with MonoDevelop
// User: lars at 00.53 24.02.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace Microsoft.Xna.Framework.Content.Pipeline
{
	
	
	public abstract class ContentProcessor<TInput,TOutput> : IContentProcessor
	{
		
#region Constructor		
		
		public ContentProcessor()
		{
		}
		
#endregion
		
#region Public Methods
		
		public abstract TOutput Process (TInput input, ContentProcessorContext context);
		
#endregion
		
#region Explicit IContentProcessor Implementation
		
		Type IContentProcessor.InputType {
			get { throw new NotImplementedException(); }
		}

		Type IContentProcessor.OutputType {
			get { throw new NotImplementedException(); }
		}

		object IContentProcessor.Process (object input, ContentProcessorContext context)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
	}
}
