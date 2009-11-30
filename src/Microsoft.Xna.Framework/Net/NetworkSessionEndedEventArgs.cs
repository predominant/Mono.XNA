using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Net
{
    public class NetworkSessionEndedEventArgs : EventArgs
    {
        private NetworkSessionEndReason endReason;

        public NetworkSessionEndedEventArgs(NetworkSessionEndReason endReason)
        {
            this.endReason = endReason;
        }

        public NetworkSessionEndReason EndReason
        {
            get
            {
                return this.endReason;
            }
        }
    }
}
