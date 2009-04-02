// Dxt3BitmapContent.cs created with MonoDevelop
// User: lars at 03.03 07.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public class Dxt3BitmapContent : DxtBitmapContent
	{

#region Constructor
		
		public Dxt3BitmapContent(int width, int height)
			: base (0, width, height)
		{
		}

#endregion
		
#region Public Methods

		public override bool TryGetFormat(out SurfaceFormat format)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
	}
}
