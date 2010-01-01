using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework.Media;

namespace Microsoft.Xna.Framework.Content
{
    internal class SongReader : ContentTypeReader<Song>
    {
        public SongReader()
        {
        }

        protected internal override Song Read(ContentReader input, Song existingInstance)
        {
            string referenceName = input.ReadString();
            throw new NotImplementedException();
        }
    }
}
