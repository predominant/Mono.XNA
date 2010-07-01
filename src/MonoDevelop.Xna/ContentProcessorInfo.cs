
using System;

namespace MonoDevelop.Xna
{


	public class ContentProcessorInfo
	{
		#region Private Fields
		
		private string name;
		private string displayName;
		
		#endregion Private Fields
		
		#region Constructor

		public ContentProcessorInfo (string name, string displayName)
		{
			this.name = name;
			this.name = name;
		}
		
		#endregion Constructor
		
		#region Properties
		
		public virtual string Name { 
			get { return name; }
		}

		public virtual string DisplayName { 
			get { return displayName; }
		}
		
		#endregion Properties
	}
}
