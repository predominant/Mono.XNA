using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Microsoft.Xna.Framework.Input.Tests
{
    /// <summary>
    /// A series of tests to validate cross platform ENUMs are equal to Xna ENUMS, so we don't have to use logic
    /// </summary>
    [TestFixture]
    public class GamePadEnumsTests
    {
        #region Setup

        #endregion Setup

        #region ButtonState

        [Test]
        public void VerifyButtonStateEnumMatchesButtonKeyStateEnum()
        {
            //Assert.AreEqual((int)ButtonState.Released, (int)ButtonKeyState.NotPressed, "ButtonState.Released should match ButtonKeyState.NotPressed");
            //Assert.AreEqual((int)ButtonState.Pressed, (int)ButtonKeyState.Pressed, "ButtonState.Pressed should match ButtonKeyState.Pressed");
        }

        #endregion ButtonState

    }
}
