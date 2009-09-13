using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Content
{
    internal class ArrayReader<T> : ContentTypeReader<T[]>
    {
        private ContentTypeReader Reader;

        public ArrayReader()
        {
        }

        protected internal override void Initialize(ContentTypeReaderManager manager)
        {
           Reader = manager.GetTypeReader(typeof(T));
        }

        protected internal override T[] Read(ContentReader input, T[] existingInstance)
        {
            int count = input.ReadInt32();
            T[] localArray = new T[count];
            for (int i = 0; i < count; i++)
            {
                localArray[i] = input.ReadObject<T>(this.Reader);
            }
            return localArray;
        }

    }
}
