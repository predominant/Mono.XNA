#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.

Authors:
Alan McGovern

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
    public sealed class TextureCollection
    {
        #region Constructors and Destructor
        internal TextureCollection()
        {
            // Nothing
        }
        
        ~TextureCollection()
        {
            Dispose(false);
        }
        #endregion Constructors and Destructor

        #region Properties
        public Texture this[int index]
        {
            get { return textures[index]; }
            set { textures[index] = value; }
        }
        #endregion Properties

        #region Methods
        internal void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        internal void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Release all textures
                    Texture[] textureArray = new Texture[textures.Count];
                    textures.CopyTo(textureArray);
                    foreach (Texture texture in textureArray)
                        texture.Dispose();
                    textures.Clear();
                }
                disposed = true;

                // Release any unmanaged components
            }
        }
        #endregion Methods

        #region Private Fields
        internal List<Texture> textures = new List<Texture>();
        private bool disposed;
        #endregion Private Fields
    }
}
