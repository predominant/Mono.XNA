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
using System.Threading;
using System.Collections.Generic;
using Tao.Sdl;
using Tao.OpenGl;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Microsoft.Xna.Framework
{
    public class Game : IDisposable
    {
        #region Private Fields
		
		private const long DefaultTargetElapsedTicks = 10000000L / 60L;
		
		private bool inRun;
        private bool isFixedTimeStep;
		private bool isMouseVisible;
		private bool isActive;
        
        GameComponentCollection components;
        List<IDrawable> visibleDrawable;
        List<IUpdateable> enabledUpdateable;

        GameServiceContainer services;
        bool disposed;

        GameTime gameUpdateTime;
        TimeSpan inactiveSleepTime;
        TimeSpan targetElapsedTime;
        
        Content.ContentManager content;
        
		IGraphicsDeviceManager graphicsManager;
        IGraphicsDeviceService graphicsService;
		
		IGameHost gameHost;        

        #endregion Private Fields

		#region Public Properties

        public GameComponentCollection Components {
            get { return components; }
        }

        public TimeSpan InactiveSleepTime {
            get { return inactiveSleepTime; }
            set { inactiveSleepTime = value; }
        }

        public bool IsActive {
            get { return isActive; }
        }

        public bool IsFixedTimeStep {
            get { return isFixedTimeStep; }
            set { isFixedTimeStep = value; }
        }

        public bool IsMouseVisible {
            get { return isMouseVisible; }
            set {
				if (isMouseVisible == value)
					return;
				isMouseVisible = value;
				Sdl.SDL_ShowCursor(isMouseVisible ? Sdl.SDL_ENABLE : Sdl.SDL_DISABLE); 
			}
        }

        public GameServiceContainer Services {
            get { return services; }
        }

        public TimeSpan TargetElapsedTime {
            get { return targetElapsedTime; }
            set { targetElapsedTime = value; }
        }

		public ContentManager Content {
            get { return this.content; }
            set { this.content = value; }
        }

		public GraphicsDevice GraphicsDevice {
            get {
                if (graphicsService == null)
                {
                    graphicsService = this.Services.GetService(typeof(IGraphicsDeviceService)) as IGraphicsDeviceService;
                    if (graphicsService == null)
                    	throw new InvalidOperationException();
                }
                return graphicsService.GraphicsDevice;
            }
        }

        public GameWindow Window {
            get { return (gameHost != null) ? gameHost.Window : null; }
        }

        #endregion Public Properties

        #region Constructors

        public Game()
        {
			inRun = false;
			
            isFixedTimeStep = true;
            
			visibleDrawable = new List<IDrawable>();
            enabledUpdateable = new List<IUpdateable>();

            components = new GameComponentCollection();
            components.ComponentAdded += new EventHandler<GameComponentCollectionEventArgs>(GameComponentAdded);
            components.ComponentRemoved += new EventHandler<GameComponentCollectionEventArgs>(GameComponentRemoved);

            services = new GameServiceContainer();

            content = new ContentManager(services);
			
            gameUpdateTime = new GameTime(TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero);

            inactiveSleepTime = TimeSpan.FromTicks(0);
			targetElapsedTime = TimeSpan.FromTicks(DefaultTargetElapsedTicks);

			gameHost = new SdlGameHost(this);
			gameHost.EnsureHost();
			
            isActive = true;
        }
		
		#endregion Constructors
		
        #region Destructor

        ~Game()
        {
            Dispose(false);
        }

        #endregion Destructor        

        #region Public Methods

        public void SuppressDraw()
        {
            throw new NotImplementedException();
        }

        public void ResetElapsedTime()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Exit()
        {
			gameHost.Exit();
        }

        public void Run()
        {
			if(inRun)
				throw new InvalidOperationException("Run Method called more than once");
			inRun = true;
			BeginRun();
			
			gameHost.Initialize();
			
			graphicsManager = (IGraphicsDeviceManager)Services.GetService(typeof (IGraphicsDeviceManager));
            if (graphicsManager != null)
                graphicsManager.CreateDevice();			

			graphicsService = (IGraphicsDeviceService)Services.GetService(typeof (IGraphicsDeviceService));
            if (graphicsService != null)
            {
                /*graphicsService.DeviceCreated += DeviceCreated;
                graphicsService.DeviceResetting += DeviceResetting;
                graphicsService.DeviceReset += DeviceReset;
                graphicsService.DeviceDisposing += DeviceDisposing;*/
            }   			
			
			Initialize();
			            
			isActive = true;           
			
			gameHost.Run();
            
			EndRun();			
			inRun = false;
        }

        public void Tick()
        {
			TimeSpan elapsedUpdateTime = TimeSpan.FromMilliseconds(Sdl.SDL_GetTicks() - gameUpdateTime.TotalRealTime.TotalMilliseconds);
			if (isFixedTimeStep)
			{
				while (elapsedUpdateTime < TargetElapsedTime)
				{
#warning To low resolution with ms (10^-3)
					Thread.Sleep(TargetElapsedTime.Milliseconds - elapsedUpdateTime.Milliseconds); 
					elapsedUpdateTime = TimeSpan.FromMilliseconds(Sdl.SDL_GetTicks() - gameUpdateTime.TotalRealTime.TotalMilliseconds);
				}
				
				gameUpdateTime.ElapsedGameTime = TargetElapsedTime;
				gameUpdateTime.TotalGameTime = gameUpdateTime.TotalGameTime.Add(TargetElapsedTime);
			}
			else
			{
				gameUpdateTime.ElapsedGameTime = elapsedUpdateTime;
				gameUpdateTime.TotalGameTime = gameUpdateTime.TotalGameTime.Add(elapsedUpdateTime);
			}
			
			gameUpdateTime.ElapsedRealTime = elapsedUpdateTime;
			gameUpdateTime.TotalRealTime = gameUpdateTime.TotalRealTime.Add(elapsedUpdateTime);
			
			Update(gameUpdateTime);
			
			elapsedUpdateTime = TimeSpan.FromMilliseconds(Sdl.SDL_GetTicks() - gameUpdateTime.TotalRealTime.TotalMilliseconds);
			if (isFixedTimeStep && elapsedUpdateTime > TargetElapsedTime)
				gameUpdateTime.IsRunningSlowly = true;
			else
				gameUpdateTime.IsRunningSlowly = false;
			
			if (!BeginDraw())
				return;
            
			Draw(gameUpdateTime);
            EndDraw();
        }

        #endregion Public methods

        #region Protected Methods

        protected virtual bool ShowMissingRequirementMessage(Exception exception)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
				return;
            
			// Dispose managed
			if (disposing)
			{
                foreach (IGameComponent component in components)
                {
                    IDisposable disposable = component as IDisposable;
                    if (disposable != null)
                        disposable.Dispose();
                }
			}
				
			// Dispose unmanaged
			Sdl.SDL_Quit();				

            disposed = true;
            if (Disposed != null)
                Disposed(this, EventArgs.Empty);        
        }

		protected virtual void BeginRun()
        {
        }

        protected virtual bool BeginDraw()
        {
			if (isFixedTimeStep && gameUpdateTime.IsRunningSlowly)
				return false;
			return graphicsManager.BeginDraw();
        }

        protected virtual void EndDraw()
        {
            graphicsManager.EndDraw();
        }

        protected virtual void Draw(GameTime gameTime)
        {
            foreach (IDrawable drawable in visibleDrawable)
            {
                drawable.Draw(gameTime);
            }
        }
		
		protected virtual void EndRun()
        {
        }

        protected virtual void Initialize()
        {
            this.graphicsService = this.Services.GetService(typeof(IGraphicsDeviceService)) as IGraphicsDeviceService;

            foreach (IGameComponent component in components)
            {
                component.Initialize();
            }

           	LoadContent();
        }

        protected virtual void LoadContent()
        {
        }

#if XNA_1_1
#else
        [System.Obsolete("The LoadGraphicsContent method is obsolete and will be removed in the future. Use the LoadContent method instead.")]
#endif
        protected virtual void LoadGraphicsContent(bool loadAllContent)
        {
            //throw new NotImplementedException();
            // We don't have anything to be done here FIXME
        }

        protected virtual void OnActivated(object sender, EventArgs args)
        {
            if (Activated != null)
                Activated(sender, args);
        }

        protected virtual void OnDeactivated(object sender, EventArgs args)
        {
            if (Deactivated != null)
                Deactivated(sender, args);
        }

        protected virtual void OnExiting(object sender, EventArgs args)
        {
            if (Exiting != null)
                Exiting(sender, args);
        }

#if XNA_1_1
        internal
#else
        protected
#endif
        virtual void UnloadContent()
        {
        }

#if XNA_1_1
#else
        [Obsolete("The UnloadGraphicsContent method is obsolete and will be removed in the future.  Use the UnloadContent method instead.")]
#endif
        protected virtual void UnloadGraphicsContent(bool unloadAllContent)
        {
        }

        protected virtual void Update(GameTime gameTime)
        {
            foreach (IUpdateable updateable in enabledUpdateable)
            {
                updateable.Update(gameTime);
            }
        }

        #endregion Protected Methods

        #region Private Methods
		
		void WindowExiting(object sender, EventArgs e)
        {
            OnExiting(sender, e);
        }

        void WindowDeactivated(object sender, EventArgs e)
        {
            isActive = false;
            OnDeactivated(sender, e);
        }

        void WindowActivated(object sender, EventArgs e)
        {
            isActive = true;
            OnActivated(sender, e);
        }
		
		void DeviceCreated(object sender, EventArgs e)
        {
            LoadContent();
        }

        void DeviceDisposing(object sender, EventArgs e)
        {
            UnloadGraphicsContent(true);
        }

        void DeviceReset(object sender, EventArgs e)
        {
            LoadGraphicsContent(false);
        }

        void DeviceResetting(object sender, EventArgs e)
        {
            UnloadGraphicsContent(false);
        }

        #region Game Component Collection Methods

        void GameComponentAdded(object sender, GameComponentCollectionEventArgs e)
        {
            IDrawable d = e.GameComponent as IDrawable;
            if (d != null)
            {
                d.DrawOrderChanged += DrawableDrawOrderChanged;
                d.VisibleChanged += DrawableVisibleChanged;

                if (d.Visible)
                    AddDrawable(d);
            }

            IUpdateable u = e.GameComponent as IUpdateable;
            if (u != null)
            {
                u.UpdateOrderChanged += UpdatableUpdateOrderChanged;
                u.EnabledChanged += UpdatableEnabledChanged;

                if (u.Enabled)
                    AddUpdatable(u);
            }
        }

        void GameComponentRemoved(object sender, GameComponentCollectionEventArgs e)
        {
            IDrawable d = e.GameComponent as IDrawable;
            if (d != null)
            {
                d.DrawOrderChanged -= DrawableDrawOrderChanged;
                d.VisibleChanged -= DrawableVisibleChanged;

                if (d.Visible)
                    visibleDrawable.Remove(d);
            }

            IUpdateable u = e.GameComponent as IUpdateable;
            if (u != null)
            {
                u.UpdateOrderChanged -= UpdatableUpdateOrderChanged;
                u.EnabledChanged -= UpdatableEnabledChanged;

                if (u.Enabled)
                    enabledUpdateable.Remove(u);
            }
        }

        #region Updatable Methods

        void AddUpdatable(IUpdateable u)
        {
            enabledUpdateable.Add(u);
            enabledUpdateable.Sort(UpdatableComparison);
        }

        void UpdatableEnabledChanged(object sender, EventArgs e)
        {
            IUpdateable u = (IUpdateable)sender;
            if (u.Enabled)
                AddUpdatable(u);
            else
                enabledUpdateable.Remove(u);
        }

        void UpdatableUpdateOrderChanged(object sender, EventArgs e)
        {
            enabledUpdateable.Sort(UpdatableComparison);
        }

        static int UpdatableComparison(IUpdateable x, IUpdateable y)
        {
            return x.UpdateOrder.CompareTo(y.UpdateOrder);
        }

        #endregion Updatable Methods

        #region Drawable Methods

        void AddDrawable(IDrawable d)
        {
            visibleDrawable.Add(d);
            visibleDrawable.Sort(DrawableComparison);
        }

        void DrawableVisibleChanged(object sender, EventArgs e)
        {
            IDrawable d = (IDrawable)sender;
            if (d.Visible)
                AddDrawable(d);
            else
                visibleDrawable.Remove(d);
        }

        void DrawableDrawOrderChanged(object sender, EventArgs e)
        {
            visibleDrawable.Sort(DrawableComparison);
        }

        static int DrawableComparison(IDrawable x, IDrawable y)
        {
            return x.DrawOrder - y.DrawOrder;
        }

        #endregion Drawable Methods 

        #endregion Game Component Collection Methods

        #endregion Private Methods

        #region Public Events

        public event EventHandler Activated;
        public event EventHandler Deactivated;
        public event EventHandler Disposed;
        public event EventHandler Exiting;

        #endregion Public Events
		
    }
}
