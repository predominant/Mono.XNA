
using System;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

namespace Microsoft.Xna.Framework.Content.Pipeline.FBXImporter
{
	
	[ContentImporter(".fbx")]
	public class FBXImporter : ContentImporter<NodeContent>
	{
		
		public FBXImporter()
		{
		}
		
		public override NodeContent Import (string filename, ContentImporterContext context)
		{
			return null;
		}
	}
}
