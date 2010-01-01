using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content.Pipeline.Audio;

namespace Microsoft.Xna.Framework.Content.Pipeline
{
    [ContentImporter(".mp3",DefaultProcessor="SongProcessor",DisplayName="MP3 Audio File")]
    public class Mp3Importer : ContentImporter<AudioContent>
    {
        public Mp3Importer()
        {
        }

        public override AudioContent Import(string filename, ContentImporterContext context)
        {
            throw new NotImplementedException();
        }
    }
}
