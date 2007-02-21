using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework.Tests
{
    public class TestGame : Game
    {
        GraphicsDeviceManager graphics;
        ContentManager content;


        public TestGame()
        {
            graphics = new GraphicsDeviceManager(this);
            content = new ContentManager(Services);
        }
        public GraphicsDeviceManager GraphicsDeviceManager
        {
            get { return graphics; }
        }
        protected override void Initialize()
        {


            base.Initialize();
        }

        protected override void LoadGraphicsContent(bool loadAllContent)
        {
            if (loadAllContent)
            {
            }

        }

        protected override void UnloadGraphicsContent(bool unloadAllContent)
        {
            if (unloadAllContent == true)
            {
                content.Unload();
            }
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
        }
    }

}
