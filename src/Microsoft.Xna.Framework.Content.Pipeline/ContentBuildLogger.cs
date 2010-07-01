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
using System.Collections.Generic;
using System.IO;

namespace Microsoft.Xna.Framework.Content.Pipeline
{
	
	
	public abstract class ContentBuildLogger
	{	
		#region Fields
		
		private Stack<String> fileStack;
		private string loggerRootDirectory;
		
		#endregion Fields
		
		#region Constructor
		
		protected ContentBuildLogger()
		{
			this.fileStack = new Stack<String>();
		}
		
		#endregion Constructor
		
		#region Properties
		
		public string LoggerRootDirectory {
			get { return loggerRootDirectory; }
			set { loggerRootDirectory = value; }
		}
		
		#endregion Properties
		
		#region Public Methods
		
		public void PushFile(string filename)
		{
			fileStack.Push(filename);
		}
		
		public void PopFile()
		{
			fileStack.Pop();
		}
		
		public abstract void LogImportantMessage(string message, Object[] messageArgs);
		
		public abstract void LogMessage(string message, Object[] messageArgs);
		
		public abstract void LogWarning(string helpLink, ContentIdentity contentIdentity, string message, Object[] messageArgs);
		
		#endregion Public Methods

		#region Protected Methods
		
		protected string GetCurrentFilename(ContentIdentity contentIdentity)
		{
			if ((contentIdentity != null) && !string.IsNullOrEmpty(contentIdentity.SourceFilename))
			{
				return GetFilename(contentIdentity.SourceFilename, loggerRootDirectory);
			}
			if (this.fileStack.Count > 0)
			{
				return GetFilename(fileStack.Peek(), loggerRootDirectory);
			}
			return null;
		}

		#endregion Protected Methods

		#region Private Methods

		private static string GetFilename(string filename, string RootDir)
		{
			string fullPath = RootDir;
			if (string.IsNullOrEmpty(fullPath))
			{
				fullPath = Path.GetFullPath("./");
			}
			if (filename.StartsWith(fullPath, StringComparison.OrdinalIgnoreCase))
			{
				return filename.Substring(fullPath.Length);
			}
			return filename;
		}
				
		#endregion Private Methods
				
	}
}
