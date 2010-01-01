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
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

namespace Microsoft.Xna.Framework.Content.Pipeline.Processors
{
	
	[ContentProcessor]
	public class ModelProcessor : ContentProcessor<NodeContent, ModelContent>
	{
		
#region Constructor

		public ModelProcessor()
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
		
		public virtual bool GenerateTangentFrames 
		{ 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); } 
		}
		
		public virtual bool ResizeTexturesToPowerOfTwo 
		{ 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
		public virtual float RotationX 
		{ 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
		public virtual float RotationY 
		{ 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}

		public virtual float RotationZ 
		{ 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); } 
		}
		
		public virtual float Scale 
		{ 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
		public virtual bool SwapWindingOrder 
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

		public override ModelContent Process(NodeContent input, ContentProcessorContext context)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
#region Protected Methods
		
		protected virtual MaterialContent ConvertMaterial(MaterialContent material, ContentProcessorContext context)
		{
			throw new NotImplementedException();
		}
		
		protected virtual void ProcessGeometryUsingMaterial(MaterialContent material, IEnumerable<GeometryContent> geometryCollection, ContentProcessorContext context)
		{
			throw new NotImplementedException();
		}
		
		protected virtual void ProcessVertexChannel(GeometryContent geometry, int vertexChannelIndex, ContentProcessorContext context)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
		
	}
}
