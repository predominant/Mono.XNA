#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team
http://www.taoframework.com
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
using System.Drawing;
using SdlDotNet.Input;
using SdlDotNet.Core;

namespace Microsoft.Xna.Framework.Input
{
    public static class Mouse
    {
        #region Private Fields

        private static MouseState mouseState;
        private static IntPtr windowHandle;

        #endregion Fields


        #region Public Properties

        public static IntPtr WindowHandle
        {
            get { return windowHandle; }
            set { windowHandle = value; }
        }

        #endregion Public Properties


        #region Constructors

        static Mouse()
        {
            Events.MouseButtonDown += new EventHandler<MouseButtonEventArgs>(Events_MouseButtonDown);
            Events.MouseButtonUp += new EventHandler<MouseButtonEventArgs>(Events_MouseButtonUp);
            Events.MouseMotion += new EventHandler<MouseMotionEventArgs>(Events_MouseMotion);
        }

        #endregion Constructors


        #region Private Methods

        private static void Events_MouseMotion(object sender, MouseMotionEventArgs e)
        {
            mouseState.x = e.X;
            mouseState.y = e.Y;
        }

        private static void Events_MouseButtonUp(object sender, MouseButtonEventArgs e)
        {
            MouseButtonEvent(e.Button, ButtonState.Released);
        }

        private static void Events_MouseButtonDown(object sender, MouseButtonEventArgs e)
        {
            MouseButtonEvent(e.Button, ButtonState.Pressed);
        }

        private static void MouseButtonEvent(MouseButton button, ButtonState state)
        {
            switch (button)
            {
                case MouseButton.PrimaryButton:
                    mouseState.left = state;
                    break;
                case MouseButton.SecondaryButton:
                    mouseState.right = state;
                    break;
                case MouseButton.MiddleButton:
                    mouseState.middle = state;
                    break;
                case MouseButton.WheelUp:
                    if (state == ButtonState.Released)
                        mouseState.wheel += 120;
                    break;
                case MouseButton.WheelDown:
                    if (state == ButtonState.Released)
                        mouseState.wheel -= 120;
                    break;
            }
        }

        #endregion Private Methods


        #region Public Methods

        public static MouseState GetState()
        {
            return mouseState;
        }

        public static void SetPosition(int x, int y)
        {
            SdlDotNet.Input.Mouse.MousePosition = new System.Drawing.Point(x, y);
        }

        #endregion Public Methods
    }
}
