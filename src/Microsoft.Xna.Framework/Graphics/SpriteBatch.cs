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
        private class Sprite
        {
            public Texture2D texture;
            public Rectangle destinationRectangle;
            public Rectangle sourceRectangle;
            public Color color;
            public float rotation;
            public Vector2 origin;
            public SpriteEffects effects;
            public float layerDepth;
        }

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
        public GraphicsDevice GraphicsDevice
        {
            get { return device; }
        }

        public bool IsDisposed
        {
            get { return disposed; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public object Tag
        {
            get { return tag; }
            set { tag = value; }
        }
        #endregion Properties


        #region Methods

        public void Begin()
        {
            Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Deferred, SaveStateMode.None);
        }

        public void Begin(SpriteBlendMode blendMode)
        {
            Begin(blendMode, SpriteSortMode.Deferred, SaveStateMode.None);
        }

        public void Begin(SpriteBlendMode blendMode, SpriteSortMode sortMode, SaveStateMode stateMode)
        {
            //to respect order Begin/Draw/end
            if (isRunning)
            {
                throw new InvalidOperationException("Begin cannot be called again until End has been successfully called.");
            }

            if (stateMode == SaveStateMode.SaveState)
                saveState = new StateBlock(this.GraphicsDevice);

            spriteBlendMode = blendMode;
            this.sortMode = sortMode;
            if (sortMode == SpriteSortMode.Immediate)
                ApplyGraphicsDeviceSettings();
            isRunning = true;
        }

        public void End()
        {
            if (!isRunning)
                throw new InvalidOperationException("Begin must be called successfully before End can be called.");
            if (sortMode == SpriteSortMode.Deferred)
            {
                ApplyGraphicsDeviceSettings();
                Flush();
            }
            Gl.glDisable(Gl.GL_TEXTURE_2D);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glPopMatrix();
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPopMatrix();

            RestoreRenderState();
            isRunning = false;
        }

        private void RestoreRenderState()
        {
            if (this.stateMode == SaveStateMode.SaveState)
                saveState.Apply();
        }

        private class BackToFrontSpriteComparer<T> : IComparer<T> where T : Sprite
        {
            public int Compare(T x, T y)
            {
                if (x.layerDepth > y.layerDepth)
                    return -1;
                if (x.layerDepth < y.layerDepth)
                    return 1;
                return 0;
            }
        }

        private class FrontToBackSpriteComparer<T> : IComparer<T> where T : Sprite
        {
            public int Compare(T x, T y)
            {
                if (x.layerDepth < y.layerDepth)
                    return -1;
                if (x.layerDepth > y.layerDepth)
                    return 1;
                return 0;
            }
        }

        private void Flush()
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

            foreach (Sprite sp in spriteList)
            {
                // Set the color, bind the texture for drawing and prepare the texture source
                if (sp.color.A <= 0) return;
                Gl.glColor4f((float)sp.color.R / 255f, (float)sp.color.G / 255f, (float)sp.color.B / 255f, (float)sp.color.A / 255f);
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, sp.texture.textureID);

                // Setup the matrix
                Gl.glPushMatrix();
                if ((sp.destinationRectangle.X != 0) || (sp.destinationRectangle.Y != 0))
                    Gl.glTranslatef(sp.destinationRectangle.X, sp.destinationRectangle.Y, 0f); // Position
                if (sp.rotation != 0)
                    Gl.glRotatef(sp.rotation, 0f, 0f, 1f); // Rotation
                if ((sp.destinationRectangle.Width != 0 && sp.origin.X != 0) || (sp.destinationRectangle.Height != 0 && sp.origin.Y != 0))
                    Gl.glTranslatef( // Orientation
                        -sp.origin.X * (float)sp.destinationRectangle.Width / (float)sp.sourceRectangle.Width,
                        -sp.origin.Y * (float)sp.destinationRectangle.Height / (float)sp.sourceRectangle.Height, 0f);

                // Calculate the points on the texture
                float x = (float)sp.sourceRectangle.X / (float)sp.texture.textureWidth;
                float y = (float)sp.sourceRectangle.Y / (float)sp.texture.textureHeight;
                float twidth = (float)sp.sourceRectangle.Width / (float)sp.texture.textureWidth;
                //float theight = (float)sp.sourceRectangle.Height / (float)sp.texture.textureHeight;
                float theight = 1.0f;

                // Draw
                Gl.glBegin(Gl.GL_QUADS);
                {
                    Gl.glTexCoord2f(x, 1f - y);
                    Gl.glVertex2f(0f, 0f);

                    Gl.glTexCoord2f(x + twidth, 1f - y);
                    Gl.glVertex2f(sp.destinationRectangle.Width, 0f);

                    Gl.glTexCoord2f(x + twidth, 1f - y - theight);
                    Gl.glVertex2f(sp.destinationRectangle.Width, sp.destinationRectangle.Height);

                    Gl.glTexCoord2f(x, 1f - y - theight);
                    Gl.glVertex2f(0f, sp.destinationRectangle.Height);
                }
                Gl.glEnd();
                Gl.glPopMatrix(); // Finish with the matrix
            }
            spriteList.Clear();
        }

        private void ApplyGraphicsDeviceSettings()
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

        public void Draw(Texture2D texture, Rectangle destinationRectangle, Nullable<Rectangle> sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth)
        {
            if (!isRunning)
                throw new InvalidOperationException("Begin must be called successfully before a Draw can be called.");

            Sprite sprite = new Sprite();
            sprite.texture = texture;
            sprite.sourceRectangle = sourceRectangle.HasValue ? sourceRectangle.Value : new Rectangle(0, 0, texture.Width, texture.Height);
            sprite.destinationRectangle = destinationRectangle;
            sprite.color = color;
            sprite.rotation = rotation;
            sprite.origin = origin;
            sprite.effects = effects;
            sprite.layerDepth = layerDepth;
            spriteList.Add(sprite);

            if (sortMode == SpriteSortMode.Immediate)
                Flush();
        }

        public void Draw(Texture2D texture, Vector2 position, Color color)
        {
            Draw(texture, position, null, color);
        }

        public void Draw(Texture2D texture, Vector2 position, Nullable<Rectangle> sourceRectangle, Color color)
        {
            if (!isRunning)
                throw new InvalidOperationException("Begin must be called successfully before a Draw can be called.");

            Sprite sprite = new Sprite();
            sprite.texture = texture;
            sprite.sourceRectangle = sourceRectangle.HasValue ? sourceRectangle.Value : new Rectangle(0, 0, texture.Width, texture.Height);
            sprite.destinationRectangle = new Rectangle((int)position.X, (int)position.Y, sprite.sourceRectangle.Width, sprite.sourceRectangle.Height);
            sprite.color = color;
            sprite.rotation = 0f;
            sprite.origin = Vector2.Zero;
            sprite.effects = SpriteEffects.None;
            sprite.layerDepth = 0f;
            spriteList.Add(sprite);

            if (sortMode == SpriteSortMode.Immediate)
                Flush();
        }

        public void Draw(Texture2D texture, Vector2 position, Nullable<Rectangle> sourceRectangle, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            Draw(texture, position, sourceRectangle, color, rotation, origin, new Vector2(scale), effects, layerDepth);
        }

        public void Draw(Texture2D texture, Vector2 position, Nullable<Rectangle> sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            if (!isRunning)
                throw new InvalidOperationException("Begin must be call before Draw");//fix msg

            Sprite sprite = new Sprite();
            sprite.texture = texture;
            sprite.sourceRectangle = sourceRectangle.HasValue ? sourceRectangle.Value : new Rectangle(0, 0, texture.Width, texture.Height);
            sprite.destinationRectangle = new Rectangle((int)position.X, (int)position.Y, (int)((float)sprite.sourceRectangle.Width * scale.X), (int)((float)sprite.sourceRectangle.Height * scale.Y));
            sprite.color = color;
            sprite.rotation = rotation;
            sprite.origin = origin;
            sprite.effects = effects;
            sprite.layerDepth = layerDepth;
            spriteList.Add(sprite);

            if (sortMode == SpriteSortMode.Immediate)
                Flush();
        }

        #endregion Methods


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
    }
}
