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
    /// Clase de la página de bienvenida.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Welcome : ContentPage
    {
        public Welcome()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Cambia la ventana actual
        /// añadiendo a la navegación
        /// la página de registro.
        /// </summary>
        private void btnRegister_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Register());
        }

        /// <summary>
        /// Cambia la ventana actual
        /// a la página de guía.
        /// </summary>
        private void btnEnter_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new PaginaMenu());
        }

        /// <summary>
        /// Cambia la ventana actual
        /// añadiendo a la navegación la
        /// página de inicio de sesión.
        /// </summary>
        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }
    }
}