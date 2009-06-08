
using System;
using System.Xml;
using MonoDevelop.Core;
using MonoDevelop.Core.Serialization;
using MonoDevelop.Projects;
using MonoDevelop.Projects.Dom;

namespace MonoDevelop.Xna
{

	public class XnaAppProject : DotNetProject
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
			nestedContentProjects.Add(new NestedContentProject());
		}

		public XnaAppProject ()
		{
			construct();
		}
		
		public XnaAppProject (string languageName)
			: base (languageName)
		{
			construct();
		}
		
		public XnaAppProject (string languageName, ProjectCreateInformation info, XmlElement projectOptions)
			: base (languageName, info, projectOptions)
		{
			construct();
		}

        #endregion


        #region DotNetProject Overrides

        protected override BuildResult DoBuild (IProgressMonitor monitor, string itemConfiguration)
        {
            return base.DoBuild(monitor, itemConfiguration); 
        }
		
		public override void Save (MonoDevelop.Core.IProgressMonitor monitor)
		{
			
			base.Save (monitor);
		}

        #endregion
		
    }

}
