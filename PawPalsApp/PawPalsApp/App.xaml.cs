using PawPalsApp.Classes;
using PawPalsApp.Resx;
using PawPalsApp.Views;
using System;
using System.Globalization;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PawPalsApp.Data;
using System.IO;
using CrossClasses;

namespace PawPalsApp
{
    public partial class App : Application
    {
        static SQLiteMascota db;
        public ConnectionHelper Helper;
        public User User;
        public App()
        {
            InitializeComponent();
            User = new User() { 
                Id = 1,
                Login = "debug"
            };
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InstalledUICulture;
            AppResources.Culture = CultureInfo.InstalledUICulture;
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
        public static SQLiteMascota SQLiteDB
        {
            get
            {
                if (db == null)
                {
                    db = new
                   SQLiteMascota(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Mascotas.db3"));
                }
                return db;
            }
        }
    }
}
