
using System;
using MonoDevelop.Projects;
using MonoDevelop.Core.Gui;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Ide.Gui.Components;

namespace MonoDevelop.Xna
{
	
	
	public class ContentProjectNodeBuilder : TypeNodeBuilder
	{
		
		#region TypeNodeBuilder Overrides
		
		public override Type NodeDataType {
			get { return typeof(ContentProject); }
		}
		
		public override Type CommandHandlerType {
			get { return typeof(ContentProjectCommandHandler); }
		}
		
		public override string GetNodeName (ITreeNavigator thisNode, object dataObject)
		{
			return ((ContentProject)dataObject).Name;
		}
		
		public override void BuildNode (ITreeBuilder treeBuilder, object dataObject, ref string label, ref Gdk.Pixbuf icon, ref Gdk.Pixbuf closedIcon)
		{
			Console.WriteLine("BuildNode");
			label = ((ContentProject)dataObject).Name;
			icon = Context.GetIcon (Stock.OpenReferenceFolder);
			closedIcon = Context.GetIcon (Stock.ClosedReferenceFolder);
		}

		public override void BuildChildNodes (ITreeBuilder builder, object dataObject)
		{
			Console.WriteLine("BuildChildNodes");
			ContentProject project = dataObject as ContentProject;
			if(project != null)
				builder.AddChild(project.References);
		}
		
		public override bool HasChildNodes (ITreeBuilder builder, object dataObject)
		{
			return true;
		}
		
		#endregion
	}
}
