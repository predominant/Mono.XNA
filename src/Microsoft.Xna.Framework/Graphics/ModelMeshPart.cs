#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.

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
using System.Text;

namespace Microsoft.Xna.Framework.Graphics
{
    public sealed class ModelMeshPart
    {
        private int baseVertex;
        private Effect effect;
        private IndexBuffer indexBuffer;
        private int numVertices;
        private int primitiveCount;
        private int startIndex;
        private int streamOffset;
        private object tag;
        private VertexBuffer vertexBuffer;
        private VertexDeclaration vertexDeclaration;
        private int vertexStride;
        internal ModelMesh parent;

        private ModelMeshPart()
        {
        }

        internal ModelMeshPart(int streamOffset, int baseVertex, int numVertices, int startIndex, int primitiveCount, VertexBuffer vertexBuffer, IndexBuffer indexBuffer, VertexDeclaration vertexDeclaration, object tag)
        {
            this.vertexBuffer = vertexBuffer;
            this.indexBuffer = indexBuffer;
            this.streamOffset = streamOffset;
            this.baseVertex = baseVertex;
            this.numVertices = numVertices;
            this.startIndex = startIndex;
            this.primitiveCount = primitiveCount;
            this.vertexDeclaration = vertexDeclaration;
            this.tag = tag;
            this.vertexStride = vertexDeclaration.GetVertexStrideSize(0);
        }

        public int BaseVertex {
            get { throw new NotImplementedException(); } }

        public Effect Effect
        {
            get { return effect; }
            set { effect = value; }
        }

        public int NumVertices { 
            get { throw new NotImplementedException(); } }

        public int PrimitiveCount { 
            get { throw new NotImplementedException(); } }

        public int StartIndex {
            get { throw new NotImplementedException(); } }

        public int StreamOffset { 
            get { throw new NotImplementedException(); } }

        public object Tag { 
            get { throw new NotImplementedException(); } 
            set { throw new NotImplementedException(); } }

        public VertexDeclaration VertexDeclaration { 
            get { throw new NotImplementedException(); } }

        public int VertexStride {
            get { throw new NotImplementedException(); } }
    }
}
