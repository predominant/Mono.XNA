
using System;
using System.Xml;
using MonoDevelop.Projects;

namespace MonoDevelop.Xna
{


	public class ContentProjectBinding : IProjectBinding
	{
		
		#region Constructor
		
		public ContentProjectBinding()
		{
		}
	
		#endregion
		
		#region IProjectBinding Implementation
		
		public string Name {
			get { return "ContentProject"; }
		}
		
		public Project CreateProject (ProjectCreateInformation info, XmlElement projectOptions)
		{
			string lang = projectOptions.GetAttribute ("language");
			return CreateProject (lang, info, projectOptions);
		}
		
		public Project CreateProject (string language, ProjectCreateInformation info, XmlElement projectOptions)
		{
			return new ContentProject(language, info, projectOptions);
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
