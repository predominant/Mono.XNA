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

namespace Microsoft.Xna.Framework.Graphics
{
    public sealed class BasicDirectionalLight
    {
        private bool enabled;
        private EffectParameter diffuseColorParam;
        private EffectParameter directionParam;
        private EffectParameter specularColorParam;
        private Vector3 cachedDiffuseColor;
        private Vector3 cachedSpecularColor;

        internal BasicDirectionalLight(EffectParameter direction, EffectParameter diffuseColor, EffectParameter specularColor)
        {
            this.directionParam = direction;
            this.diffuseColorParam = diffuseColor;
            this.specularColorParam = specularColor;
        }

        internal void Copy(BasicDirectionalLight from)
        {
            this.enabled = from.enabled;
            this.cachedDiffuseColor = from.cachedDiffuseColor;
            this.cachedSpecularColor = from.cachedSpecularColor;
            this.diffuseColorParam.SetValue(this.cachedDiffuseColor);
            this.specularColorParam.SetValue(this.cachedSpecularColor);
        }

        public Vector3 DiffuseColor
        {
            get
            {
                return this.cachedDiffuseColor;
            }
            set
            {
                if (this.enabled)
                {
                    this.diffuseColorParam.SetValue(value);
                }
                this.cachedDiffuseColor = value;
            }
        }

        public Vector3 Direction
        {
            get
            {
                return this.directionParam.GetValueVector3();
            }
            set
            {
                this.directionParam.SetValue(value);
            }
        }

        public bool Enabled
        {
            get
            {
                return this.enabled;
            }
            set
            {
                if (this.enabled != value)
                {
                    this.enabled = value;
                    if (this.enabled)
                    {
                        this.diffuseColorParam.SetValue(this.cachedDiffuseColor);
                        this.specularColorParam.SetValue(this.cachedSpecularColor);
                    }
                    else
                    {
                        this.diffuseColorParam.SetValue(Vector3.Zero);
                        this.specularColorParam.SetValue(Vector3.Zero);
                    }
                }
            }
        }

        public Vector3 SpecularColor
        {
            get
            {
                return this.cachedSpecularColor;
            }
            set
            {
                if (this.enabled)
                {
                    this.specularColorParam.SetValue(value);
                }
                this.cachedSpecularColor = value;
            }
        }
    }
}
