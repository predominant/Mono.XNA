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
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace Microsoft.Xna.Framework.Audio
{

    public class AudioEngine : IDisposable
    {
        public const int ContentVersion = 41;

        #region Events

        public event EventHandler Disposing;

        #endregion Events


        #region Constructors

        public AudioEngine(string settingsFile)
        {
            throw new NotImplementedException();
        }

        public AudioEngine(string settingsFile, TimeSpan span, Guid rendererId)
        {
            throw new NotImplementedException();
        }

        #endregion Constructors


        #region Destructors

        ~AudioEngine()
        {
        }

        #endregion


        #region Public Methods

        public static bool operator !=(AudioEngine left, AudioEngine right)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(AudioEngine left, AudioEngine right)
        {
            throw new NotImplementedException();
        }

        public bool IsDisposed
        {
            get { throw new NotImplementedException(); }
        }

        public ReadOnlyCollection<RendererDetail> RendererDetails
        {
            get { throw new NotImplementedException(); }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public AudioCategory GetCategory(string name)
        {
            throw new NotImplementedException();
        }

        public float GetGlobalVariable(string name)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public void SetGlobalVariable(string name, float value)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods


        #region Protected Methods

        protected virtual void Dispose(bool disposing)
        {
            throw new NotImplementedException();
        }

        protected void raise_Disposing(object sender, EventArgs args)
        {
            throw new NotImplementedException();
        }

        #endregion Protected Methods
    }
}
