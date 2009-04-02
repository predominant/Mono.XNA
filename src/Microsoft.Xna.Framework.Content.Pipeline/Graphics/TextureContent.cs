// TextureContent.cs created with MonoDevelop
// User: lars at 08.46 07.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public abstract class TextureContent : ContentItem
	{

#region Constructor
		
		protected TextureContent(MipmapChainCollection faces)
		{
		}

#endregion
		
#region Properties

		public MipmapChainCollection Faces 
		{ 
			get { throw new NotImplementedException(); }
		}
		
#endregion
		
#region Public Methods
		
		public void ConvertBitmapType(Type newBitmapType)
		{
			throw new NotImplementedException();
		}
		
		public virtual void GenerateMipmaps(bool overwriteExistingMipmaps)
		{
			throw new NotImplementedException();
		}
		
		public virtual void Validate()
		{
			throw new NotImplementedException();
		}

		protected void Validate(bool facesMustHaveSameMipCount)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
		
	}
}
