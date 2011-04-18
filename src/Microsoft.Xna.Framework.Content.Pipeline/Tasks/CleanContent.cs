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
using Microsoft.Build.Utilities;
using Microsoft.Build.Framework;

namespace Microsoft.Xna.Framework.Content.Pipeline.Tasks
{
	
	
	public class CleanContent : Task
	{
		#region Fields
		
		private string buildConfiguration;
		private string intermediateDirectory;
		private string outputDirectory;
		private string rootDirectory;
		private string targetPlatform;
		
		#endregion Fields
		
		#region Constructor
		
		public CleanContent()
		{
		}
		
		#endregion
		
		#region Properties
		
		public string BuildConfiguration { 
			get { return buildConfiguration; }
			set { buildConfiguration = value; }
		}
		
		public string IntermediateDirectory { 
			get { return intermediateDirectory; }
			set { IntermediateDirectory = value; }
		}
		
		public string OutputDirectory { 
			get { return outputDirectory; }
			set { outputDirectory = value; }
		}
		
		public string RootDirectory { 
			get { return rootDirectory; }
			set { rootDirectory = value; }
		}
		
		[Required]
		public string TargetPlatform { 
			get { return targetPlatform; }
			set { targetPlatform = value; }
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
