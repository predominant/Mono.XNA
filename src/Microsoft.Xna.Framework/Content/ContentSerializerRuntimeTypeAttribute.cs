using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Content
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class)]
    public sealed class ContentSerializerRuntimeTypeAttribute : Attribute
    {
        private string runtimeType;

        public ContentSerializerRuntimeTypeAttribute(string runtimeType)
        {
            if (string.IsNullOrEmpty(runtimeType))
            {
                throw new ArgumentNullException("runtimeType");
            }
            this.runtimeType = runtimeType;
        }

        public string RuntimeType
        {
            get
            {
                return this.runtimeType;
            }
        }

    }
}
