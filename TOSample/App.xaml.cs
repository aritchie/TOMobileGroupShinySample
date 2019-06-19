using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TOSample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            this.MainPage = new NavigationPage(new MainPage());
        }
    }
}
