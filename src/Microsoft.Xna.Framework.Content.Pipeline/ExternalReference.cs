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
using System.IO;

namespace Microsoft.Xna.Framework.Content.Pipeline
{
	
	
	public sealed class ExternalReference<T> : ContentItem
	{

#region Constructors
		
		public ExternalReference()
		{
		}
		
		public ExternalReference(string filename)
		{
			if (filename != null) this.filename = Path.GetFullPath(filename);
		}
		
		public ExternalReference(string filename, ContentIdentity relativeToContent)
		{
			if (filename != null)
			{
				if (filename.Length == 0) throw new ArgumentNullException("filename");
				if (relativeToContent == null) throw new ArgumentNullException("relativeToContent");
				if (string.IsNullOrEmpty(relativeToContent.SourceFilename)) throw new ArgumentNullException("relativeToContent.SourceFilename");
				this.filename = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(relativeToContent.SourceFilename), filename));
			}
		}
		
#endregion 

#region Properties

		private string filename;
		public string Filename 
		{ 
			get { return filename; }
			set {
				if (value != null)
				{
					string fullPath = Path.GetFullPath(value);
					if (!fullPath.Equals(value.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar), StringComparison.OrdinalIgnoreCase)) throw new ArgumentException("Filename not absolute");					
				}
				this.filename = value;
				}
		}
		
#endregion
		
	}
}
