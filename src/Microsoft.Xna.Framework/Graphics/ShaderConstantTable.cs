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
    public class ShaderConstantTable : IDisposable
    {
        #region Events
        public event EventHandler Disposing;
        #endregion


        #region Properties
        public ShaderConstantCollection Constants
        {
            get { throw new NotImplementedException(); }
        }

        public string Creator
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsDisposed
        {
            get { throw new NotImplementedException(); }
        }

        public Version Version
        {
            get { throw new NotImplementedException(); }
        }
        #endregion Properties


        #region Constructors
        public ShaderConstantTable(byte[] code)
        {
            throw new NotImplementedException();
        }

        ~ShaderConstantTable()
        {
        }
        #endregion


        #region Methods
        public static bool operator ==(ShaderConstantTable left, ShaderConstantTable right)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(ShaderConstantTable left, ShaderConstantTable right)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public void SetDefaults(GraphicsDevice device)
        {
            throw new NotImplementedException();
        }

        protected void raise_Disposing(Object o, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
