using NUnit.Framework;
using System;

namespace NTH.Tests
{
    [TestFixture]
    public class DateTimeTests
    {
        [Test]
        public void ToUnixTime()
        {
            /*
             "The Unix epoch is the time 00:00:00 UTC on 1 January 1970 (or 1970-01-01T00:00:00Z ISO 8601)."
             * See:
             * https://en.wikipedia.org/wiki/Unix_time#Encoding_time_as_a_number
             */
            var unixStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long expected = 0;
            var actual = unixStart.ToUnixTime();
            Assert.AreEqual(expected, actual);

            // First second
            var test1 = new DateTime(1970, 1, 1, 0, 0, 1, DateTimeKind.Utc);
            expected = 1;
            actual = test1.ToUnixTime();
            Assert.AreEqual(expected, actual);

            // -1
            var test11 = new DateTime(1969, 12, 31, 23, 59, 59, DateTimeKind.Utc);
            expected = -1;
            actual = test11.ToUnixTime();
            Assert.AreEqual(expected, actual);

            /*
             * "At 01:46:40 UTC on 9 September 2001, the Unix billennium (Unix time number 1,000,000,000) was celebrated."
             */
            var test2 = new DateTime(2001, 9, 9, 1, 46, 40, DateTimeKind.Utc);
            expected = 1000000000;
            actual = test2.ToUnixTime();
            Assert.AreEqual(expected, actual);

            /*
             * "At 23:31:30 UTC on 13 February 2009, the decimal representation of Unix time reached 1,234,567,890 seconds (like the number row on a keyboard)."
             */
            var test3 = new DateTime(2009, 2, 13, 23, 31, 30, DateTimeKind.Utc);
            expected = 1234567890;
            actual = test3.ToUnixTime();
            Assert.AreEqual(expected, actual);

            /*
             * "At 06:28:15 UTC on Sun, 7 February 2106, the Unix time will reach 0xFFFFFFFF or 4,294,967,295 seconds which, for systems that hold the time on 32 bit unsigned numbers, is the maximum attainable"
             */
            var test4 = new DateTime(2106, 2, 7, 06, 28, 15, DateTimeKind.Utc);
            expected = 0xFFFFFFFF;
            actual = test4.ToUnixTime();
            Assert.AreEqual(expected, actual);

            /*
             * "At 16:53:20 UTC on 13 May 2014, the Unix time value 1,400,000,000 seconds was celebrated over the Web"
             */
            var test5 = new DateTime(2014, 5, 13, 16, 53, 20, DateTimeKind.Utc);
            expected = 1400000000;
            actual = test5.ToUnixTime();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FromUnixTime()
        {
            // Same dates taken than in ToUnixTime

            var expected = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long value = 0;
            var actual = DateTimeEx.FromUnixToUtcDateTime(value);
            Assert.AreEqual(expected, actual);

            expected = new DateTime(1970, 1, 1, 0, 0, 1, DateTimeKind.Utc);
            value = 1;
            actual = DateTimeEx.FromUnixToUtcDateTime(value);
            Assert.AreEqual(expected, actual);

            expected = new DateTime(1969, 12, 31, 23, 59, 59, DateTimeKind.Utc);
            value = -1;
            actual = DateTimeEx.FromUnixToUtcDateTime(value);
            Assert.AreEqual(expected, actual);

            expected = new DateTime(2001, 9, 9, 1, 46, 40, DateTimeKind.Utc);
            value = 1000000000;
            actual = DateTimeEx.FromUnixToUtcDateTime(value);
            Assert.AreEqual(expected, actual);

            expected = new DateTime(2009, 2, 13, 23, 31, 30, DateTimeKind.Utc);
            value = 1234567890;
            actual = DateTimeEx.FromUnixToUtcDateTime(value);
            Assert.AreEqual(expected, actual);

            expected = new DateTime(2106, 2, 7, 06, 28, 15, DateTimeKind.Utc);
            value = 0xFFFFFFFF;
            actual = DateTimeEx.FromUnixToUtcDateTime(value);
            Assert.AreEqual(expected, actual);

            expected = new DateTime(2014, 5, 13, 16, 53, 20, DateTimeKind.Utc);
            value = 1400000000;
            actual = DateTimeEx.FromUnixToUtcDateTime(value);
            Assert.AreEqual(expected, actual);
        }
    }
}
