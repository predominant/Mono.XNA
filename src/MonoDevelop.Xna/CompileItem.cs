
using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Build.Framework;

namespace MonoDevelop.Xna
{
	
	
	public class CompileItem : ITaskItem
	{
		#region Private Fields
		
		private string itemSpec;
		private Dictionary<string, string> metadata;
		
		#endregion Private Fields
		
		#region Constructor
		
		public CompileItem()
		{
		}
		
		#endregion Constructor
		
		#region ITaskItem Implementation
		
		public string ItemSpec { 
			get { return ItemSpec; }
			set { itemSpec = value; }
		}
		
		public int MetadataCount { 
			get { return metadata.Count; }
		}
		
		public ICollection MetadataNames { 
			get { return metadata.Keys; }
		}
		
		public IDictionary CloneCustomMetadata()
		{
			return new Dictionary<string, string>(metadata);
		}
		
		public void CopyMetadataTo(ITaskItem destinationItem)
		{
			
		}
		
		public string GetMetadata(string metadataName)
		{
			return metadata[metadataName];
		}
		
		public void RemoveMetadata(string metadataName)
		{
			metadata.Remove(metadataName);
		}
		
		public void SetMetadata(string metadataName, string metadataValue)
		{
			metadata[metadataName] = metadataValue;
		}
		
		#endregion ITaskItem Implementation

	}
}
