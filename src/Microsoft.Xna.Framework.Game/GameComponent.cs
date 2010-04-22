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

namespace Microsoft.Xna.Framework
{
    public class GameComponent : IGameComponent, IUpdateable, IDisposable
    {
        readonly Game _game;
        bool _disposed;
        bool _enabled;
        int _updateOrder;

        public event EventHandler EnabledChanged;
        public event EventHandler UpdateOrderChanged;
        public event EventHandler Disposed;

        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                if (_enabled != value)
                {
                    _enabled = value;
                    OnEnabledChanged(this, EventArgs.Empty);
                }
            }
        }

		public Game Game
        {
            get { return _game; }
        }

        public int UpdateOrder
        {
            get { return _updateOrder; }
            set
            {
                if (_updateOrder != value)
                {
                    _updateOrder = value;
                    OnUpdateOrderChanged(this, EventArgs.Empty);
                }
            }
        }

        public GameComponent(Game game)
        {
            _game = game;
            _enabled = true;
        }

        ~GameComponent()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
                if (Disposed != null)
                    Disposed(this, EventArgs.Empty);
            }
        }

        public virtual void Initialize()
        {
        }

        protected virtual void OnEnabledChanged(object sender, EventArgs args)
        {
            if (EnabledChanged != null)
                EnabledChanged(this, args);
        }

        protected virtual void OnUpdateOrderChanged(object sender, EventArgs args)
        {
            if (UpdateOrderChanged != null)
                UpdateOrderChanged(this, args);
        }

        public virtual void Update(GameTime gameTime)
        {
        }
    }
}