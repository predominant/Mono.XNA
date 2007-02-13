#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team
http://www.taoframework.com
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

namespace Microsoft.Xna.Framework.Graphics
{
    public class BasicEffect : Effect
    {
        protected BasicEffect(GraphicsDevice device, BasicEffect clone)
            : base(device, clone)
        {
            throw new NotImplementedException();
        }

        public BasicEffect(GraphicsDevice device, EffectPool effectPool)
            : base(device, new byte[]{0}, CompilerOptions.None, effectPool)

        {
            throw new NotImplementedException();
        }

        public override Effect Clone(GraphicsDevice device)
        {
            throw new NotImplementedException();
        }

        public void EnableDefaultLighting()
        {
            throw new NotImplementedException();
        }

        public float Alpha { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public Vector3 AmbientLightColor { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public Vector3 DiffuseColor { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public BasicDirectionalLight DirectionalLight0 { get { throw new NotImplementedException(); } }

        public BasicDirectionalLight DirectionalLight1 { get { throw new NotImplementedException(); } }

        public BasicDirectionalLight DirectionalLight2 { get { throw new NotImplementedException(); } }

        public Vector3 EmissiveColor { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public Vector3 FogColor { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public bool FogEnabled { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public float FogEnd { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public float FogStart { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public bool LightingEnabled { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public Matrix Projection { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public Vector3 SpecularColor { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public float SpecularPower { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public Texture2D Texture { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public bool TextureEnabled { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public bool VertexColorEnabled { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public Matrix View { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        public Matrix World { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
    }
}
