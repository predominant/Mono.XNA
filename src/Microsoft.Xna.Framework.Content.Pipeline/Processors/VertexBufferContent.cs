// VertexBufferContent.cs created with MonoDevelop
// User: lars at 03.33 20.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Xna.Framework.Content.Pipeline.Processors
{
	
	
	public class VertexBufferContent : ContentItem
	{

#region Constructor
		
		public VertexBufferContent()
		{
		}

		public VertexBufferContent(int size)
		{
			
		}

#endregion
		
#region Properties

		public byte[] VertexData 
		{ 
			get { throw new NotImplementedException(); }
		}
		
#endregion
		
#region Public Methods

		public static int SizeOf(Type type)
		{
			throw new NotImplementedException();
		}
		
		public void Write<T>(int offset, int stride, IEnumerable<T> data)
		{
			throw new NotImplementedException();
		}
		
		public void Write<T>(int offset, int stride, IEnumerable<T> data, TargetPlatform targetPlatform)
		{
			throw new NotImplementedException();
		}
		
		public void Write(int offset, int stride, Type dataType, IEnumerable data)
		{
			throw new NotImplementedException();
		}
		
		public void Write(int offset, int stride, Type dataType, IEnumerable data, TargetPlatform targetPlatform)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
	}
}
