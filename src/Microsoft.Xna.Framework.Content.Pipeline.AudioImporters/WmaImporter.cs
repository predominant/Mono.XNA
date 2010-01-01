using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content.Pipeline.Audio;

namespace Microsoft.Xna.Framework.Content.Pipeline.AudioImporters
{
    [ContentImporter(".wma", DefaultProcessor = "SongProcessor", DisplayName="WMA Audio File")]
    public class WmaImporter : ContentImporter<AudioContent>
    {
        public WmaImporter()
        {
        }

        public override AudioContent Import(string filename, ContentImporterContext context)
        {
            throw new NotImplementedException();
        }
    }
}
