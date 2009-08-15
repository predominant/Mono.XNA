#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.

Authors:
 * Stuart Carnie (stuart.carnie@gmail.com)

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

using System.Drawing;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Threading;
using SdlDotNet.Graphics;

namespace Microsoft.Xna.Framework
{
    public class GraphicsDeviceManager : IGraphicsDeviceService, IDisposable, IGraphicsDeviceManager
    {
        #region Public Static Fields

        public static readonly int DefaultBackBufferHeight = 600;
        public static readonly int DefaultBackBufferWidth = 800;
        public static readonly SurfaceFormat[] ValidAdapterFormats = new SurfaceFormat[] { SurfaceFormat.Bgr32, SurfaceFormat.Bgr555, SurfaceFormat.Bgr565, SurfaceFormat.Bgra1010102 };
        public static readonly SurfaceFormat[] ValidBackBufferFormats = new SurfaceFormat[] { SurfaceFormat.Bgr565, SurfaceFormat.Bgr555, SurfaceFormat.Bgra5551, SurfaceFormat.Bgr32, SurfaceFormat.Color, SurfaceFormat.Bgra1010102 };
        public static readonly DeviceType[] ValidDeviceTypes = new DeviceType[] { DeviceType.Hardware };

        #endregion Public Static Fields

        #region Private Fields

        List<GraphicsDeviceInformation> _graphicDeviceInfoList;
        GraphicsDeviceInformation _defaultDeviceInformation;
        GraphicsDevice _graphicsDevice;
        bool _disposed;
        ShaderProfile _minimumShaderProfile;
        ShaderProfile _minimumVertexShaderProfile;
        bool _preferMultiSampling;
        SurfaceFormat _preferredBackBufferFormat;
        int _preferredBackBufferHeight;
        int _preferredBackBufferWidth;
        DepthFormat _preferredDepthStencilFormat;
        bool _synchronizeWithVerticalRetrace;
        Game _game;

        #endregion Private Fields

        #region Events

        public event EventHandler DeviceCreated;
        public event EventHandler DeviceDisposing;
        public event EventHandler DeviceReset;
        public event EventHandler DeviceResetting;
        public event EventHandler Disposed;
        public event EventHandler<PreparingDeviceSettingsEventArgs> PreparingDeviceSettings;

        #endregion Events

        #region Public Properties

        public GraphicsDevice GraphicsDevice {
            get { return _graphicsDevice; }
        }

        public bool IsFullScreen {
            get { return Video.Screen.FullScreen; }
            set {
                if (Video.Screen.FullScreen != value)
                    throw new NotImplementedException("IsFullScreen");
            }
        }

        public ShaderProfile MinimumPixelShaderProfile {
            get { return _minimumShaderProfile; }
            set { _minimumShaderProfile = value; }
        }

        public ShaderProfile MinimumVertexShaderProfile {
            get { return _minimumVertexShaderProfile; }
            set { _minimumVertexShaderProfile = value; }
        }

        public bool PreferMultiSampling {
            get { return _preferMultiSampling; }
            set { _preferMultiSampling = value; }
        }

        public SurfaceFormat PreferredBackBufferFormat {
            get { return _preferredBackBufferFormat; }
            set { _preferredBackBufferFormat = value; }
        }

        public int PreferredBackBufferHeight {
            get { return _preferredBackBufferHeight; }
            set { _preferredBackBufferHeight = value; }
        }

        public int PreferredBackBufferWidth {
            get { return _preferredBackBufferWidth; }
            set { _preferredBackBufferWidth = value; }
        }

        public DepthFormat PreferredDepthStencilFormat {
            get { return _preferredDepthStencilFormat; }
            set { _preferredDepthStencilFormat = value; }
        }

        public bool SynchronizeWithVerticalRetrace {
            get { return _synchronizeWithVerticalRetrace; }
            set { _synchronizeWithVerticalRetrace = value; }
        }

        #endregion

        #region Constructors

        public GraphicsDeviceManager(Game game)
        {
            _game = game;
            // as per test application on reference framework
            _game.Services.AddService(typeof(IGraphicsDeviceManager), this);
            _game.Services.AddService(typeof(IGraphicsDeviceService), this);
        }

