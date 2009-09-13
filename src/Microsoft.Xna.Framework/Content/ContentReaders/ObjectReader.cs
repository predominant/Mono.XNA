using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Content
{
    internal class ObjectReader : ContentTypeReader
    {
        public ObjectReader()
            : base(typeof(object))
        {
        }

        protected internal override object Read(ContentReader input, object existingInstance)
        {
            throw new NotSupportedException();
        }
    }
}
