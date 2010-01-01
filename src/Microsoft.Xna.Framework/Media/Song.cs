using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Media
{
    public sealed class Song : IEquatable<Song>, IDisposable
    {
        string name;
        int hashcode;

        internal Song()
        {
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
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
                throw new System.NotImplementedException();
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
                throw new System.NotImplementedException();
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
                throw new System.NotImplementedException();
            }
        }



        public int Rating
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public int TrackNumber
        {
            get
            {
                throw new System.NotImplementedException();
            }
        } 

    }
}
