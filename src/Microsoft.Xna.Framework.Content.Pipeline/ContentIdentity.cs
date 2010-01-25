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

namespace Microsoft.Xna.Framework.Content.Pipeline
{
	
	[Serializable]
	public class ContentIdentity
	{
		
#region Constructors
		
		public ContentIdentity()
		{
		}
		
		public ContentIdentity(string sourceFilename)
		{
			this.sourceFileName = sourceFilename;
		}
		
		public ContentIdentity(string sourceFilename, string sourceTool)
		{
			this.sourceFileName = sourceFilename;
			this.sourceTool = sourceTool;
		}
		
		public ContentIdentity(string sourceFilename, string sourceTool, string fragmentIdentifier)
		{
			this.sourceFileName = sourceFilename;
			this.sourceTool = sourceTool;
			this.fragmentIdentifier = fragmentIdentifier;
		}
		
#endregion
		
#region Properties
		
		private string sourceFileName;
        [ContentSerializer(Optional = true)]
		public string SourceFilename 
		{ 
			get { return sourceFileName; } 
			set { sourceFileName = value; } 
		}

		private string sourceTool;
        [ContentSerializer(Optional = true)]
		public string SourceTool 
		{ 
			get { return sourceTool; }
			set { sourceTool = value; } 
		}
		
		private string fragmentIdentifier;
        [ContentSerializer(Optional = true)]
		public string FragmentIdentifier 
		{ 
			get { return fragmentIdentifier; }
			set { fragmentIdentifier = value; } 
		}
		
#endregion
		
	}
}
