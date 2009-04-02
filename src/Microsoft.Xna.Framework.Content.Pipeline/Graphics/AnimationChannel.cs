// AnimationChannel.cs created with MonoDevelop
// User: lars at 08.14 04.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
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
