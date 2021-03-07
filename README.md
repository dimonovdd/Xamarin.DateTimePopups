# Xamarin.DateTimePopups [![NuGet Badge](https://buildstats.info/nuget/Xamarin.DateTimePopups)](https://www.nuget.org/packages/Xamarin.DateTimePopups/)
### Little library of popups for picking dates and times

![header](https://raw.githubusercontent.com/dimonovdd/Xamarin.DateTimePopups/main/header.svg)

# Available Platforms

| Platform | Version |
| --- | --- |
| Android | MonoAndroid90+|
| iOS | Xamarin.iOS10 |
| .NET Standard | 2.0 |

# Getting started
This library can be used in Xamarin.iOS, Xamarin.Android or Xamarin.Forms projects

## Android
In the Android project's MainLauncher or any Activity that is launched, Xamarin.Essentials must be initialized in the OnCreate method:
```csharp
protected override void OnCreate(Bundle savedInstanceState)
{
    //...
    base.OnCreate(savedInstanceState);
    Xamarin.DateTimePopups.Platform.Init(this, savedInstanceState); // add this line to your code, it may also be called: bundle
    //...
}
 ```
 
## Shared

```csharp
using System;
using Xamarin.Forms;
using Xamarin.DateTimePopups;

namespace Sample.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
            => InitializeComponent();

        async void DateButton_Clicked(System.Object sender, System.EventArgs e)
        {
            DateTime? date = await DateTimePopups.PickDateAsync();
            ResultLabel.Text = date.ToString();
        }

        async void TimeButton_Clicked(System.Object sender, System.EventArgs e)
        {
            TimeSpan? date = await DateTimePopups.PickTimeAsync();
            ResultLabel.Text = date.ToString();
        }
    }
}
 ```
