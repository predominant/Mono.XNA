using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Net
{
    public enum NetworkSessionEndReason
    {
        ClientSignedOut,
        HostEndedSession,
        RemovedByHost,
        Disconnected
    }

    public enum NetworkSessionJoinError
    {
        SessionNotFound,
        SessionNotJoinable,
        SessionFull
    }

    public enum NetworkSessionState
    {
        Lobby,
        Playing,
        Ended
    }

    public enum NetworkSessionType
    {
        Local,
        SystemLink,
        PlayerMatch,
        Ranked
    }

    [Flags]
    public enum SendDataOptions
    {
        None,
        Reliable,
        InOrder,
        ReliableInOrder,
        Chat
    }

}
