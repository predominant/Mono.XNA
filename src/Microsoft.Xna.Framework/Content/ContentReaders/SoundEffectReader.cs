using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Audio;

namespace Microsoft.Xna.Framework.Content
{
    internal class SoundEffectReader : ContentTypeReader<SoundEffect>
    {
        public SoundEffectReader()
        {
        }

        protected internal override SoundEffect Read(ContentReader input, SoundEffect existingInstance)
        {
            byte[] format = input.ReadBytes(input.ReadInt32());
            byte[] data = input.ReadBytes(input.ReadInt32());
            int loopStart = input.ReadInt32();
            int loopLength = input.ReadInt32();
            throw new NotImplementedException();
        }
    }
}
