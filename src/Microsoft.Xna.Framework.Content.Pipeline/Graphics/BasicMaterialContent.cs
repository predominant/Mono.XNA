// BasicMaterialContent.cs created with MonoDevelop
// User: lars at 08.42 04.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using Microsoft.Xna.Framework;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public class BasicMaterialContent : MaterialContent
	{

#region Constructor
		
		public BasicMaterialContent()
		{

		}
		
#endregion
		
#region Public Fields

		public const string AlphaKey = "AlphaKey";
		public const string DiffuseColorKey = "DiffuseColorKey";
		public const string EmissiveColorKey = "EmissiveColorKey";
		public const string SpecularColorKey = "SpecularColorKey";
		public const string SpecularPowerKey = "SpecularPowerKey";
		public const string TextureKey = "TextureKey";
		public const string VertexColorEnabledKey = "VertexColorEnabledKey";

#endregion
		
#region Properties

		public Nullable<float> Alpha 
		{ 
			get { return OpaqueData[AlphaKey] as Nullable<float>; }
			set { OpaqueData[AlphaKey] = value; } 
		}
		
		public Nullable<Vector3> DiffuseColor 
		{ 
			get { return OpaqueData[DiffuseColorKey] as Nullable<Vector3>; } 
			set { OpaqueData[DiffuseColorKey] = value; }
		}
		
		public Nullable<Vector3> EmissiveColor 
		{ 
			get { return OpaqueData[EmissiveColorKey] as Nullable<Vector3>; } 
			set { OpaqueData[EmissiveColorKey] = value; }
		}
		
		public Nullable<Vector3> SpecularColor 
		{ 
			get { return OpaqueData[SpecularColorKey] as Nullable<Vector3>; } 
			set { OpaqueData[SpecularColorKey] = value; }
		}
		
		public Nullable<float> SpecularPower 
		{ 
			get { return OpaqueData[SpecularPowerKey] as Nullable<float>; } 
			set { OpaqueData[SpecularPowerKey] = value; }
		}
		
		public ExternalReference<TextureContent> Texture
		{ 
			get { return Textures[TextureKey] as ExternalReference<TextureContent>; } 
			set { Textures[TextureKey] = value; }
		}
		
		public Nullable<bool> VertexColorEnabled 
		{ 
			get { return OpaqueData[VertexColorEnabledKey] as Nullable<bool>; } 
			set { OpaqueData[VertexColorEnabledKey] = value; }
		}	
		
#endregion
		
	}
}
