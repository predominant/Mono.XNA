
using System;

namespace MonoDevelop.Xna
{


	public class ContentProcessorInfo
	{
		#region Private Fields
		
		private Type type;
		private string displayName;
		
		#endregion Private Fields
		
		#region Constructor

		public ContentProcessorInfo (Type type, string displayName)
		{
			this.type = type;
			this.displayName = displayName;
		}
		
		#endregion Constructor
		
		#region Properties
		
		public Type Type {
			get { return type; }	
		}
		
		public virtual string DisplayName { 
			get { return displayName; }
		}
		
		#endregion Properties
	}
}
