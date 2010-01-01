using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework.Content
{
    internal class EffectReader : ContentTypeReader<Effect>
    {
        private static EffectPool effectpool;

        public EffectReader()
        {
        }

        internal static EffectPool EffectPool
        {
            get
            {
                if (effectpool == null)
                {
                    effectpool = new EffectPool();
                }
                return effectpool;
            }
        }

        protected internal override Effect Read(ContentReader input, Effect existingInstance)
        {
            int count = input.ReadInt32();
            
            return new Effect(input.GraphicsDevice,input.ReadBytes(count),CompilerOptions.None, EffectPool);
        }
    }
}
