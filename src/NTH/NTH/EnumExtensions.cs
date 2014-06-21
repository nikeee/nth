using System;

namespace NTH
{
    public static class EnumExtensions
    {
        // TODO: Tests
        public static T GetAttributeOfType<T>(this Enum value)
            where T : Attribute
        {
            var enumType = value.GetType();
            var memberInfo = enumType.GetMember(value.ToString());
            
            if(memberInfo.Length == 0)
                throw new ArgumentException("Invalid enum member");

            var attributes = memberInfo[0].GetCustomAttributes(typeof (T), false);

            if (attributes.Length == 0)
                return null;
            return attributes[0] as T;
        }
    }
}
