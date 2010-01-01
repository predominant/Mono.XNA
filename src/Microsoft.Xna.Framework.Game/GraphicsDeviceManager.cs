#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.

Authors:
 * Stuart Carnie (stuart.carnie@gmail.com)
 * Lars Magnusson (lavima@gmail.com)

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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Drawing;
using Tao.Sdl;
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework
{
    public class GraphicsDeviceManager : IGraphicsDeviceService, IDisposable, IGraphicsDeviceManager
    {
        #region Public Static Fields

		public static readonly int DefaultBackBufferWidth = 800;
		public static readonly int DefaultBackBufferHeight = 600;
        
        public static readonly SurfaceFormat[] ValidAdapterFormats = new SurfaceFormat[] { SurfaceFormat.Bgr32, SurfaceFormat.Bgr555, SurfaceFormat.Bgr565, SurfaceFormat.Bgra1010102 };
        public static readonly SurfaceFormat[] ValidBackBufferFormats = new SurfaceFormat[] { SurfaceFormat.Bgr565, SurfaceFormat.Bgr555, SurfaceFormat.Bgra5551, SurfaceFormat.Bgr32, SurfaceFormat.Color, SurfaceFormat.Bgra1010102 };
        public static readonly DeviceType[] ValidDeviceTypes = new DeviceType[] { DeviceType.Hardware };

        #endregion Public Static Fields

        #region Private Fields

        private GraphicsDevice graphicsDevice;
        private bool _disposed;
        private ShaderProfile minimumPixelShaderProfile;
        private ShaderProfile minimumVertexShaderProfile;
        private bool preferMultiSampling;
        private SurfaceFormat preferredBackBufferFormat;
        private int preferredBackBufferHeight;
        private int preferredBackBufferWidth;
        private DepthFormat preferredDepthStencilFormat;
        private bool synchronizeWithVerticalRetrace;
        private Game game;
		private bool isFullScreen;
		
        #endregion Private Fields

        #region Public Properties

        public GraphicsDevice GraphicsDevice {
            get { return graphicsDevice; }
        }

        public bool IsFullScreen {
            get { return isFullScreen; }
            set { isFullScreen = value; }
        }

        public ShaderProfile MinimumPixelShaderProfile {
            get { return minimumPixelShaderProfile; }
            set { minimumPixelShaderProfile = value; }
        }

        public ShaderProfile MinimumVertexShaderProfile {
            get { return minimumVertexShaderProfile; }
            set { minimumVertexShaderProfile = value; }
        }

        public bool PreferMultiSampling {
            get { return preferMultiSampling; }
            set { preferMultiSampling = value; }
        }

        public SurfaceFormat PreferredBackBufferFormat {
            get { return preferredBackBufferFormat; }
            set { preferredBackBufferFormat = value; }
        }

        public int PreferredBackBufferHeight {
            get { return preferredBackBufferHeight; }
            set { preferredBackBufferHeight = value; }
        }

        public int PreferredBackBufferWidth {
            get { return preferredBackBufferWidth; }
            set { preferredBackBufferWidth = value; }
        }

        public DepthFormat PreferredDepthStencilFormat {
            get { return preferredDepthStencilFormat; }
            set { preferredDepthStencilFormat = value; }
        }

        public bool SynchronizeWithVerticalRetrace {
            get { return synchronizeWithVerticalRetrace; }
            set { synchronizeWithVerticalRetrace = value; }
        }

        #endregion

        #region Events

        public event EventHandler DeviceCreated;
        public event EventHandler DeviceDisposing;
        public event EventHandler DeviceReset;
        public event EventHandler DeviceResetting;
        public event EventHandler Disposed;
        public event EventHandler<PreparingDeviceSettingsEventArgs> PreparingDeviceSettings;

        #endregion Events

        #region Constructors

        public GraphicsDeviceManager(Game game)
        {
			this.game = game;
            game.Services.AddService(typeof(IGraphicsDeviceManager), this);
            game.Services.AddService(typeof(IGraphicsDeviceService), this);
			
			graphicsDevice = null;
			
			preferredBackBufferWidth = DefaultBackBufferWidth;
			preferredBackBufferHeight = DefaultBackBufferHeight;
			
			preferredBackBufferFormat = SurfaceFormat.Color;
			preferredDepthStencilFormat = DepthFormat.Depth24;
			
			isFullScreen = false;
			
			minimumPixelShaderProfile = ShaderProfile.PS_1_1;
			minimumVertexShaderProfile = ShaderProfile.VS_1_1;
			
			preferMultiSampling = false;			
			
			synchronizeWithVerticalRetrace = true;
        }

        #endregion

        #region Public Methods

        public void ApplyChanges()
        {
            throw new NotImplementedException();
        }

        public void ToggleFullScreen()
        {
            isFullScreen = !isFullScreen;
			GraphicsDevice.PresentationParameters.IsFullScreen = isFullScreen;
			game.Window.BeginScreenDeviceChange(isFullScreen);
			game.Window.EndScreenDeviceChange(string.Empty, preferredBackBufferWidth, preferredBackBufferHeight); 
			GraphicsDevice.Reset();
        }
		
		#endregion Public Methods        

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
			List<GraphicsDeviceInformation> graphicDeviceInfoList = new List<GraphicsDeviceInformation>();
			
			int flags = Sdl.SDL_OPENGL;
			if (IsFullScreen)
				flags |= Sdl.SDL_FULLSCREEN;

#warning Finding available display modes along with their formats isn't supported by the current release of Tao.Sdl.
#warning The current pixel format is used for querying available modes
			Sdl.SDL_Rect[] modes = Sdl.SDL_ListModes(IntPtr.Zero, flags);
			if (modes.Length > 0)
			{	            
	            foreach (Sdl.SDL_Rect mode in modes)
	            {
	                if (mode.w == PreferredBackBufferWidth &&
	                    mode.h == PreferredBackBufferHeight)
	                    continue;
	
					GraphicsDeviceInformation info = new GraphicsDeviceInformation();
					info.Adapter = GraphicsAdapter.DefaultAdapter;
					info.DeviceType = DeviceType.Hardware;
					info.PresentationParameters.BackBufferWidth = PreferredBackBufferWidth;
					info.PresentationParameters.BackBufferHeight = PreferredBackBufferHeight;
					info.PresentationParameters.BackBufferFormat = PreferredBackBufferFormat;
					info.PresentationParameters.IsFullScreen = IsFullScreen;
	                graphicDeviceInfoList.Add(info);
				}
			}
			else 
			{
				GraphicsDeviceInformation info = new GraphicsDeviceInformation();
				info.Adapter = GraphicsAdapter.DefaultAdapter;
				info.DeviceType = DeviceType.Hardware;
				info.PresentationParameters.BackBufferWidth = PreferredBackBufferWidth;
				info.PresentationParameters.BackBufferHeight = PreferredBackBufferHeight;
				info.PresentationParameters.BackBufferFormat = PreferredBackBufferFormat;
				info.PresentationParameters.IsFullScreen = IsFullScreen;
	            graphicDeviceInfoList.Add(info);
			}
			
            RankDevices(graphicDeviceInfoList);

            if (graphicDeviceInfoList.Count == 0)
                throw new NoSuitableGraphicsDeviceException("The process of ranking devices removed all compatible devices.");  // LOCALIZE

			
			return graphicDeviceInfoList[0];
        }
		
		protected virtual void RankDevices(List<GraphicsDeviceInformation> foundDevices)
        {
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

        #endregion
		
		#region IGraphicsDeviceManager Explicit Implementation

        bool IGraphicsDeviceManager.BeginDraw()
        {
            return true;
        }

        void IGraphicsDeviceManager.CreateDevice()
        {
			GraphicsDeviceInformation info = FindBestDevice(true);
			OnPreparingDeviceSettings(this, new PreparingDeviceSettingsEventArgs(info));
			
			graphicsDevice = new GraphicsDevice(info.Adapter, info.DeviceType, game.Window.Handle, info.PresentationParameters);
			graphicsDevice.Disposing += new EventHandler(OnDeviceDisposing);
            graphicsDevice.DeviceResetting += new EventHandler(OnDeviceResetting);
            graphicsDevice.DeviceReset += new EventHandler(OnDeviceReset);
            
            OnDeviceCreated(this, EventArgs.Empty);
		}

        void IGraphicsDeviceManager.EndDraw()
        {
            graphicsDevice.Present();
        }

        #endregion IGraphicsDeviceManager Explicit Implementation

		#region IDisposable Explicit Implementation
		
		void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
		
		#endregion
    }
}
