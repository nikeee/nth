using System;

namespace NTH
{
    public class BuildMetadata
    {
        private string _value;

        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (!IsValidValue(value))
                    throw new ArgumentException("Invalid value");
                _value = value;
            }
        }

        private static bool IsValidValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;
            for (int i = 0; i < value.Length; ++i)
            {
                char c = value[i];
                if (
                    !('0' <= c && c <= '9')
                    && !('A' <= c && c <= 'Z')
                    && !('a' <= c && c <= 'z')
                    && c != '-')
                    return false;
            }
            return true;
        }

        public BuildMetadata(string metadataIdentifier)
        {
            Value = metadataIdentifier;
        }

        public override string ToString()
        {
            return _value;
        }
    }
}
