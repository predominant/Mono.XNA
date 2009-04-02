
using System;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Microsoft.Xna.Framework.Content.Pipeline.Tasks
{
	
	
	public class BuildXact : Task
	{
		
		#region Constructor
		
		public BuildXact()
		{
		}
		
		#endregion
		
		#region Properties
		
		public string BuildConfiguration { 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
		[Required]
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
		
		[Required]
		public string OutputDirectory { 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
		[Output]
		public ITaskItem[] OutputXactFiles { 
			get { throw new NotImplementedException(); }
		}
	
		public bool RebuildAll { 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}

		[Output]
		public ITaskItem[] RebuiltXactFiles { 
			get { throw new NotImplementedException(); }
		}
		
		public string RootDirectory { 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
		[Required]
		public string TargetPlatform { 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
		[Required]
		public ITaskItem[] XactProjects { 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
		[Required]
		public string XnaFrameworkVersion { 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
		#endregion
		
		#region Public Methods
		
		public override bool Execute ()
		{
			throw new NotImplementedException();
		}
				
		#endregion
		
	}
}
