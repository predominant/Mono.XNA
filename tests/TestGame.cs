using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

#region Mono.Xna specific
#if !MSXNAONLY
using Microsoft.Xna.Framework.Test;
#endif
#endregion Mono.Xna specific

namespace Tests
{
    public class TestGame : Game
    {
        IGraphicsDeviceService graphics;
        ContentManager content;

        #region Method Call Counters

        public int CountInitialize;
        public int CountBeginRun;
        public int CountBeginDraw;
        public int CountDraw;
        public int CountEndDraw;
        public int CountEndRun;
        public int CountUpdate;
        public int CountLoadGraphicsContent;
        public int CountUnloadGraphicsContent;
        public int CountOnActivated;
        public int CountOnDeactivated;
        public int CountOnExiting;

        #endregion Method Call Counters

        public TestGame()
        {
            InitializeOther(false);
        }

        public TestGame(bool useTestGraphicsDeviceManager)
        {
            InitializeOther(useTestGraphicsDeviceManager);
        }

        void InitializeOther(bool useTestGraphicsDeviceManager)
        {
            graphics = useTestGraphicsDeviceManager ? (IGraphicsDeviceService)new DummyGraphicsDeviceManager(this) : new GraphicsDeviceManager(this);

            content = new ContentManager(Services);
            TargetElapsedTime = TimeSpan.FromMilliseconds(100);

            //Components.Add(new MyComponent(this));
            //Components.Add(new MyDrawable(this));
            //Components.Add(new Invisible(this));
            //Components.Add(new NotEnabled(this));
            //Components.Add(new Ordered(this, 20));
            //Components.Add(new Ordered(this, 15));
            //Components.Add(new Ordered(this, 10));
            
            #region Mono.Xna specific
#if !MSXNAONLY
            Window = _window = new TestGameWindow(this);
#endif
            #endregion Mono.Xna specific
        }

        #region Mono.Xna specific

#if !MSXNAONLY
        ExtendedGameWindow _window;

        public TestGame(EventSource eventSource)
            : this (eventSource, true)
        {
        }

        public TestGame(EventSource eventSource, bool useTestGraphicsDeviceManager)
            : base(TestClock.Instance, eventSource)
        {
            InitializeOther(useTestGraphicsDeviceManager);
        }
#endif
        #endregion Mono.Xna specific

        public IGraphicsDeviceService GraphicsDeviceManager
        {
            get { return graphics; }
        }

        protected override bool BeginDraw()
        {
            CountBeginDraw++;
            return base.BeginDraw();
        }

        protected override void BeginRun()
        {
            CountBeginRun++;
            base.BeginRun();
        }

        protected override void Draw(GameTime gameTime)
        {
            CountDraw++;
            base.Draw(gameTime);
        }

        protected override void EndDraw()
        {
            CountEndDraw++;
            base.EndDraw();
        }

        protected override void EndRun()
        {
            CountEndRun++;
            base.EndRun();
        }

        protected override void Initialize()
        {
            CountInitialize++;
            base.Initialize();
        }

        protected override void LoadGraphicsContent(bool loadAllContent)
        {
            CountLoadGraphicsContent++;
            base.LoadGraphicsContent(loadAllContent);
        }

        protected override void OnActivated(object sender, EventArgs args)
        {
            CountOnActivated++;
            base.OnActivated(sender, args);
        }

        protected override void OnDeactivated(object sender, EventArgs args)
        {
            CountOnDeactivated++;
            base.OnDeactivated(sender, args);
        }

        protected override void OnExiting(object sender, EventArgs args)
        {
            CountOnExiting++;
            base.OnExiting(sender, args);
        }

        protected override void UnloadGraphicsContent(bool unloadAllContent)
        {
            CountUnloadGraphicsContent++;
            base.UnloadGraphicsContent(unloadAllContent);
        }

        protected override void Update(GameTime gameTime)
        {
            CountUpdate++;
            base.Update(gameTime);
        }
    }
    #region Mono.Xna specific

#if !MSXNAONLY
    #region Event Source

    class NullEventSource : EventSource
    {
        public override void Run()
        {
        }
    }

    internal delegate void RunDelegate<T>(T source);

    class DelegateBasedEventSource : EventSource
    {
        RunDelegate<DelegateBasedEventSource> _run;

        public DelegateBasedEventSource(RunDelegate<DelegateBasedEventSource> run)
        {
            _run = run;
        }

        public override void Run()
        {
            _run(this);
        }

    } 

    #endregion Event Source
#endif

    #endregion Mono.Xna specific

    #region Test Components

    public class GameComponentTestBase : GameComponent
    {
        #region Method Counters

        public int CountInitialize;
        public int CountUpdate;
        public int CountOnEnabledChanged;
        public int CountOnUpdateOrderChanged;

