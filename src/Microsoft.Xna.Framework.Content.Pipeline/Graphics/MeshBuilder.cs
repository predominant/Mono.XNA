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

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public sealed class MeshBuilder
	{

#region Constructor
		
		private MeshBuilder()
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
