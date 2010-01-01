using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Net
{
    public class HostChangedEventArgs : EventArgs
    {
        private NetworkGamer newHost;
        private NetworkGamer oldHost;

        public HostChangedEventArgs(NetworkGamer oldHost, NetworkGamer newHost)
        {
            this.oldHost = oldHost;
            this.newHost = newHost;
        }

        public NetworkGamer NewHost
        {
            get
            {
                return this.newHost;
            }
        }

        public NetworkGamer OldHost
        {
            get
            {
                return this.oldHost;
            }
        }
    }
}
