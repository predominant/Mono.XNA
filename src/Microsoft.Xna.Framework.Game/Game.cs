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
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

#if NUNITTESTS
using Microsoft.Xna.Framework.Test;
#endif

namespace Microsoft.Xna.Framework
{
    public class Game : IDisposable
    {
        internal const double DEFAULT_TARGET_ELAPSED_TIME = 1000/60;  // 60 fps
        internal const double DEFAULT_INACTIVE_SLEEP_TIME = 20;       // 20 milliseconds

        #region Private Fields
		
		private bool exit;
		private bool runMethodCalled;

        bool _isFixedTimeStep;

        GameComponentCollection _components;
        List<IDrawable> _visibleDrawable;
        List<IUpdateable> _enabledUpdateable;

        GameServiceContainer _services;
        bool _disposed;

        #region Timing

        GameTime _gameTime;
        TimeSpan _inactiveSleepTime;
        TimeSpan _targetElapsedTime;
        
        #endregion Timing

        IGraphicsDeviceService _graphicsDeviceService;
        Content.ContentManager _content;
        GameWindow _window;
        IGraphicsDeviceManager _graphicsManager;
        IGraphicsDeviceService _graphicsService;
        bool _isActive;
        bool _isExiting;

        #endregion Private Fields

#if NUNITTESTS
        #region Unit Test Support

        EventSource _eventSource;

        #endregion Unit Test Support
#endif
		
		#region Public Properties

        public GameComponentCollection Components {
            get { return _components; }
        }

        public TimeSpan InactiveSleepTime {
            get { return _inactiveSleepTime; }
            set { _inactiveSleepTime = value; }
        }

        public bool IsActive {
            get { return _isActive; }
        }

        public bool IsFixedTimeStep {
            get { return _isFixedTimeStep; }
            set { _isFixedTimeStep = value; }
        }

        public bool IsMouseVisible {
            get { return SdlDotNet.Input.Mouse.ShowCursor; }
            set { SdlDotNet.Input.Mouse.ShowCursor = value; }
        }

        public GameServiceContainer Services {
            get { return _services; }
        }

        public TimeSpan TargetElapsedTime {
            get { return _targetElapsedTime; }
            set { _targetElapsedTime = value; }
        }

#if XNA_1_1
        internal
#else
        public
#endif
        ContentManager Content {
            get { return this._content; }

#if XNA_3_0
            set { this._content = value; }
#endif
        }

#if XNA_1_1
        internal
#else
        public
#endif
        GraphicsDevice GraphicsDevice {
            get {
                IGraphicsDeviceService graphicsDeviceService = this._graphicsDeviceService;
                if (graphicsDeviceService == null)
                {
                    graphicsDeviceService = this.Services.GetService(typeof(IGraphicsDeviceService)) as IGraphicsDeviceService;
                    if (graphicsDeviceService == null)
                    {
                        throw new InvalidOperationException();
                    }
                }
                return graphicsDeviceService.GraphicsDevice;
            }
        }


        public GameWindow Window
        {
            get { return _window; }
#if NUNITTESTS
            set { SetWindow((ExtendedGameWindow)value); }
#endif
        }

        #endregion Public Properties

        #region Constructors

        public Game()
        {
			exit = false;
			runMethodCalled = false;
			
            _isFixedTimeStep = true;
            _isActive = false;
            
			_visibleDrawable = new List<IDrawable>();
            _enabledUpdateable = new List<IUpdateable>();

            _components = new GameComponentCollection();
            _components.ComponentAdded += new EventHandler<GameComponentCollectionEventArgs>(GameComponentAdded);
            _components.ComponentRemoved += new EventHandler<GameComponentCollectionEventArgs>(GameComponentRemoved);

            _services = new GameServiceContainer();

            _content = new ContentManager(_services);

             _gameTime = new GameTime(TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero);

            _inactiveSleepTime = TimeSpan.FromMilliseconds(DEFAULT_INACTIVE_SLEEP_TIME);
            _targetElapsedTime = TimeSpan.FromMilliseconds(DEFAULT_TARGET_ELAPSED_TIME);

            SetWindow(new SdlGameWindow());
			_isActive = true;
        }
		
		

#if NUNITTESTS
        /// <summary>
        /// This protected constructor is reserved for unit-testing, by allowing an alternative game clock to be provided.
        /// It should not be used
        /// </summary>
        protected Game(IGameClock gameClock, EventSource eventSource)
			: this ()
        {
            if (eventSource != null)
            {
                _eventSource = eventSource;
                _eventSource.Game = this;
            }
        }
#endif
		
		#endregion Constructors
		
        #region Destructor

        ~Game()
        {
            Dispose(false);
        }

        #endregion Destructor

        

        #region Public Methods

#if XNA_3_0
        public void SuppressDraw()
        {
            throw new NotImplementedException();
        }
#endif

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
            exit = true;
        }

        public void Run()
        {
			if(runMethodCalled)
				throw new InvalidOperationException("Run Method called more than once");
			runMethodCalled = true;
			
            _graphicsManager = (IGraphicsDeviceManager)Services.GetService(typeof (IGraphicsDeviceManager));
            if (_graphicsManager == null)
                _graphicsManager.CreateDevice();

            _graphicsService = (IGraphicsDeviceService)Services.GetService(typeof (IGraphicsDeviceService));
            if (_graphicsService != null)
            {
                _graphicsService.DeviceCreated += DeviceCreated;
                _graphicsService.DeviceResetting += DeviceResetting;
                _graphicsService.DeviceReset += DeviceReset;
                _graphicsService.DeviceDisposing += DeviceDisposing;
            }

            Initialize();
            
            _isActive = true;
			Sdl.SDL_Init (Sdl.SDL_INIT_TIMER);
            
			BeginRun();
			while (!exit)
				Tick ();
            EndRun();
        }

