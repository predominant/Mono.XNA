using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Content
{
    internal class ListReader<T> : ContentTypeReader<List<T>>
    {
        private ContentTypeReader elementReader;

        public ListReader()
        {
        }

        protected internal override void Initialize(ContentTypeReaderManager manager)
        {
            this.elementReader = manager.GetTypeReader(typeof(T));
        }

        protected internal override List<T> Read(ContentReader input, List<T> existingInstance)
        {
            int count = input.ReadInt32();
            List<T> list = existingInstance;
            if (list == null)
            {
                list = new List<T>();
            }
            while (count-- > 0)
            {
                list.Add(input.ReadObject<T>(this.elementReader));
            }
            return list;
        }
    }
}
