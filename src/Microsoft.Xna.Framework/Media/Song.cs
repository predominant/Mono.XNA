using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Media
{
    public sealed class Song : IEquatable<Song>, IDisposable
    {
        string name;
        int hashcode = -1;
        TimeSpan duration;
        int rating;
        int tracknumber;
        object handle;
        MediaSource mediaSource;

        internal MediaSource MediaSource
        {
            get 
            {
                return mediaSource;
            }
        }

        internal object Handle
        {
            get
            {
                return handle;
            }
        }

        internal Song(string Name,TimeSpan Duration, int Rating,int Tracknumber, object Handle, MediaSource source)
        {
            name = Name;
            duration = Duration;
            rating = Rating;
            tracknumber = Tracknumber;
            handle = Handle;
            mediaSource = source;
        }

        public void Dispose()
        {
        }

        public bool Equals(Song other)
        {
            throw new System.NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new System.NotImplementedException();
        }

        public static bool operator ==(Song first, Song second)
        {
            return object.Equals(first, second);
        }

        public static bool operator !=(Song first, Song second)
        {
            return !(first == second);
        }

        public override string ToString()
        {
            return this.Name;
        }

        public override int GetHashCode()
        {
            if (this.hashcode == -1)
            {
                this.hashcode = this.Name.GetHashCode();
            }
            return this.hashcode;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }
        public Album Album
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public Artist Artist
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public TimeSpan Duration
        {
            get
            {
                return duration;
            }
        }

        public Genre Genre
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public bool IsProtected
        {
            get
            {
                return mediaSource.getSong_IsProtected(handle);
            }
        }

        public bool IsRated
        {
            get
            {
                return (this.Rating > 0);
            }
        }

        public int PlayCount
        {
            get
            {
                return mediaSource.getSong_PlayCount(handle);
            }
        }

        public int Rating
        {
            get
            {
                return rating;
            }
        }

        public int TrackNumber
        {
            get
            {
                return tracknumber;
            }
        } 

    }
}
