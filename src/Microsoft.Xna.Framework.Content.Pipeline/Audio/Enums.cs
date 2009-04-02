// Enums.cs created with MonoDevelop
// User: lars at 04.47 16.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace Microsoft.Xna.Framework.Content.Pipeline.Audio
{
	
	
	public enum AudioFileType
	{
		Mp3,
		Wav,
		Wma
	}
	
	public enum ConversionFormat
	{
		Adpcm,
		Pcm,
		WindowsMedia,
		Xma
	}
	
	public enum ConversionQuality
	{
		Low,
		Medium, 
		Best
	}
}
