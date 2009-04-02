// IndexCollection.cs created with MonoDevelop
// User: lars at 07.19 07.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public sealed class IndexCollection : Collection<int>
	{
		
#region Constructor
		
		public IndexCollection()
		{
		}

#endregion
		
#region Public Methods

		public void AddRange(IEnumerable<int> indices)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
	}
}
