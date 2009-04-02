// ModelTextureProcessor.cs created with MonoDevelop
// User: lars at 03.05 20.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace Microsoft.Xna.Framework.Content.Pipeline.Processors
{
	
	[ContentProcessor]
	public class ModelTextureProcessor : TextureProcessor
	{

#region Constructor
		
		public ModelTextureProcessor()
		{
		}

#endregion
		
#region Properties

		public override Color ColorKeyColor 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		public override bool ColorKeyEnabled 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		public override bool GenerateMipmaps 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		public override bool ResizeToPowerOfTwo 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		public override TextureProcessorOutputFormat TextureFormat 
		{ 
			get { throw new NotImplementedException(); }
		}
		
#endregion
		
	}
}
