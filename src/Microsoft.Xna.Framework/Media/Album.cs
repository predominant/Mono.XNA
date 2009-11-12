using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework.Media
{
    public sealed class Album : IEquatable<Album>, IDisposable
    {
        private string name;
        private int hashcode;

        private Album()
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
        public bool Equals(Album other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Album first, Album second)
        {
            return object.Equals(first, second);
        }

        public static bool operator !=(Album first, Album second)
        {
            return !(first == second);
        }

        public override string ToString()
        {
            return this.Name;
        }

        public Texture2D GetThumbnail(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException();
        }

        public Texture2D GetAlbumArt(IServiceProvider serviceProvider)
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

        public Artist Artist
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Genre Genre
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
        public bool HasArt
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public TimeSpan Duration
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
    }
}
