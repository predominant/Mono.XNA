
using System;
using MonoDevelop.Projects;
using MonoDevelop.Core.Gui;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Ide.Gui.Components;
using MonoDevelop.Ide.Gui.Pads.ProjectPad;

namespace MonoDevelop.Xna
{	
	
	public class XnaProjectNodeBuilder : NodeBuilderExtension
	{

		#region Constructor
		
		public XnaProjectNodeBuilder()
		{
		}
		
		#endregion
		
		#region ProjectNodeBuilder Overrides
		
		public override bool CanBuildNode (Type dataType)
		{
			return typeof(XnaProject).IsAssignableFrom (dataType);
		}
		
		public override void BuildChildNodes (ITreeBuilder builder, object dataObject)
		{
			foreach(NestedContentProject contentProject in ((XnaProject)dataObject).NestedContentProjects)
				builder.AddChild(contentProject.Project);
			
			base.BuildChildNodes (builder, dataObject);
		}
		
		#endregion
	}
}
