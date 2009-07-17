
using System;
using MonoDevelop.Projects;
using MonoDevelop.Core.Gui;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Ide.Gui.Components;
using MonoDevelop.Ide.Gui.Pads.ProjectPad;

namespace MonoDevelop.Xna
{	
	
	public class XnaProjectNodeBuilder : ProjectNodeBuilder
	{

		#region Constructor
		
		public XnaProjectNodeBuilder()
		{
		}
		
		#endregion
		
		#region ProjectNodeBuilder Overrides
		
		public override Type NodeDataType {
			get { return typeof(XnaProject); }
		}
		
		public override void BuildChildNodes (MonoDevelop.Ide.Gui.Components.ITreeBuilder builder, object dataObject)
		{
			foreach(NestedContentProject contentProject in ((XnaProject)dataObject).NestedContentProjects)
				builder.AddChild(contentProject.Project);
			
			base.BuildChildNodes (builder, dataObject);
		}

		
		#endregion
	}
}
