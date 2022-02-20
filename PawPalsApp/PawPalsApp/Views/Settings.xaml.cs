using PawPalsApp.Resx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PawPalsApp.Views
{
    /// <summary>
    /// Página qe representa los ajustes de la app.
    /// Tiene dos opciones: 
    /// - Ajustes de cuenta
    /// - Ayuda
    /// ; Las cuelas te llevarán a otra página
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();
            frCuentaClic();
            frAyudaClic();
        }

        /// <summary>
        /// Método que al pulsar sobre el frame en cuestión te 
        /// llevará a una página nueva
        /// </summary>
        private void frCuentaClic()
        {
            frCuenta.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new SettingsAccount());
                })
            });
        }

        /// <summary>
        /// Método que al pulsar sobre el frame en cuestión te 
        /// llevará a una página nueva
        /// </summary>
        private void frAyudaClic()
        {
            frAyuda.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new SettingsInfo());
                })
            });
        }

        /// <summary>
        /// Comprueba que se ha
        /// iniciado sesión
        /// para acceder.
        /// </summary>
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if (((App)App.Current).User == null)
            {
                var res = await DisplayAlert(AppResources.ErrorTitle, AppResources.NeedLogin, AppResources.Login, AppResources.Back);
                if (res)
                {
                    App.Current.MainPage = new NavigationPage(new Welcome());
                }
                else
                {
                    var page = ((TabbedPage)((NavigationPage)App.Current.MainPage).CurrentPage);
                    page.CurrentPage = page.Children[0];
                }
            }
        }
    }
}