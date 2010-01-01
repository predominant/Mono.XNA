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
using System.Runtime.Remoting.Messaging;

namespace Microsoft.Xna.Framework.Storage
{
    public sealed class StorageDevice
    {
        #region Events
		
        public static event EventHandler<EventArgs> DeviceChanged;
		
        #endregion

        #region Fields        

        private DriveInfo driveInfo;
        private PlayerIndex playerIndex;
        private bool playerSpecified;
        private delegate StorageDevice showStorage();
        private delegate StorageDevice showStorage2(PlayerIndex index);

        #endregion Fields


        #region Properties

        public long FreeSpace {
            get { return (this.driveInfo.IsReady) ? this.driveInfo.AvailableFreeSpace : 0; }
        }

        public bool IsConnected {
            get { return this.driveInfo.IsReady; }
        }

        public long TotalSpace {
            get { return (this.driveInfo.IsReady) ? this.driveInfo.TotalSize : 0; }
        }

        #endregion Properties

        #region Constructors

        internal StorageDevice(PlayerIndex index)
            : this(index, true)
        {
        }

        internal StorageDevice()
            : this(PlayerIndex.One, false)
        {
        }

        private StorageDevice(PlayerIndex playerIndex, bool playerSpecified)
        {
            this.playerIndex = playerIndex;
            this.playerSpecified = playerSpecified;
            this.driveInfo = new DriveInfo(Directory.GetDirectoryRoot(Environment.GetFolderPath(System.Environment.SpecialFolder.Personal)));
        }

        #endregion Constructors


        #region Methods        

        public StorageContainer OpenContainer(string titleName)
        {
            // TODO: What happens if we open several times?
            if (string.IsNullOrEmpty(titleName))
                throw new ArgumentNullException("You must pass in a non-null title name");

            return new StorageContainer(this, titleName, playerSpecified, playerIndex);
        }

        public void DeleteContainer(string titleName)
        {
            throw new NotImplementedException();
        }

        #endregion Methods
		
		#region Old Code		
		/*
		private static showStorage deleg = ShowStorageDeviceGuide;
        private static showStorage2 deleg2 = ShowStorageDeviceGuide;
        
        public static IAsyncResult BeginShowStorageDeviceGuide(AsyncCallback callback, object stateObject)
        {
            // TODO: Is this actually thread safe?
            return deleg.BeginInvoke(callback, stateObject);
        }

        public static IAsyncResult BeginShowStorageDeviceGuide(PlayerIndex playerIndex, AsyncCallback callback, object stateObject)
        {
            // TODO: Is this actually thread safe?
            return deleg2.BeginInvoke(playerIndex, callback, stateObject);
        }

        public static StorageDevice EndShowStorageDeviceGuide(IAsyncResult asyncResult)
        {
            // TODO: Is this the right exception
            if (asyncResult == null)
                throw new ArgumentException();

            // TODO: Is this actually thread safe?
            return (((AsyncResult)asyncResult).AsyncDelegate is showStorage) ? deleg.EndInvoke(asyncResult)
                : deleg2.EndInvoke(asyncResult);
        }
        
        public static StorageDevice ShowStorageDeviceGuide()
        {
            // TODO: Is this right?
            return new StorageDevice();
        }

        public static StorageDevice ShowStorageDeviceGuide(PlayerIndex playerIndex)
        {
            // TODO: Is this right?
            return new StorageDevice(playerIndex);
        }
        */		
		#endregion Old Code
    }
}