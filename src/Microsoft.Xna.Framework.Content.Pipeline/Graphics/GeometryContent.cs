// GeometryContent.cs created with MonoDevelop
// User: lars at 07.08 07.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public class GeometryContent : ContentItem
	{
		
#region Constructor
		
		public GeometryContent()
		{
		}

#endregion
		
#region Properties

		public MaterialContent Material 
		{ 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
		public MeshContent Parent 
		{ 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
		public VertexContent Vertices 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		public IndexCollection Indices 
		{ 
			get { throw new NotImplementedException(); }
		}
	
#endregion
		
	}
}
