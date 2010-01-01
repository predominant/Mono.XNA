#region License
/*
MIT License
Copyright © 2009 The Mono.Xna Team

All rights reserved.

Authors: Lars Magnusson (lavima@gmail.com)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion License

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

		public const string AlphaKey = "Alpha";
		public const string DiffuseColorKey = "DiffuseColor";
		public const string EmissiveColorKey = "EmissiveColor";
		public const string SpecularColorKey = "SpecularColor";
		public const string SpecularPowerKey = "SpecularPower";
		public const string TextureKey = "Texture";
		public const string VertexColorEnabledKey = "VertexColorEnabled";

#endregion
		
#region Properties
        
        [ContentSerializerIgnore]
		public Nullable<float> Alpha 
		{ 
			get { return OpaqueData[AlphaKey] as Nullable<float>; }
			set { OpaqueData[AlphaKey] = value; } 
		}

        [ContentSerializerIgnore]
		public Nullable<Vector3> DiffuseColor 
		{ 
			get { return OpaqueData[DiffuseColorKey] as Nullable<Vector3>; } 
			set { OpaqueData[DiffuseColorKey] = value; }
		}

        [ContentSerializerIgnore]
		public Nullable<Vector3> EmissiveColor 
		{ 
			get { return OpaqueData[EmissiveColorKey] as Nullable<Vector3>; } 
			set { OpaqueData[EmissiveColorKey] = value; }
		}

        [ContentSerializerIgnore]
		public Nullable<Vector3> SpecularColor 
		{ 
			get { return OpaqueData[SpecularColorKey] as Nullable<Vector3>; } 
			set { OpaqueData[SpecularColorKey] = value; }
		}

        [ContentSerializerIgnore]
		public Nullable<float> SpecularPower 
		{ 
			get { return OpaqueData[SpecularPowerKey] as Nullable<float>; } 
			set { OpaqueData[SpecularPowerKey] = value; }
		}

        [ContentSerializerIgnore]
		public ExternalReference<TextureContent> Texture
		{ 
			get { return Textures[TextureKey] as ExternalReference<TextureContent>; } 
			set { Textures[TextureKey] = value; }
		}

        [ContentSerializerIgnore]
		public Nullable<bool> VertexColorEnabled 
		{ 
			get { return OpaqueData[VertexColorEnabledKey] as Nullable<bool>; } 
			set { OpaqueData[VertexColorEnabledKey] = value; }
		}	
		
#endregion
		
	}
}
