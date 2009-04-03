#region License
/*
MIT License
Copyright © 2009 The Mono.Xna Team

All rights reserved.

Authors: Lars Magnusson (lavima@gmail.com)

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
