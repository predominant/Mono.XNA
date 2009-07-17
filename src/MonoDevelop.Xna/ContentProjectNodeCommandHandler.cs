
using System;
using MonoDevelop.Projects;
using MonoDevelop.Ide.Gui.Pads.ProjectPad;

namespace MonoDevelop.Xna
{
	
	
	public class ContentProjectNodeCommandHandler : FolderCommandHandler
	{		
		
		#region Constructor
		
		public ContentProjectNodeCommandHandler()
		{
		}
		
		#endregion
		
		#region FolderCommandHandler Overrides
		
		public override string GetFolderPath (object dataObject)
		{
			return ((Project)dataObject).BaseDirectory;
	 	}	
		
		#endregion
	}
}
