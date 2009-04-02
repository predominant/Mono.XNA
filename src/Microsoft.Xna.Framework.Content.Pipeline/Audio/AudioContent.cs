// AudioContent.cs created with MonoDevelop
// User: lars at 04.37 16.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Collections.ObjectModel;

namespace Microsoft.Xna.Framework.Content.Pipeline.Audio
{
	
	
	public class AudioContent : ContentItem, IDisposable
	{

#region Constructor
		
		public AudioContent(string audioFileName, AudioFileType audioFileType)
		{
		}
		
#endregion

#region Properties

		public ReadOnlyCollection<byte> Data 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		public TimeSpan Duration 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		[ContentSerializer]
		public string FileName 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		public AudioFileType FileType 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		public AudioFormat Format 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		public int LoopLength 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		public int LoopStart 
		{ 
			get { throw new NotImplementedException(); }
		}
		
#endregion
		
#region Public Methods

		public void ConvertFormat(ConversionFormat formatType, ConversionQuality quality, string targetFileName)
		{
			throw new NotImplementedException();
		}
		
		public void Dispose()
		{
			throw new NotImplementedException();
		}
		
#endregion
		
#region Protected Methods

		//protected override void Finalize()
		//{
		//	throw new NotImplementedException();
		//}
		
#endregion
		
	}
}
