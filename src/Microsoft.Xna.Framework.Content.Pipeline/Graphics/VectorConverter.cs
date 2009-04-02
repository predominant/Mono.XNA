// VectorConverter.cs created with MonoDevelop
// User: lars at 22.53 09.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public static class VectorConverter
	{

#region Public Static Methods
		
		public static Converter<TInput, TOutput> GetConverter<TInput,TOutput>()
		{
			throw new NotImplementedException();
		}

		public static bool TryGetSurfaceFormat(Type vectorType, out SurfaceFormat surfaceFormat)
		{
			throw new NotImplementedException();
		}
		
		public static bool TryGetVectorType(SurfaceFormat surfaceFormat, out Type vectorType)
		{
			throw new NotImplementedException();
		}
		
		public static bool TryGetVectorType(VertexElementFormat vertexElementFormat, out Type vectorType)
		{
			throw new NotImplementedException();
		}
		
		public static bool TryGetVertexElementFormat(Type vectorType, out VertexElementFormat vertexElementFormat)
		{
			throw new NotImplementedException();
		}

#endregion
		
	}
}
