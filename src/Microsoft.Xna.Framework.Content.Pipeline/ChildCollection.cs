// MyClass.cs created with MonoDevelop
// User: lars at 10.18 21.02.09
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Microsoft.Xna.Framework.Content.Pipeline
{
	/// <summary>
	/// An abstract class providing a collection of child objects. 
	/// </summary>	
	public abstract class ChildCollection<TParent, TChild> : Collection<TChild>
	{	

#region Constructor
		
		protected ChildCollection(TParent parent)
		{
			throw new NotImplementedException();
		}
		
#endregion
		
#region Protected Methods
		
		protected override void InsertItem(int index, TChild item)
		{
			throw new NotImplementedException();
		}
		
		protected override void SetItem (int index, TChild item)
		{
			throw new NotImplementedException();
		}
		
		protected override void ClearItems()
		{
			throw new NotImplementedException();
		}
		
		protected override void RemoveItem(int index)
		{
			throw new NotImplementedException();
		}

		protected abstract TParent GetParent(TChild child);
		
		protected abstract void SetParent(TChild child, TParent parent);	
		
#endregion		
			
	}
}
