using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Net
{
    public class GamerJoinedEventArgs : EventArgs
    {
        private NetworkGamer gamer;

        public GamerJoinedEventArgs(NetworkGamer gamer)
        {
            this.gamer = gamer;
        }

        public NetworkGamer Gamer
        {
            get
            {
                return this.gamer;
            }
        }
    }
}
