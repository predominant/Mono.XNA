using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Audio
{
    public sealed class SoundEffectInstance : IDisposable
    {
        internal SoundEffectInstance()
        {
        }

        public void Apply3D(AudioListener listener, AudioEmitter emitter)
        {
            this.Apply3D(new AudioListener[] { listener }, emitter);
        }

        public void Apply3D(AudioListener[] listeners, AudioEmitter emitter)
        {
            throw new NotImplementedException();
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Play()
        {
            throw new NotImplementedException();
        }

        public void Resume()
        {
            throw new NotImplementedException();
        }
        
        public void Stop()
        {
            this.Stop(true);
        }


        public void Stop(bool immediate)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            throw new NotImplementedException();
        }

        public bool IsDisposed
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsLooped
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public float Pan
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public float Pitch
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public SoundState State
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public float Volume
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

    }
}
