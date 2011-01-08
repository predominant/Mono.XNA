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
using Tao.OpenGl;

namespace Microsoft.Xna.Framework.Graphics
{
    public abstract class RenderTarget : IDisposable
    {
		#region Fields
		
		protected internal GraphicsDevice graphicsDevice;
		protected internal SurfaceFormat format;
		protected internal int width;
		protected internal int height;
		protected internal int multiSampleQuality;
		protected internal MultiSampleType multiSampleType;
		protected internal RenderTargetUsage renderTargetUsage;
		protected internal int numLevels;
		
		
		private bool isContentLost;
		private bool isDisposed;
		private string name;
		private object tag;
		
		internal int renderBufferIdentifier;
		
		#endregion Fields
		
		#region Constructor/Destructor
		
        internal RenderTarget()
        {
        }

        ~RenderTarget()
        {
			Dispose(false);
        }
		
		#endregion
		
		#region Properties

        public SurfaceFormat Format {
            get { return format; }
        }

        public GraphicsDevice GraphicsDevice {
            get { return graphicsDevice; }
        }
		
		public int Height {
            get { return height; }
        }
		
		public bool IsContentLost {
			get { return isContentLost; }
		}

        public bool IsDisposed {
            get { return isDisposed; }
        }

        public int MultiSampleQuality {
            get { return multiSampleQuality; }
        }

        public MultiSampleType MultiSampleType {
            get { return multiSampleType; }
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }
		
		public RenderTargetUsage RenderTargetUsage
		{
			get { return renderTargetUsage; }	
		}

        public object Tag {
            get { return tag; }
            set { tag = value; }
        }

        public int Width {
            get { return width; }
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

        protected virtual void Dispose(bool disposeManaged)
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
