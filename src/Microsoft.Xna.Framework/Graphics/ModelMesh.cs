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
    public sealed class ModelMesh
    {

        private BoundingSphere boundingSphere;
        private ModelEffectCollection effects;
        private IndexBuffer indexBuffer;
        private ModelMeshPartCollection meshParts;
        private string name;
        private ModelBone parentBone;
        private object tag;
        private VertexBuffer vertexBuffer;

        private ModelMesh()
        {
        }

        internal ModelMesh(string name, ModelBone parentBone, BoundingSphere boundingSphere, VertexBuffer vertexBuffer, IndexBuffer indexBuffer, ModelMeshPart[] meshParts, object tag)
        {
            this.boundingSphere = new BoundingSphere();
            this.effects = new ModelEffectCollection();
            this.name = name;
            this.parentBone = parentBone;
            this.boundingSphere = boundingSphere;
            this.vertexBuffer = vertexBuffer;
            this.indexBuffer = indexBuffer;
            this.meshParts = new ModelMeshPartCollection(meshParts);
            this.tag = tag;
            int length = meshParts.Length;
            for (int i = 0; i < length; i++)
            {
                ModelMeshPart part = meshParts[i];
                part.parent = this;
            }
        }

        public BoundingSphere BoundingSphere
        {
            get { throw new NotImplementedException(); }
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }

        public void Draw(SaveStateMode saveStateMode)
        {
            throw new NotImplementedException();
        }

        public ModelEffectCollection Effects
        {
            get { throw new NotImplementedException(); }
        }

        public IndexBuffer IndexBuffer
        {
            get { throw new NotImplementedException(); }
        }

        public ModelMeshPartCollection MeshParts
        {
            get { throw new NotImplementedException(); }
        }

        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        public ModelBone ParentBone
        {
            get { throw new NotImplementedException(); }
        }

        public object Tag
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public VertexBuffer VertexBuffer
        {
            get { throw new NotImplementedException(); }
        }

    }
}