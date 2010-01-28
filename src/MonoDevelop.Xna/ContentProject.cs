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
using System.Collections;
using System.Collections.Generic;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Core;
using MonoDevelop.Core.Serialization;
using MonoDevelop.Projects;
using MonoDevelop.Projects.Dom;
using MonoDevelop.Projects.Formats.MSBuild;
using System.Reflection;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace MonoDevelop.Xna
{	
	
	public class ContentProject : DotNetProject
    {
		#region Fields
		
		[ItemProperty("XnaFrameworkVersion")]
		private string xnaFrameworkVersion = "v2.0";
		
		private List<ContentImporterInfo> importers;
		private List<ContentProcessorInfo> processors;

		#endregion Fields
		
		#region Properties
		
		public IEnumerable<ContentImporterInfo> Importers {
			get { return importers.ToArray(); }
		}
		
		public IEnumerable<ContentProcessorInfo> Processors {
			get { return processors.ToArray(); }	
		}
		
		#endregion Properties
		
        #region Constructors
		
		public ContentProject (string languageName)
			: base (languageName)
		{
			//Visible = false;
			importers = new List<ContentImporterInfo>();
			processors = new List<ContentProcessorInfo>();
		}

		public ContentProject (string language, ProjectCreateInformation info, XmlElement projectOptions)
			: base (language, info, projectOptions)
		{
			//Visible = false;
			importers = new List<ContentImporterInfo>();
			processors = new List<ContentProcessorInfo>();
		}
		
		#endregion Constructors
		
		#region Public Methods
		
		public ICollection GetImporterNames()
		{
			List<string> ret = new List<string>();
			foreach (ContentImporterInfo info in importers)
				ret.Add(info.DisplayName);
			return ret;
		}
		
		public ICollection GetProcessorNames()
		{
			List<string> ret = new List<string>();
			foreach (ContentProcessorInfo info in processors)
				ret.Add(info.DisplayName);
			return ret;
		}
		
		#endregion Public Methods
		
		#region Private Methods
		
		/// <summary>
		/// Search through the assembly and find content importers and processors.
		/// </summary>
		private void findPipelineEntries (ProjectReference reference)
		{
			string[] filenames = reference.GetReferencedFileNames(IdeApp.Workspace.ActiveConfiguration);
			if (filenames.Length == 0)
				return;
			
			Assembly assembly = Assembly.LoadFrom(filenames[0]);			
			foreach (Type type in assembly.GetTypes())
			{
				foreach (object attribute in type.GetCustomAttributes(true))
				{
					if (attribute is ContentImporterAttribute)
					{
						ContentImporterAttribute ia = attribute as ContentImporterAttribute;
						if (ia.DisplayName != null && ia.DisplayName != string.Empty)
							importers.Add(new ContentImporterInfo(type, ia.DisplayName, ia.FileExtensions, ia.DefaultProcessor, ia.CacheImportedData));
						else
							importers.Add(new ContentImporterInfo(type, type.Name, ia.FileExtensions, ia.DefaultProcessor, ia.CacheImportedData));
					}
					else if (attribute is ContentProcessorAttribute)
					{
						ContentProcessorAttribute pa = attribute as ContentProcessorAttribute;
						if(pa.DisplayName != null && pa.DisplayName != string.Empty)
							processors.Add(new ContentProcessorInfo(type, pa.DisplayName));
						else
							processors.Add(new ContentProcessorInfo(type, type.Name));
					}
				}
			}
		}
		
		#endregion Private Methods


        #region DotNetProject Overrides
		
		public override string ProjectType {
			get  { return "Content"; }
		}
		
		protected override void OnSave (IProgressMonitor monitor)
		{
			base.OnSave (monitor);
		}

		protected override void OnEndLoad ()
		{
			
			base.OnEndLoad ();
		}

		protected override void OnReferenceAddedToProject (ProjectReferenceEventArgs e)
		{
			findPipelineEntries(e.ProjectReference);
			base.OnReferenceAddedToProject(e);
		}

        #endregion DotNetProject Overrides
	}
}