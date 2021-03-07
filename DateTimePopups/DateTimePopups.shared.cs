using System;
using System.Threading.Tasks;

namespace Xamarin.DateTimePopups
{
    public static partial class DateTimePopups
    {
        public static Task<DateTime?> PickDateAsync(DateTime? selectedDate = null, DateTime? minDate = null, DateTime? maxDate = null)
               => PlatformPickDateAsync(selectedDate, minDate, maxDate);

        public static Task<TimeSpan?> PickTimeAsync(TimeSpan? selectedTime = null)
               => PlatformPickTimeAsync(selectedTime);
    }
}