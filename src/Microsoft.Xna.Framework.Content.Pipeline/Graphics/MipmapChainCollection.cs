// MipmapChainCollection.cs created with MonoDevelop
// User: lars at 08.12 07.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Collections.ObjectModel;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public sealed class MipmapChainCollection : Collection<MipmapChain>
	{

#region Constructor
		
		public MipmapChainCollection()
		{
		}

#endregion
		
#region Protected Methods

		protected override void InsertItem(int index, MipmapChain item)
		{
			throw new NotImplementedException();
		}
		
		protected override void SetItem(int index, MipmapChain item)
		{
			throw new NotImplementedException();
		}
		
		protected override void ClearItems()
		{
			throw new NotImplementedException();
		}
		
		protected override void RemoveItem(int index)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
	}
}
