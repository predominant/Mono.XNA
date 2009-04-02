// MeshHelper.cs created with MonoDevelop
// User: lars at 07.59 07.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Collections.Generic;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public static class MeshHelper
	{
		
#region Public Methods

		public static void CalculateNormals(MeshContent mesh, bool overwriteExistingNormals)
		{
			throw new NotImplementedException();
		}
		
		public static void CalculateTangentFrames(MeshContent mesh, string textureCoordinateChannelName, string tangentChannelName, string binormalChannelName)
		{
			throw new NotImplementedException();
		}

		public static BoneContent FindSkeleton(NodeContent node)
		{
			throw new NotImplementedException();
		}
		
		public static IList<BoneContent> FlattenSkeleton(BoneContent skeleton)
		{
			throw new NotImplementedException();
		}
		
		public static void MergeDuplicatePositions(MeshContent mesh, float tolerance)
		{
			throw new NotImplementedException();
		}
		
		public static void MergeDuplicateVertices(GeometryContent geometry)
		{
			throw new NotImplementedException();
		}
		
		public static void MergeDuplicateVertices(MeshContent mesh)
		{
			throw new NotImplementedException();
		}
		
		public static void OptimizeForCache(MeshContent mesh)
		{
			throw new NotImplementedException();
		}
		
		public static void SwapWindingOrder(MeshContent mesh)
		{
			throw new NotImplementedException();
		}
		
		public static void TransformScene(NodeContent scene, Matrix transform)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
	}
}
