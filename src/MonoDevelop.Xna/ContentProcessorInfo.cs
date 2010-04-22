
using System;

namespace MonoDevelop.Xna
{


	public class ContentProcessorInfo
	{
		#region Private Fields
		
		private Type type;
		private string name;
		
		#endregion Private Fields
		
		#region Constructor

		public ContentProcessorInfo (Type type, string name)
		{
			this.type = type;
			this.name = name;
		}
		
		#endregion Constructor
		
		#region Properties
		
		public Type Type {
			get { return type; }	
		}
		
		public virtual string Name { 
			get { return name; }
		}
		
		#endregion Properties
	}
}
