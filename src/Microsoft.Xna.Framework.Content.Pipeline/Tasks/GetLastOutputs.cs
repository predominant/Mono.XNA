
using System;
using Microsoft.Build.Utilities;
using Microsoft.Build.Framework;

namespace Microsoft.Xna.Framework.Content.Pipeline.Tasks
{
	
	
	public class GetLastOutputs : Task
	{
		
		#region Constructor
		
		public GetLastOutputs()
		{
		}
		
		#endregion
		
		#region Properties
		
		[Required]
		public string IntermediateDirectory { 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
		[Output]
		public ITaskItem[] OutputContentFiles { 
			get { throw new NotImplementedException(); }
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
