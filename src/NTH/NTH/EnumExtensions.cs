using System;
using System.Collections.Generic;

namespace NTH
{
    /// <summary>Some utility extensions on <typeparam name="Enum"/>.</summary>
    public static class EnumExtensions
    {
        public static T GetAttributeOfType<T>(this Enum value)
            where T : Attribute
        {
            var enumType = value.GetType();
            var memberInfo = enumType.GetMember(value.ToString());

            if (memberInfo.Length == 0)
                throw new ArgumentException("Invalid enum member");

            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);

            if (attributes.Length == 0)
                return null;
            return attributes[0] as T;
        }

        public static IEnumerable<Enum> GetFlags(this Enum input)
        {
            foreach (Enum value in Enum.GetValues(input.GetType()))
                if (input.HasFlag(value))
                    yield return value;
        }
    }
}
