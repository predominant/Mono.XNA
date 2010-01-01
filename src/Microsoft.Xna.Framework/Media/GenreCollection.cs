using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Microsoft.Xna.Framework.Media
{
    public sealed class GenreCollection : IEnumerable<Genre>, IEnumerable, IDisposable
    {
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private GenreCollection()
        {
        }

        private void Dispose(bool disposing)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Genre> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Genre this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
