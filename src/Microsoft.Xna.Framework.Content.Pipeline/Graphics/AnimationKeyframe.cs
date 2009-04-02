// AnimationKeyframe.cs created with MonoDevelop
// User: lars at 08.27 04.03.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using Microsoft.Xna.Framework;

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public sealed class AnimationKeyframe : IComparable<AnimationKeyframe>
	{
		
#region Constructor
		
		public AnimationKeyframe(TimeSpan time, Matrix transform)
		{
		}

#endregion
		
#region Properties

		public TimeSpan Time 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		public Matrix Transform 
		{ 
			get; 
			set; 
		}
		
#endregion
		
#region Public Methods

		public int CompareTo(AnimationKeyframe other)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
	}
}
