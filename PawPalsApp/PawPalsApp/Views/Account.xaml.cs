using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PawPalsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Account : ContentPage
    {
        public Account()
        {
            InitializeComponent();
        }

        private void ibtnEditar_Clicked(object sender, EventArgs e)
        {
            ibtnEditar.IsVisible = false;
            ibtnGuardar.IsVisible = true;
            eCiudad.IsReadOnly = false;
            ePais.IsReadOnly = false;

        }

        private void ibtnGuardar_Clicked(object sender, EventArgs e)
        {
            ibtnGuardar.IsVisible = false;
            ibtnEditar.IsVisible = true;
            eCiudad.IsReadOnly = true;
            ePais.IsReadOnly = true;
        }
    }
}