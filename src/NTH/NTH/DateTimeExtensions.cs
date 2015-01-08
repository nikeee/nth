using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTH
{
    // TODO: Tests
    public static class DateTimeExtensions
    {
        internal static readonly DateTime UnixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        public static long ToUnixTime(this DateTime value)
        {
            var totalSeconds = (value.ToUniversalTime() - UnixStart).TotalSeconds;
            return (long)Math.Truncate(totalSeconds);
        }
    }

    // TODO: Tests
    public static class DateTimeEx
    {
        public static DateTime FromUnixDateTime(int unixTime)
        {
            return FromUnixDateTime((long)unixTime);
        }
        public static DateTime FromUnixDateTime(long unixTime)
        {
            return DateTimeExtensions.UnixStart.AddSeconds(unixTime).ToLocalTime();
        }
    }
}
