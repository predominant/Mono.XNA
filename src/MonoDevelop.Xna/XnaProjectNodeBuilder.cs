#region License
/*
MIT License
Copyright © 2009 The Mono.Xna Team

All rights reserved.

Authors:
Lars Magnusson (lavima)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion License

using System;
using MonoDevelop.Projects;
//using MonoDevelop.Core.Gui;
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
		
		public override void BuildChildNodes (ITreeBuilder builder, object dataObject)
		{
			foreach(NestedContentProject contentProject in ((XnaProject)dataObject).NestedContentProjects)
				builder.AddChild(contentProject.Project);
			
			base.BuildChildNodes (builder, dataObject);
		}
		
		#endregion ProjectNodeBuilder Overrides
	}
}
