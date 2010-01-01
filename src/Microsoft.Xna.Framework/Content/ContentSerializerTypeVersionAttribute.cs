using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Content
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class)]
    public sealed class ContentSerializerTypeVersionAttribute : Attribute
    {
        private int typeVersion;

        public ContentSerializerTypeVersionAttribute(int typeVersion)
        {
            this.typeVersion = typeVersion;
        }

        public int TypeVersion
        {
            get
            {
                return this.typeVersion;
            }
        }
    }
}
