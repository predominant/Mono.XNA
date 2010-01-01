using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content.Pipeline.Audio;
using System.IO;

namespace Microsoft.Xna.Framework.Content.Pipeline.AudioImporters
{
    [ContentImporter(".wav", DefaultProcessor = "SoundEffectProcessor", DisplayName = "WAV Audio")]
    public class WavImporter : ContentImporter<AudioContent>
    {

        public WavImporter()
        {
        }

        public override AudioContent Import(string filename, ContentImporterContext context)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException("filename");
            }
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            FileInfo info = new FileInfo(filename);
            if (!info.Exists)
            {
                throw new FileNotFoundException("Could not locate audio file.");
            }
            AudioContent content = new AudioContent(filename, AudioFileType.Wav);
            int channelCount = content.Format.ChannelCount;
            int sampleRate = content.Format.SampleRate;
            int bitsPerSample = content.Format.BitsPerSample;
            if (content.Format.Format != 1)
            {
                throw new InvalidContentException("No PCM-Data");
            }
            if ((channelCount != 1) && (channelCount != 2))
            {
                throw new InvalidContentException("MultiChannelAudio isn't supported");
            }
            if ((sampleRate < 0x1f40) || (sampleRate > 0xbb80))
            {
                throw new InvalidContentException("Unsupported samplerate. Supported from 8khz to 48khz");
            }
            if ((bitsPerSample != 8) && (bitsPerSample != 0x10))
            {
                throw new InvalidContentException("Only 8bit or 16bit audio is supported");
            }
            return content;
        }
    }
}
