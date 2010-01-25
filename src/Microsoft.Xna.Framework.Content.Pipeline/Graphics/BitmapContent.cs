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
	
	public abstract class BitmapContent : ContentItem
	{
		#region Fields
        
        private int height;
        private int width;

		#endregion

		#region Constructors
		
		protected BitmapContent()
		{
		}
		
		protected BitmapContent(int width, int height)
		{
			
		}

		#endregion
		
		#region Properties

        [ContentSerializer]
        public int Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                this.height = value;
            }
        }

        [ContentSerializer]
        public int Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                this.width = value;
            }
        }
		
		#endregion
		
		#region Public Methods

		public static void Copy(BitmapContent sourceBitmap, BitmapContent destinationBitmap)
		{
			throw new NotImplementedException();
		}
		
		public static void Copy(BitmapContent sourceBitmap, Rectangle sourceRegion, BitmapContent destinationBitmap, Rectangle destinationRegion)
		{
			throw new NotImplementedException();
		}
		
		public abstract byte[] GetPixelData();
		
		public abstract void SetPixelData(byte[] sourceData);
		
		public abstract bool TryGetFormat(out SurfaceFormat format);
		
		public override string ToString()
		{
			throw new NotImplementedException();
		}
		
		#endregion
		
		#region Protected Methods
		
		protected static void ValidateCopyArguments(BitmapContent sourceBitmap, Rectangle sourceRegion, BitmapContent destinationBitmap, Rectangle destinationRegion)
		{
			throw new NotImplementedException();
		}

		protected abstract bool TryCopyFrom(BitmapContent sourceBitmap, Rectangle sourceRegion, Rectangle destinationRegion);
		
		protected abstract bool TryCopyTo(BitmapContent destinationBitmap, Rectangle sourceRegion, Rectangle destinationRegion);
		
		#endregion				
		
	}
}
