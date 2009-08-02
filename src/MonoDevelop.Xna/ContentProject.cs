
using System;
using System.Xml;
using MonoDevelop.Core;
using MonoDevelop.Core.Serialization;
using MonoDevelop.Projects;
using MonoDevelop.Projects.Dom;

namespace MonoDevelop.Xna
{	
	
	public class ContentProject : DotNetProject
    {
		#region Fields
		
		[ItemProperty("XnaFrameworkVersion")]
		protected string xnaFrameworkVersion = "v2.0";

		#endregion
		
		#region Properties
		
		private CompileCollection compileCollection;
		public CompileCollection CompileCollection
		{
			get { return compileCollection; }	
		}
		
		#endregion
		
        #region Constructors
		
		public ContentProject (string languageName)
			: base (languageName)
		{
		}

		public ContentProject (string language, ProjectCreateInformation info, XmlElement projectOptions)
			: base (language, info, projectOptions)
		{
			compileCollection = new CompileCollection();
			Items.Bind(compileCollection);
		}
		
		#endregion


        #region DotNetProject Overrides
		
		public override string ProjectType {
			get  { return "Content"; }
		}
		
		protected override BuildResult DoBuild (IProgressMonitor monitor, string itemConfiguration)
        {
		
            return base.DoBuild(monitor, itemConfiguration); 
        }
		
		public override void Save (IProgressMonitor monitor)
		{
			base.Save (monitor);
		}


        #endregion
	}
}