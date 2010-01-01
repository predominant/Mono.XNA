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

    public abstract class GraphicsResource : IDisposable
    {
		#region Protected Fields
		
		protected GraphicsDevice graphicsDevice;
		
		#endregion Protected Fields
		
		#region Private Fields
		
		private bool isDisposed;
		private string name;
		private int priority;
		private ResourceType resourceType;
		private object tag;
		
		#endregion Private Fields
		
		#region Operators

        //public static bool operator !=(GraphicsResource left, GraphicsResource right)
        //{
        //    throw new NotImplementedException();
        //}

        //public static bool operator ==(GraphicsResource left, GraphicsResource right)
        //{
        //    throw new NotImplementedException();
        //}
		
		#endregion Operators
		
		#region Properties

        public virtual GraphicsDevice GraphicsDevice {
            get { return graphicsDevice; }
        }

        public bool IsDisposed {
            get { return isDisposed; }
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public int Priority {
            get { return priority; }
            set { priority = value; }
        }

        public virtual ResourceType ResourceType {
            get { return resourceType; }
        }

        public object Tag {
            get { return tag; }
            set { tag = value; }
        }
		
		#endregion Properties
		
		#region Events

        public event EventHandler Disposing;
		
		#endregion Events
		
		#region Constructor/Destructor
		
        internal GraphicsResource()
        {
			isDisposed = false;
        }
		
		~GraphicsResource()
        {
			Dispose(false);
        }
		
		#endregion Constructor/Destructor
		
		#region IDisposable Implementation
		
		public void Dispose()
        {           
			Dispose(true);
        }
		
		#endregion
		
		#region Protected Methods

        protected virtual void Dispose(bool disposing)
        {
			if(isDisposed)
				return;
			
            isDisposed = true;
        }
		
		protected void raise_Disposing(object sender, EventArgs e)
        {
            if(Disposing != null)
				Disposing(sender, e);
        }
		
		#endregion
    }
}