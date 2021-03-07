using System;
using Xamarin.Forms;
using Xamarin.DateTimePopups;

namespace Sample.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            ResultLabel.Text = DateTime.Now.ToString();
        }

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
