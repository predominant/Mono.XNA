// VertexContent.cs created with MonoDevelop
// User: lars at 23.40 15.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public sealed class VertexContent
	{
		
#region Properties

		public VertexChannelCollection Channels 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		public VertexChannel<int> PositionIndices 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		public IndirectPositionCollection Positions 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		public int VertexCount 
		{ 
			get { throw new NotImplementedException(); } 
		}
		
#endregion
		
#region Public Methods

		public int Add(int positionIndex)
		{
			throw new NotImplementedException();
		}
		
		public void AddRange(IEnumerable<int> positionIndexCollection)
		{
			throw new NotImplementedException();
		}
		
		public void CreateVertexBuffer(out VertexBufferContent vertexBuffer, out VertexElement[] vertexElements, TargetPlatform targetPlatform)
		{
			throw new NotImplementedException();
		}
		
		public void Insert(int index, int positionIndex)
		{
			throw new NotImplementedException();
		}
		
		public void InsertRange(int index, IEnumerable<int> positionIndexCollection)
		{
			throw new NotImplementedException();
		}
		
		public void RemoveAt(int index)
		{
			throw new NotImplementedException();
		}
		
		public void RemoveRange(int index, int count)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
	}
}
