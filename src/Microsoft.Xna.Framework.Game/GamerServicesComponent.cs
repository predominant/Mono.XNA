#if XNA_1_1
#else
using System;

namespace Microsoft.Xna.Framework.GamerServices
{
    public class GamerServicesComponent : GameComponent
    {
        public GamerServicesComponent(Game game)
            : base(game)
        {
        }

        private void GamerServicesDispatcher_InstallingTitleUpdate(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            base.Game.Exit();
        }

        public override void Initialize()
        {
            throw new NotImplementedException();
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
            base.Update(gameTime);
        }
    }
}
#endif
