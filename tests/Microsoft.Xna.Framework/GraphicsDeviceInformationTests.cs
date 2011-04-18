using Microsoft.Xna.Framework.Graphics;
using NUnit.Framework;

namespace Tests.Microsoft.Xna.Framework
{
    [TestFixture]
    public class GraphicsDeviceInformationTests
    {
        GraphicsDeviceInformation gdi;

        [SetUp]
        public void Setup()
        {
            gdi = new GraphicsDeviceInformation();
        }

        #region Constructor Tests

        [Test]
        public void ConstructorTest()
        {
            Assert.IsNotNull(gdi);
        }

        [Test]
        public void DeviceTypeDefaultValueTest()
        {
            Assert.AreEqual(DeviceType.Hardware, gdi.DeviceType);
        }

        [Test]
        public void CreateOptionsDefaultValueTest()
        {
            Assert.AreEqual(CreateOptions.HardwareVertexProcessing, gdi.CreationOptions);
        }

        #endregion Constructor Tests

        #region Public Method Tests

        [Test]
        public void AreEqualTest()
        {
            GraphicsDeviceInformation gdi2 = new GraphicsDeviceInformation();
            Assert.AreEqual(gdi, gdi2, "Objects were expected to be equal");
        }

        [Test]
        public void TwoInstancesAreNotEqualTest()
        {
            GraphicsDeviceInformation gdi2 = new GraphicsDeviceInformation();
            gdi2.PresentationParameters.BackBufferWidth = 320;
            gdi2.PresentationParameters.BackBufferHeight = 240;
            Assert.AreNotEqual(gdi, gdi2, "Objects were not expected to be equal");
        }

        [Test]
        public void NullAndInstanceAreNotEqualTest()
        {
            Assert.IsFalse(gdi.Equals(null));
        }

        [Test]
        public void GetHashCodeIsNotEqualTest()
        {
            GraphicsDeviceInformation gdi2 = new GraphicsDeviceInformation();
            gdi2.PresentationParameters.BackBufferWidth = 320;
            gdi2.PresentationParameters.BackBufferHeight = 240;
            Assert.AreNotEqual(gdi.GetHashCode(), gdi2.GetHashCode(), "GetHashCodes were not expected to be equal");
        }

        #endregion Public Method Tests
    }
}