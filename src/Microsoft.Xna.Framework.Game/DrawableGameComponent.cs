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
		#region Public Constructors

		public DrawableGameComponent(Game game) : base(game)
		{
			throw new NotImplementedException();
		}

		#endregion Public Constructors

		#region Private Fields
		
		private int drawOrder;
		private bool visible;
		
		#endregion Private Fields

		#region Public Properties

		public int DrawOrder
		{
			get {
				return drawOrder;
			}
			set {
				drawOrder = value;
			}
		}
		
		public bool Visible
		{
			get {
				return visible;
			}
			set {
				visible = value;
			}
		}

		#endregion Public Properties
		
		#region Protected Properties
		
		protected GraphicsDevice GraphicsDevice
		{
			get {
				throw new NotImplementedException();
			}
		}
		
		#endregion Protected Properties
		
		#region Public Methods

		public virtual void Draw(GameTime gameTime)
		{
			throw new NotImplementedException();
		}

		public override void Initialize()
		{
			throw new NotImplementedException();
		}
		
		#endregion Public Methods
		
		#region Protected Methods
		
		protected override void Dispose(bool disposing)
		{
			throw new NotImplementedException();
		}
		
		protected virtual void LoadGraphicsContent(bool loadAllContent)
		{
			throw new NotImplementedException(); 
		}
        
		protected virtual void OnDrawOrderChanged(object sender, EventArgs args)
		{
			throw new NotImplementedException();
		}

		protected virtual void OnVisibleChanged(object sender, EventArgs args)
		{
			throw new NotImplementedException();
		}
        
		protected virtual void UnloadGraphicsContent(bool unloadAllContent)
		{
			throw new NotImplementedException();
		}
        
		#endregion Protected Methods

		#region Public Events

		public event EventHandler DrawOrderChanged;
		public event EventHandler VisibleChanged;

		#endregion Public Events
    }
}
