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
using Tao.OpenAl;

namespace Microsoft.Xna.Framework.Audio
{

    public class AudioEngine : IDisposable
    {
        public const int ContentVersion = 39;

        internal int source;

        internal System.Collections.Generic.List<WaveBank> Wavebanks = new System.Collections.Generic.List<WaveBank>();

        #region Events

        public event EventHandler Disposing;

        #endregion Events


        #region Constructors

        public AudioEngine(string settingsFile) : this(settingsFile, TimeSpan.FromMilliseconds(250.0), string.Empty)
        {
        }

        public AudioEngine(string settingsFile, TimeSpan lookAheadTime, string rendererId)
        {
            Alut.alutInit();

            // Generate an OpenAL source.
            Al.alGenSources(1, out source);
            if (Al.alGetError() != Al.AL_NO_ERROR)
            {
                //ERROR
            }

            Al.alSourcef(source, Al.AL_PITCH, 1.0f);
            Al.alSourcef(source, Al.AL_GAIN, 1.0f);
            //Al.alSourcefv(source, Al.AL_POSITION, sourcePosition);
            //Al.alSourcefv(source, Al.AL_VELOCITY, sourceVelocity);
            Al.alSourcei(source, Al.AL_LOOPING, 0);

            // Do a final error check and then return.
            if (Al.alGetError() == Al.AL_NO_ERROR)
            {
                //ERROR
            }

            float[] listenerPosition = { 0, 0, 0 };
            float[] listenerVelocity = { 0, 0, 0 };
            float[] listenerOrientation = { 0, 0, -1, 0, 1, 0 };

            Al.alListenerfv(Al.AL_POSITION, listenerPosition);
            Al.alListenerfv(Al.AL_VELOCITY, listenerVelocity);
            Al.alListenerfv(Al.AL_ORIENTATION, listenerOrientation);

        }

        #endregion Constructors


        #region Destructors

        ~AudioEngine()
        {
        }

        #endregion


        #region Public Methods

        /*public static bool operator !=(AudioEngine left, AudioEngine right)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(AudioEngine left, AudioEngine right)
        {
            throw new NotImplementedException();
        }*/

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

        /*public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }*/

        public AudioCategory GetCategory(string name)
        {
            throw new NotImplementedException();
        }

        public float GetGlobalVariable(string name)
        {
            throw new NotImplementedException();
        }

        /*public override int GetHashCode()
        {
            throw new NotImplementedException();
        }*/

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

        /*protected void raise_Disposing(object sender, EventArgs args)
        {
            throw new NotImplementedException();
        }*/

        #endregion Protected Methods
    }
}
