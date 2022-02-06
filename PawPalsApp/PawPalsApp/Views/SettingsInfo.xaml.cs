using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PawPalsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsInfo : ContentPage
    {
        public SettingsInfo()
        {
            InitializeComponent();
            frPrivaclic();
            frManualClic();
        }

        /** Método que lleva al usuario a el documento de 
         * políticas de privacidad de la aplicación **/
        private void frPrivaclic()
        {
            frPriva.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    Launcher.OpenAsync(new System.Uri("https://drive.google.com/file/d/1oG94XWAUJ6Qt-iFo87EmyWYCLpStjiUa/view?usp=sharing"));
                })
            });
        }

        /** Método que lleva al usuario al manual de uso de la aplicación **/
        private void frManualClic()
        {
            frManual.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    Launcher.OpenAsync(new System.Uri("https://youtu.be/GbtRCevx4fA"));
                })
            });
        }
    }
}