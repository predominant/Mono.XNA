#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.

Authors: Jérémie LAVAL <jeremie.laval@gmail.com>

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
using System.Reflection;

namespace Microsoft.Xna.Framework.Storage
{
    public sealed class StorageContainer : IDisposable
    {
        #region Events

        public event EventHandler Disposing;

        #endregion Events


        #region Private Fields

        private bool isDisposed;
        private StorageDevice parentDevice;
        private string path;
        private string titleName;

        #endregion Private Fields


        #region Properties

        public bool IsDisposed
        {
            get { return this.isDisposed; }
        }

        public string Path
        {
            get { return this.path; }
        }

        public StorageDevice StorageDevice
        {
            get { return this.parentDevice; }
        }

        public static string TitleLocation
        {
            get
            {
                // Should we add a test for nullity of Assembly.GetEntryAssembly() ?
                // (Normally GetEntryAssembly is always non null except if the library
                // has been called from unmanaged code) FIXME
                return Directory.GetParent(Assembly.GetEntryAssembly().Location).ToString();
            }
        }

        public string TitleName
        {
            get { return this.titleName; }
        }

        #endregion


        #region Constructors

        internal StorageContainer(StorageDevice device, string titleName, bool playerSpecified, PlayerIndex index)
        {
            // the reference to the Device that called OpenContainer
            this.parentDevice = device;

            // the name of the game
            this.titleName = titleName;

            // The directory separator
            char sep = System.IO.Path.DirectorySeparatorChar;

            // Maybe on Unix system the main folder should be ".SavedGames"
            this.path = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + sep +
                                     "SavedGames" + sep + titleName;

            if (playerSpecified)
            {
                switch (index)
                {
                    case PlayerIndex.One:
                        this.path += sep + "Player1";
                        break;

                    case PlayerIndex.Two:
                        this.path += sep + "Player2";
                        break;

                    case PlayerIndex.Three:
                        this.path += sep + "Player3";
                        break;

                    case PlayerIndex.Four:
                        this.path += sep + "Player4";
                        break;

                    default:    // We if there are new enum values we need to support em
                        throw new NotSupportedException();
                }
            }
            else
            {
                this.path += sep + "AllPlayers";
            }

            // If the path doesn't exist (first call) then create it
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }
        
        ~StorageContainer()
        {
        }

        #endregion Constructors


        #region Public Methods

        /*public void Delete()
        {
            Dispose();
        }*/

        public void Dispose()
        {
            if (isDisposed)
                return;

            // Fire the event
            if (Disposing != null)
                Disposing(this, EventArgs.Empty);

            // TODO: Do we need to dispose all the containers StorageContainers? If so, where do we access them
            isDisposed = true;
        }

        #endregion Public Methods
    }
}
