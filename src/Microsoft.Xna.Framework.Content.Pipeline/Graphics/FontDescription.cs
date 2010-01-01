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
using System.Collections.Generic;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	public class FontDescription : ContentItem
	{

#region Constructors

        public FontDescription(string fontName, float size, float spacing)
            : this(fontName, size, spacing, FontDescriptionStyle.Regular)
        {
        }

        public FontDescription(string fontName, float size, float spacing, FontDescriptionStyle fontStyle)
        {
            this.FontName = fontName;
            this.Size = size;
            this.Style = fontStyle;
            this.Spacing = spacing;
        }

        public FontDescription(string fontName, float size, float spacing, FontDescriptionStyle fontStyle, bool useKerning)
        {
            this.FontName = fontName;
            this.Size = size;
            this.Style = fontStyle;
            this.Spacing = spacing;
            this.UseKerning = useKerning;
        }
		
#endregion 
		
#region Properties

		private List<char> characters;		
		[ContentSerializerIgnore]
		public ICollection<char> Characters 
		{ 
			get { return characters; }
		}

        private bool useKerning;
        [ContentSerializer(Optional = true)]
        public bool UseKerning
        {
            get
            {
                return this.useKerning;
            }
            set
            {
                this.useKerning = value;
            }
        }

		private string fontName;		
		[ContentSerializer]
		public string FontName 
		{ 
			get { return fontName; }
			set { fontName = value; }
		}

        private char? defaultCharacter;
        [ContentSerializer(Optional = true)]
        public char? DefaultCharacter
        {
            get
            {
                return defaultCharacter;
            }
            set
            {
                defaultCharacter = value;
            }
        }

		private float size;
		public float Size 
		{ 
			get { return size; }
			set { size = value; }
		}

		private float spacing;
        [ContentSerializer(Optional = true)]
		public float Spacing 
		{ 
			get { return spacing; }
			set { spacing = value; }
		}
		
		private FontDescriptionStyle style;
		public FontDescriptionStyle Style 
		{ 
			get { return style; }
			set { style = value; }
		}
		
#endregion
		
	}
}
