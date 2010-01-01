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
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	[ContentSerializerCollectionItemName("Keyframe")]
	public sealed class AnimationChannel : ICollection<AnimationKeyframe>, IEnumerable<AnimationKeyframe>, IEnumerable
	{

#region Constructor
		
		public AnimationChannel()
		{
		}

#endregion
		
#region Properties
		
		public AnimationKeyframe this[int index] 
		{ 
			get { throw new NotImplementedException(); } 
		}


		public int Count 
		{ 
			get { throw new NotImplementedException(); }
		}
		
#endregion
		
#region Public Methods

		public int Add(AnimationKeyframe item)
		{
			throw new NotImplementedException();
		}
		
		public void Clear()
		{
			throw new NotImplementedException();
		}
		
		public bool Contains(AnimationKeyframe item)
		{
			throw new NotImplementedException();
		}
		
		public IEnumerator<AnimationKeyframe> GetEnumerator()
		{
			throw new NotImplementedException();
		}
		
		public int IndexOf(AnimationKeyframe item)
		{
			throw new NotImplementedException();
		}
		
		public bool Remove(AnimationKeyframe item)
		{
			throw new NotImplementedException();
		}
		
		public void RemoveAt(int index)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
#region Explicit Implementations

		bool ICollection<AnimationKeyframe>.IsReadOnly 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		void ICollection<AnimationKeyframe>.Add(AnimationKeyframe item)
		{
			throw new NotImplementedException();
		}

		void ICollection<AnimationKeyframe>.CopyTo(AnimationKeyframe[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}
		
		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
		
#endregion
		
	}
}
