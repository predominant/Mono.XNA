// PipelineException.cs created with MonoDevelop
// User: lars at 01.05 04.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xna.Framework.Content.Pipeline
{
	
	[Serializable]
	public class PipelineException : Exception
	{

#region Constructors
		
		public PipelineException()
		{
						
		}

		public PipelineException(string message)
		{
			
		}
		
		public PipelineException(string message, Exception innerException)
		{
			
		}
		
		public PipelineException(string message, Object[] messageArgs)
		{
			
		}
		
		protected PipelineException(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
			
		}
		
#endregion
		
	}
}
