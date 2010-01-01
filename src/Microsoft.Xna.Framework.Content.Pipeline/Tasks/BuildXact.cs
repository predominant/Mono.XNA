#region License
/*
MIT License
Copyright © 2009 The Mono.Xna Team

All rights reserved.

Authors: Lars Magnusson (lavima@gmail.com)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion License

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
