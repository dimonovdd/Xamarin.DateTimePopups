using System;
using Android.App;
using Android.OS;

namespace Xamarin.DateTimePopups
{
    /// <summary>Platform specific helpers.</summary>
    public static class Platform
    {
        internal static Activity currentActivity;
        internal static Bundle currentBundle;

        /// <summary>Initialize DateTimePopups with Android's activity and bundle.</summary>
        /// <param name="activity">Activity to use for initialization.</param>
        /// <param name="bundle">Bundle of the activity.</param>
        public static void Init(Activity activity, Bundle bundle)
        {
            currentActivity = activity;
            currentBundle = bundle;
        }

        internal static Activity GetActivity()
            => currentActivity
            ?? throw new NullReferenceException("The current Activity can not be detected. Ensure that you have called Init in your Activity or Application class.");
    }
}