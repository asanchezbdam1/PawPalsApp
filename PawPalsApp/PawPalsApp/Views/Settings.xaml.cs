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
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();
            frCuentaClic();
            frAyudaClic();
        }

        /** Método que al pulsar sobre el frame en cuestión te 
         * llevará a una página nueva **/
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

        /** Método que al pulsar sobre el frame en cuestión te 
         * llevará a una página nueva **/
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
    }
}