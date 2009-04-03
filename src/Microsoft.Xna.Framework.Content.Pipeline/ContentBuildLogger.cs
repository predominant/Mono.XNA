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
	
	
	public abstract class ContentBuildLogger
	{	

#region Constructor
		
		protected ContentBuildLogger()
		{
		}
		
#endregion
		
#region Properties
		
		private string loggerRootDirectory;
		public string LoggerRootDirectory
		{
			get { return loggerRootDirectory; }
			set { loggerRootDirectory = value; }
		}
		
#endregion
		
#region Public Methods
		
		public void PushFile(string filename)
		{
			throw new NotImplementedException();
		}
		
		public void PopFile()
		{
			throw new NotImplementedException();
		}
		
		public abstract void LogImportantMessage(string message, Object[] messageArgs);
		
		public abstract void LogMessage(string message, Object[] messageArgs);
		
		public abstract void LogWarning(string helpLink, ContentIdentity contentIdentity, string message, Object[] messageArgs);
		
#endregion

#region Protected Methods
		
		protected string GetCurrentFilename(ContentIdentity contentIdentity)
		{
			throw new NotImplementedException();
		}

#endregion
		
	}
}
