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

namespace Microsoft.Xna.Framework.Content.Pipeline
{
	
	
	public sealed class PipelineComponentScanner
	{

#region Constructor
		
		public PipelineComponentScanner()
		{
		}

#endregion
		
#region Properties

		private List<string> errors;
		public IList<string> Errors 
		{ 
			get { return errors; }
		}
		
		private Dictionary<string, ContentImporterAttribute> importerAttributes;
		public IDictionary<string, ContentImporterAttribute> ImporterAttributes 
		{ 
			get { return importerAttributes; }
		}

		
		public IEnumerable<string> ImporterNames 
		{ 
			get { throw new NotImplementedException(); }
		}

		public IDictionary<string, string> ImporterOutputTypes 
		{ 
			get { throw new NotImplementedException(); }
		}

		public IDictionary<string, ContentProcessorAttribute> ProcessorAttributes 
		{ 
			get { throw new NotImplementedException(); }
		}

		public IDictionary<string, string> ProcessorInputTypes 
		{ 
			get { throw new NotImplementedException(); }
		}

		public IEnumerable<string> ProcessorNames 
		{ 
			get { throw new NotImplementedException(); }
		}

		public IDictionary<string, string> ProcessorOutputTypes 
		{ 
			get { throw new NotImplementedException(); }
		}

		public IDictionary<string, ProcessorParameterCollection> ProcessorParameters 
		{ 
			get { throw new NotImplementedException(); }
		}
		
#endregion
		
#region Public Methods

		public bool Update(IEnumerable<string> pipelineAssemblies)
		{
			throw new NotImplementedException();
		}
		
		public bool Update(IEnumerable<string> pipelineAssemblies, IEnumerable<string> pipelineAssemblyDependencies)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
	}
}
