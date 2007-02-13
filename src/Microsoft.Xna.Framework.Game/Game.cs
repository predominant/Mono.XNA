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

using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Tao.OpenGl;
using SdlDotNet.Graphics;
using SdlDotNet.Core;

namespace Microsoft.Xna.Framework
{
	public class Game : IDisposable
	{
		#region Public Constructors

        public Game()
        {
            throw new NotImplementedException();
        }

		#endregion Public Constructors

		#region Destructor

		~Game()
		{
		}

		#endregion Destructor



		#region Public Properties
        
		public GameComponentCollection Components
		{
            get { throw new NotImplementedException(); }
		}

        
        public TimeSpan InactiveSleepTime {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); } }

        
		public bool IsActive
		{
            get { throw new NotImplementedException(); }
		}

        
		public bool IsFixedTimeStep { 
            get { throw new NotImplementedException(); } 
            set { throw new NotImplementedException(); } }

        
		public bool IsMouseVisible
		{
            get { throw new NotImplementedException(); }
			set{throw new NotImplementedException();}
		}

        
		public GameServiceContainer Services
		{
            get { throw new NotImplementedException(); }
		}

        
        public TimeSpan TargetElapsedTime
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        
        public GameWindow Window
        {
            get { throw new NotImplementedException(); }
        }

		#endregion Public Properties

		#region Public Methods

        
		public void Dispose()
		{
            throw new NotImplementedException();
		}

        
		public void Exit()
		{
            throw new NotImplementedException();
		}

        
		public void Run()
		{
            throw new NotImplementedException();
		}

        
		public void Tick()
		{
            throw new NotImplementedException();
		}


		#endregion Public methods

		#region Protected Methods

		protected virtual void Dispose(bool disposing)
		{
            throw new NotImplementedException();
		}

		protected virtual bool BeginDraw()
		{
            throw new NotImplementedException();
		}

		protected virtual void BeginRun()
		{
            throw new NotImplementedException();
		}

		protected virtual void Draw(GameTime gameTime)
		{
            throw new NotImplementedException();
		}

		protected virtual void EndDraw()
		{
            throw new NotImplementedException();
		}

		protected virtual void EndRun()
		{
            throw new NotImplementedException();
		}

		protected virtual void Initialize()
		{
            throw new NotImplementedException();
		}

        private void DeviceCreated(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeviceDisposing(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeviceReset(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeviceResetting(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

		protected virtual void LoadGraphicsContent(bool loadAllContent)
		{
            throw new NotImplementedException();
		}

		protected virtual void OnActivated(object sender, EventArgs args)
		{
            throw new NotImplementedException();
		}

		protected virtual void OnDeactivated(object sender, EventArgs args)
		{
            throw new NotImplementedException();
		}

		protected virtual void OnExiting(object sender, EventArgs args)
		{
            throw new NotImplementedException();
		}

		protected virtual void UnloadGraphicsContent(bool unloadAllContent)
		{
            throw new NotImplementedException();
		}

		protected virtual void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
		}

		#endregion Protected Methods

        #region Public Events

        public event EventHandler Activated;
		public event EventHandler Deactivated;
		public event EventHandler Disposed;
		public event EventHandler Exiting;

		#endregion Public Events
	}
}