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

    // TODO: Tests
    public static class DateTimeEx
    {
        internal static readonly DateTime UnixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        public static DateTime FromUnixDateTime(int unixTime)
        {
            return FromUnixDateTime((long)unixTime);
        }
        public static DateTime FromUnixDateTime(long unixTime)
        {
            return UnixStart.AddSeconds(unixTime).ToLocalTime();
        }
    }
}
