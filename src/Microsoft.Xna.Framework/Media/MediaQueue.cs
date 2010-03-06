using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Media
{
    public sealed class MediaQueue
    {
        internal MediaQueue()
        {
        }

        public Song ActiveSong
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int ActiveSongIndex
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
        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Song this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        internal void Play(Song song)
        {
            song.MediaSource.Mediaqueue_Play_Song(song.Handle);
        }

    }
}
