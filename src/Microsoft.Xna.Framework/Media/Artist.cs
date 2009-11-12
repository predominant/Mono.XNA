using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Media
{
    public sealed class Artist : IEquatable<Artist>, IDisposable
    {
        private string name;

        private int hashcode;

        private Artist()
        {
        }

        public static bool operator ==(Artist first, Artist second)
        {
            return object.Equals(first, second);
        }

        public static bool operator !=(Artist first, Artist second)
        {
            return !(first == second);
        }

        public override int GetHashCode()
        {
            if (this.hashcode == -1)
            {
                this.hashcode = this.Name.GetHashCode();
            }
            return this.hashcode;
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return this.Name;
        }

        public AlbumCollection Albums
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public SongCollection Songs
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
        }

        public bool Equals(Artist other)
        {
            throw new NotImplementedException();
        }

    }
}
