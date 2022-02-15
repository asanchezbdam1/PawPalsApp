using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawPalsApp.Classes;
using PawPalsApp.Resx;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PawPalsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Care : ContentPage
    {
        public Care()
        {
            InitializeComponent();
            obtenerDatos();
        }

        private async void obtenerDatos()
        {
            //Obtención de datos
            var mascotas = await App.SQLiteDBMascota.GetMascotasAsync();
            if (mascotas != null)
            {
                pMasc.ItemsSource = obtenerNombres(mascotas);
            }
            else
            {
                pMasc.Title = "Añade una mascota";
            }
        }
        private List<string> obtenerNombres(List<Mascotas> mascotas)
        {
            List<string> nombres = new List<string>();
            foreach (Mascotas mascota in mascotas)
            {
                nombres.Add(mascota.Nombre);
            }
            return nombres;
        }
        private void btnAddDiet_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(eDiet.Text))
            {
                string nom = pMasc.SelectedItem.ToString();
                Mascotas mascota = App.SQLiteDBMascota.GetMascotasByNameAsync(nom).Result;
                App.SQLiteDBDieta.SaveDietaAsync(new Dieta()
                { 
                    Dietas = eDiet.Text,
                    IdMascota = mascota.Nombre
                });
            }
        }

        private void btnDeleteDiet_Clicked(object sender, EventArgs e)
        {

        }

        private void btnAddexercise_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(eExercise.Text))
            {
                string nom = pMasc.SelectedItem.ToString();
                Mascotas mascota = App.SQLiteDBMascota.GetMascotasByNameAsync(nom).Result;

            }
        }

        private void btnDeleteexercise_Clicked(object sender, EventArgs e)
        {

        }

        private void btnAddHygiene_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(eHygiene.Text))
            {
                string nom = pMasc.SelectedItem.ToString();
                Mascotas mascota = App.SQLiteDBMascota.GetMascotasByNameAsync(nom).Result;
            }
        }

        private void btnDeleteHygiene_Clicked(object sender, EventArgs e)
        {

        }


        private void btnAñadirMascota_Clicked(object sender, EventArgs e)
        {
            añadirMascotaAsync();
        }

        private async Task añadirMascotaAsync()
        {
            string result = await DisplayPromptAsync("Mascota", "Escribe el nombre de tu mascota", "OK", AppResources.Back);
            if (!String.IsNullOrWhiteSpace(result))
            {
                string action = await DisplayActionSheet("ActionSheet: SavePhoto?", AppResources.Back, null, "Photo");
                if (action.Equals("Photo"))
                {
                    App.SQLiteDBMascota.SaveMascotaAsync(new Mascotas()
                    {
                        Nombre = result,
                        Imagen = PickPost().Result
                    });
                }
            }
        }

        private async Task<byte[]> PickPost()
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.IsSupported)
            {
                await DisplayAlert("Error", AppResources.ErrorTitle, AppResources.Back);
                return null;
            }
            var opt = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Small,
                CompressionQuality = 25
            };

            var img = await CrossMedia.Current.PickPhotoAsync(opt);

            if (img == null) return null;
            byte[] buf = new byte[img.GetStream().Length];

            img.GetStream().Read(buf, 0, buf.Length);

            if (buf.Length > ConnectionHelper.MAX_IMAGE_SIZE)
            {
                DisplayAlert(AppResources.ErrorTitle, AppResources.ImageSizeError, AppResources.Back);
                return null;
            }

            return buf;
        }

        private void pMasc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}