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
    public static class Keyboard
    {
        #region Private Member Variables

		private static KeyboardState state;
        private static Keys[] keyDictionary;

        #endregion


        #region Constructors

        static Keyboard()
        {
		    keyDictionary = new Keys[(int)Sdl.SDLK_LAST];
			
            // TODO: Fix any keys that report incorrect values
            // Any key that has a World value must be changed
            keyDictionary[(int)Sdl.SDLK_UNKNOWN] = Keys.Oem8;
            keyDictionary[(int)Sdl.SDLK_a] = Keys.A;
            keyDictionary[(int)Sdl.SDLK_b] = Keys.B;
            keyDictionary[(int)Sdl.SDLK_c] = Keys.C;
            keyDictionary[(int)Sdl.SDLK_d] = Keys.D;
            keyDictionary[(int)Sdl.SDLK_e] = Keys.E;
            keyDictionary[(int)Sdl.SDLK_f] = Keys.F;
            keyDictionary[(int)Sdl.SDLK_g] = Keys.G;
            keyDictionary[(int)Sdl.SDLK_h] = Keys.H;
            keyDictionary[(int)Sdl.SDLK_i] = Keys.I;
            keyDictionary[(int)Sdl.SDLK_j] = Keys.J;
            keyDictionary[(int)Sdl.SDLK_k] = Keys.K;
            keyDictionary[(int)Sdl.SDLK_l] = Keys.L;
            keyDictionary[(int)Sdl.SDLK_m] = Keys.M;
            keyDictionary[(int)Sdl.SDLK_n] = Keys.N;
            keyDictionary[(int)Sdl.SDLK_o] = Keys.O;
            keyDictionary[(int)Sdl.SDLK_p] = Keys.P;
            keyDictionary[(int)Sdl.SDLK_q] = Keys.Q;
            keyDictionary[(int)Sdl.SDLK_r] = Keys.R;
            keyDictionary[(int)Sdl.SDLK_s] = Keys.S;
            keyDictionary[(int)Sdl.SDLK_t] = Keys.T;
            keyDictionary[(int)Sdl.SDLK_u] = Keys.U;
            keyDictionary[(int)Sdl.SDLK_v] = Keys.V;
            keyDictionary[(int)Sdl.SDLK_w] = Keys.W;
            keyDictionary[(int)Sdl.SDLK_x] = Keys.X;
            keyDictionary[(int)Sdl.SDLK_y] = Keys.Y;
            keyDictionary[(int)Sdl.SDLK_z] = Keys.Z;
            keyDictionary[(int)Sdl.SDLK_KP_PLUS] = Keys.Add;
            keyDictionary[(int)Sdl.SDLK_MENU] = Keys.Apps;
            keyDictionary[(int)Sdl.SDLK_WORLD_1] = Keys.Attn;
            keyDictionary[(int)Sdl.SDLK_BACKSPACE] = Keys.Back;
            keyDictionary[(int)Sdl.SDLK_WORLD_3] = Keys.BrowserBack;
            keyDictionary[(int)Sdl.SDLK_F15] = Keys.BrowserFavorites;
            keyDictionary[(int)Sdl.SDLK_WORLD_5] = Keys.BrowserForward;
            keyDictionary[(int)Sdl.SDLK_WORLD_6] = Keys.BrowserHome;
            keyDictionary[(int)Sdl.SDLK_WORLD_7] = Keys.BrowserRefresh;
            keyDictionary[(int)Sdl.SDLK_F14] = Keys.BrowserSearch;
            keyDictionary[(int)Sdl.SDLK_WORLD_9] = Keys.BrowserStop;
            keyDictionary[(int)Sdl.SDLK_CAPSLOCK] = Keys.CapsLock;
            keyDictionary[(int)Sdl.SDLK_WORLD_10] = Keys.Crsel;
            keyDictionary[(int)Sdl.SDLK_0] = Keys.D0;
            keyDictionary[(int)Sdl.SDLK_1] = Keys.D1;
            keyDictionary[(int)Sdl.SDLK_2] = Keys.D2;
            keyDictionary[(int)Sdl.SDLK_3] = Keys.D3;
            keyDictionary[(int)Sdl.SDLK_4] = Keys.D4;
            keyDictionary[(int)Sdl.SDLK_5] = Keys.D5;
            keyDictionary[(int)Sdl.SDLK_6] = Keys.D6;
            keyDictionary[(int)Sdl.SDLK_7] = Keys.D7;
            keyDictionary[(int)Sdl.SDLK_8] = Keys.D8;
            keyDictionary[(int)Sdl.SDLK_9] = Keys.D9;
            keyDictionary[(int)Sdl.SDLK_WORLD_20] = Keys.Decimal;
            keyDictionary[(int)Sdl.SDLK_DELETE] = Keys.Delete;
            keyDictionary[(int)Sdl.SDLK_KP_PERIOD] = Keys.Delete;
            keyDictionary[(int)Sdl.SDLK_KP_DIVIDE] = Keys.Divide;
            keyDictionary[(int)Sdl.SDLK_DOWN] = Keys.Down;
            keyDictionary[(int)Sdl.SDLK_END] = Keys.End;
            keyDictionary[(int)Sdl.SDLK_RETURN] = Keys.Enter;
            keyDictionary[(int)Sdl.SDLK_WORLD_21] = Keys.EraseEof;
            keyDictionary[(int)Sdl.SDLK_ESCAPE] = Keys.Escape;
            keyDictionary[(int)Sdl.SDLK_WORLD_22] = Keys.Execute;
            keyDictionary[(int)Sdl.SDLK_WORLD_23] = Keys.Exsel;
            keyDictionary[(int)Sdl.SDLK_F1] = Keys.F1;
            keyDictionary[(int)Sdl.SDLK_F2] = Keys.F2;
            keyDictionary[(int)Sdl.SDLK_F3] = Keys.F3;
            keyDictionary[(int)Sdl.SDLK_F4] = Keys.F4;
            keyDictionary[(int)Sdl.SDLK_F5] = Keys.F5;
            keyDictionary[(int)Sdl.SDLK_F6] = Keys.F6;
            keyDictionary[(int)Sdl.SDLK_F7] = Keys.F7;
            keyDictionary[(int)Sdl.SDLK_F8] = Keys.F8;
            keyDictionary[(int)Sdl.SDLK_F9] = Keys.F9;
            keyDictionary[(int)Sdl.SDLK_F10] = Keys.F10;
            keyDictionary[(int)Sdl.SDLK_F11] = Keys.F11;
            keyDictionary[(int)Sdl.SDLK_F12] = Keys.F12;
            keyDictionary[(int)Sdl.SDLK_F13] = Keys.F13;
            keyDictionary[(int)Sdl.SDLK_F14] = Keys.F14;
            keyDictionary[(int)Sdl.SDLK_F15] = Keys.F15;
            keyDictionary[(int)Sdl.SDLK_WORLD_56] = Keys.F16;
            keyDictionary[(int)Sdl.SDLK_WORLD_57] = Keys.F17;
            keyDictionary[(int)Sdl.SDLK_WORLD_58] = Keys.F18;
            keyDictionary[(int)Sdl.SDLK_WORLD_59] = Keys.F19;
            keyDictionary[(int)Sdl.SDLK_WORLD_60] = Keys.F20;
            keyDictionary[(int)Sdl.SDLK_WORLD_61] = Keys.F21;
            keyDictionary[(int)Sdl.SDLK_WORLD_62] = Keys.F22;
            keyDictionary[(int)Sdl.SDLK_WORLD_63] = Keys.F23;
            keyDictionary[(int)Sdl.SDLK_WORLD_64] = Keys.F24;
            keyDictionary[(int)Sdl.SDLK_HELP] = Keys.Help;
            keyDictionary[(int)Sdl.SDLK_HOME] = Keys.Home;
            keyDictionary[(int)Sdl.SDLK_INSERT] = Keys.Insert;
            keyDictionary[(int)Sdl.SDLK_WORLD_24] = Keys.LaunchApplication1;
            keyDictionary[(int)Sdl.SDLK_WORLD_25] = Keys.LaunchApplication2;
            keyDictionary[(int)Sdl.SDLK_WORLD_26] = Keys.LaunchMail;
            keyDictionary[(int)Sdl.SDLK_LEFT] = Keys.Left;
            keyDictionary[(int)Sdl.SDLK_LALT] = Keys.LeftAlt;
            keyDictionary[(int)Sdl.SDLK_LCTRL] = Keys.LeftControl;
            keyDictionary[(int)Sdl.SDLK_LSHIFT] = Keys.LeftShift;
            keyDictionary[(int)Sdl.SDLK_LSUPER] = Keys.LeftWindows;
            keyDictionary[(int)Sdl.SDLK_WORLD_27] = Keys.MediaNextTrack;
            keyDictionary[(int)Sdl.SDLK_WORLD_28] = Keys.MediaPlayPause;
            keyDictionary[(int)Sdl.SDLK_WORLD_29] = Keys.MediaPreviousTrack;
            keyDictionary[(int)Sdl.SDLK_WORLD_30] = Keys.MediaStop;
            keyDictionary[(int)Sdl.SDLK_KP_MULTIPLY] = Keys.Multiply;
            keyDictionary[(int)Sdl.SDLK_NUMLOCK] = Keys.NumLock;
            keyDictionary[(int)Sdl.SDLK_KP0] = Keys.NumPad0;
            keyDictionary[(int)Sdl.SDLK_KP1] = Keys.NumPad1;
            keyDictionary[(int)Sdl.SDLK_KP2] = Keys.NumPad2;
            keyDictionary[(int)Sdl.SDLK_KP3] = Keys.NumPad3;
            keyDictionary[(int)Sdl.SDLK_KP4] = Keys.NumPad4;
            keyDictionary[(int)Sdl.SDLK_KP5] = Keys.NumPad5;
            keyDictionary[(int)Sdl.SDLK_KP6] = Keys.NumPad6;
            keyDictionary[(int)Sdl.SDLK_KP7] = Keys.NumPad7;
            keyDictionary[(int)Sdl.SDLK_KP8] = Keys.NumPad8;
            keyDictionary[(int)Sdl.SDLK_KP9] = Keys.NumPad9;
            keyDictionary[(int)Sdl.SDLK_KP_ENTER] = Keys.Enter;
            keyDictionary[(int)Sdl.SDLK_WORLD_31] = Keys.Oem8;
            keyDictionary[(int)Sdl.SDLK_BACKSLASH] = Keys.OemBackslash;
            keyDictionary[(int)Sdl.SDLK_WORLD_33] = Keys.OemClear;
            keyDictionary[(int)Sdl.SDLK_RIGHTBRACKET] = Keys.OemCloseBrackets;
            keyDictionary[(int)Sdl.SDLK_COMMA] = Keys.OemComma;
            keyDictionary[(int)Sdl.SDLK_MINUS] = Keys.OemMinus;
            keyDictionary[(int)Sdl.SDLK_LEFTBRACKET] = Keys.OemOpenBrackets;
            keyDictionary[(int)Sdl.SDLK_PERIOD] = Keys.OemPeriod;
            keyDictionary[(int)Sdl.SDLK_BACKSLASH] = Keys.OemPipe;
            keyDictionary[(int)Sdl.SDLK_EQUALS] = Keys.OemPlus;
            keyDictionary[(int)Sdl.SDLK_SLASH] = Keys.OemQuestion;
            keyDictionary[(int)Sdl.SDLK_QUOTE] = Keys.OemQuotes;
            keyDictionary[(int)Sdl.SDLK_SEMICOLON] = Keys.OemSemicolon;
            keyDictionary[(int)Sdl.SDLK_BACKQUOTE] = Keys.OemTilde;
            keyDictionary[(int)Sdl.SDLK_WORLD_45] = Keys.Pa1;
            keyDictionary[(int)Sdl.SDLK_PAGEDOWN] = Keys.PageDown;
            keyDictionary[(int)Sdl.SDLK_PAGEUP] = Keys.PageUp;
            keyDictionary[(int)Sdl.SDLK_WORLD_46] = Keys.Play;
            keyDictionary[(int)Sdl.SDLK_PRINT] = Keys.Print;
            keyDictionary[(int)Sdl.SDLK_PRINT] = Keys.PrintScreen;
            keyDictionary[(int)Sdl.SDLK_WORLD_47] = Keys.ProcessKey;
            keyDictionary[(int)Sdl.SDLK_RIGHT] = Keys.Right;
            keyDictionary[(int)Sdl.SDLK_RALT] = Keys.RightAlt;
            keyDictionary[(int)Sdl.SDLK_RCTRL] = Keys.RightControl;
            keyDictionary[(int)Sdl.SDLK_RSHIFT] = Keys.RightShift;
            keyDictionary[(int)Sdl.SDLK_RSUPER] = Keys.RightWindows;
            keyDictionary[(int)Sdl.SDLK_SCROLLOCK] = Keys.Scroll;
            keyDictionary[(int)Sdl.SDLK_WORLD_48] = Keys.Select;
            keyDictionary[(int)Sdl.SDLK_WORLD_49] = Keys.SelectMedia;
            keyDictionary[(int)Sdl.SDLK_WORLD_50] = Keys.Separator;
            keyDictionary[(int)Sdl.SDLK_WORLD_51] = Keys.Sleep;
            keyDictionary[(int)Sdl.SDLK_SPACE] = Keys.Space;
            keyDictionary[(int)Sdl.SDLK_KP_MINUS] = Keys.Subtract;
            keyDictionary[(int)Sdl.SDLK_TAB] = Keys.Tab;
            keyDictionary[(int)Sdl.SDLK_UP] = Keys.Up;
            keyDictionary[(int)Sdl.SDLK_WORLD_52] = Keys.VolumeDown;
            keyDictionary[(int)Sdl.SDLK_WORLD_53] = Keys.VolumeMute;
            keyDictionary[(int)Sdl.SDLK_WORLD_54] = Keys.VolumeUp;
            keyDictionary[(int)Sdl.SDLK_WORLD_55] = Keys.Zoom;
        }

        #endregion Constructors


        #region Public Methods

        public static KeyboardState GetState()
        {
			state = new KeyboardState((int)Sdl.SDLK_LAST);
			int numKeys = 0;
            byte[] keys = Sdl.SDL_GetKeyState(out numKeys);
			for (int key = Sdl.SDLK_UNKNOWN; key < Sdl.SDLK_LAST; key++)
				if (keys[key] > 0)
					state[keyDictionary[key]] = KeyState.Down;
			
			return state;
        }

        public static KeyboardState GetState(Microsoft.Xna.Framework.PlayerIndex playerIndex)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
