#region License
/*
MIT License
Copyright © 2011 The MonoXNA Team

All rights reserved.

Authors:
 * Alan McGovern <alan.mcgovern@gmail.com>
 * Tim Pambor
 * Lars Magnusson <lavima@gmail.com>
 
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
using Microsoft.Xna.Framework.Storage;

namespace Microsoft.Xna.Framework.Content
{

    public class ContentManager : IDisposable
    {
        #region Fields

        private Dictionary<string, object> assets;
        private bool disposed;
        private string rootDirectory;
        private IServiceProvider serviceProvider;
       
        #endregion Fields

        #region Properties

        public IServiceProvider ServiceProvider {
            get { return this.serviceProvider; }
        }

        public string RootDirectory {
            get { return this.rootDirectory; }
            set {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                if (this.assets.Count > 0)
                {
                    throw new InvalidOperationException("Cannot Change RootDirectory");
                }
                value = Path.GetFullPath(Path.Combine(StorageContainer.TitleLocation, value));
                this.rootDirectory = value;
            }
        }

        #endregion Properties

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

        #endregion Constructors

		#region Destructor

        ~ContentManager()
        {
            Dispose(false);
        }

        #endregion Destructor


        #region Methods

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

            object cached;
            if (this.assets.TryGetValue(assetName, out cached)) //Check if cached object is available
            {
                if (!(cached is T)) throw new ContentLoadException("Not an XNB file");
                return (T)cached; //Return cached object.
            }

            T asset = this.ReadAsset<T>(assetName, null);
            this.assets.Add(assetName, asset);
            return asset;
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

        internal static string CleanPath(string path)
        {
            int lastindex;
            path = path.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
            for (int i = 1; i < path.Length; i = Math.Max(lastindex - 1, 1))
            {
                i = path.IndexOf(@"\..\", i);
                if (i < 0)
                {
                    return path;
                }
                lastindex = path.LastIndexOf(Path.DirectorySeparatorChar, i - 1) + 1;
                path = path.Remove(lastindex, (i - lastindex) + @"\..\".Length);
            }
            return path;
        }

        protected T ReadAsset<T>(string assetName, Action<IDisposable> recordDisposableObject)
        {
            if (this.disposed)
                throw new ObjectDisposedException(base.ToString());
			
            if (string.IsNullOrEmpty(assetName))
                throw new ArgumentNullException("assetName");
			
            using (Stream assetStream = this.OpenStream(assetName))
            {
                using (ContentReader reader = new ContentReader(this, assetStream, assetName, recordDisposableObject))
                {
                    return reader.ReadAsset<T>();
                }
            }
        }

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
		
        #endregion Methods
    }
}
