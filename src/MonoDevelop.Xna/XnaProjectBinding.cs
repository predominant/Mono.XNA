
using System;
using System.IO;
using System.Xml;
using MonoDevelop.Core;
using MonoDevelop.Projects;
using MonoDevelop.Projects.Dom;

namespace MonoDevelop.Xna
{
	
	
	public class XnaProjectBinding : IProjectBinding
	{
		
		#region Constructor
		
		public XnaProjectBinding()
		{
		}
	
		#endregion
		
		#region IProjectBinding Implementation
		
		public string Name {
			get { return "XnaProject"; }
		}
		
		public Project CreateProject (ProjectCreateInformation info, XmlElement projectOptions)
		{
			string lang = projectOptions.GetAttribute ("language");
			return CreateProject (lang, info, projectOptions);
		}
		
		public Project CreateProject (string language, ProjectCreateInformation info, XmlElement projectOptions)
		{
			
			XnaProject project = new XnaProject(language, info, projectOptions);
			
			ProjectCreateInformation contentInfo = new ProjectCreateInformation();
			contentInfo.CombineName = info.CombineName;
			contentInfo.CombinePath = info.CombinePath;
			contentInfo.ProjectBasePath = Path.Combine(info.ProjectBasePath, "Content");
			contentInfo.ProjectName = "Content";			
			
			ContentProject contentProject = (ContentProject)Services.ProjectService.CreateProject("ContentProject", contentInfo, projectOptions);
			contentProject.FileName = Path.Combine (contentInfo.ProjectBasePath, contentInfo.ProjectName);
			if(!Directory.Exists(contentProject.BaseDirectory))
				Directory.CreateDirectory(contentProject.BaseDirectory);
			
			project.NestedContentProjects.Add(new NestedContentProject(project, contentProject, contentProject.FileName.Replace(info.ProjectBasePath, ".")));
			
			return project;
		}
		
		public Project CreateSingleFileProject (string file)
		{
			return null;			
		}

		public bool CanCreateSingleFileProject (string sourceFile)
		{
			return false;	
		}
		
		#endregion
	}
}
