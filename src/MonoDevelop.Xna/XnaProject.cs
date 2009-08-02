
using System;
using System.Xml;
using System.IO;
using MonoDevelop.Core;
using MonoDevelop.Core.Serialization;
using MonoDevelop.Projects;
using MonoDevelop.Projects.Dom;
using MonoDevelop.Core.ProgressMonitoring;


namespace MonoDevelop.Xna
{

	public class XnaProject : DotNetProject
    {
		#region Fields
		
		[ItemProperty("XnaFrameworkVersion")]
		protected string xnaFrameworkVersion = "v2.0";
		
		#endregion
		
		#region Properties
		
		[ItemProperty("XnaPlatform")]
		protected XnaPlatformType xnaPlatform;
		public XnaPlatformType XnaPlatform {
			get { return xnaPlatform; }
			set { xnaPlatform = value; }
		}
		
		protected NestedContentProjectCollection nestedContentProjects;
		public NestedContentProjectCollection NestedContentProjects
		{
			get { return nestedContentProjects; }	
		}
		
		#endregion

        #region Constructors
		
		private void construct()
		{
			nestedContentProjects = new NestedContentProjectCollection();			
			Items.Bind(nestedContentProjects);
		}

		public XnaProject ()
		{
			construct();
		}
		
		public XnaProject (string languageName)
			: base (languageName)
		{
			construct();
		}
		
		public XnaProject (string languageName, ProjectCreateInformation info, XmlElement projectOptions)
			: base (languageName, info, projectOptions)
		{
			construct();			
		}

        #endregion


        #region DotNetProject Overrides
		
		public override string ProjectType {
			get  { return "Xna"; }
		}
				
		protected override BuildResult DoBuild (IProgressMonitor monitor, string itemConfiguration)
        {
            return base.DoBuild(monitor, itemConfiguration); 
        }
		
		
		public override void Save (IProgressMonitor monitor)
		{
			Console.WriteLine("Save");
			foreach(NestedContentProject nestedProj in nestedContentProjects)
				nestedProj.Project.Save(monitor);
			
			base.Save (monitor);
		}
		
		protected override void OnEndLoad ()
		{
			Console.WriteLine("EndLoad");
			foreach(NestedContentProject project in nestedContentProjects)
				project.Parent = this;
		}

        #endregion
		
    }

}
