using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Tests.Microsoft.Xna.Framework.Content
{
    [TestFixture]
    public class ContentTypeReaderTests
    {
        FakeReader reader;

        [SetUp]
        public void Setup()
        {
            reader = new FakeReader(typeof(Texture));
        }

        //[Test]
        //public void EqualsTest()
        //{
        //    FakeReader reader2 = new FakeReader(typeof(Texture));
        //    Assert.AreNotEqual(reader, reader2, "#1");
        //    Assert.IsFalse(reader == reader2, "#2");
        //    Assert.AreNotEqual(reader, null, "#3");
        //    Assert.IsFalse(reader.Equals((object)5), "#4");
        //    Assert.IsTrue(reader.Equals(reader), "#5");
        //}

        [Ignore("Not sure what Initialise does")]
        [Test]
        public void Initialise()
        {
            reader.Init(null);
        }

        [Test]
        public void TypeTest()
        {
            Assert.AreEqual(typeof(Texture), reader.TargetType);
        }

        [Test]
        public void TypeVersion()
        {
            Assert.AreEqual(0, reader.TypeVersion);
        }
    }


    [TestFixture]
    public class ContentTypeReaderGenericTests
    {
        FakeReaderGeneric<int> readerGeneric;

        [SetUp]
        public void Setup()
        {
            readerGeneric = new FakeReaderGeneric<int>();
        }

        [Ignore("Not sure what Initialise does")]
        [Test]
        public void Initialise()
        {
            readerGeneric.Init(null);
        }

        //[Test]
        //public void EqualsTest()
        //{
        //    FakeReaderGeneric<int> readerGeneric2 = new FakeReaderGeneric<int>();
        //    Assert.AreNotEqual(readerGeneric, readerGeneric2, "#1");
        //    Assert.IsFalse(readerGeneric == readerGeneric2, "#2");
        //    Assert.AreNotEqual(readerGeneric, null, "#3");
        //    Assert.IsFalse(readerGeneric.Equals((object)5), "#4");
        //    Assert.IsTrue(readerGeneric.Equals(readerGeneric), "#5");
        //}



        [Test]
        public void TypeTest()
        {
            Assert.AreEqual(typeof(int), readerGeneric.TargetType);
        }

        [Test]
        public void TypeVersion()
        {
            Assert.AreEqual(0, readerGeneric.TypeVersion);
        }
    }

    public class FakeReader : ContentTypeReader
    {
        public FakeReader(Type targetType)
            : base(targetType)
        {

        }

        protected override object Read(ContentReader input, object existingInstance)
        {
            return null;
        }

        public new Type TargetType
        {
            get { return base.TargetType; }
        }

        public override int TypeVersion
        {
            get { return base.TypeVersion; }
        }

        public void Init(ContentTypeReaderManager manager)
        {
            Initialize(manager);
        }

        protected override void Initialize(ContentTypeReaderManager manager)
        {
            base.Initialize(manager);
        }
    }


    public class FakeReaderGeneric<T> : ContentTypeReader<T>
    {

        public FakeReaderGeneric()
            : base()
        {
        }

        public new Type TargetType
        {
            get { return base.TargetType; }
        }

        public override int TypeVersion
        {
            get { return base.TypeVersion; }
        }

        public void Init(ContentTypeReaderManager manager)
        {
            Initialize(manager);
        }

        protected override void Initialize(ContentTypeReaderManager manager)
        {
            base.Initialize(manager);
        }

        protected override T Read(ContentReader input, T existingInstance)
        {
            return default(T);
        }
    }
}
