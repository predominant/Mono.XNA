#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.


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
using Tao.Sdl;

namespace Microsoft.Xna.Framework.Input
{
    public struct GamePadTriggers
    {
        #region Private Fields

        internal float left;
        internal float right;

        #endregion Private Fields

        #region Constructors

        public GamePadTriggers(float left, float right)
        {
            this.left = left;
            this.right = right;
        }

        #endregion Constructors


        #region Public Properties

        public float Left
        {
            get   { return this.left;  }
        }

        public float Right
        {
            get { return this.right; }
        }

        #endregion Public Properties


        #region Public Methods

        public static bool operator !=(GamePadTriggers left, GamePadTriggers right)
        {
            return !(left == right);
        }

        public static bool operator ==(GamePadTriggers left, GamePadTriggers right)
        {
            return (left.left == right.left) && (left.right == right.right);
        }

        public override bool Equals(object obj)
        {
            return (obj is GamePadTriggers) ? ((GamePadTriggers)obj == this) : false;
        }

        public override int GetHashCode()
        {
            return (int)left ^ (int)right;
        }
        
        public override string ToString()
        {
            return string.Format("{{Left:{0} Right:{1}}}", left, right);
        }

        #endregion
    }
}
