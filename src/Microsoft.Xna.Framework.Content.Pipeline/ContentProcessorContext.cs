// ContentProcessorContext.cs created with MonoDevelop
// User: lars at 01.10 24.02.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using Microsoft.Xna.Framework;

namespace Microsoft.Xna.Framework.Content.Pipeline
{
	
	
	public sealed class ContentProcessorContext
	{

#region Constructor
		
		public ContentProcessorContext()
		{
		}
		
#endregion
		
#region Properties

		private string buildConfiguration;
		public string BuildConfiguration 
		{ 
			get { return buildConfiguration; }
		}
		
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

		private string outputFilename;
		public string OutputFilename 
		{ 
			get { return outputFilename; }
		}

		private ContentBuildLogger logger;
		public ContentBuildLogger Logger 
		{ 
			get { return logger; }
		}

		private OpaqueDataDictionary parameters;
		public OpaqueDataDictionary Parameters 
		{ 
			get { return parameters; }
		}

		private TargetPlatform targetPlatform;
		public TargetPlatform TargetPlatform 
		{ 
			get { return targetPlatform; }
		}
		
#endregion
		
#region Public Methods

		public void AddDependency(string filename)
		{
			
		}
		
		public void AddOutputFile(string filename)
		{
			
		}
		
#endregion
		
	}
}