        #endregion

        #region Public Methods

        public void ApplyChanges()
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #region IGraphicsDeviceManager Methods

        bool IGraphicsDeviceManager.BeginDraw()
        {
            return _game.IsActive;
        }

        void IGraphicsDeviceManager.CreateDevice()
        {
            GraphicsDeviceInformation info = FindBestDevice(true);
            OnPreparingDeviceSettings(this, new PreparingDeviceSettingsEventArgs(info));
            info.PresentationParameters.BackBufferWidth = PreferredBackBufferWidth;
            info.PresentationParameters.BackBufferHeight = PreferredBackBufferHeight;
            info.PresentationParameters.AutoDepthStencilFormat = PreferredDepthStencilFormat;
            info.PresentationParameters.BackBufferFormat = PreferredBackBufferFormat;

			_graphicsDevice = new GraphicsDevice(info.Adapter, info.DeviceType, Video.WindowHandle, info.CreationOptions, info.PresentationParameters);
			_graphicsDevice.Disposing += new EventHandler(_graphicsDevice_Disposing);
            _graphicsDevice.DeviceResetting += new EventHandler(_graphicsDevice_DeviceResetting);
            _graphicsDevice.DeviceReset += new EventHandler(_graphicsDevice_DeviceReset);
            
            OnDeviceCreated(this, EventArgs.Empty);
        }

        void IGraphicsDeviceManager.EndDraw()
        {
            _graphicsDevice.Present();
        }

        #endregion IGraphicsDeviceManager Methods

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
            if (!_disposed)
            {
                _disposed = true;

                if (disposing && Disposed != null)
                {
                    Disposed(this, EventArgs.Empty);
                }
            }
        }

        protected virtual GraphicsDeviceInformation FindBestDevice(bool anySuitableDevice)
        {
            if (_defaultDeviceInformation == null)
            {
                _defaultDeviceInformation = new GraphicsDeviceInformation();
                Size[] modes = Video.ListModes();

                _graphicDeviceInfoList = new List<GraphicsDeviceInformation>();
                _graphicDeviceInfoList.Add(_defaultDeviceInformation);
                foreach (Size mode in modes)
                {
                    if (mode.Width == _defaultDeviceInformation.PresentationParameters.BackBufferWidth &&
                        mode.Height == _defaultDeviceInformation.PresentationParameters.BackBufferHeight)
                        continue;

                    _graphicDeviceInfoList.Add(new GraphicsDeviceInformation(mode.Width, mode.Height));
                }
            }

            List<GraphicsDeviceInformation> di = new List<GraphicsDeviceInformation>(_graphicDeviceInfoList);
            RankDevices(di);

            if (di.Count == 0)
                throw new NoSuitableGraphicsDeviceException("The process of ranking devices removed all compatible devices.");  // LOCALIZE

            return di[0];
        }

        protected virtual void OnDeviceCreated(object sender, EventArgs args)
        {
            if (DeviceCreated != null)
                DeviceCreated(this, args);
        }

        protected virtual void OnDeviceDisposing(object sender, EventArgs args)
        {
            if (DeviceDisposing != null)
                DeviceDisposing(this, args);
        }

        protected virtual void OnDeviceReset(object sender, EventArgs args)
        {
            if (DeviceReset != null)
                DeviceReset(this, args);
        }

        protected virtual void OnDeviceResetting(object sender, EventArgs args)
        {
            if (DeviceResetting != null)
                DeviceResetting(this, args);
        }

        protected virtual void OnPreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs args)
        {
            if (PreparingDeviceSettings != null)
                PreparingDeviceSettings(this, args);
        }

        protected virtual void RankDevices(List<GraphicsDeviceInformation> foundDevices)
        {
        }

        #endregion

        #region Private Members

        void _graphicsDevice_Disposing(object sender, EventArgs e)
        {
            OnDeviceDisposing(sender, e);
        }

        void _graphicsDevice_DeviceReset(object sender, EventArgs e)
        {
            OnDeviceReset(sender, e);
        }

        void _graphicsDevice_DeviceResetting(object sender, EventArgs e)
        {
            OnDeviceResetting(sender, e);
        }

        #endregion Private Members
    }
}
