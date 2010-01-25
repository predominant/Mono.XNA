#region License
/*
MIT License
Copyright © 2009 The Mono.Xna Team

All rights reserved.

Authors: Lars Magnusson (lavima@gmail.com)

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

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public class EffectMaterialContent : MaterialContent
	{
		
#region Constructor
		
		public EffectMaterialContent()
		{
		}
		
#endregion

#region Public Fields

		public const string CompiledEffectKey = "CompiledEffect";
		public const string EffectKey = "Effect";
		
#endregion
		
#region Properties

        [ContentSerializerIgnore]
        public ExternalReference<CompiledEffect> CompiledEffect
        {
            get
            {
                return base.GetReferenceTypeProperty<ExternalReference<CompiledEffect>>("CompiledEffect");
            }
            set
            {
                base.SetProperty<ExternalReference<CompiledEffect>>("CompiledEffect", value);
            }
        }

        [ContentSerializerIgnore]
        public ExternalReference<EffectContent> Effect
        {
            get
            {
                return base.GetReferenceTypeProperty<ExternalReference<EffectContent>>("Effect");
            }
            set
            {
                base.SetProperty<ExternalReference<EffectContent>>("Effect", value);
            }
        }
		
#endregion
		
	}
}
