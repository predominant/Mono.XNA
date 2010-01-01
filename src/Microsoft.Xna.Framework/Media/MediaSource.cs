using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Media
{
    public sealed class MediaSource
    {
        private MediaSourceType mediaSourceType;
        private string name;

        internal MediaSource()
        {
        }

        public static IList<MediaSource> GetAvailableMediaSources()
        {
            return new MediaSource[] { new MediaSource() };
        }


        public override string ToString()
        {
            return this.Name;
        }

        public MediaSourceType MediaSourceType
        {
            get
            {
                return this.mediaSourceType;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

    }
}
