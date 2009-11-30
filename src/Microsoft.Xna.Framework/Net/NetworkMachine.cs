using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.GamerServices;

namespace Microsoft.Xna.Framework.Net
{
    public sealed class NetworkMachine
    {
        internal NetworkMachine()
        {
        }

        public void RemoveFromSession()
        {
            throw new NotImplementedException();
        }

        public GamerCollection<NetworkGamer> Gamers
        {
            get
            {
                throw new NotImplementedException();
            }
        }

    }
}
