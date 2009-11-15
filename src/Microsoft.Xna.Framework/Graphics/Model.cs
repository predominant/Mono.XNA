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
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework.Content;

namespace Microsoft.Xna.Framework.Graphics
{
    public sealed class Model
    {
        internal ModelBoneCollection bones;
        private ModelMeshCollection meshes;
        private ModelBone root;
        private object tag;

        public Model()
        {
        }

        internal static Model Read(ContentReader input)
        {
            Model model = new Model();
            model.ReadBones(input);
            VertexDeclaration[] vertexDeclarations = ReadVertexDeclarations(input);
            model.ReadMeshes(input, vertexDeclarations);
            model.root = model.ReadBoneReference(input);
            model.Tag = input.ReadObject<object>();
            return model;
        }

        private void ReadBones(ContentReader input)
        {
            ModelBone[] bones = new ModelBone[input.ReadInt32()];

            for (int i = 0; i < bones.Length; i++)
            {
                string name = input.ReadObject<string>();
                Matrix transform = input.ReadMatrix();
                bones[i] = new ModelBone(i, name, transform);
            }

            this.bones = new ModelBoneCollection(bones);

            foreach (ModelBone bone in bones)
            {
                ModelBone newParent = this.ReadBoneReference(input);
                int size = input.ReadInt32();
                ModelBone[] newChildren = new ModelBone[size];
                for (int j = 0; j < size; j++)
                {
                    newChildren[j] = this.ReadBoneReference(input);
                }
                bone.SetParentChildren(newParent, newChildren);
            }
        }

        private static VertexDeclaration[] ReadVertexDeclarations(ContentReader input)
        {
            int length = input.ReadInt32();
            VertexDeclaration[] declarationArray = new VertexDeclaration[length];
            for (int i = 0; i < length; i++)
            {
                declarationArray[i] = input.ReadObject<VertexDeclaration>();
            }
            return declarationArray;
        }

        private void ReadMeshes(ContentReader input, VertexDeclaration[] vertexDeclarations)
        {
            int length = input.ReadInt32();
            ModelMesh[] meshes = new ModelMesh[length];
            for (int i = 0; i < length; i++)
            {
                string name = input.ReadObject<string>();
                ModelBone parentBone = this.ReadBoneReference(input);
                BoundingSphere boundingSphere = new BoundingSphere();
                boundingSphere.Center = input.ReadVector3();
                boundingSphere.Radius = input.ReadSingle();
                VertexBuffer vertexBuffer = input.ReadObject<VertexBuffer>();
                IndexBuffer indexBuffer = input.ReadObject<IndexBuffer>();
                object tag = input.ReadObject<object>();
                ModelMeshPart[] meshParts = ReadMeshParts(input, vertexBuffer, indexBuffer, vertexDeclarations);
                meshes[i] = new ModelMesh(name, parentBone, boundingSphere, vertexBuffer, indexBuffer, meshParts, tag);
            }
            this.meshes = new ModelMeshCollection(meshes);
        }

        private static ModelMeshPart[] ReadMeshParts(ContentReader input, VertexBuffer vertexBuffer, IndexBuffer indexBuffer, VertexDeclaration[] vertexDeclarations)
        {
            int length = input.ReadInt32();
            ModelMeshPart[] meshParts = new ModelMeshPart[length];
            for (int i = 0; i < length; i++)
            {
                int streamOffset = input.ReadInt32();
                int baseVertex = input.ReadInt32();
                int numVertices = input.ReadInt32();
                int startIndex = input.ReadInt32();
                int primitiveCount = input.ReadInt32();
                int index = input.ReadInt32();
                VertexDeclaration vertexDeclaration = vertexDeclarations[index];
                object tag = input.ReadObject<object>();
                meshParts[i] = new ModelMeshPart(streamOffset, baseVertex, numVertices, startIndex, primitiveCount, vertexBuffer, indexBuffer, vertexDeclaration, tag);
                int uniqueI = i;
                input.ReadSharedResource<Effect>(delegate(Effect effect)
                {
                    meshParts[uniqueI].Effect = effect;
                });
            }   
            return meshParts;
         }

        private ModelBone ReadBoneReference(ContentReader input)
        {
            int length = this.bones.Count + 1;
            int count = 0;
            if (length <= 0xff)
            {
                count = input.ReadByte();
            }
            else
            {
                count = input.ReadInt32();
            }
            if (count != 0)
            {
                return this.bones[count - 1];
            }
            return null;
        }

        public ModelBoneCollection Bones
        {
            get { return bones; }
        }

        public ModelMeshCollection Meshes
        {
            get { return meshes; }
        }

        public ModelBone Root
        {
            get { return root; }
        }

        public object Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        public void CopyAbsoluteBoneTransformsTo(Matrix[] destinationBoneTransforms)
        {
            throw new NotImplementedException();
        }

        public void CopyBoneTransformsFrom(Matrix[] sourceBoneTransforms)
        {
            throw new NotImplementedException();
        }

        public void CopyBoneTransformsTo(Matrix[] destinationBoneTransforms)
        {
            throw new NotImplementedException();
        }
    }
}
