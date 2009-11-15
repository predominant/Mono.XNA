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
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Microsoft.Xna.Framework.Content
{
    public sealed class ContentReader : BinaryReader
    {
        private ContentManager contentManager;
        private GraphicsDevice graphicsDevice;
        private string assetName;
        private ContentTypeReader[] typeReaders;
        private Action<IDisposable> recordDisposableObject;
        private List<Action<object>>[] ResourceFixups;

        internal GraphicsDevice GraphicsDevice 
        {
            get
            {
                IGraphicsDeviceService service = (IGraphicsDeviceService)this.contentManager.ServiceProvider.GetService(typeof(IGraphicsDeviceService));
                if (service == null)
                {
                    throw new ContentLoadException("No GraphicsDevice");
                }
                GraphicsDevice graphicsDevice = service.GraphicsDevice;
                if (graphicsDevice == null)
                {
                    throw new ContentLoadException("No GraphicsDevice");
                }
                return graphicsDevice;
            }

        }

        internal ContentReader(ContentManager manager, Stream stream, GraphicsDevice graphicsDevice)
            : base(stream)
        {
            this.graphicsDevice = graphicsDevice;
        }
        internal ContentReader(ContentManager contentManager, Stream input, string assetName, Action<IDisposable> recordDisposableObject)
            : base(PrepareStream(input, assetName))
        {
            this.contentManager = contentManager;
            this.assetName = assetName;
            this.recordDisposableObject = recordDisposableObject;
        }

        internal string PathToReference(string referenceName)
        {
            int length = this.assetName.LastIndexOfAny(new char[] { '\\', '/', Path.DirectorySeparatorChar });
            string str = "";
            if (length != -1)
             {
                str = this.assetName.Substring(0, length);
             }
            return ContentManager.CleanPath(Path.Combine(str, referenceName));
        }

        private int ReadHeader()
        {
            int Count = base.Read7BitEncodedInt();
            this.typeReaders = ContentTypeReaderManager.ReadTypeManifest(Count, this);
            int ResourceCount = base.Read7BitEncodedInt();
            if (ResourceCount > 0)
            {
                this.ResourceFixups = new List<Action<object>>[ResourceCount];
                for (int i = 0; i < ResourceCount; i++)
                {
                    this.ResourceFixups[i] = new List<Action<object>>();
                }
            }
            return ResourceCount;
        }

        internal T ReadAsset<T>()
        {
            T local;
            try
            {
                int ResourceCount = this.ReadHeader();
                local = this.ReadObject<T>();
                this.ReadSharedResources(ResourceCount);
            }
            catch (IOException exception)
            {
                throw new ContentLoadException("Bad XNB", exception);
            }
            return local;
        }

        private void ReadSharedResources(int ResourceCount)
        {
            if (ResourceCount > 0)
            {
                object[] Ressources = new object[ResourceCount];
                for (int i = 0; i < ResourceCount; i++)
                {
                    Ressources[i] = this.ReadObject<object>();
                }
                for (int j = 0; j < ResourceCount; j++)
                {
                    foreach (Action<object> action in this.ResourceFixups[j])
                    {
                        action(Ressources[j]);
                    }
                }
            }
        }

        private static Stream PrepareStream(Stream input, string assetName)
        {
            Stream stream;
            try
            {
                bool flag; //Compressionflag
                BinaryReader reader = new BinaryReader(input);
                if (((reader.ReadByte() != 0x58) || (reader.ReadByte() != 0x4e)) || (reader.ReadByte() != 0x42)) //First three bytes have to be "XNB"
                {
                    throw new ContentLoadException("Bad XNB Magic");
                }
                if (reader.ReadByte() != 0x77) //Platform have to be "w" -> stands for windows
                {
                    throw new ContentLoadException("Bad XNB Platform");
                }
                switch (reader.ReadUInt16()) //Version
                {
                    case 3:
                        flag = false; //Not compressed Stream
                        break;

                    case 0x8003:
                        flag = true; //Compressed Stream
                        break;

                    default:
                        throw new ContentLoadException("Bad XNB Version");
                }
                int num = reader.ReadInt32(); //Number of bytes
                if (input.CanSeek && ((num - 10) > (input.Length - input.Position))) //Check if we can read the expected number of bytes
                {
                    throw new ContentLoadException("Bad XNB Size");
                }
                if (flag) //DecompressStream
                {
                    //TODO: Add support for compressed Content
                }
                stream = input;
            }
            catch (IOException exception)
            {
                throw new ContentLoadException("Bad XNB",exception);
            }
            return stream;
        }

        public ContentManager ContentManager {
            get { return this.contentManager; }
        }

        public string AssetName {
            get { return this.assetName; }
        }

        public T ReadExternalReference<T>()
        {
            string str = this.ReadString();
            if (string.IsNullOrEmpty(str))
            {
                return default(T);
            }
            string pathToReference = this.PathToReference(str);
            return this.contentManager.Load<T>(pathToReference);
        }

        public Matrix ReadMatrix()
        {
            Matrix result = new Matrix();
            result.M11 = ReadSingle();
            result.M12 = ReadSingle();
            result.M13 = ReadSingle();
            result.M14 = ReadSingle(); 
            result.M21 = ReadSingle();
            result.M22 = ReadSingle();
            result.M23 = ReadSingle();
            result.M24 = ReadSingle();
            result.M31 = ReadSingle();
            result.M32 = ReadSingle();
            result.M33 = ReadSingle();
            result.M34 = ReadSingle();
            result.M41 = ReadSingle();
            result.M42 = ReadSingle();
            result.M43 = ReadSingle();
            result.M44 = ReadSingle();
            return result;
        }

        public Color ReadColor()
        {
            Color color = new Color();
            color.PackedValue = this.ReadUInt32();
            return color;
        }

        public override double ReadDouble()
        {
            return base.ReadDouble(); //TODO: Maybe Doubles are stored in another way
        }

        public override float ReadSingle()
        {
            return base.ReadSingle(); //TODO: Maybe Singles are stored in another way
        }

        public T ReadObject<T>()
        {
            int index = base.Read7BitEncodedInt();
            if (index == 0)
            {
                return default(T);
            }
            index--;
            if (index >= this.typeReaders.Length)
            {
                throw new Exception();
            }
            ContentTypeReader reader = this.typeReaders[index];
            return this.ReadObject<T>(reader);

        }

        public T ReadObject<T>(ContentTypeReader typeReader)
        {
            //typeReader.Initialize(new ContentTypeReaderManager(this));
            return (T)typeReader.Read(this, default(T));
        }

        public T ReadObject<T>(T existingInstance)
        {
            throw new NotImplementedException();
        }

        public T ReadObject<T>(ContentTypeReader typeReader, T existingInstance)
        {
            return (T)typeReader.Read(this, existingInstance);
        }

        public Quaternion ReadQuaternion()
        {
            throw new NotImplementedException();
        }

        public T ReadRawObject<T>()
        {
            throw new NotImplementedException();
        }

        public T ReadRawObject<T>(ContentTypeReader typeReader)
        {
            throw new NotImplementedException();
        }

        public T ReadRawObject<T>(T existingInstance)
        {
            throw new NotImplementedException();
        }

        public T ReadRawObject<T>(ContentTypeReader typeReader, T existingInstance)
        {
            throw new NotImplementedException();
        }

        public void ReadSharedResource<T>(Action<T> fixup)
        {
            if (fixup == null)
            {
                throw new ArgumentNullException("fixup");
            }
            int index = base.Read7BitEncodedInt();
            if (index != 0)
            {
                index--;
                if ( index >= this.ResourceFixups.Length)
                {
                    throw new ContentLoadException("Bad XNB");
                }
                this.ResourceFixups[index].Add(delegate (object value) {
                    if (!(value is T))
                    {
                        throw new ContentLoadException("Bad XNB");
                    }
                    fixup((T) value);
                });
            }       
         }

        public Vector2 ReadVector2()
        {
            Vector2 result = new Vector2();
            result.X = ReadSingle();
            result.Y = ReadSingle();
            return result;
        }

        public Vector3 ReadVector3()
        {
            Vector3 result = new Vector3();
            result.X = ReadSingle();
            result.Y = ReadSingle();
            result.Z = ReadSingle();
            return result;
        }

        public Vector4 ReadVector4()
        {
            //FIXME: Test this. Should 'w' be first or last?
            Vector4 result = new Vector4();
            result.X = ReadSingle();
            result.Y = ReadSingle();
            result.Z = ReadSingle();
            result.W = ReadSingle();
            return result;
        }
    }
}
