using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Microsoft.Xna.Framework.Media
{
    public sealed class AlbumCollection : IEnumerable<Album>, IEnumerable, IDisposable
    {
        internal AlbumCollection(List<Album> albumlist)
        {
        }

        public IEnumerator<Album> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
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

        public Album this[int index]
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
