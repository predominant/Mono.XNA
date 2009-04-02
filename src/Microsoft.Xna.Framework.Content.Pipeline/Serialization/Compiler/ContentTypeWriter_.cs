// ContentTypeWriter_.cs created with MonoDevelop
// User: lars at 18.01 20.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler
{
	
	
	public abstract class ContentTypeWriter<T> : ContentTypeWriter
	{

#region Constructor
		
		public ContentTypeWriter()
		{
		}

#endregion
		
		
#region Public Methods

		protected internal override void Write(ContentWriter output, Object value)
		{
			
		}
		
		protected internal abstract void Write(ContentWriter output, T value);
		
#endregion
		
	}
}
