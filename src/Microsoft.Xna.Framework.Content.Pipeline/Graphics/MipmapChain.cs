// MipmapChain.cs created with MonoDevelop
// User: lars at 08.06 07.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Collections.ObjectModel;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public sealed class MipmapChain : Collection<BitmapContent>
	{

#region Constructor
		
		public MipmapChain()
		{
		}
		
		public MipmapChain(BitmapContent bitmap)
		{
			
		}

#endregion
		
#region Public Methods
		
		public static MipmapChain op_Implicit(BitmapContent bitmap)
		{
			throw new NotImplementedException();
		}		
		
#endregion
		
#region Protected Methods

		protected override void InsertItem(int index, BitmapContent item)
		{
			throw new NotImplementedException();
		}
		
		protected override void SetItem(int index, BitmapContent item)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
	}
}
