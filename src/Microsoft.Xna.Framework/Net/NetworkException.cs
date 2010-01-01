using System;
using System.Runtime.Serialization;

namespace Microsoft.Xna.Framework.Net
{

    [System.Serializable]
    public class NetworkException : System.Exception
    {

        public NetworkException()
        {
        }

        public NetworkException(string message)
            : base(message)
        {
        }

        public NetworkException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }

        protected NetworkException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }

    } 

}
