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
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

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
		private List<string> dependencies;
		private Dictionary<string, IContentImporter> cachedImporters;
		private Dictionary<string, IContentProcessor> cachedProcessors;
		
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
			dependencies = new List<string>();
			cachedImporters = new Dictionary<string, IContentImporter>();
			cachedProcessors = new Dictionary<string, IContentProcessor>();
        }
		
		#endregion Constructor
		
		#region Methods
		
		internal void AddDependency (string filename)
		{
			dependencies.Add(filename);
		}
		
		IContentImporter getImporterInstance (string importerName)
		{
			foreach (ITaskItem assemblyItem in PipelineAssemblies)
			{
				try
				{
					Assembly assembly = Assembly.Load(assemblyItem.GetMetadata("Filename"));
					foreach (Type type in assembly.GetTypes())
					{
						if (type.Name == importerName && type.GetInterface("IContentImporter") != null)
							return (IContentImporter)Activator.CreateInstance(type, new object[] {});
					}
				}
				catch (Exception e)
				{
					Log.LogWarning(e.Message);
				}
			}
			return null;
		}
		
		IContentProcessor getProcessorInstance (string processorName)
		{
			foreach (ITaskItem assemblyItem in PipelineAssemblies)
			{
				try
				{
					Assembly assembly = Assembly.Load(assemblyItem.GetMetadata("Filename"));
					foreach (Type type in assembly.GetTypes())
					{
						if (type.Name == processorName && type.GetInterface("IContentProcessor") != null)
							return (IContentProcessor)Activator.CreateInstance(type, new object[] {});
					}
				}
				catch (Exception e)
				{
					Log.LogWarning(e.Message);
				}
			}
			return null;
		}
		
		private TargetPlatform getTargetPlatform()
		{
			if (TargetPlatform == "Windows")
				return Microsoft.Xna.Framework.TargetPlatform.Windows;
			else if (TargetPlatform == "Xbox360")
				return Microsoft.Xna.Framework.TargetPlatform.Xbox360;
			else if (TargetPlatform == "Zune")
				return Microsoft.Xna.Framework.TargetPlatform.Zune;
			else 
				return Microsoft.Xna.Framework.TargetPlatform.Unknown;
		}
		
		#endregion Methods
		
		#region Task Overrides
		
		public override bool Execute()
		{
			Log.LogMessage("Building content:");
			
			XBuildLogger logger = new XBuildLogger(this.Log);
			ContentCompiler compiler = new ContentCompiler(PipelineAssemblies);
		
			foreach (ITaskItem sourceItem in SourceAssets)
			{
				//foreach (string name in sourceItem.MetadataNames)
				//	Log.LogMessage(name + " : " + sourceItem.GetMetadata(name));
				string assetName = sourceItem.GetMetadata("Name");
				
				Log.LogMessage("Building " + assetName);
				
				Stream outputStream = new FileStream(OutputDirectory + assetName + ".xnb", FileMode.OpenOrCreate);
				ContentWriter contentWriter = new ContentWriter(outputStream, getTargetPlatform(), CompressContent);
				
				string importerName = sourceItem.GetMetadata("Importer");
				string processorName = sourceItem.GetMetadata("Processor");
				
				IContentImporter importer = getImporterInstance(importerName);
				if (importer == null)
					Log.LogError("Could not find the importer (" + importerName + ")");
				
				IContentProcessor processor = getProcessorInstance(processorName);
				if (importer == null)
					Log.LogError("Could not find the processor (" + processorName + ")");
				
				Log.LogMessage("Using " + importerName + " and " + processorName);
				
				ContentImporterContext importerContext = new ContentImporterContext(this, IntermediateDirectory, OutputDirectory, logger);
				ContentProcessorContext processorContext = new ContentProcessorContext();
				
				processor.Process(importer.Import(sourceItem.GetMetadata("Include"), importerContext), processorContext);
			}
				
			return true;
		}
		
		#endregion Task Overrides
    }
}
