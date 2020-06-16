using System;

namespace Shaparak.PaymentFacilitation.Core.Infrastructure {

    internal static class TimeStampHelper {

        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Convert a <see cref="DateTime"/> value to correspondig Unix Timestamp.
        /// Note that you must send DateTime value in UTC for this method to work correctly.
        /// </summary>
        /// <param name="value">DateTime value to convert to Timestamp.</param>
        /// <returns>Unix Timestamp for the given <see cref="DateTime"/> value.</returns>
        public static long ToTimestamp(this DateTime value) {
            TimeSpan elapsedTime = value - Epoch;
            return (long)elapsedTime.TotalSeconds;
        }

        /// <summary>
        /// Convert a <see cref="DateTime"/> value to correspondig Unix Timestamp3.
        /// Note that you must send DateTime value in UTC for this method to work correctly.
        /// </summary>
        /// <param name="value">DateTime value to convert to Timestamp3.</param>
        /// <returns>Unix Timestamp3 for the given <see cref="DateTime"/> value.</returns>
        public static long ToTimestamp3(this DateTime value) {
            long epoch = (value.Ticks - 621355968000000000) / 10000;
            return epoch;
        }
    }
}
