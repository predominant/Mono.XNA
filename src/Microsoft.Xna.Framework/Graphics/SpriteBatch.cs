#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.

Authors:
* Rob Loach
* Olivier Dufour (Duff)

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
using System.Text;
using Tao.OpenGl;

namespace Microsoft.Xna.Framework.Graphics
{
    public class SpriteBatch : IDisposable
    {	
		#region Private Fields
        
		private object tag = null;
        private string name = string.Empty;
        private GraphicsDevice device;
        private bool disposed;
        private static SpriteBlendMode spriteBlendMode = SpriteBlendMode.None;
        private List<Sprite> spriteList = new List<Sprite>();
        private SpriteSortMode sortMode;
        private bool isRunning = false;
        private SaveStateMode stateMode;
        private StateBlock saveState;
        
		#endregion Private Fields
		

        #region Constructors and Destructor

        public SpriteBatch(GraphicsDevice graphicsDevice)
        {
            this.device = graphicsDevice;
        }

        ~SpriteBatch()
        {
            Dispose(false);
        }

        #endregion Constructors and Deconstructor


        #region Events

        public event EventHandler Disposing;

        #endregion Events


        #region Properties
		
        public GraphicsDevice GraphicsDevice {
            get { return device; }
        }

        public bool IsDisposed {
            get { return disposed; }
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public object Tag {
            get { return tag; }
            set { tag = value; }
        }
		
        #endregion Properties


        #region Public Methods

        public void Begin()
        {
            Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Deferred, SaveStateMode.None, Matrix.Identity);
        }

        public void Begin(SpriteBlendMode blendMode)
        {
            Begin(blendMode, SpriteSortMode.Deferred, SaveStateMode.None, Matrix.Identity);
        }

        public void Begin(SpriteBlendMode blendMode, SpriteSortMode sortMode, SaveStateMode stateMode)
        {
            this.Begin(blendMode, sortMode, stateMode, Matrix.Identity);
        }

        public void Begin(SpriteBlendMode blendMode, SpriteSortMode sortMode, SaveStateMode stateMode, Matrix transformMatrix)
        {
            //to respect order Begin/Draw/end
            if (isRunning)
                throw new InvalidOperationException("Begin cannot be called again until End has been successfully called.");

            if (stateMode == SaveStateMode.SaveState)
                saveState = new StateBlock(this.GraphicsDevice);


            spriteBlendMode = blendMode;
            this.sortMode = sortMode;
            if (sortMode == SpriteSortMode.Immediate)
                applyGraphicsDeviceSettings();
            isRunning = true;
        }

        public void End()
        {
            if (!isRunning)
                throw new InvalidOperationException("Begin must be called successfully before End can be called.");
            
			if (sortMode != SpriteSortMode.Immediate)
            {
                applyGraphicsDeviceSettings();
                flush();
            }
			
            Gl.glDisable(Gl.GL_TEXTURE_2D);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glPopMatrix();
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPopMatrix();

            restoreRenderState();
            isRunning = false;
        }        

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (Disposing != null)
                    Disposing(this, null);

                if (disposing)
                {
                    // Release any managed components
                }
                disposed = true;

