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

using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework.Graphics;
using SdlDotNet.Core;
using SdlDotNet.Graphics;

#if NUNITTESTS
using Microsoft.Xna.Framework.Test;
#endif

namespace Microsoft.Xna.Framework
{
    public class Game : IDisposable
    {
        public const double DEFAULT_TARGET_ELAPSED_TIME = 1000/60;  // 60 fps
        public const double DEFAULT_INACTIVE_SLEEP_TIME = 20;       // 20 milliseconds

        #region Private Fields

        bool _isFixedTimeStep;

        GameComponentCollection _components;
        List<IDrawable> _visibleDrawable;
        List<IUpdateable> _enabledUpdateable;

        GameServiceContainer _services;
        bool _disposed;

        #region Timing

        GameTime _gameTime;
        IGameClock _gameClock;
        TimeSpan _inactiveSleepTime;
        TimeSpan _targetElapsedTime;
        long _currentUpdate;

        #endregion Timing

        TickDelegate _tickDelegate;
        ExtendedGameWindow _window;
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

        #region Public Constructors

        public Game()
        {
            InitializeState(new GameClock(), new SdlGameWindow(this));
        }

#if NUNITTESTS
        /// <summary>
        /// This protected constructor is reserved for unit-testing, by allowing an alternative game clock to be provided.
        /// It should not be used
        /// </summary>
        protected Game(IGameClock gameClock, EventSource eventSource)
        {
            if (eventSource != null)
            {
                _eventSource = eventSource;
                _eventSource.Game = this;
            }
            InitializeState(gameClock, null);
        }

#endif

        void InitializeState(IGameClock gameClock, ExtendedGameWindow window)
        {
            _isFixedTimeStep = true;
            _isActive = false;
            _tickDelegate = FixedTimeStepTick;

            _visibleDrawable = new List<IDrawable>();
            _enabledUpdateable = new List<IUpdateable>();

            _components = new GameComponentCollection();
            _components.ComponentAdded += new EventHandler<GameComponentCollectionEventArgs>(GameComponentAdded);
            _components.ComponentRemoved += new EventHandler<GameComponentCollectionEventArgs>(GameComponentRemoved);

            _services = new GameServiceContainer();

            _gameClock = gameClock;
            _gameTime = new GameTime(TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero);

            _inactiveSleepTime = TimeSpan.FromMilliseconds(DEFAULT_INACTIVE_SLEEP_TIME);
            _targetElapsedTime = TimeSpan.FromMilliseconds(DEFAULT_TARGET_ELAPSED_TIME);

            SetWindow(window);
        }

        void SetWindow(ExtendedGameWindow window)
        {
            _window = window;
            if (_window != null)
            {
                _window.Exiting += new EventHandler(WindowExiting);
                _window.Activated += new EventHandler(WindowActivated);
                _window.Deactivated += new EventHandler(WindowDeactivated);
            }
        }

        #endregion Public Constructors

        #region Destructor

        ~Game()
        {
            Dispose(false);
        }

        #endregion Destructor

        #region Public Properties

        public GameComponentCollection Components
        {
            get { return _components; }
        }

        public TimeSpan InactiveSleepTime
        {
            get { return _inactiveSleepTime; }
            set { _inactiveSleepTime = value; }
        }

        public bool IsActive
        {
            get { return _isActive; }
        }

        public bool IsFixedTimeStep
        {
            get { return _isFixedTimeStep; }
            set
            {
                if (_isFixedTimeStep != value)
                {
                    _isFixedTimeStep = value;
                    _tickDelegate = _isFixedTimeStep ? (TickDelegate)FixedTimeStepTick : (TickDelegate)VariableTimeStepTick;
                }
            }
        }

        public bool IsMouseVisible
        {
            get { return SdlDotNet.Input.Mouse.ShowCursor; }
            set { SdlDotNet.Input.Mouse.ShowCursor = value; }
        }

        public GameServiceContainer Services
        {
            get { return _services; }
        }

