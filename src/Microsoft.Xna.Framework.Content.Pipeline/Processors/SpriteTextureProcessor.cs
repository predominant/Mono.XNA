// SpriteTextureProcessor.cs created with MonoDevelop
// User: lars at 03.22 20.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.ComponentModel;
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework.Content.Pipeline.Processors
{
	
	
	public class SpriteTextureProcessor : TextureProcessor
	{

#region Constructor
		
		public SpriteTextureProcessor()
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
		
		[Browsable(false)]
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
