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
    public class VertexDeclaration : IDisposable
    {
        VertexElement[] vertexelements;
        GraphicsDevice graphicsDevice;

        public VertexDeclaration(GraphicsDevice graphicsDevice, VertexElement[] elements) 
        {
        //Internaly emulate the VertexDeclaration because there isn't something like that in OpenGl
            vertexelements = elements;
        }

        ~VertexDeclaration()
        {
        }

        public static bool operator !=(VertexDeclaration left, VertexDeclaration right) { throw new NotImplementedException(); }

        public static bool operator ==(VertexDeclaration left, VertexDeclaration right) { throw new NotImplementedException(); }

        public GraphicsDevice GraphicsDevice { get { throw new NotImplementedException(); } }

        public bool IsDisposed { get { throw new NotImplementedException(); } }

        public string Name { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public object Tag { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public event EventHandler Disposing;

        public void Dispose() { throw new NotImplementedException(); }

        protected virtual void Dispose(bool disposing) { throw new NotImplementedException(); }

        public override bool Equals(object obj) { throw new NotImplementedException(); }

        public override int GetHashCode() { throw new NotImplementedException(); }

        public VertexElement[] GetVertexElements() 
        {
            return vertexelements; 
        }

        public int GetVertexStrideSize(int stream) 
        {
            int size = 0;

            foreach ( VertexElement element in vertexelements)
            {
                int typesize = 0;

                if (element.Stream != stream) continue;

                switch (element.VertexElementFormat)
                {
                    case VertexElementFormat.Vector2:
                        typesize = 2 * 4;
                        break;
                    case VertexElementFormat.Vector3:
                        typesize = 3 * 4;
                        break;
                    case VertexElementFormat.Byte4:
                        typesize = 4 * 1;
                        break;
                    case VertexElementFormat.Color:
                        typesize = 4 * 1;
                        break;
                    case VertexElementFormat.HalfVector2:
                        //typesize = 3 * 4; Unknown
                        break;
                    case VertexElementFormat.HalfVector4:
                        //typesize = 3 * 4; Unknown
                        break;
                    case VertexElementFormat.Rgba32:
                        //typesize = 3 * 4; Unknown
                        break;
                }

                if (element.Offset + typesize > size) size = element.Offset + typesize;
            }

            return size;
        }

        public static int GetVertexStrideSize(VertexElement[] elements, int stream) { throw new NotImplementedException(); }

        protected void raise_Disposing(object sender, EventArgs e) { throw new NotImplementedException(); }

        public override string ToString() { throw new NotImplementedException(); }
    }
}
