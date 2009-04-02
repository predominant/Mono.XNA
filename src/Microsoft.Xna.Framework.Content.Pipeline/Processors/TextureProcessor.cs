// TextureProcessor.cs created with MonoDevelop
// User: lars at 03.28 20.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

namespace Microsoft.Xna.Framework.Content.Pipeline.Processors
{
	
	
	public class TextureProcessor : ContentProcessor<TextureContent, TextureContent>
	{

#region Constructor
		
		public TextureProcessor()
		{
		}

#endregion
		
#region Properties

		public virtual Color ColorKeyColor 
		{ 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
		public virtual bool ColorKeyEnabled 
		{ 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
		public virtual bool GenerateMipmaps 
		{ 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
		public virtual bool ResizeToPowerOfTwo 
		{ 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
		public virtual TextureProcessorOutputFormat TextureFormat 
		{ 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
#endregion
		
#region Public Methods

		public override TextureContent Process(TextureContent input, ContentProcessorContext context)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
	}
}
