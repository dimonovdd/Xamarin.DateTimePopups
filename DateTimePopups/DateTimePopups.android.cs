using System;
using System.Threading.Tasks;
using Android.App;
using Android.Text.Format;
using Android.Views;

namespace Xamarin.DateTimePopups
{
    public static partial class DateTimePopups
    {
        static Task<DateTime?> PlatformPickDateAsync(DateTime? selectedDate = null, DateTime? minDate = null, DateTime? maxDate = null)
        {
            selectedDate ??= DateTime.Now;
            var activity = Platform.GetActivity();
            var tcs = new TaskCompletionSource<DateTime?>();

            using var dialog = new DatePickerDialog(
                activity,
                (sender, e) => tcs.TrySetResult(e.Date),
                selectedDate.Value.Year,
                selectedDate.Value.Month - 1,
                selectedDate.Value.Day);

            if (minDate != null)
                dialog.DatePicker.MinDate = minDate.Value.ToUnixTimestamp();

            if (maxDate != null)
                dialog.DatePicker.MaxDate = maxDate.Value.ToUnixTimestamp();

            dialog.KeyPress += DialogKeyPress;

            dialog.CancelEvent +=
                (sender, e) => tcs.TrySetResult(null);

            dialog.Show();
            return tcs.Task;
        }

        static Task<TimeSpan?> PlatformPickTimeAsync(TimeSpan? selectedTime = null)
        {
            selectedTime ??= DateTime.Now.TimeOfDay;
            var activity = Platform.GetActivity();

            var tcs = new TaskCompletionSource<TimeSpan?>();

            using var dialog = new TimePickerDialog(
                 activity,
                 (sender, e) => tcs.TrySetResult(
                     e != null
                     ? new TimeSpan(e.HourOfDay, e.Minute, 0)
                     : (TimeSpan?)null),
                 selectedTime.Value.Hours,
                 selectedTime.Value.Minutes,
                 DateFormat.Is24HourFormat(activity));

            dialog.KeyPress += DialogKeyPress;

            dialog.CancelEvent +=
                (sender, e) => tcs.TrySetResult(null);

            dialog.Show();
            return tcs.Task;
        }

        private static void DialogKeyPress(object sender, global::Android.Content.DialogKeyEventArgs e)
        {
            if (e.KeyCode == Keycode.Back && sender is Dialog dialog)
                dialog?.Cancel();
        }

        static readonly DateTime jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static long ToUnixTimestamp(this DateTime dateTime)
            => (long)(dateTime.ToUniversalTime() - jan1st1970).TotalMilliseconds;

        
    }
}
