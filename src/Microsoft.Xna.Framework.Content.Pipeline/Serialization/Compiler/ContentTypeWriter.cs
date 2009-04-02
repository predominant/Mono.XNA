// ContentTypeWriter.cs created with MonoDevelop
// User: lars at 18.01 20.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler
{
	
	
	public abstract class ContentTypeWriter
	{

#region Constructor
		
		protected ContentTypeWriter()
		{
		}
		
#endregion
		
#region Properties

		public Type TargetType 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		public virtual int TypeVersion 
		{ 
			get { throw new NotImplementedException(); }
		}
		
#endregion

#region Public Methods

		public abstract string GetRuntimeReader(TargetPlatform targetPlatform);
		
		public virtual string GetRuntimeType(TargetPlatform targetPlatform)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
#region Protected Methods

		protected virtual void Initialize(ContentCompiler compiler)
		{
			throw new NotImplementedException();
		}
		
		protected internal virtual bool ShouldCompressContent(TargetPlatform targetPlatform, Object value)
		{
			throw new NotImplementedException();
		}
		
		protected internal abstract void Write(ContentWriter output, Object value);
		
#endregion
		
	}
}
