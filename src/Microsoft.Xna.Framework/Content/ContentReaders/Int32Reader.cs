using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Content
{
    internal class Int32Reader : ContentTypeReader<int>
    {
        public Int32Reader()
        {
        }

        protected internal override int Read(ContentReader input, int existingInstance)
        {
            return input.ReadInt32();
        }
    }
}
