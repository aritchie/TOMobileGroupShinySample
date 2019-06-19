using System;
using System.ComponentModel;
using Shiny;
using Shiny.Jobs;
using Xamarin.Forms;


namespace TOSample
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        async void Handle_Clicked(object sender, System.EventArgs e)
        {
           await ShinyHost
                .Resolve<IJobManager>()
                .RunAll();
        }
    }
}
