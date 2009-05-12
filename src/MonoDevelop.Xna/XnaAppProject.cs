
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
		
		#endregion

        #region Constructors

		public XnaAppProject ()
		{
		}
		
		public XnaAppProject (string languageName)
			: base (languageName)
		{
		}
		
		public XnaAppProject (string languageName, ProjectCreateInformation info, XmlElement projectOptions)
			: base (languageName, info, projectOptions)
		{
			
		}

        #endregion


        #region DotNetProject Overrides

        protected override BuildResult DoBuild (IProgressMonitor monitor, string itemConfiguration)
        {
			
            return base.DoBuild(monitor, itemConfiguration); 
        }

        #endregion
		
    }

}
