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
                if (_value == null)
                    return false;
                char c;
                for (int i = 0; i < _value.Length; ++i)
                {
                    c = _value[i];
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

        public string GetStringValue()
        {
            return _value;
        }

        #region operators

        #region >

        public static bool operator >(PreReleaseIdentifier a, PreReleaseIdentifier b)
        {
            bool isADigit = a.IsDigitValue;
            bool isBDigit = b.IsDigitValue;
            if (isADigit && isBDigit)
            {
                return a.GetIntegerValue() > b.GetIntegerValue();
            }

            // Numeric identifiers always have lower precedence than non-numeric identifiers
            if (isADigit)
                return false;
            if (isBDigit)
                return true;
            
            var valueA = a.GetStringValue();
            var valueB = b.GetStringValue();

            // taking a short one here
            if (valueA == valueB)
                return false;

            var max = Math.Min(valueA.Length, valueB.Length);

            for (int i = 0; i < max; ++i)
            {
                if (valueA[i] > valueB[i])
                    return true;
                if (valueA[i] < valueB[i])
                    return false;
            }

            // all identifiers are equal, so take a look at the total count
            if (max != Math.Max(valueA.Length, valueB.Length))
            {
                if (valueA.Length == max) // if a is the one with less identifiers
                    return false; // so it must be less valuable
                return true; // else, return false
            }

            return false; // essentially, a == b
        }

        #endregion
        #region <

        public static bool operator <(PreReleaseIdentifier a, PreReleaseIdentifier b)
        {
            bool isADigit = a.IsDigitValue;
            bool isBDigit = b.IsDigitValue;
            if (isADigit && isBDigit)
            {
                return a.GetIntegerValue() < b.GetIntegerValue();
            }

            // Numeric identifiers always have lower precedence than non-numeric identifiers
            if (isADigit)
                return true;
            if (isBDigit)
                return false;
            
            var valueA = a.GetStringValue();
            var valueB = b.GetStringValue();

            // taking a short one here
            if (valueA == valueB)
                return false;

            var max = Math.Min(valueA.Length, valueB.Length);

            for (int i = 0; i < max; ++i)
            {
                if (valueA[i] < valueB[i])
                    return true;
                if (valueA[i] > valueB[i])
                    return false;
            }

            // all identifiers are equal, so take a look at the total count
            if (max != Math.Max(valueA.Length, valueB.Length))
            {
                if (valueA.Length == max) // if a is the one with less identifiers
                    return true; // so it must be less valuable
                return false; // else, return false
            }

            return false; // essentially, a == b
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

        public override int GetHashCode()
        {
             return base.GetHashCode(); // No immutable fields available, so just call the base?
        }

        #endregion

        #endregion

        public override string ToString()
        {
            return _value;
        }
    }
}
