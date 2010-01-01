#region License

/*
MIT License
Copyright © 2007 The Mono.Xna Team

All rights reserved.

Authors:
 * Stuart Carnie

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

using Microsoft.Xna.Framework.Graphics.PackedVector;
using Microsoft.Xna.Framework.Tests;
using NUnit.Framework;

namespace Microsoft.Xna.Framework.Graphics.Tests
{
    [TestFixture]
    public class ColorTests
    {
        /// <summary>
        /// A test for the constructors
        /// </summary>
        [Test]
        public void ConstructorTest()
        {
            Color c = new Color(0x00, 0x10, 0x20);
            Assert.IsInstanceOfType(typeof(Color), c, "Color was not constructed");

            Assert.AreEqual(0x00, c.R, "Red component invalid");
            Assert.AreEqual(0x10, c.G, "Green component invalid");
            Assert.AreEqual(0x20, c.B, "Blue component invalid");
            Assert.AreEqual(0xFF, c.A, "Alpha component invalid");

            Assert.AreEqual(0xFF001020, c.PackedValue, "Unexpected PackedValue");
        }

        /// <summary>
        /// A test for Equals, and that standard colors also equal new instance
        ///</summary>
        [Test]
        public void EqualsTest()
        {
            Color c1 = new Color(0x00, 0x10, 0x20);
            Color c2 = new Color(0x00, 0x10, 0x20);
            
            Assert.AreEqual(c1, c2, "Colors c1 and c2 should be equal");

            c1 = Color.Blue;

            c2 = new Color(0, 0, 0xFF);

            Assert.AreEqual(c1, c2, "Colors c1(Color.Blue) and c2 should be equal");

        }

        /// <summary>
        /// Validates that GetHashCode is derived from the packed value
        ///</summary>
        [Test]
        public void GetHashCodeTests()
        {
            Color c1 = new Color(0x00, 0x10, 0x20);
            Assert.AreEqual(c1.PackedValue, (uint)c1.GetHashCode(), "HashCode should match PackedValue");
            Assert.AreEqual(0xFF001020, (uint)c1.GetHashCode(), "Unexpected hash code");
            Assert.AreEqual(0xFF001020, c1.PackedValue, "Unexpected packedvalue");

            c1 = Color.Blue;
            Assert.AreEqual(c1.PackedValue, (uint)c1.GetHashCode(), "Color.Blue packedvalue and GetHashCode do not match");
        }

        #region IPackedVector Tests
      
        [Test]
        public void PackFromVector4Tests()
        {
            IPackedVector pv = new Color();
            pv.PackFromVector4(new Vector4(1.0f, 0.75f, 0.5f, 0.0f));
            Assert.AreEqual(0x00FFBF80, ((Color)pv).PackedValue);
        }

        [Test]
        public void ToVector4Tests()
        {
            Color c = new Color(0xFF, 0xBF, 0x7F, 0x00);
            Vector4 v = c.ToVector4();

            Assert.IsTrue(TestHelper.ApproximatelyEquals(1.0f, v.X), "Unexpected value for X");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(0.75f, v.Y), "Unexpected value for Y");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(0.5f, v.Z), "Unexpected value for Z");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(0.0f, v.W), "Unexpected value for W");
        }

        [Test]
        public void ToVector3Tests()
        {
            Color c = new Color(0xFF, 0xBF, 0x7F, 0x00);
            Vector3 v = c.ToVector3();

            Assert.IsTrue(TestHelper.ApproximatelyEquals(1.0f, v.X), "Unexpected value for X");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(0.75f, v.Y), "Unexpected value for Y");
            Assert.IsTrue(TestHelper.ApproximatelyEquals(0.5f, v.Z), "Unexpected value for Z");
        }

   
	    #endregion IPackedVector Tests
        
    }
}