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
using SdlDotNet.Core;
using SdlDotNet.Input;

namespace Microsoft.Xna.Framework.Input
{
    public static class GamePad
    {
        #region Button Constants

        const int A = 2;
        const int B = 3;
        const int X = 1;
        const int Y = 4;
        const int Back = 9;
        const int Start = 10;
        const int LeftShoulder = 5;
        const int RightShoulder = 6;
        const int LeftStick = 11;
        const int RightStick = 12;
        const int LeftTrigger = 7;
        const int RightTrigger = 8;

        // For the circular axis dead zone, this value is the maximum distance for x² + y², when x = y = 1 | -1
        const float MaxDistance = 1.4142135623730951f;
        const int MaxSticks = 4;
        #endregion Button Constants


        #region Constructors

        static Joystick[] _sticks;
        static GamePadState[] _state;
        static int s_numJoysticks;

        static GamePad()
        {
            // SDL currently does not detect new devices, so we'll statically initialize the array of available joysticks
            Joysticks.Initialize();

            s_numJoysticks = Joysticks.NumberOfJoysticks > MaxSticks ? MaxSticks : Joysticks.NumberOfJoysticks;
            _state = new GamePadState[MaxSticks];
            _sticks = new Joystick[MaxSticks];

            if (s_numJoysticks > 0)
            {
                for (int i = 0; i < s_numJoysticks; i++)
                {
                    _sticks[i] = Joysticks.OpenJoystick(i);
                    _state[i].isConnected = true;
                }

                Events.JoystickButtonDown += new EventHandler<JoystickButtonEventArgs>(Events_JoystickButtonDown);
                Events.JoystickButtonUp += new EventHandler<JoystickButtonEventArgs>(Events_JoystickButtonUp);
                Events.JoystickAxisMotion += new EventHandler<JoystickAxisEventArgs>(Events_JoystickAxisMotion);
                Events.JoystickHatMotion += new EventHandler<JoystickHatEventArgs>(Events_JoystickHatMotion);
            }
        }

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

        #endregion Constructors


        #region Public Methods

        public static GamePadCapabilities GetCapabilities(PlayerIndex playerIndex)
        {
            if (playerIndex < PlayerIndex.One || playerIndex > PlayerIndex.Four)
                throw new InvalidOperationException();

            GamePadCapabilities caps = new GamePadCapabilities();
            Joystick stick = _sticks[(int)playerIndex];
            if (stick != null)
            {
                caps.hasAButton = stick.NumberOfButtons > 1;
                caps.hasBButton = stick.NumberOfButtons > 0;
                caps.hasDPadDownButton = caps.hasDPadLeftButton = caps.hasDPadRightButton = caps.hasDPadUpButton = stick.NumberOfHats > 0;
                caps.hasLeftShoulderButton = stick.NumberOfButtons > 4;
                caps.hasRightShoulderButton = stick.NumberOfButtons > 5;
                caps.hasStartButton = stick.NumberOfButtons > 7;
                caps.hasXButton = stick.NumberOfButtons > 2;
                caps.hasYButton = stick.NumberOfButtons > 3;
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
                Joystick j = _sticks[number];

                _state[number].buttons.A = (ButtonState)j.GetButtonState(A);
                _state[number].buttons.B = (ButtonState)j.GetButtonState(B);
                _state[number].buttons.X = (ButtonState)j.GetButtonState(X);
                _state[number].buttons.Y = (ButtonState)j.GetButtonState(Y);
                _state[number].buttons.Back = (ButtonState)j.GetButtonState(Back);
                _state[number].buttons.Start = (ButtonState)j.GetButtonState(Start);
                _state[number].buttons.LeftShoulder = (ButtonState)j.GetButtonState(LeftShoulder);
                _state[number].buttons.LeftStick = (ButtonState)j.GetButtonState(LeftStick);
                _state[number].buttons.RightShoulder = (ButtonState)j.GetButtonState(RightShoulder);
                _state[number].buttons.RightStick = (ButtonState)j.GetButtonState(RightStick);

                float x1 = Rescale(j.GetAxisPosition(JoystickAxis.Horizontal));
                float y1 = Rescale(j.GetAxisPosition(JoystickAxis.Vertical));
                float x2 = Rescale(j.GetAxisPosition(JoystickAxis.Axis3));
                float y2 = Rescale(j.GetAxisPosition(JoystickAxis.Axis4));

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
                GamePadDPad.ToGamePadDPad(ref _state[number].dPad, j.GetHatState(0));

                // converts ButtonKeyState.Pressed ( = 1) to float of 1.0f
                // since SDL doesn't support reading the position of the trigger.  Will review this later
                _state[number].triggers.left = (int)j.GetButtonState(LeftTrigger)*1.0f;
                _state[number].triggers.right = (int)j.GetButtonState(RightTrigger)*1.0f;
            }

            return _state[number];
        }

        const float DEADZONE = 0.2f;
        const double EPSILON = 1 / 100000;

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
            return (0.5f - p)*2f;
        }

        public static bool SetVibration(PlayerIndex playerIndex, float leftMotor, float rightMotor)
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}﻿
