using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework.Media
{
    public sealed class Picture : IEquatable<Picture>, IDisposable
    {
        private int hashcode;
        private PictureAlbum album;
        private DateTime date;
        private int width;
        private int height;

        internal Picture()
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

        public bool Equals(Picture other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }


        public override int GetHashCode()
        {
            if (this.hashcode == -1)
            {
                this.hashcode = this.Name.GetHashCode();
            }
            return this.hashcode;
        }


        public Texture2D GetTexture(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException();
        }

        public Texture2D GetThumbnail(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Picture first, Picture second)
        {
            return object.Equals(first, second);
        }

        public static bool operator !=(Picture first, Picture second)
        {
            return !(first == second);
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
        public int Width
        {
            get
            {
                return this.width;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
        }

        public PictureAlbum Album
        {
            get
            {
                return this.album;
            }
        }
    }
}
