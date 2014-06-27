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

        public PreReleaseIdentifier(string identifier)
        {
            if (string.IsNullOrWhiteSpace(identifier))
                throw new ArgumentNullException("identifier");
            Value = identifier;
        }


        public int GetIntegerValue()
        {
            if (!IsDigitValue)
                throw new InvalidOperationException();
            return int.Parse(Value);
        }

        #region operators

        #region >

        public static bool operator >(PreReleaseIdentifier a, PreReleaseIdentifier b)
        {
            if (a.IsDigitValue && b.IsDigitValue)
            {
                return a.GetIntegerValue() > b.GetIntegerValue();
            }
            throw new NotImplementedException();
        }

        #endregion
        #region <

        public static bool operator <(PreReleaseIdentifier a, PreReleaseIdentifier b)
        {
            if (a.IsDigitValue && b.IsDigitValue)
            {
                return a.GetIntegerValue() < b.GetIntegerValue();
            }
            throw new NotImplementedException();
        }

        #endregion
        #region ==

        public static bool operator ==(PreReleaseIdentifier a, PreReleaseIdentifier b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if ((object)a == null || (object)b == null)
                return false;

            return a._value == b._value; // TODO: case (in)sensitive?
        }

        public static bool operator !=(PreReleaseIdentifier a, PreReleaseIdentifier b)
        {
            return !(a == b);
        }

        #endregion
        #region equals

        public override bool Equals(object obj)
        {
            var p = obj as PreReleaseIdentifier;
            if (p == null)
                return false;
            return p._value == _value; // TODO: case (in)sensitive?
        }

        public bool Equals(PreReleaseIdentifier obj)
        {
            if (obj == null)
                return false;
            return obj._value == _value; // TODO: case (in)sensitive?
        }

        // public override int GetHashCode()
        // {
        //     return _value.GetHashCode();
        // }

        #endregion

        #endregion

    }
}
