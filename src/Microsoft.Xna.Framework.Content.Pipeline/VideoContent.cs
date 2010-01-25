using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Media;

namespace Microsoft.Xna.Framework.Content.Pipeline
{
    public class VideoContent : ContentItem, IDisposable
    {
        public VideoContent(string filename)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int BitsPerSecond
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public TimeSpan Duration
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        [ContentSerializer(ElementName = "Filename", AllowNull = false)]
        public string Filename
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public float FramesPerSecond
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Height
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        private bool IsDisposed
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        [ContentSerializer(ElementName = "VideoSoundtrackType", AllowNull = false)]
        public VideoSoundtrackType VideoSoundtrackType
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Width
        {
            get
            {
                throw new NotImplementedException();
            }
        }

    }
}
