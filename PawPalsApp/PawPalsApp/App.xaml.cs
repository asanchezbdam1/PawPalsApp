using PawPalsApp.Classes;
using PawPalsApp.Resx;
using PawPalsApp.Views;
using System;
using System.Globalization;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CrossClasses;

namespace PawPalsApp
{
    public partial class App : Application
    {
        public ConnectionHelper Helper;
        public User User;
        public App()
        {
            InitializeComponent();
            User = new User();
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InstalledUICulture;
            AppResources.Culture = CultureInfo.InstalledUICulture;
            //MainPage = new NavigationPage(new PaginaMenu());
            MainPage = new NavigationPage(new Welcome());
            Helper = new ConnectionHelper();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
