#region License
/*
MIT License
Copyright © 2009 The Mono.Xna Team

All rights reserved.

Authors:
Lars Magnusson (lavima)

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
using MonoDevelop.Projects;
using MonoDevelop.Core.Serialization;

namespace MonoDevelop.Xna
{
	
	[DataItem("Compile")]
	public class ContentSource : ProjectItem
	{		
		#region Properties
		
		[ItemProperty("Include")]
		private string include;
		public string Include {
			get { return include; }
			set { include = value; }
		}
		
		[ItemProperty("Importer")]
		private string importer;
		public string Importer {
			get { return importer; }
			set { importer = value; }
		}
		
		[ItemProperty("Processor")]
		private string processor;
		public string Processor {
			get { return processor; }
			set { processor = value; }
		}
		
		[ItemProperty("Name")]
		private string name;
		public string Name {
			get { return name; }
			set { name = value; }
		}
		
		#endregion
		
		#region Constructors
		
		public ContentSource()
		{
		}
		
		public ContentSource(string include, string name, string importer, string processor)
		{
			this.include = include;	
			this.name = name;
			this.importer = importer;
			this.processor = processor;
		}
		
		#endregion
		
		
		
	}
}
