#if!MSXNAONLY
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using NUnit.Framework;
using SdlDotNet.Input;

namespace Microsoft.Xna.Framework.Microsoft.Xna.Framework.Input
{
    [TestFixture]
    public class GamePadDPadTests
    {
        [Test]
        public void ValidateToGamePadDPadFromJoystickHatStates()
        {
            GamePadDPad o = new GamePadDPad();
            GamePadDPad.ToGamePadDPad(ref o, JoystickHatStates.None);
            Assert.AreEqual(ButtonState.Released, o.Up, "For JoystickHatStates.None, o.Up = ButtonState.Released");
            Assert.AreEqual(ButtonState.Released, o.Right, "For JoystickHatStates.None, o.Right = ButtonState.Released");
            Assert.AreEqual(ButtonState.Released, o.Down, "For JoystickHatStates.None, o.Down = ButtonState.Released");
            Assert.AreEqual(ButtonState.Released, o.Left, "For JoystickHatStates.None, o.Left = ButtonState.Released");

            GamePadDPad.ToGamePadDPad(ref o, JoystickHatStates.Up);
            Assert.AreEqual(ButtonState.Pressed, o.Up, "For JoystickHatStates.Up, o.Up = ButtonState.Pressed");
            Assert.AreEqual(ButtonState.Released, o.Right, "For JoystickHatStates.Up, o.Right = ButtonState.Released");
            Assert.AreEqual(ButtonState.Released, o.Down, "For JoystickHatStates.Up, o.Down = ButtonState.Released");
            Assert.AreEqual(ButtonState.Released, o.Left, "For JoystickHatStates.Up, o.Left = ButtonState.Released");

            GamePadDPad.ToGamePadDPad(ref o, JoystickHatStates.RightUp);
            Assert.AreEqual(ButtonState.Pressed, o.Up, "For JoystickHatStates.RightUp, o.Up = ButtonState.Pressed");
            Assert.AreEqual(ButtonState.Pressed, o.Right, "For JoystickHatStates.RightUp, o.Right = ButtonState.Pressed");
            Assert.AreEqual(ButtonState.Released, o.Down, "For JoystickHatStates.RightUp, o.Down = ButtonState.Released");
            Assert.AreEqual(ButtonState.Released, o.Left, "For JoystickHatStates.RightUp, o.Left = ButtonState.Released");

            GamePadDPad.ToGamePadDPad(ref o, JoystickHatStates.Right);
            Assert.AreEqual(ButtonState.Released, o.Up, "For JoystickHatStates.Right, o.Up = ButtonState.Released");
            Assert.AreEqual(ButtonState.Pressed, o.Right, "For JoystickHatStates.Right, o.Right = ButtonState.Pressed");
            Assert.AreEqual(ButtonState.Released, o.Down, "For JoystickHatStates.Right, o.Down = ButtonState.Released");
            Assert.AreEqual(ButtonState.Released, o.Left, "For JoystickHatStates.Right, o.Left = ButtonState.Released");

            GamePadDPad.ToGamePadDPad(ref o, JoystickHatStates.RightDown);
            Assert.AreEqual(ButtonState.Released, o.Up, "For JoystickHatStates.RightDown, o.Up = ButtonState.Released");
            Assert.AreEqual(ButtonState.Pressed, o.Right, "For JoystickHatStates.RightDown, o.Right = ButtonState.Pressed");
            Assert.AreEqual(ButtonState.Pressed, o.Down, "For JoystickHatStates.RightDown, o.Down = ButtonState.Pressed");
            Assert.AreEqual(ButtonState.Released, o.Left, "For JoystickHatStates.RightDown, o.Left = ButtonState.Released");

            GamePadDPad.ToGamePadDPad(ref o, JoystickHatStates.Down);
            Assert.AreEqual(ButtonState.Released, o.Up, "For JoystickHatStates.Down, o.Up = ButtonState.Released");
            Assert.AreEqual(ButtonState.Released, o.Right, "For JoystickHatStates.Down, o.Right = ButtonState.Released");
            Assert.AreEqual(ButtonState.Pressed, o.Down, "For JoystickHatStates.Down, o.Down = ButtonState.Pressed");
            Assert.AreEqual(ButtonState.Released, o.Left, "For JoystickHatStates.Down, o.Left = ButtonState.Released");

            GamePadDPad.ToGamePadDPad(ref o, JoystickHatStates.LeftDown);
            Assert.AreEqual(ButtonState.Released, o.Up, "For JoystickHatStates.LeftDown, o.Up = ButtonState.Released");
            Assert.AreEqual(ButtonState.Released, o.Right, "For JoystickHatStates.LeftDown, o.Right = ButtonState.Released");
            Assert.AreEqual(ButtonState.Pressed, o.Down, "For JoystickHatStates.LeftDown, o.Down = ButtonState.Pressed");
            Assert.AreEqual(ButtonState.Pressed, o.Left, "For JoystickHatStates.LeftDown, o.Left = ButtonState.Pressed");

            GamePadDPad.ToGamePadDPad(ref o, JoystickHatStates.Left);
            Assert.AreEqual(ButtonState.Released, o.Up, "For JoystickHatStates.Left, o.Up = ButtonState.Released");
            Assert.AreEqual(ButtonState.Released, o.Right, "For JoystickHatStates.Left, o.Right = ButtonState.Released");
            Assert.AreEqual(ButtonState.Released, o.Down, "For JoystickHatStates.Left, o.Down = ButtonState.Released");
            Assert.AreEqual(ButtonState.Pressed, o.Left, "For JoystickHatStates.Left, o.Left = ButtonState.Pressed");

            GamePadDPad.ToGamePadDPad(ref o, JoystickHatStates.LeftUp);
            Assert.AreEqual(ButtonState.Pressed, o.Up, "For JoystickHatStates.LeftUp, o.Up = ButtonState.Pressed");
            Assert.AreEqual(ButtonState.Released, o.Right, "For JoystickHatStates.LeftUp, o.Right = ButtonState.Released");
            Assert.AreEqual(ButtonState.Released, o.Down, "For JoystickHatStates.LeftUp, o.Down = ButtonState.Released");
            Assert.AreEqual(ButtonState.Pressed, o.Left, "For JoystickHatStates.LeftUp, o.Left = ButtonState.Pressed");

            
        }
    }
}
#endif