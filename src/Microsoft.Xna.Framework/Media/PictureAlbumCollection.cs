using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Microsoft.Xna.Framework.Media
{
    public sealed class PictureAlbumCollection : IEnumerable<PictureAlbum>, IEnumerable, IDisposable
    {
        internal PictureAlbumCollection()
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

        public IEnumerator<PictureAlbum> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public PictureAlbum this[int index]
        {
            get
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
 
    }
}
