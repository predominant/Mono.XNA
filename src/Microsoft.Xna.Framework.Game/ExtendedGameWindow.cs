using System;

namespace Microsoft.Xna.Framework
{
#if NUNITTESTS
	public
#else
    internal
#endif 
	abstract class ExtendedGameWindow : GameWindow
    {
        protected ExtendedGameWindow(Game game) : base()
        {
        }

        public abstract bool Visible { get; }

        public abstract void Initialize();

        #region Protected Methods

        protected void OnExiting(object sender, EventArgs args)
        {
            if (Exiting != null)
                Exiting(sender, args);
        }

        protected void OnActivated(object sender, EventArgs args)
        {
            OnActivated();
            if (Activated != null)
                Activated(sender, args);
        }

        protected void OnDeactivated(object sender, EventArgs args)
        {
            OnDeactivated();
            if (Deactivated != null)
                Deactivated(sender, args);
        }

        protected void OnVisibleChanged(object sender, EventArgs args)
        {
            if (VisibleChanged != null)
                VisibleChanged(sender, args);
        }

        #endregion Protected Methods

        #region Events

        public event EventHandler Exiting;
        public event EventHandler Activated;
        public event EventHandler Deactivated;
        public event EventHandler VisibleChanged;

        #endregion Events
    }
}