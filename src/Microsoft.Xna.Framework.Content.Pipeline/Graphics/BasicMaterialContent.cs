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
