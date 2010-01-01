using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Media
{
    public sealed class Genre : IEquatable<Genre>, IDisposable
    {
        private string name;
        private int hashcode;

        private Genre()
        {
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
        public bool Equals(Genre other)
        {
            throw new NotImplementedException();
        }
        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }
        public static bool operator ==(Genre first, Genre second)
        {
            return object.Equals(first, second);
        }

        public static bool operator !=(Genre first, Genre second)
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

        public SongCollection Songs
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public AlbumCollection Albums
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
