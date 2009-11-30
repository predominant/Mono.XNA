using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework.Net
{
    public class PacketReader : BinaryReader
    {
        public PacketReader()
            : this(0)
        {
        }

        public PacketReader(int capacity)
            : base(new MemoryStream(capacity))
        {
        }

        public Color ReadColor()
        {
            Color color = new Color();
            color.PackedValue = this.ReadUInt32();
            return color;
        }

        public override double ReadDouble()
        {
            throw new NotImplementedException();
        }

        public Matrix ReadMatrix()
        {
            Matrix matrix;
            matrix.M11 = this.ReadSingle();
            matrix.M12 = this.ReadSingle();
            matrix.M13 = this.ReadSingle();
            matrix.M14 = this.ReadSingle();
            matrix.M21 = this.ReadSingle();
            matrix.M22 = this.ReadSingle();
            matrix.M23 = this.ReadSingle();
            matrix.M24 = this.ReadSingle();
            matrix.M31 = this.ReadSingle();
            matrix.M32 = this.ReadSingle();
            matrix.M33 = this.ReadSingle();
            matrix.M34 = this.ReadSingle();
            matrix.M41 = this.ReadSingle();
            matrix.M42 = this.ReadSingle();
            matrix.M43 = this.ReadSingle();
            matrix.M44 = this.ReadSingle();
            return matrix;
        }

        public Quaternion ReadQuaternion()
        {
            Quaternion quaternion;
            quaternion.X = this.ReadSingle();
            quaternion.Y = this.ReadSingle();
            quaternion.Z = this.ReadSingle();
            quaternion.W = this.ReadSingle();
            return quaternion;
        }

        public override float ReadSingle()
        {
            throw new NotImplementedException();
        }

        public Vector2 ReadVector2()
        {
            Vector2 vector;
            vector.X = this.ReadSingle();
            vector.Y = this.ReadSingle();
            return vector;
        }

        public Vector3 ReadVector3()
        {
            Vector3 vector;
            vector.X = this.ReadSingle();
            vector.Y = this.ReadSingle();
            vector.Z = this.ReadSingle();
            return vector;
        }

        public Vector4 ReadVector4()
        {
            Vector4 vector;
            vector.X = this.ReadSingle();
            vector.Y = this.ReadSingle();
            vector.Z = this.ReadSingle();
            vector.W = this.ReadSingle();
            return vector;
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
