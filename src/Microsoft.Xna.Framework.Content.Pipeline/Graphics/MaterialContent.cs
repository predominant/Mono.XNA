// MaterialContent.cs created with MonoDevelop
// User: lars at 08.43 04.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public class MaterialContent : ContentItem
	{

#region Constructor
		
		public MaterialContent()
		{
		}
		
#endregion
		
#region Properties

		public TextureReferenceDictionary Textures 
		{ 
			get { throw new NotImplementedException(); }
		}
		
#endregion
		
#region Protected Methods

		protected T GetReferenceTypeProperty<T>(string key)
		{
			throw new NotImplementedException();
		}
		
		protected ExternalReference<TextureContent> GetTexture(string key)
		{
			throw new NotImplementedException();
		}
		
		protected Nullable<T> GetValueTypeProperty<T>(string key) where T : struct
		{
			throw new NotImplementedException();
		}
		
		protected void SetProperty<T>(string key, T value)
		{
			throw new NotImplementedException();
		}
		
		protected void SetTexture(string key, ExternalReference<TextureContent> value)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
	}
}
