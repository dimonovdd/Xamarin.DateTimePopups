using System;
using System.Threading.Tasks;
using DT.iOS.DatePickerDialog;
using UIKit;

namespace Xamarin.DateTimePopups
{
    public static partial class DateTimePopups
    {
        static Task<DateTime?> PlatformPickDateAsync(DateTime? defaultDate = null, DateTime? minDate = null, DateTime? maxDate = null)
            => ShowPicker(false, defaultDate, minDate, maxDate);

        static async Task<TimeSpan?> PlatformPickTimeAsync(TimeSpan? defaultTime = null)
        {
            var dateTime = await ShowPicker(true, defaultTime != null ? DateTime.Now.Date + defaultTime : null);
            return dateTime != null
                ? new TimeSpan(dateTime.Value.TimeOfDay.Hours, dateTime.Value.TimeOfDay.Minutes, 0)
                : (TimeSpan?)null;
        }

        static Task<DateTime?> ShowPicker(bool isTime, DateTime? selectedDate = null, DateTime? minDate = null, DateTime? maxDate = null)
        {
            var tcs = new TaskCompletionSource<DateTime?>();

            var dialog = new DatePickerDialog();
            dialog.Show(
                null,
                "Done",
                "Cancel",
                isTime ? UIDatePickerMode.Time : UIDatePickerMode.Date,
                (date) => tcs.TrySetResult(date),
                selectedDate ?? DateTime.Now,
                maxDate,
                minDate,
                () => tcs.TrySetResult(null));        

            return tcs.Task;
        }
    }
}