using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Microsoft.Xna.Framework.Net
{
    [Serializable]
    public class NetworkNotAvailableException : NetworkException
    {
        public NetworkNotAvailableException()
        {
        }

        public NetworkNotAvailableException(string message)
            : base(message)
        {
        }

        protected NetworkNotAvailableException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public NetworkNotAvailableException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

}
