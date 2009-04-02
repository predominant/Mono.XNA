// MaterialProcessor.cs created with MonoDevelop
// User: lars at 11.13 16.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

namespace Microsoft.Xna.Framework.Content.Pipeline.Processors
{
	
	
	[ContentProcessor]
	public class MaterialProcessor : ContentProcessor<MaterialContent, MaterialContent>
	{

#region Constructor
		
		public MaterialProcessor()
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
		
		public virtual bool ResizeTexturesToPowerOfTwo 
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

		public override MaterialContent Process(MaterialContent input, ContentProcessorContext context)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
#region Protected Properties

		protected virtual ExternalReference<CompiledEffect> BuildEffect(ExternalReference<EffectContent> effect, ContentProcessorContext context)
		{
			throw new NotImplementedException();
		}
		
		protected virtual ExternalReference<TextureContent> BuildTexture(string textureName, ExternalReference<TextureContent> texture, ContentProcessorContext context)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
	}
}
