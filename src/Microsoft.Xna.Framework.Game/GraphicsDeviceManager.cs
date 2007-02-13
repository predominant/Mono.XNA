#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team
http://www.taoframework.com
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

using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Microsoft.Xna.Framework
{
    public class GraphicsDeviceManager : IGraphicsDeviceService, IDisposable, IGraphicsDeviceManager
    {
        #region Events

        public event EventHandler DeviceCreated;
        public event EventHandler DeviceDisposing;
        public event EventHandler DeviceReset;
        public event EventHandler DeviceResetting;
        public event EventHandler Disposed;
        public event EventHandler<PreparingDeviceSettingsEventArgs> PreparingDeviceSettings;

        #endregion

        #region Public Static Fields

        public static readonly int DefaultBackBufferHeight = 0;
        public static readonly int DefaultBackBufferWidth = 0;
        public static readonly SurfaceFormat[] ValidAdapterFormats = new SurfaceFormat[] { SurfaceFormat.Bgr32, SurfaceFormat.Bgr555, SurfaceFormat.Bgr565, SurfaceFormat.Bgra1010102 };
        public static readonly SurfaceFormat[] ValidBackBufferFormats = new SurfaceFormat[] { SurfaceFormat.Bgr565, SurfaceFormat.Bgr555, SurfaceFormat.Bgra5551, SurfaceFormat.Bgr32, SurfaceFormat.Color, SurfaceFormat.Bgra1010102 };
        public static readonly DeviceType[] ValidDeviceTypes = new DeviceType[] { DeviceType.Hardware };

        #endregion Public Static Fields

        #region Public Properties

        public GraphicsDevice GraphicsDevice
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsFullScreen
        {
            get { throw new NotImplementedException(); }
           set { throw new NotImplementedException(); }
        }

        public ShaderProfile MinimumPixelShaderProfile
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public ShaderProfile MinimumVertexShaderProfile
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool PreferMultiSampling
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public SurfaceFormat PreferredBackBufferFormat
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public int PreferredBackBufferHeight
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public int PreferredBackBufferWidth
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public DepthFormat PreferredDepthStencilFormat
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool SynchronizeWithVerticalRetrace
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        #endregion

        #region Constructors

        public GraphicsDeviceManager(Game game)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Public Methods

        public void ApplyChanges()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool BeginDraw()
        {
            throw new NotImplementedException();
        }

        public void CreateDevice()
        {
            throw new NotImplementedException();
        }

        public void EndDraw()
        {
            throw new NotImplementedException();
        }

        public void ToggleFullScreen()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Protected Methods

        protected virtual bool CanResetDevice(GraphicsDeviceInformation newDeviceInfo)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            throw new NotImplementedException();
        }

        protected virtual GraphicsDeviceInformation FindBestDevice(bool anySuitableDevice)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnDeviceCreated(object sender, EventArgs args)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnDeviceDisposing(object sender, EventArgs args)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnDeviceReset(object sender, EventArgs args)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnDeviceResetting(object sender, EventArgs args)
        {
            throw new NotImplementedException();
        }

        protected virtual void OnPreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs args)
        {
            throw new NotImplementedException();
        }

        protected virtual void RankDevices(List<GraphicsDeviceInformation> foundDevices)
        {
            throw new NotImplementedException();
        }

        #endregion

        
    }
}