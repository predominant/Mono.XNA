using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Media
{
    public enum MediaState
    {
        Stopped,
        Playing,
        Paused
    }

    public enum MediaSourceType
    {
        LocalDevice = 0,
        WindowsMediaConnect = 4
    }

    public enum VideoSoundtrackType
    {
        Music,
        Dialog,
        MusicAndDialog
    }
}
