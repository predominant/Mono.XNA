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
using MonoDevelop.Projects;
using MonoDevelop.Projects.Formats.MSBuild;
using MonoDevelop.Core.Serialization;


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
		public string Include {
			get { return include; }
			set { include = value; }
		}
		
		/// <value>
		/// The content project ID
		/// </value>
		[ItemProperty("Project")]
		private string projectId;
		public string ProjectId {
			get { return projectId; }
			set { projectId = value; }
		}
		
		/// <value>
		/// Wether visible or not
		/// </value>
		[ItemProperty("Visible")]
		private bool visible;
		public bool Visible {
			get { return visible; }
			set { visible = value; }
		}
		
		/// <value>
		/// A reference to the content project itself
		/// </value>
		private ContentProject project;
		public ContentProject Project {
		 	get { return project; }
			set { 
				project = value; 
				projectId = project.ItemId;
			}
		}
		
		#endregion Properties
		
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
