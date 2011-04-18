using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Microsoft.Xna.Framework.Content;

namespace Tests.Microsoft.Xna.Framework.Content
{
    [TestFixture]
    public class ContentSerializerAttributeTests
    {
        private ContentSerializerAttribute attribute;

        [SetUp]
        public void Setup()
        {
            attribute = new ContentSerializerAttribute();
            attribute.AllowNull = true;
            attribute.ElementName = "Name";
            attribute.FlattenContent = true;
        }

        [Test]
        public void EqualsTest()
        {
            ContentSerializerAttribute clone = new ContentSerializerAttribute();
            attribute.AllowNull = true;
            attribute.ElementName = "Name";
            attribute.FlattenContent = true;

            Assert.AreNotEqual(this.attribute, clone, "#1");

            clone = this.attribute.Clone();
            Assert.AreNotSame(this.attribute, clone, "#2");
            Assert.AreEqual(this.attribute, clone, "#3");
            Assert.IsTrue(this.attribute != clone, "#4");
            Assert.IsFalse(this.attribute.Equals(null), "#5");
            int aa = 5;
            Assert.IsFalse(this.attribute.Equals(aa), "#6");
        }

        [Test]
        public void ToStringTest()
        {
            Assert.AreEqual("Microsoft.Xna.Framework.Content.ContentSerializerAttribute", this.attribute.ToString());
        }

        [Test]
        public void IsDefaultAttributeTest()
        {
            Assert.IsFalse(this.attribute.IsDefaultAttribute());
        }
    }
}
