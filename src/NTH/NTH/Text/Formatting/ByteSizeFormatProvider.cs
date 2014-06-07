using System;
using System.Globalization;

namespace NTH.Text.Formatting
{
    public class ByteSizeFormatProvider : IFormatProvider, ICustomFormatter
    {
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            var argType = arg.GetType();
            if (argType != typeof(long)
                && argType != typeof(int)
                && argType != typeof(short)
                && argType != typeof(byte))
            {
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(string.Format("The format of '{0}' is invalid.", format), e);
                }
            }

            var byteSize = long.Parse(arg.ToString(), NumberStyles.None, null);
            return ByteSizeFormatter.FormatBytes(byteSize, false);
        }

        private string HandleOtherFormats(string format, object arg)
        {
            var formattable = arg as IFormattable;
            if (formattable != null)
                return formattable.ToString(format, CultureInfo.CurrentCulture);
            if (arg != null)
                return arg.ToString();
            return string.Empty;
        }

        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : null;
        }
    }
}