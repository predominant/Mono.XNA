using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Microsoft.Xna.Framework.Media
{
    public sealed class SongCollection : IEnumerable<Song>, IEnumerable, IDisposable
    {
        List<Song> songs;

        internal SongCollection(List<Song> songlist)
        {
            songs = songlist;
        }

        public void Dispose()
        {
        }

        public IEnumerator<Song> GetEnumerator()
        {
            return songs.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return songs.GetEnumerator();
        }

        public Song this[int index]
        {
            get
            {
                return songs[index];
            }
        }

        public int Count
        {
            get
            {
                return songs.Count;
            }
        }
    }
}
