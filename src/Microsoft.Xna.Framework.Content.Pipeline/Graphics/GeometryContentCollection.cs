// GeometryContentCollection.cs created with MonoDevelop
// User: lars at 07.13 07.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public sealed class GeometryContentCollection : ChildCollection<MeshContent, GeometryContent>
	{
		
#region Constructor
		
		public GeometryContentCollection()
			: base (null)
		{
		}

#endregion
		
#region Protected Methods
		
		protected override MeshContent GetParent(GeometryContent child)
		{
			throw new NotImplementedException();
		}
		
		protected override void SetParent(GeometryContent child, MeshContent parent)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
	}
}
