// SongProcessor.cs created with MonoDevelop
// User: lars at 03.14 20.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using Microsoft.Xna.Framework.Content.Pipeline.Audio;

namespace Microsoft.Xna.Framework.Content.Pipeline.Processors
{
	
	
	public class SongProcessor : ContentProcessor<AudioContent, SongContent>
	{

#region Constructor
		
		public SongProcessor()
		{
		}
		
#endregion
		
#region Properties

		public ConversionQuality Quality 
		{ 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
#endregion
		
#region Public Methods

		public override SongContent Process(AudioContent input, ContentProcessorContext context)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
	}
}
