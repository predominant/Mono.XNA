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
			ContentProject project = new ContentProject(language, info, projectOptions);
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
