// ProcessorParameterCollection.cs created with MonoDevelop
// User: lars at 01.22 04.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Collections.ObjectModel;

namespace Microsoft.Xna.Framework.Content.Pipeline
{
	
	
	[Serializable]
	public sealed class ProcessorParameterCollection : ReadOnlyCollection<ProcessorParameter>
	{
		
		public ProcessorParameterCollection()
			: base (null)
		{
		}
	}
}
