using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.GamerServices;

namespace Microsoft.Xna.Framework.Net
{
    public class InviteAcceptedEventArgs : EventArgs
    {
        private SignedInGamer gamer;
        private bool isCurrentSession;

        public InviteAcceptedEventArgs(SignedInGamer gamer, bool isCurrentSession)
        {
            this.gamer = gamer;
            this.isCurrentSession = isCurrentSession;
        }

        public SignedInGamer Gamer
        {
            get
            {
                return this.gamer;
            }
        }

        public bool IsCurrentSession
        {
            get
            {
                return this.isCurrentSession;
            }
        }
    }
}
