using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework.Net
{
    public class PacketWriter : BinaryWriter
    {
        public PacketWriter()
            : this(0)
        {
        }

        public PacketWriter(int capacity)
            : base(new MemoryStream(capacity))
        {
        }

        public void Write(Color value)
        {
            this.Write(value.PackedValue);
        }

        public void Write(Matrix value)
        {
            this.Write(value.M11);
            this.Write(value.M12);
            this.Write(value.M13);
            this.Write(value.M14);
            this.Write(value.M21);
            this.Write(value.M22);
            this.Write(value.M23);
            this.Write(value.M24);
            this.Write(value.M31);
            this.Write(value.M32);
            this.Write(value.M33);
            this.Write(value.M34);
            this.Write(value.M41);
            this.Write(value.M42);
            this.Write(value.M43);
            this.Write(value.M44);
        }

        public void Write(Quaternion value)
        {
            this.Write(value.X);
            this.Write(value.Y);
            this.Write(value.Z);
            this.Write(value.W);
        }

        public void Write(Vector2 value)
        {
            this.Write(value.X);
            this.Write(value.Y);
        }

        public void Write(Vector3 value)
        {
            this.Write(value.X);
            this.Write(value.Y);
            this.Write(value.Z);
        }

        public void Write(Vector4 value)
        {
            this.Write(value.X);
            this.Write(value.Y);
            this.Write(value.Z);
            this.Write(value.W);
        }

        public override void Write(double value)
        {
            throw new NotImplementedException();
        }

        public override void Write(float value)
        {
            throw new NotImplementedException();
        }

        public int Length
        {
            get
            {
                return (int)this.BaseStream.Length;
            }
        }

        public int Position
        {
            get
            {
                return (int)this.BaseStream.Position;
            }
            set
            {
                this.BaseStream.Position = value;
            }
        }

    }
}
