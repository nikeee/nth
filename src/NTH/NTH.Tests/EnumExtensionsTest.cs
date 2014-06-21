using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NTH.Tests
{
    [TestClass]
    public class EnumExtensionsTest
    {
        [TestMethod]
        public void GetAttributeOfType()
        {
            var value = SampleEnum.Spitze;
            var attribute = value.GetAttributeOfType<TestAttribute>();

            var expected = typeof (TestAttribute);
            var actual = attribute.GetType();
            Assert.AreEqual(expected, actual);
            Assert.AreNotEqual(attribute, null);
            Assert.AreEqual(attribute.Name, "Ganztoll");


            value = SampleEnum.Top;
            attribute = value.GetAttributeOfType<TestAttribute>();

            expected = typeof(TestAttribute);
            actual = attribute.GetType();
            Assert.AreEqual(expected, actual);
            Assert.AreNotEqual(attribute, null);
            Assert.AreEqual(attribute.Name, "Fantastic!");


            value = SampleEnum.Spitze;
            var attribute2 = value.GetAttributeOfType<TestAttribute2>();

            expected = typeof(TestAttribute2);
            actual = attribute2.GetType();
            Assert.AreEqual(expected, actual);
            Assert.AreNotEqual(attribute2, null);
            Assert.AreEqual(attribute2.Name2, "Nope1");

            value = SampleEnum.Top;
            attribute2 = value.GetAttributeOfType<TestAttribute2>();

            expected = typeof(TestAttribute2);
            actual = attribute2.GetType();
            Assert.AreEqual(expected, actual);
            Assert.AreNotEqual(attribute2, null);
            Assert.AreEqual(attribute2.Name2, "Nope2");
        }
    }

    enum SampleEnum
    {
        [TestAttribute("Ganztoll")]
        [TestAttribute2("Nope1")]
        Spitze,
        [TestAttribute("Fantastic!")]
        [TestAttribute2("Nope2")]
        Top
    }

    public class TestAttribute : Attribute
    {
        public string Name { get; set; }

        public TestAttribute(string name)
        {
            Name = name;
        }
    }
    public class TestAttribute2 : Attribute
    {
        public string Name2 { get; set; }

        public TestAttribute2(string name2)
        {
            Name2 = name2;
        }
    }
}
