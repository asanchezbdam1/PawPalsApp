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
        static SQLiteMascota dbMascota;
        static SQLiteDieta dbDieta;
        static SQLiteEjercicio dbEjercicio;
        static SQLiteHigiene dbHigiene;
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
        public static SQLiteMascota SQLiteDBMascota
        {
            get
            {
                if (dbMascota == null)
                {
                    dbMascota = new
                   SQLiteMascota(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Mascotas.db3"));
                }
                return dbMascota;
            }
        }
        public static SQLiteDieta SQLiteDBDieta
        {
            get
            {
                if (dbDieta == null)
                {
                    dbDieta = new
                   SQLiteDieta(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Dietas.db3"));
                }
                return dbDieta;
            }
        }
        public static SQLiteEjercicio SQLiteDBEjercicio
        {
            get
            {
                if (dbEjercicio == null)
                {
                    dbEjercicio = new
                   SQLiteEjercicio(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Ejercicios.db3"));
                }
                return dbEjercicio;
            }
        }
        public static SQLiteHigiene SQLiteDBHigiene
        {
            get
            {
                if (dbHigiene == null)
                {
                    dbHigiene = new
                   SQLiteHigiene(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Higienes.db3"));
                }
                return dbHigiene;
            }
        }
    }
}
