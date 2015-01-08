using System;

namespace NTH
{
    public static class DateTimeExtensions
    {
        public static long ToUnixTime(this DateTime value)
        {
            var totalSeconds = (value.ToUniversalTime() - DateTimeEx.UnixStart).TotalSeconds;
            return (long)Math.Truncate(totalSeconds);
        }
    }

    public static class DateTimeEx
    {
        internal static readonly DateTime UnixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime FromUnixToUtcDateTime(int unixTime)
        {
            return FromUnixToUtcDateTime((long)unixTime);
        }
        public static DateTime FromUnixToUtcDateTime(long unixTime)
        {
            return UnixStart.AddSeconds(unixTime);
        }


        // TODO: Tests
        public static DateTime FromUnixToLocalTime(int unixTime)
        {
            return FromUnixToLocalTime((long)unixTime);
        }
        public static DateTime FromUnixToLocalTime(long unixTime)
        {
            return FromUnixToUtcDateTime(unixTime).ToLocalTime();
        }
    }
}
