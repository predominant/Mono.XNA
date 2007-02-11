#region License
/*
MIT License
Copyright ? 2006 The Mono.Xna Team
http://www.taoframework.com
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
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Xna.Framework.Input
{
    public struct GamePadButtons
    {
        #region Private Fields

        private ButtonState a;
        private ButtonState b;
        private ButtonState back;
        private ButtonState leftShoulder;
        private ButtonState rightShoulder;
        private ButtonState leftStick;
        private ButtonState rightStick;
        private ButtonState start;
        private ButtonState x;
        private ButtonState y;

        #endregion Private Fields


        #region Public Properties

        public ButtonState A
        {
            get { return this.a; }
        }

        public ButtonState B
        {
            get { return this.b; }
        }

        public ButtonState Back
        {
            get { return this.back; }
        }

        public ButtonState LeftShoulder
        {
            get { return this.leftShoulder; }
        }

        public ButtonState RightShoulder
        {
            get { return this.rightShoulder; }
        }

        public ButtonState LeftStick
        {
            get { return this.leftStick; }
        }

        public ButtonState RightStick
        {
            get { return this.rightStick; }
        }

        public ButtonState Start
        {
            get { return this.start; }
        }

        public ButtonState X
        {
            get { return this.x; }
        }

        public ButtonState Y
        {
            get { return this.y; }
        }

        #endregion


        #region Public Methods

        public static bool operator !=(GamePadButtons left, GamePadButtons right)
        {
            return !(left == right);
        }

        public static bool operator ==(GamePadButtons left, GamePadButtons right)
        {
            return (left.a == right.a)
                && (left.b == right.b)
                && (left.back == right.back)
                && (left.leftShoulder == right.leftShoulder)
                && (left.leftStick == right.leftStick)
                && (left.rightShoulder == right.rightShoulder)
                && (left.rightStick == right.rightStick)
                && (left.start == right.start)
                && (left.x == right.x)
                && (left.y == right.y);
        }

        public override bool Equals(object obj)
        {
            return (obj is GamePadButtons) ? ((GamePadButtons)obj) == this : false;
        }

        public override int GetHashCode()
        {
            // TODO: Is this even worth doing? They're just bools...
            return this.a.GetHashCode()
                 ^ this.b.GetHashCode()
                 ^ this.back.GetHashCode()
                 ^ this.leftShoulder.GetHashCode()
                 ^ this.leftStick.GetHashCode()
                 ^ this.rightShoulder.GetHashCode()
                 ^ this.rightStick.GetHashCode()
                 ^ this.start.GetHashCode()
                 ^ this.x.GetHashCode()
                 ^ this.y.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(64);

            output.Append("{{Buttons:");
            if (this.a == ButtonState.Pressed)
                output.Append((output.Length == 0) ? "A" : " A");

            if (this.b == ButtonState.Pressed)
                output.Append((output.Length == 0) ? "B" : " B");

            if (this.x == ButtonState.Pressed)
                output.Append((output.Length == 0) ? "X" : " X");

            if (this.y == ButtonState.Pressed)
                output.Append((output.Length == 0) ? "Y" : " Y");

            if (this.leftShoulder == ButtonState.Pressed)
                output.Append((output.Length == 0) ? "LeftShoulder" : " LeftShoulder");

            if (this.rightShoulder == ButtonState.Pressed)
                output.Append((output.Length == 0) ? "RightShoulder" : " RightShoulder");

            if (this.leftStick == ButtonState.Pressed)
                output.Append((output.Length == 0) ? "LeftStick" : " LeftStick");

            if (this.rightStick == ButtonState.Pressed)
                output.Append((output.Length == 0) ? "RightStick" : " RightStick");

            if (this.start == ButtonState.Pressed)
                output.Append((output.Length == 0) ? "Start" : " Start");

            if (this.back == ButtonState.Pressed)
                output.Append((output.Length == 0) ? "Back" : " Back");

            if (output.Length == 10)
                output.Append("None");

            output.Append("}}");
            return output.ToString();
        }

        #endregion Public Methods
    }
}
