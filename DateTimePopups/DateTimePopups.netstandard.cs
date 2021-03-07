using System;
using System.Threading.Tasks;

namespace Xamarin.DateTimePopups
{
    public static partial class DateTimePopups
    {
        static Task<DateTime?> PlatformPickDateAsync(DateTime? selectedDate = null, DateTime? minDate = null, DateTime? maxDate = null)
               => throw new NotImplementedException(GetMess(nameof(PickDateAsync)));

        static Task<TimeSpan?> PlatformPickTimeAsync(TimeSpan? selectedTime = null)
               => throw new NotImplementedException(GetMess(nameof(PickTimeAsync)));

        static string GetMess(string val)
            => $"{val} not supported on netstandart project";
    }
}
