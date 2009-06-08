
using System;
using MonoDevelop.Projects;
using MonoDevelop.Core.Serialization;

namespace MonoDevelop.Xna
{
	
	[DataItem]
	public class NestedContentProject : ProjectItem
	{
		#region Constants
		
		public const string DefaultContentProject = "Content/Content.contentproj";
		
		#endregion
		
		#region Properties
		
		[ItemProperty("Include")]
		private string include;
		public string Include
		{
			get { return include; }	
		}
		
		[ItemProperty("Project")]
		private string project;
		public string Project
		{
			get { return project; }
			set { project = value; }
		}
		
		[ItemProperty("Visible")]
		private bool visible;
		public bool Visible
		{
			get { return visible; }
			set { visible = value; }
		}
		
		#endregion
		
		#region Constructor
		
		public NestedContentProject()
		{
			include = DefaultContentProject;
			visible = false;
		}
		
		#endregion
	}
}
