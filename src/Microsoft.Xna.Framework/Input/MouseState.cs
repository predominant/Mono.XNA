#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.

Authors:
 * Rob Loach

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
    [Serializable]
    public struct MouseState
    {
        #region Private Fields

        private int x;
        private int y;
        private int wheel;
        private ButtonState left;
        private ButtonState right;
        private ButtonState middle;
        private ButtonState xb1;
        private ButtonState xb2;

        #endregion Private Fields


        #region Public Properties

        public ButtonState LeftButton
        {
            get { return this.left; }
            internal set { this.left = value; }
        }

        public ButtonState MiddleButton
        {
            get { return this.middle; }
            internal set { this.middle = value; }
        }

        public ButtonState RightButton
        {
            get { return this.right; }
            internal set { this.right = value; }
        }

        public int ScrollWheelValue
        {
            get { return this.wheel; }
            internal set { this.wheel = value; }
        }

        public int X
        {
            get { return this.x; }
            internal set { this.x = value; }
        }

        public ButtonState XButton1
        {
            get { return this.xb1; }
            internal set { this.xb1 = value; }
        }

        public ButtonState XButton2
        {
            get { return this.xb2; }
            internal set { this.xb2 = value; }
        }

        public int Y
        {
            get { return this.y; }
            internal set { this.y = value; }
        }

        #endregion Public Properties


        #region Public Methods

        public static bool operator !=(MouseState left, MouseState right)
        {
            return !(left == right);
        }

        public static bool operator ==(MouseState left, MouseState right)
        {
            return (left.LeftButton == right.RightButton)
                && (left.MiddleButton == right.MiddleButton)
                && (left.RightButton == right.RightButton)
                && (left.ScrollWheelValue == right.ScrollWheelValue)
                && (left.X == right.X)
                && (left.XButton1 == right.XButton1)
                && (left.XButton2 == right.XButton2)
                && (left.Y == right.Y);
        }

        public override bool Equals(object obj)
        {
            return (obj is MouseState) ? (MouseState)obj == this : false;
        }

        public MouseState(int x, int y, int scrollWheel, Microsoft.Xna.Framework.Input.ButtonState leftButton, Microsoft.Xna.Framework.Input.ButtonState middleButton, Microsoft.Xna.Framework.Input.ButtonState rightButton, Microsoft.Xna.Framework.Input.ButtonState xButton1, Microsoft.Xna.Framework.Input.ButtonState xButton2)
        {
            this.x = x;
			this.y = y;
			this.wheel = scrollWheel;
			this.left = leftButton;
			this.right = rightButton;
			this.middle = middleButton;
			this.xb1 = xButton1;
			this.xb2 = xButton2;
        }

        public override int GetHashCode()
        {
            return wheel + x ^ y + (int)left + (int)right + (int)middle + (int)xb1 + (int)xb2;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(32);

            if (this.left == ButtonState.Pressed)
                output.Append((output.Length == 0) ? "Left" : " Left");

            if (this.right == ButtonState.Pressed)
                output.Append((output.Length == 0) ? "Right" : " Right");

            if (this.middle == ButtonState.Pressed)
                output.Append((output.Length == 0) ? "Middle" : " Middle");

            if (this.xb1 == ButtonState.Pressed)
                output.Append((output.Length == 0) ? "XButton1" : " XButton1");

            if (this.xb2 == ButtonState.Pressed)
                output.Append((output.Length == 0) ? "XButton2" : " XButton2");

            if (output.Length == 0)
                output.Append("None");

            // TODO: why bother with a string builder when you don't use it here?
            return string.Format("{{X:{0} Y:{1} Buttons:{2} Wheel:{3}}}", this.x.ToString(), this.y.ToString(), output.ToString(), this.wheel.ToString());
        }

        #endregion Public Methods
    }
}
