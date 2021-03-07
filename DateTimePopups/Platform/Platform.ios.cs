using System;
using System.Threading.Tasks;

namespace Xamarin.DateTimePopups
{
    public static class Platform
    {
        internal static bool IsInitialized { get; set; }

        public static void Init()
        {
            IsInitialized = true;
        }
    }
}
