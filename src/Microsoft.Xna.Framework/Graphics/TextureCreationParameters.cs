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
using System.Runtime.InteropServices;

namespace Microsoft.Xna.Framework.Graphics
{
    [Serializable]
    public struct TextureCreationParameters
    {
		#region Private Fields
		
        private int m_Width;
        private int m_Height;
        private int m_Depth;
        private int m_MipLevels;
        private SurfaceFormat m_Format;
        private Color m_ColorKey;
        private FilterOptions m_Filter;
        private FilterOptions m_MipFilter;
        private static TextureCreationParameters m_Default;
		
		#endregion Private Fields
		
		#region Properties

        public int Width { 
			get { return m_Width; } 
			set { m_Width = value; } 
		}
        
        public int Height { 
			get { return m_Height; } 
			set { m_Height = value; } 
		}
        
        public int Depth { 
			get { return m_Depth; } 
			set { m_Depth = value; } 
		}
        
        public int MipLevels { 
			get { return m_MipLevels; } 
			set { m_MipLevels = value; } 
		}
        
        public SurfaceFormat Format { 
			get { return m_Format; } 
			set { m_Format = value; } 
		}
        
        public Color ColorKey { 
			get { return m_ColorKey; } 
			set { m_ColorKey = value; } 
		}
        
        public FilterOptions Filter { 
			get { return m_Filter; } 
			set { m_Filter = value; } 
		}
        
        public FilterOptions MipFilter { 
			get { return m_MipFilter; } 
			set { m_MipFilter = value; } 
		}
        
        public static TextureCreationParameters Default { 
			get { return m_Default; } 
		}
		
		#endregion Properties
		
		#region Constructors
        
        public TextureCreationParameters(int width, int height, int depth, int mipLevels, SurfaceFormat format, 
			TextureUsage textureUsage, Color colorKey, FilterOptions filter, FilterOptions mipFilter)
        {
            m_Width = width;
            m_Height = height;
            m_Depth = depth;
            m_MipLevels = mipLevels;
            m_Format = format;
            m_ColorKey = colorKey;
            m_Filter = filter;
            m_MipFilter = mipFilter;
		}

        static TextureCreationParameters()
        {
            TextureCreationParameters.m_Default = new TextureCreationParameters(
                0, 0, 0, 0,
                SurfaceFormat.Unknown,
                TextureUsage.None,
                Color.TransparentBlack,
                FilterOptions.Dither | FilterOptions.Triangle,
                FilterOptions.Box);
        }
		
		#endregion Constructors
		
		#region Operators
   
        public static bool operator !=(TextureCreationParameters left, TextureCreationParameters right) { throw new NotImplementedException(); }

        public static bool operator ==(TextureCreationParameters left, TextureCreationParameters right) { throw new NotImplementedException(); }
		
		#endregion Operators
 
		#region Object Overrides
		
        public override bool Equals(object obj) 
		{ 
			throw new NotImplementedException(); 
		}

        public override int GetHashCode() 
		{ 
			throw new NotImplementedException(); 
		}

        public override string ToString() 
		{ 
			throw new NotImplementedException(); 
		}
		
		#endregion Object Overrides
    }
}
