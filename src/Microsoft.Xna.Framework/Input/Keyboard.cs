#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team
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
using SdlDotNet.Core;
using SdlDotNet.Input;

namespace Microsoft.Xna.Framework.Input
{
    public static class Keyboard
    {
        #region Private Member Variables

        private static KeyboardState state = new KeyboardState((int)Key.Last);
        private static Keys[] keyDictionary = new Keys[(int)Key.Last];

        #endregion


        #region Constructors

        static Keyboard()
        {
            // Register the KeyboardUp and KeyboardDown events
            Events.KeyboardDown += new EventHandler<KeyboardEventArgs>(Events_KeyboardAction);
            Events.KeyboardUp += new EventHandler<KeyboardEventArgs>(Events_KeyboardAction);

            // Map all of the SDL.NET keys to the XNA keys

            // TODO: Fix any keys that report incorrect values
            // Any key that has a World value must be changed
            keyDictionary[(int)Key.Unknown] = Keys.Oem8;
            keyDictionary[(int)Key.A] = Keys.A;
            keyDictionary[(int)Key.B] = Keys.B;
            keyDictionary[(int)Key.C] = Keys.C;
            keyDictionary[(int)Key.D] = Keys.D;
            keyDictionary[(int)Key.E] = Keys.E;
            keyDictionary[(int)Key.F] = Keys.F;
            keyDictionary[(int)Key.G] = Keys.G;
            keyDictionary[(int)Key.H] = Keys.H;
            keyDictionary[(int)Key.I] = Keys.I;
            keyDictionary[(int)Key.J] = Keys.J;
            keyDictionary[(int)Key.K] = Keys.K;
            keyDictionary[(int)Key.L] = Keys.L;
            keyDictionary[(int)Key.M] = Keys.M;
            keyDictionary[(int)Key.N] = Keys.N;
            keyDictionary[(int)Key.O] = Keys.O;
            keyDictionary[(int)Key.P] = Keys.P;
            keyDictionary[(int)Key.Q] = Keys.Q;
            keyDictionary[(int)Key.R] = Keys.R;
            keyDictionary[(int)Key.S] = Keys.S;
            keyDictionary[(int)Key.T] = Keys.T;
            keyDictionary[(int)Key.U] = Keys.U;
            keyDictionary[(int)Key.V] = Keys.V;
            keyDictionary[(int)Key.W] = Keys.W;
            keyDictionary[(int)Key.X] = Keys.X;
            keyDictionary[(int)Key.Y] = Keys.Y;
            keyDictionary[(int)Key.Z] = Keys.Z;
            keyDictionary[(int)Key.KeypadPlus] = Keys.Add;
            keyDictionary[(int)Key.Menu] = Keys.Apps;
            keyDictionary[(int)Key.World1] = Keys.Attn;
            keyDictionary[(int)Key.Backspace] = Keys.Back;
            keyDictionary[(int)Key.World3] = Keys.BrowserBack;
            keyDictionary[(int)Key.F15] = Keys.BrowserFavorites;
            keyDictionary[(int)Key.World5] = Keys.BrowserForward;
            keyDictionary[(int)Key.World6] = Keys.BrowserHome;
            keyDictionary[(int)Key.World7] = Keys.BrowserRefresh;
            keyDictionary[(int)Key.F14] = Keys.BrowserSearch;
            keyDictionary[(int)Key.World9] = Keys.BrowserStop;
            keyDictionary[(int)Key.CapsLock] = Keys.CapsLock;
            keyDictionary[(int)Key.World10] = Keys.Crsel;
            keyDictionary[(int)Key.Zero] = Keys.D0;
            keyDictionary[(int)Key.One] = Keys.D1;
            keyDictionary[(int)Key.Two] = Keys.D2;
            keyDictionary[(int)Key.Three] = Keys.D3;
            keyDictionary[(int)Key.Four] = Keys.D4;
            keyDictionary[(int)Key.Five] = Keys.D5;
            keyDictionary[(int)Key.Six] = Keys.D6;
            keyDictionary[(int)Key.Seven] = Keys.D7;
            keyDictionary[(int)Key.Eight] = Keys.D8;
            keyDictionary[(int)Key.Nine] = Keys.D9;
            keyDictionary[(int)Key.World20] = Keys.Decimal;
            keyDictionary[(int)Key.Delete] = Keys.Delete;
            keyDictionary[(int)Key.KeypadPeriod] = Keys.Delete;
            keyDictionary[(int)Key.KeypadDivide] = Keys.Divide;
            keyDictionary[(int)Key.DownArrow] = Keys.Down;
            keyDictionary[(int)Key.End] = Keys.End;
            keyDictionary[(int)Key.Return] = Keys.Enter;
            keyDictionary[(int)Key.World21] = Keys.EraseEof;
            keyDictionary[(int)Key.Escape] = Keys.Escape;
            keyDictionary[(int)Key.World22] = Keys.Execute;
            keyDictionary[(int)Key.World23] = Keys.Exsel;
            keyDictionary[(int)Key.F1] = Keys.F1;
            keyDictionary[(int)Key.F2] = Keys.F2;
            keyDictionary[(int)Key.F3] = Keys.F3;
            keyDictionary[(int)Key.F4] = Keys.F4;
            keyDictionary[(int)Key.F5] = Keys.F5;
            keyDictionary[(int)Key.F6] = Keys.F6;
            keyDictionary[(int)Key.F7] = Keys.F7;
            keyDictionary[(int)Key.F8] = Keys.F8;
            keyDictionary[(int)Key.F9] = Keys.F9;
            keyDictionary[(int)Key.F10] = Keys.F10;
            keyDictionary[(int)Key.F11] = Keys.F11;
            keyDictionary[(int)Key.F12] = Keys.F12;
            keyDictionary[(int)Key.F13] = Keys.F13;
            keyDictionary[(int)Key.F14] = Keys.F14;
            keyDictionary[(int)Key.F15] = Keys.F15;
            keyDictionary[(int)Key.World56] = Keys.F16;
            keyDictionary[(int)Key.World57] = Keys.F17;
            keyDictionary[(int)Key.World58] = Keys.F18;
            keyDictionary[(int)Key.World59] = Keys.F19;
            keyDictionary[(int)Key.World60] = Keys.F20;
            keyDictionary[(int)Key.World61] = Keys.F21;
            keyDictionary[(int)Key.World62] = Keys.F22;
            keyDictionary[(int)Key.World63] = Keys.F23;
            keyDictionary[(int)Key.World64] = Keys.F24;
            keyDictionary[(int)Key.Help] = Keys.Help;
            keyDictionary[(int)Key.Home] = Keys.Home;
            keyDictionary[(int)Key.Insert] = Keys.Insert;
            keyDictionary[(int)Key.World24] = Keys.LaunchApplication1;
            keyDictionary[(int)Key.World25] = Keys.LaunchApplication2;
            keyDictionary[(int)Key.World26] = Keys.LaunchMail;
            keyDictionary[(int)Key.LeftArrow] = Keys.Left;
            keyDictionary[(int)Key.LeftAlt] = Keys.LeftAlt;
            keyDictionary[(int)Key.LeftControl] = Keys.LeftControl;
            keyDictionary[(int)Key.LeftShift] = Keys.LeftShift;
            keyDictionary[(int)Key.LeftWindows] = Keys.LeftWindows;
            keyDictionary[(int)Key.World27] = Keys.MediaNextTrack;
            keyDictionary[(int)Key.World28] = Keys.MediaPlayPause;
            keyDictionary[(int)Key.World29] = Keys.MediaPreviousTrack;
            keyDictionary[(int)Key.World30] = Keys.MediaStop;
            keyDictionary[(int)Key.KeypadMultiply] = Keys.Multiply;
            keyDictionary[(int)Key.NumLock] = Keys.NumLock;
            keyDictionary[(int)Key.Keypad0] = Keys.NumPad0;
            keyDictionary[(int)Key.Keypad1] = Keys.NumPad1;
            keyDictionary[(int)Key.Keypad2] = Keys.NumPad2;
            keyDictionary[(int)Key.Keypad3] = Keys.NumPad3;
            keyDictionary[(int)Key.Keypad4] = Keys.NumPad4;
            keyDictionary[(int)Key.Keypad5] = Keys.NumPad5;
            keyDictionary[(int)Key.Keypad6] = Keys.NumPad6;
            keyDictionary[(int)Key.Keypad7] = Keys.NumPad7;
            keyDictionary[(int)Key.Keypad8] = Keys.NumPad8;
            keyDictionary[(int)Key.Keypad9] = Keys.NumPad9;
            keyDictionary[(int)Key.KeypadEnter] = Keys.Enter;
            keyDictionary[(int)Key.World31] = Keys.Oem8;
            keyDictionary[(int)Key.Backslash] = Keys.OemBackslash;
            keyDictionary[(int)Key.World33] = Keys.OemClear;
            keyDictionary[(int)Key.RightBracket] = Keys.OemCloseBrackets;
            keyDictionary[(int)Key.Comma] = Keys.OemComma;
            keyDictionary[(int)Key.Minus] = Keys.OemMinus;
            keyDictionary[(int)Key.LeftBracket] = Keys.OemOpenBrackets;
            keyDictionary[(int)Key.Period] = Keys.OemPeriod;
            keyDictionary[(int)Key.Backslash] = Keys.OemPipe;
            keyDictionary[(int)Key.Equals] = Keys.OemPlus;
            keyDictionary[(int)Key.Slash] = Keys.OemQuestion;
            keyDictionary[(int)Key.Quote] = Keys.OemQuotes;
            keyDictionary[(int)Key.Semicolon] = Keys.OemSemicolon;
            keyDictionary[(int)Key.BackQuote] = Keys.OemTilde;
            keyDictionary[(int)Key.World45] = Keys.Pa1;
            keyDictionary[(int)Key.PageDown] = Keys.PageDown;
            keyDictionary[(int)Key.PageUp] = Keys.PageUp;
            keyDictionary[(int)Key.World46] = Keys.Play;
            keyDictionary[(int)Key.Print] = Keys.Print;
            keyDictionary[(int)Key.Print] = Keys.PrintScreen;
            keyDictionary[(int)Key.World47] = Keys.ProcessKey;
            keyDictionary[(int)Key.RightArrow] = Keys.Right;
            keyDictionary[(int)Key.RightAlt] = Keys.RightAlt;
            keyDictionary[(int)Key.RightControl] = Keys.RightControl;
            keyDictionary[(int)Key.RightShift] = Keys.RightShift;
            keyDictionary[(int)Key.RightWindows] = Keys.RightWindows;
            keyDictionary[(int)Key.ScrollLock] = Keys.Scroll;
            keyDictionary[(int)Key.World48] = Keys.Select;
            keyDictionary[(int)Key.World49] = Keys.SelectMedia;
            keyDictionary[(int)Key.World50] = Keys.Separator;
            keyDictionary[(int)Key.World51] = Keys.Sleep;
            keyDictionary[(int)Key.Space] = Keys.Space;
            keyDictionary[(int)Key.KeypadMinus] = Keys.Subtract;
            keyDictionary[(int)Key.Tab] = Keys.Tab;
            keyDictionary[(int)Key.UpArrow] = Keys.Up;
            keyDictionary[(int)Key.World52] = Keys.VolumeDown;
            keyDictionary[(int)Key.World53] = Keys.VolumeMute;
            keyDictionary[(int)Key.World54] = Keys.VolumeUp;
            keyDictionary[(int)Key.World55] = Keys.Zoom;
        }

        #endregion Constructors


        #region Public Methods

        private static void Events_KeyboardAction(object sender, SdlDotNet.Input.KeyboardEventArgs e)
        {
            // Get the corresponding XNA key from the SDL key and set it's state
            state[keyDictionary[(int)e.Key]] = e.Down ? KeyState.Down : KeyState.Up;
        }

        public static KeyboardState GetState()
        {
            //TODO: Will this work? The state contains an object on the heap. Will the reference be the same
            // when you return the "state" from this class?
            return state;
        }

        #endregion
    }
}
