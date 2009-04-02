// PipelineComponentScanner.cs created with MonoDevelop
// User: lars at 01.10 03.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

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
