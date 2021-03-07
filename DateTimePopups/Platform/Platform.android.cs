using System;
using Android.App;
using Android.OS;

namespace Xamarin.DateTimePopups
{
    public static class Platform
    {
        internal static Activity currentActivity;
        internal static Bundle currentBundle;

        public static void Init(Activity activity, Bundle bundle)
        {
            currentActivity = activity;
            currentBundle = bundle;
        }

        internal static Activity GetActivity()
            => currentActivity != null
            ? currentActivity
            : throw new NullReferenceException("The current Activity can not be detected. Ensure that you have called Init in your Activity or Application class.");
    }
}