                // Release any unmanaged components
            }
        }

        public void Draw(Texture2D texture, Rectangle destinationRectangle, Color color)
        {
            Draw(texture, destinationRectangle, null, color, 0f, Vector2.Zero, SpriteEffects.None, 0f);
        }

        public void Draw(Texture2D texture, Rectangle destinationRectangle, Nullable<Rectangle> sourceRectangle, Color color)
        {
            Draw(texture, destinationRectangle, sourceRectangle, color, 0f, Vector2.Zero, SpriteEffects.None, 0f);
        }
		
		public void Draw(Texture2D texture, Vector2 position, Color color)
        {
            Draw(texture, position, null, color);
        }

        public void Draw(Texture2D texture, Vector2 position, Nullable<Rectangle> sourceRectangle, Color color)
        {
            Rectangle destination = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
			Draw(texture, destination, sourceRectangle, color, 0f, Vector2.Zero, SpriteEffects.None, 0f);
        }

        public void Draw(Texture2D texture, Vector2 position, Nullable<Rectangle> sourceRectangle, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            int width;
            int height;
            if (sourceRectangle.HasValue)
            {
                width = (int)(sourceRectangle.Value.Width * scale);
                height = (int)(sourceRectangle.Value.Height * scale);
            }
            else
            {
                width = (int)(texture.Width * scale);
                height = (int)(texture.Height * scale);
            }
            Rectangle destination = new Rectangle((int)position.X, (int)position.Y, width, height);
			Draw(texture, destination, sourceRectangle, color, rotation, origin, effects, layerDepth);
        }

        public void Draw(Texture2D texture, Vector2 position, Nullable<Rectangle> sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            int width;
            int height;
            if (sourceRectangle.HasValue)
            {
                width = (int)(sourceRectangle.Value.Width * scale.X);
                height = (int)(sourceRectangle.Value.Height * scale.Y);
            }
            else
            {
                width = (int)(texture.Width * scale.X);
                height = (int)(texture.Height * scale.Y);
            }
            Rectangle destination = new Rectangle((int)position.X, (int)position.Y, width, height);
			Draw(texture, destination, sourceRectangle, color, rotation, origin, effects, layerDepth);
        }

        public void Draw(Texture2D texture, Rectangle destinationRectangle, Nullable<Rectangle> sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth)
        {
            if (!isRunning)
                throw new InvalidOperationException("Begin must be called successfully before a Draw can be called.");

            Sprite sprite = new Sprite(texture, 
				sourceRectangle.HasValue ? sourceRectangle.Value : new Rectangle(0, 0, texture.Width, texture.Height),
				destinationRectangle,
				color,
				rotation, 
				origin, 
				effects,
				layerDepth);
			
			spriteList.Add(sprite);

            if (sortMode == SpriteSortMode.Immediate)
                flush();
        }        

        public void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color)
        {
            if (spriteFont == null)
            {
                throw new ArgumentNullException("spriteFont");
            }
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
            Vector2 one = Vector2.One;
            spriteFont.Draw(ref text, this, position, color, 0f, Vector2.Zero, ref one, SpriteEffects.None, 0f);
        }

        public void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            Vector2 vector;
            if (spriteFont == null)
            {
                throw new ArgumentNullException("spriteFont");
            }
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
            vector.X = scale;
            vector.Y = scale;
            spriteFont.Draw(ref text, this, position, color, rotation, origin,ref vector, effects, layerDepth);
        }


        //public void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        //{
        //    Vector2 vector;
        //    if (spriteFont == null)
        //    {
        //        throw new ArgumentNullException("spriteFont");
        //    }
        //    if (text == null)
        //    {
        //        throw new ArgumentNullException("text");
        //    }
        //    vector.X = scale;
        //    vector.Y = scale;
        //    spriteFont.Draw(, this, position, color, rotation, origin, vector, effects, layerDepth);
        //} 

        #endregion Public Methods
		
		#region Private Methods
		
		private void restoreRenderState()
        {
            if (this.stateMode == SaveStateMode.SaveState)
                saveState.Apply();
        }

        private void flush()
        {
            switch (sortMode)
            {
                case SpriteSortMode.BackToFront:
                    spriteList.Sort(new BackToFrontSpriteComparer<Sprite>());
                    break;
                case SpriteSortMode.FrontToBack:
                    spriteList.Sort(new FrontToBackSpriteComparer<Sprite>());
                    break;
                case SpriteSortMode.Texture: // nothing here?
                    break;
            }

            foreach (Sprite sprite in spriteList)
            {
                // Set the color, bind the texture for drawing and prepare the texture source
                if (sprite.Color.A <= 0) continue;
                Gl.glColor4f((float)sprite.Color.R / 255f, (float)sprite.Color.G / 255f, (float)sprite.Color.B / 255f, (float)sprite.Color.A / 255f);
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, sprite.Texture.textureId);

                // Setup the matrix
                Gl.glPushMatrix();
                if ((sprite.DestinationRectangle.X != 0) || (sprite.DestinationRectangle.Y != 0))
                    Gl.glTranslatef(sprite.DestinationRectangle.X, sprite.DestinationRectangle.Y, 0f); // Position
                if (sprite.Rotation != 0)
                    Gl.glRotatef(MathHelper.ToDegrees(sprite.Rotation), 0f, 0f, 1f); // Rotation
                if ((sprite.DestinationRectangle.Width != 0 && sprite.Origin.X != 0) || (sprite.DestinationRectangle.Height != 0 && sprite.Origin.Y != 0))
                    Gl.glTranslatef( // Orientation
                        -sprite.Origin.X * (float)sprite.DestinationRectangle.Width / (float)sprite.SourceRectangle.Width,
                        -sprite.Origin.Y * (float)sprite.DestinationRectangle.Height / (float)sprite.SourceRectangle.Height, 0f);

                // Calculate the points on the texture
                float x = (float)sprite.SourceRectangle.X / (float)sprite.Texture.Width;
                float y = (float)sprite.SourceRectangle.Y / (float)sprite.Texture.Height;
                float twidth = (float)sprite.SourceRectangle.Width / (float)sprite.Texture.Width;
                float theight = (float)sprite.SourceRectangle.Height / (float)sprite.Texture.Height;
				
				// Draw
                Gl.glBegin(Gl.GL_QUADS);
                {
                    Gl.glTexCoord2f(x,y + theight);
                    Gl.glVertex2f(0f, sprite.DestinationRectangle.Height);

                    Gl.glTexCoord2f(x + twidth, y + theight);
                    Gl.glVertex2f(sprite.DestinationRectangle.Width, sprite.DestinationRectangle.Height);

                    Gl.glTexCoord2f(x + twidth,y);
                    Gl.glVertex2f(sprite.DestinationRectangle.Width, 0f);

                    Gl.glTexCoord2f(x,y);
                    Gl.glVertex2f(0f, 0f);
                }
                Gl.glEnd();
                Gl.glPopMatrix(); // Finish with the matrix
            }
            spriteList.Clear();
        }

        private void applyGraphicsDeviceSettings()
        {
            // Set the blend mode
							
            switch (spriteBlendMode)
            {
                case SpriteBlendMode.AlphaBlend:
                    Gl.glEnable(Gl.GL_BLEND);
                    Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
                    break;
                case SpriteBlendMode.Additive:
                    Gl.glEnable(Gl.GL_BLEND);
                    Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE);
                    break;
                case SpriteBlendMode.None:
                    Gl.glDisable(Gl.GL_BLEND);
                    break;
                default:
                    throw new NotSupportedException("The given blend mode isn't yet supported.");
            }
			
            Gl.glEnable(Gl.GL_TEXTURE_2D);

            // Reset the projection matrix and use the orthographic matrix
            int[] viewPort = new int[4];
            Gl.glGetIntegerv(Gl.GL_VIEWPORT, viewPort);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glPushMatrix();
            Gl.glLoadIdentity();
            Gl.glOrtho(0, viewPort[2], viewPort[3], 0, -1, 1); // viewPort[2] = width, viewPort[3] = height
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPushMatrix();
            Gl.glLoadIdentity();
        }
		
		#endregion Private Methods

       	#region Comparers
		
		private class BackToFrontSpriteComparer<T> : IComparer<T> where T : Sprite
        {
            public int Compare(T x, T y)
            {
                if (x.LayerDepth > y.LayerDepth)
                    return -1;
                if (x.LayerDepth < y.LayerDepth)
                    return 1;
                return 0;
            }
        }

        private class FrontToBackSpriteComparer<T> : IComparer<T> where T : Sprite
        {
            public int Compare(T x, T y)
            {
                if (x.LayerDepth < y.LayerDepth)
                    return -1;
                if (x.LayerDepth > y.LayerDepth)
                    return 1;
                return 0;
            }
        }        
		
		#endregion
    }
}
