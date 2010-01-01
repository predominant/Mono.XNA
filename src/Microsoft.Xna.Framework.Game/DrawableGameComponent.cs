#region License

/*
MIT License
Copyright © 2006 The Mono.Xna Team

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
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework
{
    public class DrawableGameComponent : GameComponent, IDrawable
    {
        #region Private Fields

        int _drawOrder;
        bool _visible;
        IGraphicsDeviceService _graphicsService;

        #endregion Private Fields

        #region Public Constructors

        public DrawableGameComponent(Game game) : base(game)
        {
            _visible = true;
        }

        #endregion Public Constructors

        #region Public Properties

        public int DrawOrder
        {
            get { return _drawOrder; }
            set
            {
                if (_drawOrder != value)
                {
                    _drawOrder = value;
                    OnDrawOrderChanged(this, EventArgs.Empty);
                }
            }
        }

        public bool Visible
        {
            get { return _visible; }
            set
            {
                if (_visible != value)
                {
                    _visible = value;
                    OnVisibleChanged(this, EventArgs.Empty);
                }
            }
        }

        #endregion Public Properties

        #region Protected Properties

#if XNA_1_1
        protected
#else
        public
#endif
            GraphicsDevice GraphicsDevice
        {
            get { return _graphicsService.GraphicsDevice; }
        }

        #endregion Protected Properties

        #region Public Methods

        public virtual void Draw(GameTime gameTime)
        {
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public override void Initialize()
        {
            _graphicsService = (IGraphicsDeviceService)Game.Services.GetService(typeof(IGraphicsDeviceService));
            if (_graphicsService == null)
                throw new InvalidOperationException("Drawable components require IGraphicsDeviceService in the Services collection.");

            //_graphicsService.DeviceResetting += DeviceResetting;
            //_graphicsService.DeviceReset += DeviceReset;
            
            LoadGraphicsContent(true);
            LoadContent();
        }

        #endregion Public Methods

        #region Protected Methods

#if XNA_1_1
        internal
#else
        protected
#endif
            virtual void LoadContent()
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.UnloadGraphicsContent(true);
                this.UnloadContent();
            }
            base.Dispose(disposing);
        }

#if XNA_1_1
#else
        [System.ObsoleteAttribute("Use LoadContent() instead")]
#endif

        protected virtual void LoadGraphicsContent(bool loadAllContent)
        {
        }

#if XNA_1_1
        internal
#else
        protected
#endif
            virtual void UnloadContent()
        {
        }

        protected virtual void OnDrawOrderChanged(object sender, EventArgs args)
        {
            if (DrawOrderChanged != null)
                DrawOrderChanged(sender, args);
        }

        protected virtual void OnVisibleChanged(object sender, EventArgs args)
        {
            if (VisibleChanged != null)
                VisibleChanged(sender, args);
        }

#if XNA_1_1
#else
        [System.ObsoleteAttribute("Use UnloadContent() instead")]
#endif
        protected virtual void UnloadGraphicsContent(bool unloadAllContent)
        {
        }

        #endregion Protected Methods

        #region Private Methods

        void DeviceReset(object sender, EventArgs e)
        {
            LoadGraphicsContent(false);
        }

        void DeviceResetting(object sender, EventArgs e)
        {
            UnloadGraphicsContent(false);
        }

        #endregion Private Methods

        #region Public Events

        public event EventHandler DrawOrderChanged;
        public event EventHandler VisibleChanged;

        #endregion Public Events
    }
}