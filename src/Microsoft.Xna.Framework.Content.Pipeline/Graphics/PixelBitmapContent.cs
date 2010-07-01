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
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public class PixelBitmapContent<T> : BitmapContent where T : struct, IEquatable<T>
	{
		#region Fields
		
		private static int pixelSize;
		private T[][] pixelData;
		
		#endregion Fields
		
		#region Properties
		
		private static int PixelSize {
			get { 
				if (pixelSize == 0)
					pixelSize = Marshal.SizeOf(typeof(T));
				return pixelSize;
			}
		}
		
		#endregion Properties
		
		#region Constructors
		
		static PixelBitmapContent()
		{
			pixelSize = 0;	
		}

        public PixelBitmapContent(int width, int height)
            : base(width, height)
        {
			pixelData = new T[height][];
			for (int y = 0; y < height; y++)
				pixelData[y] = new T[width];
        }

		protected PixelBitmapContent() {}

        #endregion Constructors
		
		#region Methods
	
		public T GetPixel(int x, int y)
		{
			return pixelData[y][x];
		}
		
		public T[] GetRow(int y)
		{
			return pixelData[y];
		}
		
		public void ReplaceColor(T originalColor, T newColor)
		{
			for (int y = 0; y < Height; y++)
			{
				for (int x = 0; x < Width; x++)
				{
					T color = pixelData[y][x];
					if (color.Equals(originalColor))
						pixelData[y][x] = newColor;
				}
			}
		}
		
		public void SetPixel(int x, int y, T value)
		{
			pixelData[y][x] = value;
		}
		
		#endregion Methods
		
		#region BitmapContent Overrides
		
		public override byte[] GetPixelData()
		{
			byte[] ret = new byte[Width * Height * PixelSize];
			int numBytesInRow = Width * PixelSize;
			
			// This won't work
			for (int y = 0; y < Height; y++)
				Buffer.BlockCopy(pixelData[y], 0, ret, y * numBytesInRow, numBytesInRow);
			
			return ret;
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
		
		#endregion BitmapContent Overrides
		
		
		
		
		
		
	}
}
