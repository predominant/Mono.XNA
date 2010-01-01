using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Microsoft.Xna.Framework.Net
{
    public sealed class AvailableNetworkSessionCollection : ReadOnlyCollection<AvailableNetworkSession>, IDisposable
    {
        internal AvailableNetworkSessionCollection(IList<AvailableNetworkSession> sessions)
            : base(sessions)
        {
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool IsDisposed
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
