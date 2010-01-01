using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.GamerServices;

namespace Microsoft.Xna.Framework.Net
{
    public class NetworkGamer : Gamer
    {

        internal NetworkGamer()
        {
        }

        public bool HasLeftSession
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool HasVoice
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public byte Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsGuest
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsHost
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsLocal
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsMutedByLocalUser
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsPrivateSlot
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsReady
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

        public bool IsTalking
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public NetworkMachine Machine
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public TimeSpan RoundtripTime
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public NetworkSession Session
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
