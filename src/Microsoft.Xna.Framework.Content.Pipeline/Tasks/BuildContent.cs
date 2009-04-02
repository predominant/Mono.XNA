// BuildContent.cs created with MonoDevelop
// User: lars at 15.39 22.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Microsoft.Xna.Framework.Content.Pipeline.Tasks
{
    
    
    public class BuildContent : Task
    {
       
		#region Constructor
		
        public BuildContent()
        {
        }
		
		#endregion
		
		#region Public Fields
		
		public const string CancelEventNameFormat = "";
		
		#endregion
		
		#region Properties
		
		public string BuildConfiguration { 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
		public bool CompressContent { 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
		public string IntermediateDirectory { 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
		[Output]
		public ITaskItem[] IntermediateFiles { 
			get { throw new NotImplementedException(); }
		}

		public string LoggerRootDirectory { 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
		[Output]
		public ITaskItem[] OutputContentFiles { 
			get { throw new NotImplementedException(); }
		}
		
		public string OutputDirectory { 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
		[Required]
		public ITaskItem[] PipelineAssemblies { 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}

		public ITaskItem[] PipelineAssemblyDependencies { 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
		public bool RebuildAll { 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
		[Output]
		public ITaskItem[] RebuiltContentFiles { 
			get { throw new NotImplementedException(); }
		}

		public string RootDirectory { 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
		[Required]
		public ITaskItem[] SourceAssets { 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
		[Required]
		public string TargetPlatform { 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
		#endregion
		
		#region Public Methods
		
		public override bool Execute()
		{
			throw new NotImplementedException();
		}
		
		#endregion
    }
}
