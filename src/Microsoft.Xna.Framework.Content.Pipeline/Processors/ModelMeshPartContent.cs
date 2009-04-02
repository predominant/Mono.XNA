// ModelMeshPartContent.cs created with MonoDevelop
// User: lars at 13.09 16.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

namespace Microsoft.Xna.Framework.Content.Pipeline.Processors
{
	
	
	public sealed class ModelMeshPartContent
	{
		
#region Properties

		public int BaseVertex 
		{ 
			get { throw new NotImplementedException(); }
		}

		public MaterialContent Material 
		{ 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
		public int NumVertices 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		public int PrimitiveCount 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		public int StartIndex 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		public int StreamOffset 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		public Object Tag 
		{ 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
#endregion

#region Public Methods

		public VertexElement[] GetVertexDeclaration()
		{
			throw new NotImplementedException();
		}
		
#endregion
		
	}
}
