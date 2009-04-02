// InvalidContentException.cs created with MonoDevelop
// User: lars at 00.55 03.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xna.Framework.Content.Pipeline
{
	
	[SerializableAttribute]
	public class InvalidContentException : Exception
	{

#region Constructors
		
		public InvalidContentException()
		{
		}
		
		public InvalidContentException(string message)
		{
			
		}
		
		public InvalidContentException(string message, ContentIdentity contentIdentity)
		{
			
		}
		
		public InvalidContentException(string message, ContentIdentity contentIdentity, Exception innerException)
		{
			
		}
		
		public InvalidContentException(string message, Exception innerException)
		{
			
		}
		
		protected InvalidContentException(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
			
		}

#endregion
		
#region Properties

		private ContentIdentity contentIdentity;
		public ContentIdentity ContentIdentity { 
			get { return contentIdentity; }
			set { contentIdentity = value; }
		}
		
#endregion
		
#region Public Methods

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}
		
#endregion
		
	}
}
