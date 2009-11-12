using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Audio
{
    public sealed class SoundEffect : IDisposable
    {
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
    }

}
