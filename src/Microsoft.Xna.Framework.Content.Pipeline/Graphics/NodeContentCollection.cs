// NodeContentCollection.cs created with MonoDevelop
// User: lars at 08.22 07.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public sealed class NodeContentCollection : ChildCollection<NodeContent, NodeContent>
	{

#region Constructor
		
		public NodeContentCollection()
			: base (null)
		{
		}
		
#endregion 
		
#region Protected Methods

		protected override NodeContent GetParent(NodeContent child)
		{
			throw new NotImplementedException();
		}
		
		protected override void SetParent(NodeContent child, NodeContent parent)
		{
			throw new NotImplementedException();
		}
		
#endregion 
		
	}
}
