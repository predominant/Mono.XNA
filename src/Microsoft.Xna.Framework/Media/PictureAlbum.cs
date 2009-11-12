using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Media
{
    public sealed class PictureAlbum : IEquatable<PictureAlbum>, IDisposable
    {
        private int hashcode;
        private PictureAlbumCollection albums;
        private PictureAlbum parent;
        private PictureCollection pictures;

        internal PictureAlbum()
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

        public bool Equals(PictureAlbum other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(PictureAlbum first, PictureAlbum second)
        {
            return object.Equals(first, second);
        }

        public static bool operator !=(PictureAlbum first, PictureAlbum second)
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

        public override string ToString()
        {
            return this.Name;
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public PictureAlbumCollection Albums
        {
            get
            {
                return this.albums;
            }
        }
 
        public PictureAlbum Parent
        {
            get
            {
                return this.parent;
            }
        }

        public PictureCollection Pictures
        {
            get
            {
                return this.pictures;
            }
        }
 

    }
}
