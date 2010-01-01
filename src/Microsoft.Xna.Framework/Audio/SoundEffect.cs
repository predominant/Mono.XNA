using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Audio
{
    public sealed class SoundEffect : IDisposable
    {

        internal SoundEffect()
        {
        }

        public SoundEffectInstance CreateInstance()
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
        }

        public bool Play()
        {
            return this.Play(1f, 0f, 0f);
        }

        public bool Play(float volume, float pitch, float pan)
        {
            throw new NotImplementedException();
        }

        public static float DistanceScale
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

        public static float DopplerScale
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

        public TimeSpan Duration
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsDisposed
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public static float MasterVolume
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

        public string Name
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

        public static float SpeedOfSound
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