        #endregion Method Counters

        public GameComponentTestBase(Game game) : base(game)
        {
        }


        public override void Initialize()
        {
            CountInitialize++;
            base.Initialize();
        }

        protected override void OnEnabledChanged(object sender, EventArgs args)
        {
            CountOnEnabledChanged++;
            base.OnEnabledChanged(sender, args);
        }

        protected override void OnUpdateOrderChanged(object sender, EventArgs args)
        {
            CountOnUpdateOrderChanged++;
            base.OnUpdateOrderChanged(sender, args);
        }

        public override void Update(GameTime gameTime)
        {
            CountUpdate++;
            base.Update(gameTime);
        }
    }

    public class DrawableGameComponentTestBase : DrawableGameComponent
    {
        #region Method Counters

        public int CountInitialize;
        public int CountUpdate;
        public int CountOnEnabledChanged;
        public int CountOnUpdateOrderChanged;
        public int CountDraw;
        public int CountLoadGraphicsContent;
        public int CountUnloadGraphicsContent;
        public int CountOnDrawOrderChanged;
        public int CountOnVisibleChanged;

        #endregion Method Counters

        public DrawableGameComponentTestBase(Game game) : base(game)
        {
        }

        public override void Initialize()
        {
            CountInitialize++;
            base.Initialize();
        }

        protected override void OnEnabledChanged(object sender, EventArgs args)
        {
            CountOnEnabledChanged++;
            base.OnEnabledChanged(sender, args);
        }

        protected override void OnUpdateOrderChanged(object sender, EventArgs args)
        {
            CountOnUpdateOrderChanged++;
            base.OnUpdateOrderChanged(sender, args);
        }

        public override void Update(GameTime gameTime)
        {
            CountUpdate++;
            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            CountDraw++;
            base.Draw(gameTime);
        }

        protected override void LoadGraphicsContent(bool loadAllContent)
        {
            CountLoadGraphicsContent++;
            base.LoadGraphicsContent(loadAllContent);
        }

        protected override void OnDrawOrderChanged(object sender, EventArgs args)
        {
            CountOnDrawOrderChanged++;
            base.OnDrawOrderChanged(sender, args);
        }

        protected override void OnVisibleChanged(object sender, EventArgs args)
        {
            CountOnVisibleChanged++;
            base.OnVisibleChanged(sender, args);
        }

        protected override void UnloadGraphicsContent(bool unloadAllContent)
        {
            CountUnloadGraphicsContent++;
            base.UnloadGraphicsContent(unloadAllContent);
        }
    }

    class MyComponent : GameComponentTestBase
    {
        public MyComponent(Game game)
            : base(game)
        {
        }
    }

    class MyDrawable : DrawableGameComponentTestBase
    {
        public MyDrawable(Game game)
            : base(game)
        {
        }
    }

    class Invisible : DrawableGameComponentTestBase
    {
        public Invisible(Game game)
            : base(game)
        {
            Visible = false;
        }
    }

    class NotEnabled : DrawableGameComponentTestBase
    {
        public NotEnabled(Game game)
            : base(game)
        {
            Enabled = false;
        }
    }

    class Ordered : DrawableGameComponentTestBase
    {
        public Ordered(Game game, int order)
            : base(game)
        {
            Enabled = false;
            DrawOrder = order;
        }

        public override string ToString()
        {
            return String.Format("Ordered:{0}", DrawOrder);
        }
    } 

    #endregion Test Components

    #region DummyDeviceManager

    public class DummyGraphicsDeviceManager : IGraphicsDeviceService, IDisposable, IGraphicsDeviceManager
    {
        GraphicsDevice _graphicsDevice;
        bool _beginDrawResult;
        Game _game;

        public DummyGraphicsDeviceManager(Game game)
        {
            _game = game;
            _game.Services.AddService(typeof(IGraphicsDeviceManager), this);
            _game.Services.AddService(typeof(IGraphicsDeviceService), this);
            _beginDrawResult = true;
        }

        #region IGraphicsDeviceService Members

#pragma warning disable 67

        public event EventHandler DeviceCreated;
        public event EventHandler DeviceDisposing;
        public event EventHandler DeviceReset;
        public event EventHandler DeviceResetting;

#pragma warning restore 67

        public GraphicsDevice GraphicsDevice
        {
            get { return _graphicsDevice; }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
        }

        #endregion

        #region IGraphicsDeviceManager Members

        public bool BeginDraw()
        {
            return _beginDrawResult;
        }

        public void CreateDevice()
        {
        }

        public void EndDraw()
        {
        }

        #endregion

        public bool BeginDrawResult
        {
            get { return _beginDrawResult; }
            set { _beginDrawResult = value; }
        }
    }

    #endregion DummyDeviceManager

}
