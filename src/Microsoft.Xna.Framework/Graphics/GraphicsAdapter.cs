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
using System.Runtime.InteropServices;
using Tao.Sdl;
using Tao.OpenGl;

namespace Microsoft.Xna.Framework.Graphics
{
    public sealed class GraphicsAdapter : IDisposable
    {
		#region Fields

		private static ReadOnlyCollection<GraphicsAdapter> adapters;        
		private bool disposed;
        private DisplayMode currentDisplayMode;
		private GraphicsDeviceCapabilities hardwareCapabilities;

        #endregion Fields
		
		#region Properties        
		
        public static GraphicsAdapter DefaultAdapter {
            get { return Adapters[0]; }
        }		
		
		public static ReadOnlyCollection<GraphicsAdapter> Adapters {
            get {
                if (adapters == null)
                	adapters = new ReadOnlyCollection<GraphicsAdapter>(new GraphicsAdapter[] { new GraphicsAdapter () });
				
				
				
                return adapters;
            }
        } 
		
		public DisplayMode CurrentDisplayMode {
            get { return currentDisplayMode; }
        }        

        public string Description {
            get { throw new NotImplementedException(); }
        }

        public int DeviceId {
            get { throw new NotImplementedException(); }
        }

        public Guid DeviceIdentifier {
            get { throw new NotImplementedException(); }
        }

        public string DeviceName {
            get { throw new NotImplementedException(); }
        }

        public string DriverDll {
            get { throw new NotImplementedException(); }
        }

        public Version DriverVersion {
            get { throw new NotImplementedException(); }
        }

        public bool IsDefaultAdapter {
            get { throw new NotImplementedException(); }
        }

        public IntPtr MonitorHandle {
            get { throw new NotImplementedException(); }
        }

        public int Revision {
            get { throw new NotImplementedException(); }
        }

        public int SubSystemId {
            get { throw new NotImplementedException(); }
        }

        public DisplayModeCollection SupportedDisplayModes {
            get { throw new NotImplementedException(); }
        }

        public int VendorId {
            get { throw new NotImplementedException(); }
        }
		
		#endregion Properties
		
		#region Constructor / Destructor
		
		private GraphicsAdapter()
        {
			IntPtr infoPtr = Sdl.SDL_GetVideoInfo ();
			Sdl.SDL_VideoInfo info = (Sdl.SDL_VideoInfo) Marshal.PtrToStructure (infoPtr, typeof (Sdl.SDL_VideoInfo));
            currentDisplayMode = new DisplayMode(info.current_w, info.current_h, -1, SurfaceFormat.Bgr32);
			
			hardwareCapabilities = new GraphicsDeviceCapabilities();
			findGLCapabilities();
        }
		
        ~GraphicsAdapter ()
        {
            Dispose();
        }
		
		#endregion Properties
		
		#region Operators
		
		public static bool operator == (GraphicsAdapter left, GraphicsAdapter right)
		{
			return left.Equals (right);
		}
		
		public static bool operator != (GraphicsAdapter left, GraphicsAdapter right)
		{
			return !left.Equals (right);
		}
		
		#endregion Operators
        
		#region Methods
		
		public bool CheckDepthStencilMatch(DeviceType deviceType, SurfaceFormat adapterFormat, SurfaceFormat renderTargetFormat,
            DepthFormat depthStencilFormat)
        {
            throw new NotImplementedException();
        }

        public bool CheckDeviceFormat(DeviceType deviceType, SurfaceFormat adapterFormat, TextureUsage usage,
			QueryUsages queryUsages, ResourceType resourceType, DepthFormat checkFormat)
        {
            throw new NotImplementedException();
        }

        public bool CheckDeviceFormat(DeviceType deviceType, SurfaceFormat adapterFormat, TextureUsage usage,
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

        public GraphicsDeviceCapabilities GetCapabilities(DeviceType deviceType)
        {
            if (deviceType != DeviceType.Hardware)
				throw new DeviceNotSupportedException("Only hardware supported.");
			
			return hardwareCapabilities;
        }

        public bool IsDeviceTypeAvailable(DeviceType deviceType)
        {
            throw new NotImplementedException();
        }	
		
		private void findGLCapabilities()
		{
			Gl.glGetIntegerv(Gl.GL_MAX_COLOR_ATTACHMENTS_EXT, out hardwareCapabilities.maxSimultaneousRenderTargets);
		}
		
		#endregion Methods
		
		#region IDisposable Implementation
		
		public void Dispose()
        {
            GC.SuppressFinalize(this);
        }	
		
		#endregion IDisposable Implementation
		
		#region Object Overrides
		
		public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj is GraphicsAdapter)
            {
                return GetHashCode() == obj.GetHashCode();
            }

            return false;
        }
		
		public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
		
		#endregion Object Overrides
		
    }
}