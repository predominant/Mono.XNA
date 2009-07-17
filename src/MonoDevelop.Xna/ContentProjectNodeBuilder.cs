
using System;
using MonoDevelop.Projects;
using MonoDevelop.Core.Gui;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Ide.Gui.Components;

namespace MonoDevelop.Xna
{
	
	
	public class ContentProjectNodeBuilder : TypeNodeBuilder
	{
		
		#region Constructor
		
		public ContentProjectNodeBuilder()
		{
		}
		
		#endregion
		
		#region TypeNodeBuilder Overrides
		
		public override Type NodeDataType {
			get { return typeof(ContentProject); }
		}
		
		public override Type CommandHandlerType {
			get { return typeof(ContentProjectNodeCommandHandler); }
		}
		
		public override string GetNodeName (ITreeNavigator thisNode, object dataObject)
		{
			return ((ContentProject)dataObject).Name;
		}
		
		protected override void Initialize ()
		{
			
		}
		
		public override void Dispose ()
		{
			
		}
		
		public override void BuildNode (ITreeBuilder treeBuilder, object dataObject, ref string label, ref Gdk.Pixbuf icon, ref Gdk.Pixbuf closedIcon)
		{
			label = ((ContentProject)dataObject).Name;
			icon = Context.GetIcon (Stock.OpenReferenceFolder);
			closedIcon = Context.GetIcon (Stock.ClosedReferenceFolder);
		}

		public override void BuildChildNodes (ITreeBuilder builder, object dataObject)
		{
			
		}
		
		public override bool HasChildNodes (ITreeBuilder builder, object dataObject)
		{
			return true;
		}
		
		public override int CompareObjects (ITreeNavigator thisNode, ITreeNavigator otherNode)
		{
			return -1;
		}
		
		#endregion
	}
}
