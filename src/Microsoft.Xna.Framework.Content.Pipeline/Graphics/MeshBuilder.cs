// MeshBuilder.cs created with MonoDevelop
// User: lars at 07.43 07.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public sealed class MeshBuilder
	{

#region Constructor
		
		public MeshBuilder()
		{
		}

#endregion
		
#region Properties

		public bool MergeDuplicatePositions 
		{ 
			get; 
			set; 
		}
		
		public float MergePositionTolerance 
		{ 
			get; 
			set; 
		}
		
		public string Name 
		{ 
			get; 
			set; 
		}
		
		public bool SwapWindingOrder 
		{ 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
#endregion
		
#region Properties

		public void AddTriangleVertex(int indexIntoVertexCollection)
		{
			throw new NotImplementedException();
		}
		
		public int CreatePosition(float x, float y, float z)
		{
			throw new NotImplementedException();
		}
		
		public int CreatePosition(Vector3 pos)
		{
			throw new NotImplementedException();
		}
		
		public int CreateVertexChannel<T>(string usage)
		{
			throw new NotImplementedException();
		}
		
		public MeshContent FinishMesh()
		{
			throw new NotImplementedException();
		}

		public void SetMaterial(MaterialContent material)
		{
			throw new NotImplementedException();
		}
		
		public void SetOpaqueData(OpaqueDataDictionary opaqueData)
		{
			throw new NotImplementedException();
		}

		public void SetVertexChannelData(int vertexDataIndex, Object channelData)
		{
			throw new NotImplementedException();
		}
		
		public static MeshBuilder StartMesh(string name)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
	}
}
