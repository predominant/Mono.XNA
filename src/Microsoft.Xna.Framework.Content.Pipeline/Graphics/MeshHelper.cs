#region License
/*
MIT License
Copyright © 2009 The Mono.Xna Team

All rights reserved.

Authors: Lars Magnusson (lavima@gmail.com)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion License

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