        public TimeSpan TargetElapsedTime
        {
            get { return _targetElapsedTime; }
            set { _targetElapsedTime = value; }
        }

        public GameWindow Window
        {
            get { return _window; }
#if NUNITTESTS
            set { SetWindow((ExtendedGameWindow)value); }
#endif
        }

        #endregion Public Properties

        #region Public Methods

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Exit()
        {
            Events.QuitApplication();
        }

        public void Run()
        {
            PreInitialize();

            Initialize();

            _window.Initialize();

            _isActive = true;

            BeginRun();

            Update(_gameTime);

            _gameClock.Start();

#if NUNITTESTS
            if (_eventSource != null)
                _eventSource.Run();
            else
            {
                Events.Tick += new EventHandler<TickEventArgs>(Events_Tick);
                Events.Run();
            }
#else
            Events.Fps = 60;
            Events.Tick += new EventHandler<TickEventArgs>(Events_Tick);
            Events.Run();
#endif
            EndRun();
        }

        void Events_Tick(object sender, TickEventArgs e)
        {               
            TickImpl();
        }

        public void Tick()
        {
            TickImpl();
        }

        void TickImpl()
        {
            if (!IsActive)
                Thread.Sleep(InactiveSleepTime);

            _gameClock.Tick();
            _gameTime.TotalRealTime = TimeSpan.FromMilliseconds(_gameClock.TotalElapsedMilliseconds);

            _tickDelegate();
        }

        #endregion Public methods

        #region Protected Methods

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
            foreach (IGameComponent component in _components)
            {
                component.Initialize();
            }

            // Default behaviour in MS implementation on windows passes true, suspect false for platforms with lesser available memory
            LoadGraphicsContent(true);
        }

        void DeviceCreated(object sender, EventArgs e)
        {
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

        protected virtual void LoadGraphicsContent(bool loadAllContent)
        {
            throw new NotImplementedException();
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

        void PreInitialize()
        {
            _graphicsManager = (IGraphicsDeviceManager)Services.GetService(typeof (IGraphicsDeviceManager));
            if (_graphicsManager != null)
                _graphicsManager.CreateDevice();

            _graphicsService = (IGraphicsDeviceService)Services.GetService(typeof (IGraphicsDeviceService));
            if (_graphicsService != null)
            {
                _graphicsService.DeviceCreated += DeviceCreated;
                _graphicsService.DeviceResetting += DeviceResetting;
                _graphicsService.DeviceReset += DeviceReset;
                _graphicsService.DeviceDisposing += DeviceDisposing;
            }
        }

        /// <summary>
        /// The fixed time step
        /// </summary>
        void FixedTimeStepTick()
        {
            _currentUpdate += _gameClock.ElapsedMilliseconds;

            TimeSpan elapsed = TimeSpan.FromMilliseconds(_gameClock.ElapsedMilliseconds);
            _gameTime.ElapsedRealTime = elapsed;

            long updatesDue = _currentUpdate/_targetElapsedTime.Milliseconds;

            if (updatesDue > 0)
            {
                _gameTime.ElapsedGameTime = _targetElapsedTime;
                while (updatesDue > 0)
                {
                    Update(_gameTime);
                    _gameTime.TotalGameTime += _targetElapsedTime;
                    updatesDue--;
                }
                _currentUpdate = 0;
            }

            DrawFrame();

            _gameTime.ElapsedGameTime = TimeSpan.Zero;
        }

        void VariableTimeStepTick()
        {
            TimeSpan elapsed = TimeSpan.FromMilliseconds(_gameClock.ElapsedMilliseconds);

            _gameTime.ElapsedGameTime = _gameTime.ElapsedRealTime = elapsed;
            _gameTime.TotalGameTime += elapsed;

            Update(_gameTime);
            DrawFrame();
        }

        void DrawFrame()
        {
            if (_window.Visible && BeginDraw())
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

    internal delegate void TickDelegate();
}