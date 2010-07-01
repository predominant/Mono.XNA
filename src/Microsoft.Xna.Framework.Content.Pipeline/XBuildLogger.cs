using System;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Microsoft.Xna.Framework.Content.Pipeline
{
	internal class XBuildLogger : ContentBuildLogger
	{
		#region Fields
		
		private TaskLoggingHelper log;
		
		#endregion Fields
		
		#region Constructor
		
		public XBuildLogger (TaskLoggingHelper log)
		{
			this.log = log;
		}
		
		#endregion Constructor
		
		#region ContentBuildLogger Overrides
		
		public override void LogImportantMessage (string message, object[] messageArgs)
		{
			log.LogMessage(MessageImportance.High, message, messageArgs);
		}		
		
		public override void LogMessage (string message, object[] messageArgs)
		{
			log.LogMessage(message, messageArgs);
		}		
		
		public override void LogWarning (string helpLink, ContentIdentity contentIdentity, string message, object[] messageArgs)
		{
			log.LogWarning(message, messageArgs);
		}
		
		#endregion ContentBuildLogger Overrides
		
	}
}

