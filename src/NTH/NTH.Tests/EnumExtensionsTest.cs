using NUnit.Framework;
using System;

namespace NTH.Tests
{
    [TestFixture]
    public class EnumExtensionsTest
    {
        [Test]
        public void GetAttributeOfType()
        {
            var value = SampleEnum.Spitze;
            var attribute = value.GetAttributeOfType<DemoTestAttribute>();

            var expected = typeof(DemoTestAttribute);
            var actual = attribute.GetType();
            Assert.AreEqual(expected, actual);
            Assert.AreNotEqual(attribute, null);
            Assert.AreEqual(attribute.Name, "Ganztoll");


            value = SampleEnum.Top;
            attribute = value.GetAttributeOfType<DemoTestAttribute>();

            expected = typeof(DemoTestAttribute);
            actual = attribute.GetType();
            Assert.AreEqual(expected, actual);
            Assert.AreNotEqual(attribute, null);
            Assert.AreEqual(attribute.Name, "Fantastic!");


            value = SampleEnum.Spitze;
            var attribute2 = value.GetAttributeOfType<DemoTestAttribute2>();

            expected = typeof(DemoTestAttribute2);
            actual = attribute2.GetType();
            Assert.AreEqual(expected, actual);
            Assert.AreNotEqual(attribute2, null);
            Assert.AreEqual(attribute2.Name2, "Nope1");

            value = SampleEnum.Top;
            attribute2 = value.GetAttributeOfType<DemoTestAttribute2>();

            expected = typeof(DemoTestAttribute2);
            actual = attribute2.GetType();
            Assert.AreEqual(expected, actual);
            Assert.AreNotEqual(attribute2, null);
            Assert.AreEqual(attribute2.Name2, "Nope2");
        }
    }

    enum SampleEnum
    {
        [DemoTestAttribute("Ganztoll")]
        [DemoTestAttribute2("Nope1")]
        Spitze,
        [DemoTestAttribute("Fantastic!")]
        [DemoTestAttribute2("Nope2")]
        Top
    }

    public class DemoTestAttribute : Attribute
    {
        public string Name { get; set; }

        public DemoTestAttribute(string name)
        {
            Name = name;
        }
    }
    public class DemoTestAttribute2 : Attribute
    {
        public string Name2 { get; set; }

        public DemoTestAttribute2(string name2)
        {
            Name2 = name2;
        }
    }
}
