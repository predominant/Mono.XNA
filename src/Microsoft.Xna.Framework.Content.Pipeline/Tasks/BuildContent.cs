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
    
    public class BuildContent : Task
    {
       
		#region Public Fields
		
		public const string CancelEventNameFormat = "";
		
		#endregion Public Fields
		
		#region Private Fields
		
		private bool compressContent;
		private bool rebuildAll;
		private string buildConfiguration;
		private string intermediateDirectory;
		private string loggerRootDirectory;
		private string outputDirectory;
		private string rootDirectory;
		private string targetPlatform;
		private ITaskItem[] intermediateFiles;
		private ITaskItem[] outputContentFiles;
		private ITaskItem[] pipelineAssemblies;
		private ITaskItem[] pipelineAssemblyDependencies;
		private ITaskItem[] rebuiltContentFiles;
		private ITaskItem[] sourceAssets;
		
		#endregion Private Fields
		
		#region Properties
		
		public string BuildConfiguration { 
			get { return buildConfiguration; }
			set { buildConfiguration = value; }
		}
		
		public bool CompressContent { 
			get { return compressContent; }
			set { compressContent = value; }
		}
		
		public string IntermediateDirectory { 
			get { return intermediateDirectory; }
			set { intermediateDirectory = value; }
		}
		
		[Output]
		public ITaskItem[] IntermediateFiles { 
			get { return intermediateFiles; }
		}

		public string LoggerRootDirectory { 
			get { return loggerRootDirectory; }
			set { loggerRootDirectory = value; }
		}
		
		[Output]
		public ITaskItem[] OutputContentFiles { 
			get { return outputContentFiles; }
		}
		
		public string OutputDirectory { 
			get { return outputDirectory; }
			set { outputDirectory = value; }
		}
		
		[Required]
		public ITaskItem[] PipelineAssemblies { 
			get { return pipelineAssemblies; }
			set { pipelineAssemblies = value; }
		}

		public ITaskItem[] PipelineAssemblyDependencies { 
			get { return pipelineAssemblyDependencies; }
			set { pipelineAssemblyDependencies = value; }
		}
		
		public bool RebuildAll { 
			get { return rebuildAll; }
			set { rebuildAll = value; }
		}
		
		[Output]
		public ITaskItem[] RebuiltContentFiles { 
			get { return rebuiltContentFiles; }
		}

		public string RootDirectory { 
			get { return rootDirectory; }
			set { rootDirectory = value; }
		}
		
		[Required]
		public ITaskItem[] SourceAssets { 
			get { return sourceAssets; }
			set { sourceAssets = value; }
		}
		
		[Required]
		public string TargetPlatform { 
			get { return targetPlatform; }
			set { targetPlatform = value; }
		}
		
		#endregion
		
		#region Constructor
		
        public BuildContent()
        {
        }
		
		#endregion Constructor
		
		#region Task Overrides
		
		public override bool Execute()
		{
			foreach (ITaskItem sourceAsset in sourceAssets)
			{
				
			}
			return true;
		}
		
		#endregion Task Overrides
    }
}
