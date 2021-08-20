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

            DateTime defaultDate = selectedDate ?? DateTime.Now;

            if (defaultDate.Kind == DateTimeKind.Unspecified)
            {
                defaultDate = DateTime.SpecifyKind(defaultDate, DateTimeKind.Local);
            }

            var dialog = new DatePickerDialog(useLocalizedButtons: true);
            dialog.Show(
                null,
                isTime ? UIDatePickerMode.Time : UIDatePickerMode.Date,
                (date) => tcs.TrySetResult(date),
                defaultDate,
                maxDate,
                minDate,
                () => tcs.TrySetResult(null),
                Platform.getCurrentViewFunc);

            return tcs.Task;
        }
    }
}