using System;
using System.Threading.Tasks;

namespace Xamarin.DateTimePopups
{
    /// <summary>Helper for picking date and time using native popups</summary>
    public static partial class DateTimePopups
    {
        /// <summary>Method returns the date picked by the user or null if a cancellation occurred</summary>
        /// <param name="defaultDate">Date that will be shown by default</param>
        /// <param name="minDate">Minimum allowed date</param>
        /// <param name="maxDate">Maximum allowed date</param>
        /// <returns>(Day, Month, Year) or null</returns>
        public static async Task<DateTime?> PickDateAsync(
            DateTime? defaultDate = null,
            DateTime? minDate = null,
            DateTime? maxDate = null)
            => (await PlatformPickDateAsync(defaultDate, minDate, maxDate))?.Date;

        /// <summary>Method returns the time picked by the user or null if a cancellation occurred</summary>
        /// <param name="defaultTime">Time that will be shown by default</param>
        /// <returns>(hours, Minutes) or null</returns>
        public static Task<TimeSpan?> PickTimeAsync(TimeSpan? defaultTime = null)
               => PlatformPickTimeAsync(defaultTime);
    }
}