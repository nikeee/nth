using System;

namespace NTH
{
    public class PreReleaseIdentifier
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
                // TODO: Validation check
                _value = value;
            }
        }


        public bool IsDigitValue
        {
            get
            {
                if (Value == null)
                    return false;
                char c;
                for (int i = 0; i < Value.Length; ++i)
                {
                    c = Value[i];
                    if (!('0' <= c && c <= '9'))
                        return false;
                }
                return true;
            }
        }

        public int GetIntegerValue()
        {
            if (!IsDigitValue)
                throw new InvalidOperationException();
            return int.Parse(Value);
        }

        public PreReleaseIdentifier(string identifier)
        {
            if (string.IsNullOrWhiteSpace(identifier))
                throw new ArgumentNullException("identifier");
            Value = identifier;
        }
    }
}
