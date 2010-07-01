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

namespace Microsoft.Xna.Framework.Content.Pipeline
{
	
	
	public abstract class ContentProcessor<TInput,TOutput> : IContentProcessor
	{
		
		#region Constructor		
		
		protected ContentProcessor()
		{
		}
		
		#endregion Constructor
		
		#region Methods
		
		public abstract TOutput Process (TInput input, ContentProcessorContext context);
		
		#endregion Methods
		
		#region Explicit IContentProcessor Implementation
		
		Type IContentProcessor.InputType {
			get { return typeof(TInput); }
		}

		Type IContentProcessor.OutputType {
			get { return typeof(TOutput); }
		}

		object IContentProcessor.Process (object input, ContentProcessorContext context)
		{
			if (input == null) 
				throw new ArgumentNullException("input");
			if (!(input is TInput)) 
				throw new ArgumentException("Wrong content processor input type");
			
			return Process((TInput)input, context);
		}
		
		#endregion Explicit IContentProcessor Implementation
		
	}
}
