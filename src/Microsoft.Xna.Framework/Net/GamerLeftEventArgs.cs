using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Net
{
    public class GamerLeftEventArgs : EventArgs
    {
        private NetworkGamer gamer;

        public GamerLeftEventArgs(NetworkGamer gamer)
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
