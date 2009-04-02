// ContentBuildLogger.cs created with MonoDevelop
// User: lars at 10.56 21.02.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

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
