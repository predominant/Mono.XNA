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

namespace Microsoft.Xna.Framework.Graphics
{
    public abstract class RenderTarget : IDisposable
    {
		#region Protected Fields
		
		protected GraphicsDevice graphicsDevice;
		
		#endregion Protected Fields
		
		#region Private Fields
		
		private bool isDisposed;
		private string name;
		private object tag;
		
		#endregion Private Fields
		
		#region Constructor/Destructor
		
        internal RenderTarget()
        {
            throw new NotImplementedException();
        }

        ~RenderTarget()
        {
			Dispose(false);
        }
		
		#endregion
		
		#region Operators

        public static bool operator !=(RenderTarget left, RenderTarget right)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(RenderTarget left, RenderTarget right)
        {
            throw new NotImplementedException();
        }
		
		#endregion Operators
		
		#region Properties

        public SurfaceFormat Format {
            get { throw new NotImplementedException(); }
        }

        public GraphicsDevice GraphicsDevice {
            get { return graphicsDevice; }
        }

        public int Height {
            get { throw new NotImplementedException(); }
        }

        public bool IsDisposed {
            get { return isDisposed; }
        }

        public int MultiSampleQuality {
            get { throw new NotImplementedException(); }
        }

        public MultiSampleType MultiSampleType {
            get { throw new NotImplementedException(); }
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public object Tag {
            get { return tag; }
            set { tag = value; }
        }

        public int Width {
            get { throw new NotImplementedException(); }
        }
		
		#endregion Properties
		
		#region Events

		public virtual event EventHandler ContentLost;
        public event EventHandler Disposing;
		
		#endregion Events
		
		#region IDispose Implementation

        public void Dispose()
        {
            Dispose(true);
        }
		
		#endregion IDispose Implementation
		
		#region Protected Methods

        protected virtual void Dispose(bool disposing)
        {
            if(isDisposed)
				return;
			
            isDisposed = true;
        }
		
		protected virtual void raise_ContentLost(Object sender, EventArgs e)
		{
			if(ContentLost != null)
				ContentLost(sender, e);
		}

        protected void raise_Disposing(object sender, EventArgs e)
        {
            if(Disposing != null)
				Disposing(sender, e);
        }
		
		#endregion Protected Methods
    }
}
