// MeshContent.cs created with MonoDevelop
// User: lars at 07.56 07.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public class MeshContent : NodeContent
	{

#region Constructor
		
		public MeshContent()
		{
		}

#endregion
		
#region Properties

		public GeometryContentCollection Geometry 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		public PositionCollection Positions 
		{ 
			get { throw new NotImplementedException(); }
		}
		
#endregion
		
	}
}
