// ContentIdentity.cs created with MonoDevelop
// User: lars at 11.07 21.02.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace Microsoft.Xna.Framework.Content.Pipeline
{
	
	[Serializable]
	public class ContentIdentity
	{
		
#region Constructors
		
		public ContentIdentity()
		{
		}
		
		public ContentIdentity(string sourceFilename)
		{
			this.sourceFileName = sourceFilename;
		}
		
		public ContentIdentity(string sourceFilename, string sourceTool)
		{
			this.sourceFileName = sourceFilename;
			this.sourceTool = sourceTool;
		}
		
		public ContentIdentity(string sourceFilename, string sourceTool, string fragmentIdentifier)
		{
			this.sourceFileName = sourceFilename;
			this.sourceTool = sourceTool;
			this.fragmentIdentifier = fragmentIdentifier;
		}
		
#endregion
		
#region Properties
		
		private string sourceFileName;
		public string SourceFilename 
		{ 
			get { return sourceFileName; } 
			set { sourceFileName = value; } 
		}

		private string sourceTool;
		public string SourceTool 
		{ 
			get { return sourceTool; }
			set { sourceTool = value; } 
		}
		
		private string fragmentIdentifier;
		public string FragmentIdentifier 
		{ 
			get { return fragmentIdentifier; }
			set { fragmentIdentifier = value; } 
		}
		
#endregion
		
	}
}
