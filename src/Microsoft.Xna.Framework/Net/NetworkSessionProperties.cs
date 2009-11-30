using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Microsoft.Xna.Framework.Net
{
    public class NetworkSessionProperties : IList<int?>, ICollection<int?>, IEnumerable<int?>, IEnumerable
    {
        private int?[] data;

        public IEnumerator<int?> GetEnumerator()
        {
            return (IEnumerator<int?>)this.data.GetEnumerator();
        }

        void ICollection<int?>.Add(int? item)
        {
            throw new NotSupportedException();
        }

        void ICollection<int?>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<int?>.Contains(int? item)
        {
            throw new NotImplementedException();
        }

        void ICollection<int?>.CopyTo(int?[] array, int arrayIndex)
        {
            this.data.CopyTo(array, arrayIndex);
        }

        bool ICollection<int?>.Remove(int? item)
        {
            throw new NotSupportedException();
        }

        void IList<int?>.Insert(int index, int? item)
        {
            throw new NotSupportedException();
        }

        void IList<int?>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        int IList<int?>.IndexOf(int? item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.data.GetEnumerator();
        }

        bool ICollection<int?>.IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public int Count
        {
            get
            {
                return 8;
            }
        }

        public int? this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

    }
}
