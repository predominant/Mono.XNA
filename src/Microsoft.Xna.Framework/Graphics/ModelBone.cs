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
    public sealed class ModelBone
    {
        private string name;
        private int index;
        internal ModelBone parent;
        internal ModelBoneCollection children;
        private Matrix transform;

        internal ModelBone()
        {
        }

        internal ModelBone(int i, string name, Matrix transform)
        {
            this.index = i;
            this.name = name;
            this.transform = transform;
        }

        internal void SetParentChildren(ModelBone Parent, ModelBone[] Children)
        {
            this.parent = Parent;
            this.children = new ModelBoneCollection(Children);
        }

        public ModelBoneCollection Children
        {
            get { return children; }
        }

        public int Index
        {
            get { return index; }
        }

        public string Name
        {
            get { return name; }
        }

        public ModelBone Parent
        {
            get { return parent; }
        }

        public Matrix Transform
        {
            get { return transform; }
            set { transform = value; }
        }
    }
}