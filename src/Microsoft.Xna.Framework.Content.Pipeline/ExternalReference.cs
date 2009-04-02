// ExternalReference.cs created with MonoDevelop
// User: lars at 08.25 28.02.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace Microsoft.Xna.Framework.Content.Pipeline
{
	
	
	public sealed class ExternalReference<T> : ContentItem
	{

#region Constructors
		
		public ExternalReference()
		{
		}
		
		public ExternalReference(string filename)
		{
			this.filename = filename;
		}
		
		public ExternalReference(string filename, ContentIdentity relativeToContent)
		{
			this.filename = filename;
		}
		
#endregion 

#region Properties

		private string filename;
		public string Filename 
		{ 
			get { return filename; }
			set { filename = value; }
		}
		
#endregion
		
	}
}
