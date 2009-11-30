using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Permissions;
using System.Runtime.Serialization;

namespace Microsoft.Xna.Framework.Net
{
    [Serializable]
    public class NetworkSessionJoinException : NetworkException
    {
        private NetworkSessionJoinError joinError;

        public NetworkSessionJoinException()
        {
        }

        public NetworkSessionJoinException(string message)
            : base(message)
        {
        }

        protected NetworkSessionJoinException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            this.joinError = (NetworkSessionJoinError)info.GetInt32("joinError");
        }

        public NetworkSessionJoinException(string message, NetworkSessionJoinError joinError)
            : base(message)
        {
            this.joinError = joinError;
        }

        public NetworkSessionJoinException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            base.GetObjectData(info, context);
            info.AddValue("joinError", (int)this.joinError);
        }

        public NetworkSessionJoinError JoinError
        {
            get
            {
                return this.joinError;
            }
            set
            {
                this.joinError = value;
            }
        }
    }
}