        public void Tick()
        {
			TimeSpan updateTime = TimeSpan.FromTicks( Sdl.SDL_GetTicks() - _gameTime.TotalRealTime.Milliseconds);
            if (_isFixedTimeStep)
			{
				while (updateTime < TargetElapsedTime)
					updateTime = TimeSpan.FromTicks( Sdl.SDL_GetTicks() - _gameTime.TotalRealTime.Milliseconds);				
				
				_gameTime.ElapsedGameTime = TargetElapsedTime;
				_gameTime.TotalGameTime += TargetElapsedTime;
			}
			else
			{
				_gameTime.ElapsedGameTime = updateTime;
				_gameTime.TotalGameTime += updateTime;
			}
			
			_gameTime.ElapsedRealTime += updateTime;
			_gameTime.TotalRealTime += updateTime;
			
			Update(_gameTime);
			Draw(_gameTime);
        }

        #endregion Public methods

        #region Protected Methods

#if XNA_3_0
        protected virtual bool ShowMissingRequirementMessage(Exception exception)
        {
            throw new NotImplementedException();
        }
#endif

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                foreach (IGameComponent component in _components)
                {
                    IDisposable disposable = component as IDisposable;
                    if (disposable != null)
                        disposable.Dispose();
                }

                _disposed = true;
                if (Disposed != null)
                    Disposed(this, EventArgs.Empty);
            }
        }

        protected virtual bool BeginDraw()
        {
            return _graphicsManager.BeginDraw();
        }

        protected virtual void BeginRun()
        {
        }

        protected virtual void Draw(GameTime gameTime)
        {
            foreach (IDrawable drawable in _visibleDrawable)
            {
                drawable.Draw(gameTime);
            }
        }

        protected virtual void EndDraw()
        {
            _graphicsManager.EndDraw();
        }

        protected virtual void EndRun()
        {
        }

        protected virtual void Initialize()
        {
            this._graphicsDeviceService = this.Services.GetService(typeof(IGraphicsDeviceService)) as IGraphicsDeviceService;

            foreach (IGameComponent component in _components)
            {
                component.Initialize();
            }

           	LoadContent();
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

#if XNA_1_1
        internal
#else
        protected
#endif
        virtual void LoadContent()
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
            foreach (IUpdateable updateable in _enabledUpdateable)
            {
                updateable.Update(gameTime);
            }
        }

        #endregion Protected Methods

        #region Private Methods
		
		private void SetWindow(GameWindow window)
        {
            _window = window;
            if (_window != null)
            {
                //_window.Exiting += new EventHandler(WindowExiting);
                //_window.Activated += new EventHandler(WindowActivated);
                //_window.Deactivated += new EventHandler(WindowDeactivated);
            }
        }        

        void DrawFrame()
        {
            if (BeginDraw())
            {
                Draw(_gameTime);
                EndDraw();
            }
        }

        void WindowExiting(object sender, EventArgs e)
        {
            OnExiting(sender, e);
        }

        void WindowDeactivated(object sender, EventArgs e)
        {
            _isActive = false;
            OnDeactivated(sender, e);
        }

        void WindowActivated(object sender, EventArgs e)
        {
            _isActive = true;
            OnActivated(sender, e);
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
                    _visibleDrawable.Remove(d);
            }

            IUpdateable u = e.GameComponent as IUpdateable;
            if (u != null)
            {
                u.UpdateOrderChanged -= UpdatableUpdateOrderChanged;
                u.EnabledChanged -= UpdatableEnabledChanged;

                if (u.Enabled)
                    _enabledUpdateable.Remove(u);
            }
        }

        #region Updatable Methods

        void AddUpdatable(IUpdateable u)
        {
            _enabledUpdateable.Add(u);
            _enabledUpdateable.Sort(UpdatableComparison);
        }

        void UpdatableEnabledChanged(object sender, EventArgs e)
        {
            IUpdateable u = (IUpdateable)sender;
            if (u.Enabled)
                AddUpdatable(u);
            else
                _enabledUpdateable.Remove(u);
        }

        void UpdatableUpdateOrderChanged(object sender, EventArgs e)
        {
            _enabledUpdateable.Sort(UpdatableComparison);
        }

        static int UpdatableComparison(IUpdateable x, IUpdateable y)
        {
            return x.UpdateOrder - y.UpdateOrder;
        }

        #endregion Updatable Methods

        #region Drawable Methods

        void AddDrawable(IDrawable d)
        {
            _visibleDrawable.Add(d);
            _visibleDrawable.Sort(DrawableComparison);
        }

        void DrawableVisibleChanged(object sender, EventArgs e)
        {
            IDrawable d = (IDrawable)sender;
            if (d.Visible)
                AddDrawable(d);
            else
                _visibleDrawable.Remove(d);
        }

        void DrawableDrawOrderChanged(object sender, EventArgs e)
        {
            _visibleDrawable.Sort(DrawableComparison);
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

        #region Internal Members

        #endregion Internal Members
    }
}
