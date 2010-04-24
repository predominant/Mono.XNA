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
using Tao.Sdl;

namespace Microsoft.Xna.Framework.Input
{
    #region JoystickAxis

    /// <summary>
    /// JoystickAxes
    /// </summary>
    /// <remarks></remarks>
    internal enum JoystickAxis
    {
        /// <summary>
        /// Horizontal Axis
        /// </summary>
        Horizontal = 0,
        /// <summary>
        /// Vertical Axis
        /// </summary>
        Vertical = 1,
        /// <summary>
        /// For some controllers
        /// </summary>
        Axis3 = 2,
        /// <summary>
        /// For some controllers
        /// </summary>
        Axis4 = 3,
        /// <summary>
        /// For some controllers
        /// </summary>
        Axis5 = 4,
        /// <summary>
        /// For some controllers
        /// </summary>
        Axis6 = 5
    }

    #endregion

    public static class GamePad
    {
        #region Constants

        private const int A = 2;
        private const int B = 3;
        private const int X = 1;
        private const int Y = 4;
        private const int Back = 9;
        private const int Start = 10;
        private const int LeftShoulder = 5;
        private const int RightShoulder = 6;
        private const int LeftStick = 11;
        private const int RightStick = 12;
        private const int LeftTrigger = 7;
        private const int RightTrigger = 8;

        // For the circular axis dead zone, this value is the maximum distance for x² + y², when x = y = 1 | -1
        private const float MaxDistance = 1.4142135623730951f;
        private const int MaxSticks = 4;
		
		private const float JOYSTICK_ADJUSTMENT = 32768;
        private const float JOYSTICK_SCALE = 65535;
		
		private const float DEADZONE = 0.2f;
        private const double EPSILON = 1 / 100000;
		
        #endregion Constants

		#region Fields
		
		private static IntPtr[] _sticks;
        private static GamePadState[] _state;
        private static int s_numJoysticks;
		
		#endregion Fields

        #region Constructors        

        static GamePad()
        {
           	s_numJoysticks = Sdl.SDL_NumJoysticks() > MaxSticks ? MaxSticks : Sdl.SDL_NumJoysticks();
            _state = new GamePadState[MaxSticks];
            _sticks = new IntPtr[MaxSticks];

            if (s_numJoysticks > 0)
            {
                for (int i = 0; i < s_numJoysticks; i++)
                {
                    _sticks[i] = Sdl.SDL_JoystickOpen(i);//Joysticks.OpenJoystick(i);
                    _state[i].isConnected = true;
                }
				/*
 				Events.JoystickButtonDown += new EventHandler<JoystickButtonEventArgs>(Events_JoystickButtonDown);
                Events.JoystickButtonUp += new EventHandler<JoystickButtonEventArgs>(Events_JoystickButtonUp);
                Events.JoystickAxisMotion += new EventHandler<JoystickAxisEventArgs>(Events_JoystickAxisMotion);
                Events.JoystickHatMotion += new EventHandler<JoystickHatEventArgs>(Events_JoystickHatMotion);
            	*/
            }
        }
/*
        static void Events_JoystickHatMotion(object sender, JoystickHatEventArgs e)
        {
            if (e.Device > MaxSticks) return;
            _state[e.Device].PacketNumber++;        // integer wrapping is handled by setter
        }

        static void Events_JoystickAxisMotion(object sender, JoystickAxisEventArgs e)
        {
            if (e.Device > MaxSticks) return;
            _state[e.Device].PacketNumber++;        // integer wrapping is handled by setter
        }

        static void Events_JoystickButtonUp(object sender, JoystickButtonEventArgs e)
        {
            if (e.Device > MaxSticks) return;
            _state[e.Device].PacketNumber++;        // integer wrapping is handled by setter
        }

        static void Events_JoystickButtonDown(object sender, JoystickButtonEventArgs e)
        {
            if (e.Device > MaxSticks) return;
            _state[e.Device].PacketNumber++;        // integer wrapping is handled by setter
        }
*/
        #endregion Constructors

        #region Public Methods

        public static GamePadCapabilities GetCapabilities(PlayerIndex playerIndex)
        {
            if (playerIndex < PlayerIndex.One || playerIndex > PlayerIndex.Four)
                throw new InvalidOperationException();

            GamePadCapabilities caps = new GamePadCapabilities();
            IntPtr stick = _sticks[(int)playerIndex];
            if (stick != null)
            {
                caps.hasAButton = Sdl.SDL_JoystickNumButtons(stick) > 1;
                caps.hasBButton = Sdl.SDL_JoystickNumButtons(stick) > 0;
                caps.hasDPadDownButton = caps.hasDPadLeftButton = caps.hasDPadRightButton = caps.hasDPadUpButton = Sdl.SDL_JoystickNumHats(stick) > 0;
                caps.hasLeftShoulderButton = Sdl.SDL_JoystickNumButtons(stick) > 4;
                caps.hasRightShoulderButton = Sdl.SDL_JoystickNumButtons(stick) > 5;
                caps.hasStartButton = Sdl.SDL_JoystickNumButtons(stick) > 7;
                caps.hasXButton = Sdl.SDL_JoystickNumButtons(stick) > 2;
                caps.hasYButton = Sdl.SDL_JoystickNumButtons(stick) > 3;
                caps.isConnected = true;
                caps.gamePadType = GamePadType.GamePad;
            }
            return caps;
        }

