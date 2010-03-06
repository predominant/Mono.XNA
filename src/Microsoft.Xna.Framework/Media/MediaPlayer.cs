using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Media
{
    public static class MediaPlayer
    {
        public static event EventHandler ActiveSongChanged;
        public static event EventHandler MediaStateChanged;

        private static MediaQueue queue = new MediaQueue();

        public static void GetVisualizationData(VisualizationData visualizationData)
        {
            throw new NotImplementedException();
        }

        public static float Volume
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

        public static void Play(Song song)
        {
            queue.Play(song);
        }

        public static void Resume()
        {
            throw new NotImplementedException();
        }

        public static void Pause()
        {
            throw new NotImplementedException();
        }

        public static void MoveNext()
        {
            throw new NotImplementedException();
        }
        public static void MovePrevious()
        {
            throw new NotImplementedException();
        }

        public static void Play(SongCollection songs)
        {
            throw new NotImplementedException();
        }


        public static void Play(SongCollection songs, int index)
        {
            throw new NotImplementedException();
        }

        public static void Stop()
        {
            throw new NotImplementedException();
        }

        public static TimeSpan PlayPosition
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public static bool IsVisualizationEnabled
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

        public static bool GameHasControl
        {
            get
            {
                return true;
            }
        }

        public static bool IsMuted
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

        public static bool IsRepeating
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

        public static bool IsShuffled
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

        public static MediaQueue Queue
        {
            get
            {
                return queue;
            }
        }

        public static MediaState State
        {
            get
            {
                throw new NotImplementedException();
            }
        }

    }
}
