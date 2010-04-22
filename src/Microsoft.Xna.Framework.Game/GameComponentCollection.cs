#region License

/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.
 
Authors:
 * Stuart Carnie (stuart.carnie@gmail.com)

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

namespace Microsoft.Xna.Framework
{
    public sealed class GameComponentCollection : Collection<IGameComponent>
    {
        public event EventHandler<GameComponentCollectionEventArgs> ComponentAdded;
        public event EventHandler<GameComponentCollectionEventArgs> ComponentRemoved;


        public GameComponentCollection()
        {
        }

        protected override void ClearItems()
        {
            foreach (IGameComponent component in this)
            {
                OnComponentRemoved(new GameComponentCollectionEventArgs(component));
            }

            base.ClearItems();
        }

        protected override void InsertItem(int index, IGameComponent item)
        {
            base.InsertItem(index, item);
            OnComponentAdded(new GameComponentCollectionEventArgs(item));
        }

        void OnComponentAdded(GameComponentCollectionEventArgs eventArgs)
        {
            if (ComponentAdded != null)
                ComponentAdded(this, eventArgs);
        }

        void OnComponentRemoved(GameComponentCollectionEventArgs eventArgs)
        {
            if (ComponentRemoved != null)
                ComponentRemoved(this, eventArgs);
        }

        protected override void RemoveItem(int index)
        {
            IGameComponent item = this[index];
            base.RemoveItem(index);
            OnComponentRemoved(new GameComponentCollectionEventArgs(item));
        }

        protected override void SetItem(int index, IGameComponent item)
        {
            IGameComponent oldItem = this[index];
            if (!oldItem.Equals(item))
            {
                OnComponentRemoved(new GameComponentCollectionEventArgs(oldItem));
                base.SetItem(index, item);
                OnComponentAdded(new GameComponentCollectionEventArgs(item));
            }
        }
    }
}
