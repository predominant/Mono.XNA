
using System;
using System.Collections.Generic;

namespace MonoDevelop.Xna
{


	public class ContentImporterInfo
	{
		#region Private Fields
		
		private Type type;
		private string displayName;
		private IEnumerable<string> fileExtensions;	
		private bool cacheImportedData;
		private string defaultProcessor;
		
		#endregion Private Fields

		#region Constructor
		
		public ContentImporterInfo (Type type, string displayName, IEnumerable<string> fileExtensions, string defaultProcessor, bool cacheImportedData)
		{
			this.type = type;
			this.displayName = displayName;
			this.fileExtensions = new List<string>(fileExtensions);
			this.defaultProcessor = defaultProcessor;
			this.cacheImportedData = cacheImportedData;
		}
		
		#endregion Constructor
		
		#region Properties
				
		public Type Type {
			get { return type; }	
		}
		
		public virtual string DisplayName { 
			get { return displayName; }
		}
		
		public IEnumerable<string> FileExtensions { 
			get { return fileExtensions; }
		}	
		
		public string DefaultProcessor { 
			get { return defaultProcessor; } 
		}
		
		public bool CacheImportedData { 
			get { return cacheImportedData; } 
		}

		#endregion Properties
	}
}
