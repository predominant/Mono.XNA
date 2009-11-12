using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework.Media
{
    public sealed class VideoPlayer : IDisposable
    {
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            throw new NotImplementedException();
        }

        public Texture2D GetTexture()
        {
            throw new NotImplementedException();
        }

        public void Pause()
        {
        }

        public void Play(Video video)
        {
        }

        public void Resume()
        {
        }

        public void Stop()
        {
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

        public bool IsMuted
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

        public TimeSpan PlayPosition
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public MediaState State
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Video Video
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
