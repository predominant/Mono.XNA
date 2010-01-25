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
using Microsoft.Xna.Framework;

namespace Microsoft.Xna.Framework.Content.Pipeline
{
	
	
	public sealed class ContentProcessorContext
	{

#region Constructor
		
		internal ContentProcessorContext()
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

        public TOutput BuildAndLoadAsset<TInput, TOutput>(ExternalReference<TInput> sourceAsset, string processorName)
        {
            return BuildAndLoadAsset<TInput, TOutput>(sourceAsset, processorName, null, null);
        }

        public TOutput BuildAndLoadAsset<TInput, TOutput>(ExternalReference<TInput> sourceAsset, string processorName, OpaqueDataDictionary processorParameters, string importerName)
        {
            throw new NotImplementedException(); 
        }

        public ExternalReference<TOutput> BuildAsset<TInput, TOutput>(ExternalReference<TInput> sourceAsset, string processorName)
        {
            return BuildAsset<TInput, TOutput>(sourceAsset, processorName, null, null, null);
        }

        public ExternalReference<TOutput> BuildAsset<TInput, TOutput>(ExternalReference<TInput> sourceAsset, string processorName, OpaqueDataDictionary processorParameters, string importerName, string assetName)
        {
            throw new NotImplementedException();
        }

        public TOutput Convert<TInput, TOutput>(TInput input, string processorName)
        {
            return Convert<TInput, TOutput>(input, processorName, new OpaqueDataDictionary());
        }

        public TOutput Convert<TInput, TOutput>(TInput input, string processorName, OpaqueDataDictionary processorParameters)
        {
            throw new NotImplementedException();
        }

		public void AddDependency(string filename)
		{
            throw new NotImplementedException();
		}
		
		public void AddOutputFile(string filename)
		{
            throw new NotImplementedException();
		}
		
#endregion
		
	}
}
