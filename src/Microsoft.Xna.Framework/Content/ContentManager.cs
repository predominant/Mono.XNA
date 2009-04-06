#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.

Authors:
Alan McGovern <alan.mcgovern@gmail.com>
 
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
using System.Collections.Generic;
using System.Text;
using System.Net;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection;

namespace Microsoft.Xna.Framework.Content
{

    public class ContentManager : IDisposable
    {
        #region Private Members

        private Dictionary<string, object> assets;
        private bool disposed;
        private string rootDirectory;
        private IServiceProvider serviceProvider;
       
        #endregion


        #region Public Properties

        public IServiceProvider ServiceProvider
        {
            get { return this.serviceProvider; }
        }

        #endregion


        #region Public Constructors

        public ContentManager(IServiceProvider serviceProvider) : this(serviceProvider, string.Empty)
        {
            // Empty
        }

        public ContentManager(IServiceProvider serviceProvider, string rootDirectory)
        {
            if (serviceProvider == null)
                throw new ArgumentNullException("serviceProvider");

            if (rootDirectory == null)
                throw new ArgumentNullException("rootDirectory");

            this.assets = new Dictionary<string, object>();
            this.rootDirectory = rootDirectory;
            this.serviceProvider = serviceProvider;
        }

        #endregion
        

        #region Destructor

        ~ContentManager()
        {
            Dispose(false);
        }

        #endregion


        #region Protected Methods

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // Dispose any managed resources
                    Unload();
                }
                // Dispose any unmanaged resources

                this.disposed = true;
            }
        }


        protected virtual Stream OpenStream(string assetName)
        {
            Stream stream;
            try
            {
                string path = Path.Combine(rootDirectory, assetName + ".xnb");
                stream = File.OpenRead(path);
            }
            catch (FileNotFoundException fileNotFound)
            {
                throw new ContentLoadException("The content file was not found.", fileNotFound);
            }
            catch (DirectoryNotFoundException directoryNotFound)
            {
                throw new ContentLoadException("The directory was not found.", directoryNotFound);
            }
            catch (Exception exception)
            {
                throw new ContentLoadException("Opening stream error.", exception);
            }
            return stream;
        }

        #endregion Protected Methods


        #region Public Methods

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual T Load<T>(string assetName)
        {
            if (this.disposed)
                throw new ObjectDisposedException(base.ToString());   // Prints out the full type information as the message

            if (string.IsNullOrEmpty(assetName))
                throw new ArgumentNullException("assetName");       // We can't load an asset if we don't know it's name

            // Try to get a stream for the supplied asset
            Stream assetStream = GetAssetStream(assetName);

            // Get the graphics device from the service provider to pass to the contentreader
            GraphicsDevice graphicsDevice = ((IGraphicsDeviceService)this.serviceProvider.GetService(typeof(IGraphicsDeviceService))).GraphicsDevice;
            
            // Create a contentreader for the stream to read out the asset (whatever it is)
            ContentReader contentReader = new ContentReader(this, assetStream, graphicsDevice);

            // Get the asset's type readers. There can be a few of these like for the model class.
            ContentTypeReader[] assetReaders = GetAssetReaders<T>(assetStream);

            // Get the 1-based index of the typereader we should use to start decoding with
            int index = assetStream.ReadByte();
            T asset = contentReader.ReadObject<T>(assetReaders[index-1]);

            this.assets.Add(assetName, asset);
            return asset;
        }

        private ContentTypeReader[] GetAssetReaders<T>(Stream assetStream)
        {
            int length;
            int numberOfReaders;
            ContentTypeReader[] contentReaders;
            BinaryReader binaryReader = new BinaryReader(assetStream);
            // The first 4 bytes should be the "XNBw" header. i use that to detect an invalid file
            if (assetStream.ReadByte() != 'X' ||
                assetStream.ReadByte() != 'N' ||
                assetStream.ReadByte() != 'B' ||
                assetStream.ReadByte() != 'w')
                throw new ContentLoadException("Not an XNB file");

            // I think these two bytes are some kind of version number. Either for the XNB file or the type readers
            short version = binaryReader.ReadInt16();

            // The next int32 is the length of the XNB file
            int xnbLength = binaryReader.ReadInt32();

            // The next byte i read tells me the number of content readers in this XNB file
            numberOfReaders = assetStream.ReadByte();
            contentReaders = new ContentTypeReader[numberOfReaders];
            
            // For each reader in the file, we read out the length of the string which contains the type of the reader,
            // then we read out the string. Finally we instantiate an instance of that reader using reflection
            for (int i = 0; i < numberOfReaders; i++)
            {
                length = assetStream.ReadByte();

                // Create a new buffer which can hold the entire string.
                byte[] buffer = new byte[length];
                assetStream.Read(buffer, 0, length);

                // This string tells us what reader we need to decode the following data
                string readerTypeString = Encoding.UTF8.GetString(buffer);

                // I think the next 4 bytes refer to the "Version" of the type reader,
                // although it always seems to be zero
                int typeReaderVersion = binaryReader.ReadInt32();

                // Get the type of the reader
                Type readerType = Type.GetType(readerTypeString);

                // Get the default constructor for the reader
                ConstructorInfo info = readerType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, Type.EmptyTypes, null);

                // Instantiate an instance of the reader
                contentReaders[i] = (ContentTypeReader)info.Invoke(null);
            }

            return contentReaders;
        }

        public virtual void Unload()
        {
            if (this.disposed)
                throw new ObjectDisposedException(this.GetType().ToString());

            Dictionary<string, object>.Enumerator enumerator = assets.GetEnumerator();
            while (enumerator.MoveNext())
            {
                IDisposable disposableObject = enumerator.Current.Value as IDisposable;
                if (disposableObject != null)
                    disposableObject.Dispose();
            }
            enumerator.Dispose();
            this.assets.Clear();
            this.disposed = true;
        }

        #endregion


        #region Private Methods

        private Stream GetAssetStream(string assetName)
        {
            Stream stream = null;
            string path = Path.Combine(this.rootDirectory, assetName + ".xnb");

            // If the file doesn't exist, don't even try to open it. Throw an exception
            if (!File.Exists(path))
                throw new ContentLoadException("File could not be found");

            // If we can't open the file, throw a ContentLoadException.
            try
            {
                stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            }
            catch (Exception ex)
            {
                throw new ContentLoadException("File could not be opened", ex);
            }

            return stream;
        }

        #endregion
    }
}
