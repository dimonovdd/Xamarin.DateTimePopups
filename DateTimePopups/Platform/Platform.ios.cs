using System;
using UIKit;

namespace Xamarin.DateTimePopups
{
    
    public static partial class Platform
    {
        internal static Func<UIView> getCurrentViewFunc;

        /// <summary>Initialize DateTimePopups</summary>
        /// <param name="getCurrentView">Functions for getting the current UIView</param>
        public static void Init(Func<UIView> getCurrentView)
            => getCurrentViewFunc = getCurrentView;
    }
}