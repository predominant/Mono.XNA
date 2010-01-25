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
	
	
	public class PixelBitmapContent<T> : BitmapContent where T : struct, IEquatable<T>
	{
		
		#region Fields
		
		private T[][] pixelData;
		
		#endregion
		
		#region Constructor

        protected PixelBitmapContent()
        {
        }

        public PixelBitmapContent(int width, int height)
            : base(width, height)
        {
        }

		#endregion
		
		#region BitmapContent Overrides
		
		public override byte[] GetPixelData()
		{
			throw new NotImplementedException();
		}
		
		public override void SetPixelData(byte[] sourceData)
		{
			throw new NotImplementedException();
		}
		
		public override string ToString()
		{
			throw new NotImplementedException();
		}

		public override bool TryGetFormat(out SurfaceFormat format)
		{
			throw new NotImplementedException();
		}
		
		protected override bool TryCopyFrom(BitmapContent sourceBitmap, Rectangle sourceRegion, Rectangle destinationRegion)
		{
			throw new NotImplementedException();
		}
		
		protected override bool TryCopyTo(BitmapContent destinationBitmap, Rectangle sourceRegion, Rectangle destinationRegion)
		{
			throw new NotImplementedException();
		}
		
		#endregion
		
		#region Public Methods
	
		public T GetPixel(int x, int y)
		{
			throw new NotImplementedException();
		}
		
		public T[] GetRow(int y)
		{
			throw new NotImplementedException();
		}
		
		public void ReplaceColor(T originalColor, T newColor)
		{
			throw new NotImplementedException();
		}
		
		public void SetPixel(int x, int y, T value)
		{
			throw new NotImplementedException();
		}
		
		#endregion
		
		
		
		
	}
}
