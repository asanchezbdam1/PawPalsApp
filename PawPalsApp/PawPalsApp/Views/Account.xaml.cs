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
            cargarDatos();
        }

        /** Método que modifica las propiedades 'IsVisible' y 'IsReadOnly' de diferentes componentes para hacer que aparezcan y desaparezcan.
         * En este caso se podrá escribir en los campos de ciudad y pais y se cambiará el icono de editar por el de guardar **/
        private void ibtnEditar_Clicked(object sender, EventArgs e)
        {
            ibtnEditar.IsVisible = false;
            ibtnGuardar.IsVisible = true;
            eCiudad.IsEnabled = false;
            ePais.IsEnabled = false;
        }

        private void cargarDatos()
        {
            User usuario = ((App)App.Current).User;
            entUserName.Text = usuario.Login;
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
            eCiudad.IsEnabled = true;
            ePais.IsEnabled = true;
            entUserName.IsEnabled = true;
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
    }
}