        public static GamePadState GetState(PlayerIndex playerIndex)
        {
            return GetState(playerIndex, GamePadDeadZone.IndependentAxes);
        }

        public static GamePadState GetState(PlayerIndex playerIndex, GamePadDeadZone deadZoneMode)
        {
            int number = (int)playerIndex;
            if (number < s_numJoysticks)
            {
                IntPtr j = _sticks[number];

                _state[number].buttons.A = (ButtonState)Sdl.SDL_JoystickGetButton(j,A);
                _state[number].buttons.B = (ButtonState)Sdl.SDL_JoystickGetButton(j, B);
                _state[number].buttons.X = (ButtonState)Sdl.SDL_JoystickGetButton(j, X);
                _state[number].buttons.Y = (ButtonState)Sdl.SDL_JoystickGetButton(j, Y);
                _state[number].buttons.Back = (ButtonState)Sdl.SDL_JoystickGetButton(j, Back);
                _state[number].buttons.Start = (ButtonState)Sdl.SDL_JoystickGetButton(j, Start);
                _state[number].buttons.LeftShoulder = (ButtonState)Sdl.SDL_JoystickGetButton(j, LeftShoulder);
                _state[number].buttons.LeftStick = (ButtonState)Sdl.SDL_JoystickGetButton(j, LeftStick);
                _state[number].buttons.RightShoulder = (ButtonState)Sdl.SDL_JoystickGetButton(j, RightShoulder);
                _state[number].buttons.RightStick = (ButtonState)Sdl.SDL_JoystickGetButton(j, RightStick);

                float x1 = Rescale((float)(Sdl.SDL_JoystickGetAxis(j, (int)JoystickAxis.Horizontal) + JOYSTICK_ADJUSTMENT) / JOYSTICK_SCALE);
                float y1 = Rescale(Sdl.SDL_JoystickGetAxis(j, (int)JoystickAxis.Vertical));
                float x2 = Rescale(Sdl.SDL_JoystickGetAxis(j, (int)JoystickAxis.Axis3));
                float y2 = Rescale(Sdl.SDL_JoystickGetAxis(j, (int)JoystickAxis.Axis4));

                switch (deadZoneMode)
                {
                    case GamePadDeadZone.IndependentAxes:
                        _state[number].thumbSticks.left = IndependentAxisDeadZone(x1, y1);
                        _state[number].thumbSticks.right = IndependentAxisDeadZone(x2, y2);
                        break;

                    case GamePadDeadZone.Circular:
                        _state[number].thumbSticks.left = CircularAxisDeadZone(x1, y1);
                        _state[number].thumbSticks.right = CircularAxisDeadZone(x2, y2);
                        break;

                    case GamePadDeadZone.None:
                        _state[number].thumbSticks.left = new Vector2(x1, y1);
                        _state[number].thumbSticks.right = new Vector2(x2, y2);
                        break;
                }
                GamePadDPad.ToGamePadDPad(ref _state[number].dPad, Sdl.SDL_JoystickGetHat(j, 0));

                // converts ButtonKeyState.Pressed ( = 1) to float of 1.0f
                // since SDL doesn't support reading the position of the trigger.  Will review this later
                _state[number].triggers.left = (int)Sdl.SDL_JoystickGetButton(j, LeftTrigger) * 1.0f;
                _state[number].triggers.right = (int)Sdl.SDL_JoystickGetButton(j, RightTrigger) * 1.0f;
            }
			else
				_state[number].isConnected = false;
			
            return _state[number];
        }

        public static bool SetVibration(PlayerIndex playerIndex, float leftMotor, float rightMotor)
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
		
		#region Private Methods
		
		/// <summary>
        /// As per http://blogs.msdn.com/shawnhar/archive/2007/03/28/gamepads-suck.aspx
        /// <paramref name="x"/> and <paramref name="y"/> are assumed to be between -1.0 and 1.0
        /// </summary>
        static Vector2 IndependentAxisDeadZone(float x, float y)
        {
            return new Vector2(
                Math.Max(Math.Abs(x) - DEADZONE, 0) * Math.Sign(x) / (1 - DEADZONE),
                Math.Max(Math.Abs(y) - DEADZONE, 0) * Math.Sign(y) / (1 - DEADZONE));
        }

        /// <summary>
        /// As per http://blogs.msdn.com/shawnhar/archive/2007/03/28/gamepads-suck.aspx
        /// Both <paramref name="x"/> and <paramref name="y"/> parameters assumed to be between -1.0 and 1.0
        /// </summary>
        static Vector2 CircularAxisDeadZone(float x, float y)
        {
            float dist = (float)Math.Max(Math.Sqrt(x * x + y * y), EPSILON);
            float deadZone = Math.Max(dist - DEADZONE, 0)/(MaxDistance - DEADZONE)/dist;
            return new Vector2(x*deadZone, y*deadZone);
        }

        static float Rescale(float p)
        {
            return (0.5f - p)*2.0f;
        }

        #endregion Private Methods
        
    }
}