#region License
/*
MIT License
Copyright © 2006 - 2007 The Mono.Xna Team

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
using System.Collections.ObjectModel;

namespace Microsoft.Xna.Framework.Graphics
{
    public sealed class GraphicsAdapter : IDisposable
    {
        ~GraphicsAdapter()
        {
            Dispose(false);
        }
        GraphicsAdapter()
        {
            // Empty
        }

        public static bool operator !=(GraphicsAdapter l, GraphicsAdapter r)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(GraphicsAdapter l, GraphicsAdapter r)
        {
            throw new NotImplementedException();
        }

        public static ReadOnlyCollection<GraphicsAdapter> Adapters
        {
            get { throw new NotImplementedException(); }
        }

        public DisplayMode CurrentDisplayMode
        {
            get { throw new NotImplementedException(); }
        }

        public static GraphicsAdapter DefaultAdapter
        {
            get
            {
                return new GraphicsAdapter();
            }
        }

        public string Description
        {
            get { throw new NotImplementedException(); }
        }

        public int DeviceId
        {
            get { throw new NotImplementedException(); }
        }

        public Guid DeviceIdentifier
        {
            get { throw new NotImplementedException(); }
        }

        public string DeviceName
        {
            get { throw new NotImplementedException(); }
        }

        public string DriverDll
        {
            get { throw new NotImplementedException(); }
        }

        public Version DriverVersion
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsDefaultAdapter
        {
            get { throw new NotImplementedException(); }
        }

        public IntPtr MonitorHandle
        {
            get { throw new NotImplementedException(); }
        }

        public int Revision
        {
            get { throw new NotImplementedException(); }
        }

        public int SubSystemId
        {
            get { throw new NotImplementedException(); }
        }

        public DisplayModeCollection SupportedDisplayModes
        {
            get { throw new NotImplementedException(); }
        }

        public int VendorId
        {
            get { throw new NotImplementedException(); }
        }


        public bool CheckDepthStencilMatch(DeviceType deviceType, SurfaceFormat adapterFormat, SurfaceFormat renderTargetFormat,
            DepthFormat depthStencilFormat)
        {
            throw new NotImplementedException();
        }

        public bool CheckDeviceFormat(DeviceType deviceType, SurfaceFormat adapterFormat, ResourceUsage usage,
            QueryUsages queryUsages, ResourceType resourceType, DepthFormat checkFormat)
        {
            throw new NotImplementedException();
        }

        public bool CheckDeviceFormat(DeviceType deviceType, SurfaceFormat adapterFormat, ResourceUsage usage,
            QueryUsages queryUsages, ResourceType resourceType, SurfaceFormat checkFormat)
        {
            throw new NotImplementedException();
        }

        public bool CheckDeviceFormatConversion(DeviceType deviceType, SurfaceFormat sourceFormat, SurfaceFormat targetFormat)
        {
            throw new NotImplementedException();
        }

        public bool CheckDeviceMultiSampleType(DeviceType deviceType, SurfaceFormat surfaceFormat,
            bool isFullScreen, MultiSampleType sampleType)
        {
            throw new NotImplementedException();
        }

        public bool CheckDeviceMultiSampleType(DeviceType deviceType, SurfaceFormat surfaceFormat,
            bool isFullScreen, MultiSampleType sampleType, out int qualityLevels)
        {
            throw new NotImplementedException();
        }

        public bool CheckDeviceType(DeviceType deviceType, SurfaceFormat displayFormat, SurfaceFormat backBufferFormat, bool isFullScreen)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Release any managed components
                }
                disposed = true;

                // Release any unmanaged components
            }
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public GraphicsDeviceCapabilities GetCapabilities(DeviceType deviceType)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public bool IsDeviceTypeAvailable(DeviceType deviceType)
        {
            throw new NotImplementedException();
        }

        private bool disposed;
    }
}