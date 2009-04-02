// NodeContent.cs created with MonoDevelop
// User: lars at 08.17 07.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public class NodeContent : ContentItem
	{

#region Constructor
		
		public NodeContent()
		{
		}

#endregion
		
#region Properties

		public Matrix AbsoluteTransform 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		public AnimationContentDictionary Animations 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		public NodeContentCollection Children 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		public NodeContent Parent 
		{ 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
		public Matrix Transform 
		{ 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
#endregion
		
	}
}
