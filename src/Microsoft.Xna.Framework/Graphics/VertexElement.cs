#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion License


using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Microsoft.Xna.Framework.Graphics
{
    [Serializable]
    public struct VertexElement
    {
        internal short stream;
        internal short offset;
        internal VertexElementFormat format;
        internal VertexElementMethod method;
        internal VertexElementUsage usage;
        internal byte usageIndex;

        public VertexElement(short stream, short offset, VertexElementFormat elementFormat,
            VertexElementMethod elementMethod, VertexElementUsage elementUsage, byte usageIndex)
        {
            this.stream = stream;
            this.offset = offset;
            this.usageIndex = usageIndex;
            this.format = elementFormat;
            this.method = elementMethod;
            this.usage = elementUsage;
        }

        public static bool operator !=(VertexElement left, VertexElement right)
        {
            return !(left == right);
        }

        public static bool operator ==(VertexElement left, VertexElement right)
        {
            return (((((left.stream == right.stream) && (left.offset == right.offset)) && ((left.usageIndex == right.usageIndex) && (left.usage == right.usage))) && (left.format == right.format)) && (left.method == right.method));
        }

        public short Offset
        {
            get
            {
                return this.offset;
            }
            set
            {
                this.offset = value;
            }
        }
 

        public short Stream 
        {
            get 
            {
                return stream;
            }
            set 
            {
                this.stream = value;
            } 
        }

        public byte UsageIndex
        {
            get
            {
                return this.usageIndex;
            }
            set
            {
                this.usageIndex = value;
            }
        }

        public VertexElementFormat VertexElementFormat
        {
            get
            {
                return this.format;
            }
            set
            {
                this.format = value;
            }
        }


        public VertexElementMethod VertexElementMethod
        {
            get
            {
                return this.method;
            }
            set
            {
                this.method = value;
            }
        }


        public VertexElementUsage VertexElementUsage
        {
            get
            {
                return this.usage;
            }
            set
            {
                this.usage = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj.GetType() != base.GetType())
            {
                return false;
            }
            return (this == ((VertexElement)obj));
        }

        public override int GetHashCode() { throw new NotImplementedException(); }

        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{{Stream:{0} Offset:{1} Format:{2} Method:{3} Usage:{4} UsageIndex:{5}}}", new object[] { this.Stream, this.Offset, this.VertexElementFormat, this.VertexElementMethod, this.VertexElementUsage, this.UsageIndex });
        }
    }
}
