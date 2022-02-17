using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CrossClasses;
using PawPalsApp.Resx;
using PawPalsApp.Classes;

namespace PawPalsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Account : ContentPage
    {
        public Account()
        {
            InitializeComponent();
        }

        /** Método que modifica las propiedades 'IsEabled' y 'IsReadOnly' de diferentes componentes para hacer que aparezcan y desaparezcan.
         * En este caso se podrá escribir en los campos de ciudad y pais y se cambiará el icono de editar por el de guardar **/
        private void ibtnEditar_Clicked(object sender, EventArgs e)
        {
            ibtnEditar.IsVisible = false;
            ibtnGuardar.IsVisible = true;
            eCiudad.IsEnabled = true;
            ePais.IsEnabled = true;
            entUserName.IsEnabled = true;
        }

        private void cargarDatos()
        {
            User usuario = ((App)App.Current).User;
            lblUser.Text = usuario.Login;
            entEmail.Text = usuario.Email;
            if (!string.IsNullOrEmpty(usuario.Name) ||
                !string.IsNullOrEmpty(usuario.City) ||
                !string.IsNullOrEmpty(usuario.Country))
            {
                entUserName.Text = usuario.Name;
                eCiudad.Text = usuario.City;
                ePais.Text = usuario.Country;
            }
        }
        /**  **/
        private async void ibtnGuardar_Clicked(object sender, EventArgs e)
        {
            ibtnGuardar.IsVisible = false;
            ibtnEditar.IsVisible = true;
            eCiudad.IsEnabled = false;
            ePais.IsEnabled = false;
            entUserName.IsEnabled = false;
            if (!string.IsNullOrWhiteSpace(eCiudad.Text)
                || !string.IsNullOrWhiteSpace(ePais.Text)
                || !string.IsNullOrWhiteSpace(entUserName.Text))
            {
                var userUpdated = new UpdateUser()
                {
                    Id = ((App)App.Current).User.Id,
                    City = eCiudad.Text,
                    Country = ePais.Text,
                    Name = entUserName.Text
                };
                var res = ConnectionHelper.Send(userUpdated) as User;
                if (res != null && res.Id != 0)
                {
                    ((App)App.Current).User = res;
                    cargarDatos();
                    await DisplayAlert("Updated", AppResources.Updated, AppResources.Back);
                }
                else
                {
                    await DisplayAlert("Error", AppResources.ErrorTitle, AppResources.Back);
                }

            }
            else
            {
                await DisplayAlert("Error", AppResources.ErrorNull, "OK");
            }

        }

        private void ibtnPerfil_Clicked(object sender, EventArgs e)
        {

        }

        private void ibtnSalir_Clicked(object sender, EventArgs e)
        {
            ((App)App.Current).User = null;
            App.Current.MainPage = new NavigationPage(new Welcome());
        }
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
            else
            {
                cargarDatos();
            }
        }
    }
}