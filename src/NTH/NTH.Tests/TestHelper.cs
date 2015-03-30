using NUnit.Framework;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NTH.Tests
{
    internal static class TestHelper
    {
        internal static void AssertException<T>(Action action)
            where T : Exception
        {
            if (action == null)
                throw new DivideByZeroException();
            try
            {
                action();
            }
            catch (T e)
            {
                Assert.IsNotNull(e);
                return;
            }
            Assert.Fail("No exception thrown.");
        }

        internal static bool IsSerializable<T>(T instance)
        {
            Assert.IsNotNull(instance);

            using (var ms = new MemoryStream())
            {
                var b = new BinaryFormatter();
                try
                {
                    b.Serialize(ms, instance);

                    var instance2 = Deserialize<T>(ms);
                    Assert.IsNotNull(instance2);

                    return true;
                }
                catch (Exception ex)
                {
                    Assert.Fail(ex.Message);
                    return false; // Redundant, whatever
                }
            }
        }

        private static T Deserialize<T>(Stream stream)
        {
            var bf = new BinaryFormatter();
            stream.Position = 0;
            return (T)bf.Deserialize(stream);
        }

        internal static bool HasAttribute<TType, TAttribute>()
            where TAttribute : Attribute
        {
            var attr = Attribute.GetCustomAttribute(typeof(TType), typeof(TAttribute));
            Assert.IsNotNull(attr);
            return attr != null; // Redundant, whatever
        }
    }
}
