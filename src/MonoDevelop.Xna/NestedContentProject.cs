
using System;
using System.IO;
using MonoDevelop.Projects;
using MonoDevelop.Core.Serialization;
using MonoDevelop.Core.ProgressMonitoring;

namespace MonoDevelop.Xna
{
	
	/// <summary>
	/// Project item that refer to the a nested content project. 
	/// </summary>
	[DataItem]
	public class NestedContentProject : ProjectItem
	{
		#region Properties
		
		/// <value>
		/// The relative path to the content project file
		/// </value>
		[ItemProperty("Include")]
		private string include;
		public string Include
		{
			get { return include; }
			set { include = value; }
		}
		
		/// <value>
		/// The content project ID
		/// </value>
		[ItemProperty("Project")]
		private string projectId;
		public string ProjectId
		{
			get { return projectId; }
			set { projectId = value; }
		}
		
		/// <value>
		/// Wether visible or not
		/// </value>
		[ItemProperty("Visible")]
		private bool visible;
		public bool Visible
		{
			get { return visible; }
			set { visible = value; }
		}
		
		private XnaProject parent;
		public XnaProject Parent
		{
			get { return parent; }
			set { parent = value; }
		}
		
		private ContentProject project;
		public ContentProject Project
		{
		 	get { 
				if (project==null)
					project = (ContentProject)ContentProject.LoadProject(Path.Combine(parent.BaseDirectory, include.Substring(2)), new SimpleProgressMonitor());
				
				return project; 
			}
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
			parent = null;
		}
		
		public NestedContentProject(XnaProject parent, ContentProject project, string include)
		{
			this.visible = false;
			this.include = include;
			this.Project = project;	
			this.parent = parent;
		}
		
		#endregion
	}
}
