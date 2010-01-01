
using System;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;

namespace Microsoft.Xna.Framework.Content.Pipeline.FBXImporter
{
	
	[StructLayout(LayoutKind.Sequential)]
	public class MarshaledNode
	{
		#region Fields

		private IntPtr name;
		private IntPtr sourceFilename;
		private IntPtr fragmentIdentifier;
		private IntPtr sourceTool;
		
		#endregion
		
		#region Constructor
		
		public MarshaledNode()
		{
		}
		
		#endregion
	}
}
