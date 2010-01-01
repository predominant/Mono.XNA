using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Microsoft.Xna.Framework.Media
{
    public sealed class PictureCollection : IEnumerable<Picture>, IEnumerable, IDisposable
    {

        internal PictureCollection()
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

        public IEnumerator<Picture> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public Picture this[int index]
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
