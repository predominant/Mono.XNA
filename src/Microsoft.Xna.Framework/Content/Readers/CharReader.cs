using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Content.Readers
{
    internal class CharReader : ContentTypeReader<char>
    {
        public CharReader()
        {
        }

        protected internal override char Read(ContentReader input, char existingInstance)
        {
            return input.ReadChar();
        }
    }
}
