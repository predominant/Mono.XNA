// ContentImporterContext.cs created with MonoDevelop
// User: lars at 11.23 21.02.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace Microsoft.Xna.Framework.Content.Pipeline
{
	
	
	public sealed class ContentImporterContext
	{
		
#region Constructor
		
		public ContentImporterContext()
		{
		}
		
#endregion
		
#region Properties

		private string intermediateDirectory; 
		public string IntermediateDirectory 
		{ 
			get { return intermediateDirectory; } 
		}
		
		private string outputDirectory;
		public string OutputDirectory 
		{ 
			get { return outputDirectory; }
		}
		
		private ContentBuildLogger logger;
		public ContentBuildLogger Logger 
		{ 
			get { return logger; }
		}
		
#endregion

#region Public Methods

		public void AddDependency(string filename)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
	}
}
