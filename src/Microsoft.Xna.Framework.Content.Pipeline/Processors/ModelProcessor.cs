// ModelProcessor.cs created with MonoDevelop
// User: lars at 13.14 16.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

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
