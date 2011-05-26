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
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Build.Framework;

namespace Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler
{
	
	
	public sealed class ContentCompiler
	{
		#region Fields
		
		private Dictionary<Type, ContentTypeWriter> typeWriters;
		
		#endregion Fields

		#region Constructor
		
		internal ContentCompiler(ITaskItem[] pipelineAssembliesItems)
		{
			typeWriters = new Dictionary<Type, ContentTypeWriter>();
			initializeTypeWriters(pipelineAssembliesItems);
		}

		#endregion Constructor
		
		#region Methods

		public ContentTypeWriter GetTypeWriter(Type type)
		{
			if (typeWriters.ContainsKey(type))
				return typeWriters[type];
			
			return null;
		}
		
		internal void RegisterTypeWriter(ContentTypeWriter typeWriter)
		{
			typeWriters.Add(typeWriter.TargetType, typeWriter);	
		}
		
		private void initializeTypeWriters(ITaskItem[] pipelineAssembliesItems)
		{
			foreach (ITaskItem pipelineAssemblyItem in pipelineAssembliesItems)
			{
				Assembly pipelineAssembly = Assembly.Load(pipelineAssemblyItem.GetMetadata("OriginalItemSpec"));
				IEnumerable<Type> writerTypes = from writerType in pipelineAssembly.GetTypes()
					where writerType.IsDefined(typeof(ContentTypeWriterAttribute), false) 
					select writerType;
				
				foreach (Type writerType in writerTypes)
				{
					ContentTypeWriter writer = (ContentTypeWriter)Activator.CreateInstance(writerType);
					writer.RegisterAndInitialize(this);
				}
			}
		}
		
		#endregion Methods
		
	}
}
