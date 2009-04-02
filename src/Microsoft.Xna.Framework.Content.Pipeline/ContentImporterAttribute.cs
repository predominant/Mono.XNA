// ContentImporterAttribute.cs created with MonoDevelop
// User: lars at 03.24 22.02.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Collections.Generic;

namespace Microsoft.Xna.Framework.Content.Pipeline
{
	
	
	public class ContentImporterAttribute : Attribute
	{

#region Constructors
		
		public ContentImporterAttribute (string fileExtension)
		{
			this.fileExtensions = new List<string>();
			this.fileExtensions.Add(fileExtension);
		}
		
		public ContentImporterAttribute (string[] fileExtensions)
		{		
			this.fileExtensions = new List<string>(fileExtensions); 
		}
		
#endregion
		
#region Properties
		
		private bool cacheImportedData;
		public bool CacheImportedData 
		{ 
			get { return cacheImportedData; } 
			set { cacheImportedData = value; } 
		}

		private string defaultProcessor;
		public string DefaultProcessor 
		{ 
			get { return defaultProcessor; } 
			set { defaultProcessor = value; } 
		}
		
		private string displayName;
		public virtual string DisplayName 
		{ 
			get { return displayName; }
			set { displayName = value; } 
		}
		
		private List<string> fileExtensions;		
		public IEnumerable<string> FileExtensions 
		{ 
			get { return fileExtensions; }
		}

#endregion

	}
}
