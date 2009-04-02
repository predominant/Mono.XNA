// PixelBitmapContent.cs created with MonoDevelop
// User: lars at 08.26 07.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public class PixelBitmapContent<T> : BitmapContent where T : struct, IEquatable<T>
	{

#region Constructor
		
		public PixelBitmapContent()
		{
		}
		
		public PixelBitmapContent(int width, int height)
		{
			
		}

#endregion
		
#region Public Methods
	
		public T GetPixel(int x, int y)
		{
			throw new NotImplementedException();
		}
		
		public override byte[] GetPixelData()
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
		
#endregion
		
#region Protected Methods

		protected override bool TryCopyFrom(BitmapContent sourceBitmap, Rectangle sourceRegion, Rectangle destinationRegion)
		{
			throw new NotImplementedException();
		}
		
		protected override bool TryCopyTo(BitmapContent destinationBitmap, Rectangle sourceRegion, Rectangle destinationRegion)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
	}
}
