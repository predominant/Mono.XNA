#region License

/*
MIT License
Copyright © 2006 The Mono.Xna Team

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
using Tao.Sdl;

namespace Microsoft.Xna.Framework.Input
{
    public struct GamePadDPad
    {
        #region Private Fields

        ButtonState _down;
        ButtonState _left;
        ButtonState _right;
        ButtonState _up;

        #endregion Private Fields

#if NUNITTESTS
        public
#else
        internal 
#endif
        static void ToGamePadDPad(ref GamePadDPad pad, int state)
        {
            pad._up = (ButtonState)Math.Sign((int)(state & Sdl.SDL_HAT_UP));
            pad._right = (ButtonState)Math.Sign((int)(state & Sdl.SDL_HAT_RIGHT));
            pad._down = (ButtonState)Math.Sign((int)(state & Sdl.SDL_HAT_DOWN));
            pad._left = (ButtonState)Math.Sign((int)(state & Sdl.SDL_HAT_LEFT));
        }

        #region Public Fields

        public ButtonState Down
        {
            get { return _down; }
        }

        public ButtonState Left
        {
            get { return _left; }
        }

        public ButtonState Right
        {
            get { return _right; }
        }

        public ButtonState Up
        {
            get { return _up; }
        }

        #endregion Public Fields

        #region Public Methods

        public GamePadDPad(Microsoft.Xna.Framework.Input.ButtonState upValue, Microsoft.Xna.Framework.Input.ButtonState downValue, Microsoft.Xna.Framework.Input.ButtonState leftValue, Microsoft.Xna.Framework.Input.ButtonState rightValue)
        {
            _down = downValue;
            _left = leftValue;
            _right = rightValue;
            _up = upValue;
        }

        public static bool operator !=(GamePadDPad left, GamePadDPad right)
        {
            return !(left == right);
        }

        public static bool operator ==(GamePadDPad left, GamePadDPad right)
        {
            return (left._down == right._down)
                   && (left._up == right._up)
                   && (left._left == right._left)
                   && (left._right == right._right);
        }

        public override bool Equals(object obj)
        {
            return (obj is GamePadDPad) ? (GamePadDPad)obj == this : false;
        }

        public override int GetHashCode()
        {
            return (int)_left ^ (int)_right ^ (int)_up ^ (int)_down;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(20);
            output.Append("{{DPad:");

            if (_up == ButtonState.Pressed)
                output.Append((output.Length == 0) ? "Up" : " Up");

            if (_down == ButtonState.Pressed)
                output.Append((output.Length == 0) ? "Down" : " Down");

            if (_left == ButtonState.Pressed)
                output.Append((output.Length == 0) ? "Left" : " Left");

            if (_right == ButtonState.Pressed)
                output.Append((output.Length == 0) ? "Right" : " Right");

            if (output.Length == 0)
                output.Append("None");

            output.Append("}}");
            return output.ToString();
        }

        #endregion Public Methods
    }
}
