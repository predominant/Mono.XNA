#region License
/*
MIT License
Copyright © 2009 The Mono.Xna Team

All rights reserved.

Authors:
Lars Magnusson (lavima)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion License

using System;
using System.IO;
using System.Xml;
using MonoDevelop.Core;
using MonoDevelop.Projects;
using MonoDevelop.Projects.Dom;
using MonoDevelop.Projects.Formats.MSBuild;

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
			contentInfo.SolutionName = info.SolutionName;
			contentInfo.SolutionPath = info.SolutionPath;
			contentInfo.ProjectBasePath = info.ProjectBasePath.Combine("Content");
			contentInfo.ProjectName = "Content";
			
			ContentProject contentProject = (ContentProject)Services.ProjectService.CreateProject("ContentProject", contentInfo, projectOptions);
			FilePath includePath = FilePath.Empty.Combine("Content").Combine(contentProject.FileName);
			NestedContentProject nestedContent = new NestedContentProject(contentProject, includePath);
			project.NestedContentProjects.Add(nestedContent);
			
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
