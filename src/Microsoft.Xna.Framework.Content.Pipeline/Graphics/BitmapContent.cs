// BitmapContent.cs created with MonoDevelop
// User: lars at 02.18 07.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{	
	
	public abstract class BitmapContent : ContentItem
	{

#region Constructors
		
		protected BitmapContent()
		{
		}
		
		protected BitmapContent(int width, int height)
		{
		}

#endregion
		
#region Properties

		public int Height 
		{ 
			get; 
			set; 
		}
		
		public int Width 
		{ 
			get; 
			set; 
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
