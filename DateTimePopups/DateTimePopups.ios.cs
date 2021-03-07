using System;
using System.Threading.Tasks;
using DT.iOS.DatePickerDialog;
using UIKit;

namespace Xamarin.DateTimePopups
{
    public static partial class DateTimePopups
    {
        static Task<DateTime?> PlatformPickDateAsync(DateTime? selectedDate = null, DateTime? minDate = null, DateTime? maxDate = null)
        {
            return ShowPicker(false, selectedDate, minDate, maxDate);
        }

        static async Task<TimeSpan?> PlatformPickTimeAsync(TimeSpan? selectedTime = null)
        {
            var dateTime = await ShowPicker(true, selectedTime != null ? DateTime.Now.Date + selectedTime : null);
            return dateTime.Value.TimeOfDay;
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