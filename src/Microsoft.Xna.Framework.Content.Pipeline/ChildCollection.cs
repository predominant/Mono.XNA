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
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Microsoft.Xna.Framework.Content.Pipeline
{
	/// <summary>
	/// An abstract class providing a collection of child objects. 
	/// </summary>	
    public abstract class ChildCollection<TParent, TChild> : Collection<TChild>
        where TParent : class
        where TChild : class
	{	

		private TParent parentNode;
		
#region Constructor
		
		protected ChildCollection(TParent parent)
		{
			if (parent == null) throw new ArgumentNullException("parent");
			this.parentNode = parent;
		}
		
#endregion
		
#region Protected Methods
		
		protected override void InsertItem(int index, TChild item)
		{
			if (item == null) throw new ArgumentNullException("item");
			if (GetParent(item) != null) throw new InvalidOperationException("Child already has Parent");
			base.InsertItem(index, item);
			SetParent(item, parentNode);
		}
		
		protected override void SetItem (int index, TChild item)
		{
			if (item == null) throw new ArgumentNullException("item");
			TChild child = base[index];
			if (!object.ReferenceEquals(child,item))
			{
				if (GetParent(item) != null) throw new InvalidOperationException("Child already has Parent");
				base.SetItem(index, item);
				SetParent(child, default(TParent));
				SetParent(item, parentNode);
			}
		}
		
		protected override void ClearItems()
		{
			foreach (TChild child in this)
			{
				TParent parent = default(TParent);
				SetParent(child,parent);
			}
			base.ClearItems();
		}
		
		protected override void RemoveItem(int index)
		{
			TChild child = base[index];
			base.RemoveItem(index);
			SetParent(child, default(TParent));
		}

		protected abstract TParent GetParent(TChild child);
		
		protected abstract void SetParent(TChild child, TParent parent);	
		
#endregion		
			
	}
}
