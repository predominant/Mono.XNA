#region License
/*
MIT License
Copyright © 2011 The MonoXNA Team

All rights reserved.

Authors: 
 * Lars Magnusson <lavima@gmail.com>

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

namespace Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler
{
	
	
	public abstract class ContentTypeWriter
	{
		#region Fields
		
		private Type targetType;
		private int typeVersion;
		
		#endregion Fields
		
		#region Constructor
		
		protected ContentTypeWriter(Type targetType)
		{
			this.targetType = targetType;
		}
		
		#endregion Constructor
		
		#region Properties

		public Type TargetType { 
			get { return targetType; }
		}
		
		public virtual int TypeVersion { 
			get { return typeVersion; }
		}
		
		#endregion Properties

		#region Methods

		public abstract string GetRuntimeReader(TargetPlatform targetPlatform);
		
		public virtual string GetRuntimeType(TargetPlatform targetPlatform)
		{
			return targetType.FullName;
		}
		
		internal void RegisterAndInitialize(ContentCompiler compiler)
		{
			Initialize(compiler);	
		}
		
		protected virtual void Initialize(ContentCompiler compiler)
		{
			compiler.RegisterTypeWriter(this);
		}
		
		protected internal virtual bool ShouldCompressContent(TargetPlatform targetPlatform, Object value)
		{
			return true;
		}
		
		protected internal abstract void Write(ContentWriter output, Object value);
		
		#endregion Methods		
	}
	
	public abstract class ContentTypeWriter<T> : ContentTypeWriter
	{

		#region Constructor
		
		protected ContentTypeWriter()
			: base(typeof(T))
		{
		}

		#endregion Constructor
		
		
		#region Methods

		protected internal override void Write(ContentWriter output, Object value)
		{
			Write(output, (T)value);
		}
		
		protected internal abstract void Write(ContentWriter output, T value);
		
		#endregion Methods
		
	}
}
