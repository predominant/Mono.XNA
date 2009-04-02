
using System;
using Microsoft.Build.Utilities;
using Microsoft.Build.Framework;

namespace Microsoft.Xna.Framework.Content.Pipeline.Tasks
{
	
	
	public class CleanContent : Task
	{
		
		#region Constructor
		
		public CleanContent()
		{
		}
		
		#endregion
		
		#region Properties
		
		public string BuildConfiguration { 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
		public string IntermediateDirectory { 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
		public string OutputDirectory { 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
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
		
		#endregion
		
		#region Public Methods
		
		public override bool Execute ()
		{
			throw new NotImplementedException();	
		}
		
		#endregion
		
	}
}
