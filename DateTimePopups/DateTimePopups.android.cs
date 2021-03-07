using System;
using System.Threading.Tasks;
using Android.App;
using Android.Text.Format;
using Android.Views;

namespace Xamarin.DateTimePopups
{
    public static partial class DateTimePopups
    {
        static Task<DateTime?> PlatformPickDateAsync(DateTime? defaultDate = null, DateTime? minDate = null, DateTime? maxDate = null)
        {
            var activity = Platform.GetActivity();
            defaultDate ??= DateTime.Now;

            var tcs = new TaskCompletionSource<DateTime?>();

            using var dialog = new DatePickerDialog(
                activity,
                (sender, e) => tcs.TrySetResult(e?.Date),
                defaultDate.Value.Year,
                defaultDate.Value.Month - 1,
                defaultDate.Value.Day);

            if (minDate != null)
                dialog.DatePicker.MinDate = minDate.Value.ToUnixTimestamp();

            if (maxDate != null)
                dialog.DatePicker.MaxDate = maxDate.Value.ToUnixTimestamp();

            dialog.CancelEvent += (sender, e) => tcs.TrySetResult(null);
            dialog.KeyPress += DialogKeyPress;

            dialog.Show();
            return tcs.Task;
        }

        static Task<TimeSpan?> PlatformPickTimeAsync(TimeSpan? defaultTime = null)
        {
            var activity = Platform.GetActivity();
            defaultTime ??= DateTime.Now.TimeOfDay;

            var tcs = new TaskCompletionSource<TimeSpan?>();

            using var dialog = new TimePickerDialog(
                 activity,
                 (sender, e) => tcs.TrySetResult(
                     e != null
                     ? new TimeSpan(e.HourOfDay, e.Minute, 0)
                     : (TimeSpan?)null),
                 defaultTime.Value.Hours,
                 defaultTime.Value.Minutes,
                 DateFormat.Is24HourFormat(activity));

            dialog.CancelEvent += (sender, e) => tcs.TrySetResult(null);
            dialog.KeyPress += DialogKeyPress;

            dialog.Show();
            return tcs.Task;
        }

        static void DialogKeyPress(object sender, global::Android.Content.DialogKeyEventArgs e)
        {
            if (e.KeyCode == Keycode.Back && sender is Dialog dialog)
                dialog?.Cancel();
        }

        static readonly DateTime jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        static long ToUnixTimestamp(this DateTime dateTime)
            => (long)(dateTime.ToUniversalTime() - jan1st1970).TotalMilliseconds;  
    }
}