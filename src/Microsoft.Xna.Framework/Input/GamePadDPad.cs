#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team
http://www.taoframework.com
All rights reserved.

Authors:

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
using System.Text;

namespace Microsoft.Xna.Framework.Input
{
    public struct GamePadDPad
    {
        #region Private Fields

        private ButtonState down;
        private ButtonState left;
        private ButtonState right;
        private ButtonState up;

        #endregion Private Fields


        #region Public Fields

        public ButtonState Down
        {
            get { return this.down; }
        }

        public ButtonState Left
        {
            get { return this.left; }
        }

        public ButtonState Right
        {
            get { return this.right; }
        }

        public ButtonState Up
        {
            get { return this.up; }
        }

        #endregion Public Fields


        #region Public Methods

        public static bool operator !=(GamePadDPad left, GamePadDPad right)
        {
            return !(left == right);
        }

        public static bool operator ==(GamePadDPad left, GamePadDPad right)
        {
            return (left.Down == right.Down)
                && (left.Up == right.Up)
                && (left.Left == right.Left)
                && (left.Right == right.Right);
        }

        public override bool Equals(object obj)
        {
            return (obj is GamePadDPad) ? (GamePadDPad)obj == this : false;
        }

        public override int GetHashCode()
        {
            return (int)left ^ (int)right ^ (int)up ^ (int)down;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(20);
            output.Append("{{DPad:");

            if (this.up == ButtonState.Pressed)
                output.Append((output.Length == 0) ? "Up" : " Up");

            if (this.down == ButtonState.Pressed)
                output.Append((output.Length == 0) ? "Down" : " Down");

            if (this.left == ButtonState.Pressed)
                output.Append((output.Length == 0) ? "Left" : " Left");

            if (this.right == ButtonState.Pressed)
                output.Append((output.Length == 0) ? "Right" : " Right");

            if (output.Length == 0)
                output.Append("None");

            output.Append("}}");
            return output.ToString();
        }

        #endregion Public Methods
    }
}
