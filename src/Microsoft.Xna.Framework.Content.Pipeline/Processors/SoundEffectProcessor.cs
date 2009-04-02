// SoundEffectProcessor.cs created with MonoDevelop
// User: lars at 03.18 20.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using Microsoft.Xna.Framework.Content.Pipeline.Audio;

namespace Microsoft.Xna.Framework.Content.Pipeline.Processors
{
	
	
	public class SoundEffectProcessor : ContentProcessor<AudioContent, SoundEffectContent>
	{

#region Constructor
		
		public SoundEffectProcessor()
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

		public override SoundEffectContent Process(AudioContent input, ContentProcessorContext context)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
	}
}
