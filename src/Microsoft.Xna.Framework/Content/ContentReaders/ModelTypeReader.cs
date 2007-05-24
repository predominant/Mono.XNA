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
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework.Content
{
    class ModelReader : ContentTypeReader<Model>
    {
        internal ModelReader()
        {
            // Do nothing
        }

        protected internal override Model Read(ContentReader input, Model existingInstance)
        {
            //pea_proj.xnb

            //must read : bones, mesh, root, tag
            // for bone : index, name, parent, transform (DONE)
            // for mesh : boundingSphere, effects, indexBuffer, meshParts, name, parentBone, tag, vertex buffer
            // for boundingSphere : Center, Radius
            // for effects : list of effect is count and lot of things here ...
            // for indexBuffer : lot of things here ...
            // for vertexBuffer : lot of things here ...
            // for meshParts : lot of things here ...
            // for root : index of bones
            // for tag  : object ???

            //in file we have some reader : model reader , stringreader, vertexDeclarationReader, vertexBufferReader, Index buffer reader, basic effect reader
            Model result = new Model();
            int bonesCount = input.ReadInt32();
            ModelBone[] bones = new ModelBone[bonesCount];


            for (int i = 0; i < bonesCount; i++)
            {
                string name = input.ReadString();
                Matrix transform = input.ReadMatrix();
                bones[i] = new ModelBone(i, name, transform);
            }
            result.bones = new ModelBoneCollection(bones);

            foreach (ModelBone bone in result.bones)
            {
                int parentIndex = input.ReadByte();
                bone.parent = result.Bones[parentIndex - 1];

                int childCount = input.ReadInt32();
                ModelBone[] childs = new ModelBone[childCount];
                for (int j = 0; j < childCount; j++)
                {
                    int childIndex = input.ReadByte();
                    childs[j] = result.Bones[childIndex - 1];
                }
                bone.children = new ModelBoneCollection(childs);
            }

            //mesh now
            //0x01f1
            //0x04 bytes =  unk
            //lot onf unknow here

            //0x0212
            //0x04 bytes = mesh count
            //foreach mesh
            //0x?? bytes = string (name)
            //
            //
            //
            //
            //
            //boundingSphere, effects, indexBuffer, meshParts, parentBone, tag, vertex buffer

            throw new NotImplementedException();
        }
    }
}
