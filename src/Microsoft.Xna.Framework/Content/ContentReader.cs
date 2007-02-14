#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team
http://www.taoframework.com
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
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework.Content
{
    public sealed class ContentReader : BinaryReader
    {
        private ContentManager contentManager;
        private GraphicsDevice graphicsDevice;

        internal GraphicsDevice GraphicsDevice
        {
            get { return this.graphicsDevice; }
        }

        internal ContentReader(ContentManager manager, Stream stream, GraphicsDevice graphicsDevice)
            : base(stream)
        {
            this.graphicsDevice = graphicsDevice;
        }

        public ContentManager ContentManager
        {
            get { return this.contentManager; }
        }


        public T ReadExternalReference<T>()
        {
            throw new NotImplementedException();
        }

        public Matrix ReadMatrix()
        {
            throw new NotImplementedException();
        }

        public T ReadObject<T>()
        {
            throw new NotImplementedException();
        }

        public T ReadObject<T>(ContentTypeReader typeReader)
        {
            return reader.Read(this, default(T));
        }

        public T ReadObject<T>(T existingInstance)
        {
            throw new NotImplementedException();
        }

        public T ReadObject<T>(ContentTypeReader typeReader, T existingInstance)
        {
            return (T)typeReader.Read(this, existingInstance);
        }

        public Quaternion ReadQuaternion()
        {
            throw new NotImplementedException();
        }

        public T ReadRawObject<T>()
        {
            throw new NotImplementedException();
        }

        public T ReadRawObject<T>(ContentTypeReader typeReader)
        {
            throw new NotImplementedException();
        }

        public T ReadRawObject<T>(T existingInstance)
        {
            throw new NotImplementedException();
        }

        public T ReadRawObject<T>(ContentTypeReader typeReader, T existingInstance)
        {
            throw new NotImplementedException();
        }

        public void ReadSharedResource<T>(Action<T> fixup)
        {
            throw new NotImplementedException();
        }

        public Vector2 ReadVector2()
        {
            throw new NotImplementedException();
        }

        public Vector3 ReadVector3()
        {
            throw new NotImplementedException();
        }

        public Vector4 ReadVector4()
        {
            throw new NotImplementedException();
        }
    }
}
