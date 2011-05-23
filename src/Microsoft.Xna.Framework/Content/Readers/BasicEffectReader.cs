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
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework.Content.Readers
{
    class BasicEffectReader : ContentTypeReader<BasicEffect>
    {
        private static Dictionary<GraphicsDevice, BasicEffect> sharedEffects;

        public BasicEffectReader()
        {
            // Do nothing
        }

        static BasicEffectReader()
        {
            sharedEffects = new Dictionary<GraphicsDevice, BasicEffect>();
        }

        private static BasicEffect GetSharedEffect(GraphicsDevice device)
        {
            BasicEffect effect;
            if (!sharedEffects.TryGetValue(device, out effect))
            {
                effect = new BasicEffect(device, null);
                sharedEffects.Add(device, effect);
                device.Disposing += new EventHandler(BasicEffectReader.RemoveDevice);
            }
            return effect;
        }

        private static void RemoveDevice(object sender, EventArgs e)
        {
            GraphicsDevice key = (GraphicsDevice)sender;
            sharedEffects[key].Dispose();
            sharedEffects.Remove(key);
        }

        protected internal override BasicEffect Read(ContentReader input, BasicEffect existingInstance)
        {
            GraphicsDevice graphicsDevice = input.GraphicsDevice;
            BasicEffect effect = (BasicEffect)GetSharedEffect(graphicsDevice).Clone(graphicsDevice);
            Texture texture = input.ReadExternalReference<Texture>();
            //Skip because Effects aren't implemented
            //if (texture != null)
            //{
            //    Texture2D textured = texture as Texture2D;
            //    if (textured == null)
            //    {
            //        throw new ContentLoadException("BasicEffect can only Texture2D");
            //    }
            //    effect.Texture = textured;
            //    effect.TextureEnabled = true;
            //}
            /*effect.DiffuseColor =*/ input.ReadVector3();
            /*effect.EmissiveColor =*/ input.ReadVector3();
            /*effect.SpecularColor =*/ input.ReadVector3();
            /*effect.SpecularPower =*/ input.ReadSingle();
            /*effect.Alpha =*/ input.ReadSingle();
            /*effect.VertexColorEnabled =*/ input.ReadBoolean();
            return effect;
        }

    }
}
