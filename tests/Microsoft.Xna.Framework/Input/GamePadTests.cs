using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using NUnit.Framework;

namespace Microsoft.Xna.Framework.Microsoft.Xna.Framework.Input
{
    [TestFixture]
    public class GamePadTests
    {
        [ExpectedException(typeof(InvalidOperationException))]
        [Test]
        public void TestGetStateOutOfRangePlayerThrowsInvalidOperationException()
        {
            GamePad.GetState((PlayerIndex)5);
        }
        
        [ExpectedException(typeof(InvalidOperationException))]
        [Test]
        public void TestGetCapabilitiesOutOfRangePlayerThrowsInvalidOperationException()
        {
            GamePad.GetCapabilities((PlayerIndex)5);
        }
    }
}
