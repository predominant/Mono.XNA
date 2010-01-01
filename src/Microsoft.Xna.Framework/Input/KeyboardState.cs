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


using Tao.Sdl;
using System.Collections.Generic;

namespace Microsoft.Xna.Framework.Input
{
    public struct KeyboardState
    {
        #region Private Fields

		private bool[] keyStates;

        #endregion Private Fields


        #region Public Properties

        public KeyState this[Keys key]
        {
            get { return keyStates[(int)key] ? KeyState.Down : KeyState.Up; }
            internal set { this.keyStates[(int)key] = (value == KeyState.Down) ? true : false; }
        }

        #endregion


        #region Constructors

        internal KeyboardState(int numKeys)
        {
            keyStates = new bool[numKeys];
        }

        public KeyboardState(params Microsoft.Xna.Framework.Input.Keys[] keys)
        {
            throw new System.NotImplementedException();
        }

        #endregion


        #region Public Methods

        public static bool operator !=(KeyboardState a, KeyboardState b)
        {
            return !(a == b);
        }

        public static bool operator ==(KeyboardState a, KeyboardState b)
        {
            return a.keyStates == b.keyStates;
        }

        public override bool Equals(object obj)
        {
            return (obj is KeyboardState) ? false : (KeyboardState)obj == this;
        }

        public override int GetHashCode()
        {
            return keyStates.GetHashCode();
        }

        public Keys[] GetPressedKeys()
        {
            List<Keys> keysDown = new List<Keys>();
            for (int i = 0; i < keyStates.Length; i++)
                if (keyStates[i])
                    keysDown.Add((Keys)i);

            return keysDown.ToArray();
        }

        public bool IsKeyDown(Keys key)
        {
            return keyStates[(int)key];
        }

        public bool IsKeyUp(Keys key)
        {
            return !keyStates[(int)key];
        }

        #endregion
    }
}
