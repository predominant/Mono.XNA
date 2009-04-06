
using System;
using System.Xml;
using MonoDevelop.Core;
using MonoDevelop.Projects;
using MonoDevelop.Projects.Dom;

namespace XnaAddin
{
	
	
	public class XnaContentProject : DotNetProject
    {

        #region Constructors

		public XnaContentProject ()
		{
		}
		
		public XnaContentProject (string languageName)
			: base (languageName)
		{
		}
		
		public XnaContentProject (string languageName, ProjectCreateInformation info, XmlElement projectOptions)
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
