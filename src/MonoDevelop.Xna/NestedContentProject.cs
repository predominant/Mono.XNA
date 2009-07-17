
using System;
using MonoDevelop.Projects;
using MonoDevelop.Core.Serialization;

namespace MonoDevelop.Xna
{
	
	[DataItem]
	public class NestedContentProject : ProjectItem
	{
		#region Properties
		
		[ItemProperty("Include")]
		private string include;
		public string Include
		{
			get { return include; }
			set { include = value; }
		}
		
		[ItemProperty("Project")]
		private string projectId;
		public string ProjectId
		{
			get { return projectId; }
			set { projectId = value; }
		}
		
		[ItemProperty("Visible")]
		private bool visible;
		public bool Visible
		{
			get { return visible; }
			set { visible = value; }
		}
		
		private ContentProject project;
		public ContentProject Project
		{
		 	get { return project; }
			set { 
				project = value; 
				projectId = project.ItemId;
			}
		}
		
		#endregion
		
		#region Constructors
		
		public NestedContentProject()
		{
			visible = false;
			include = "";
			project = null;
		}
		
		public NestedContentProject(ContentProject project, string include)
		{
			this.visible = false;
			this.include = include;
			this.Project = project;			
		}
		
		#endregion
	}
}
