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
            obtenerNombreMascotas();
        }

        private async void obtenerNombreMascotas()
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
        private async void obtenerDietasMascota(string nombreMascota)
        {
            //Obtención de datos
            var dietas = await App.SQLiteDBDieta.GetDietaByMascotaAsync(nombreMascota);
            if (dietas != null)
            {
                lvDiets.ItemsSource = dietas;
            }
        }
        private async void obtenerEjerciciosMascota(string nombreMascota)
        {
            //Obtención de datos
            var ejercicios = await App.SQLiteDBEjercicio.GetEjercicioByMascotaAsync(nombreMascota);
            if (ejercicios != null)
            {
                lvExercises.ItemsSource = ejercicios;
            }
        }
        private async void obtenerHygieneMascota(string nombreMascota)
        {
            //Obtención de datos
            var higienes = await App.SQLiteDBHigiene.GetHigieneByMascotaAsync(nombreMascota);
            if (higienes != null)
            {
                lvHygiene.ItemsSource = higienes;
            }
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
            if (lvDiets.SelectedItem != null)
            {
                App.SQLiteDBDieta.DeleteDietaAsync((Dieta)lvDiets.SelectedItem);
            }
        }

        private void btnAddexercise_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(eExercise.Text))
            {
                string nom = pMasc.SelectedItem.ToString();
                Mascotas mascota = App.SQLiteDBMascota.GetMascotasByNameAsync(nom).Result;
                App.SQLiteDBEjercicio.SaveEjercicioAsync(new Ejercicios()
                {
                    Ejercicio = eExercise.Text,
                    IdMascota = mascota.Nombre
                });
            }
        }

        private void btnDeleteexercise_Clicked(object sender, EventArgs e)
        {
            if (lvExercises.SelectedItem != null)
            {
                App.SQLiteDBEjercicio.DeleteEjercicioAsync((Ejercicios)lvExercises.SelectedItem);
            } 
        }

        private void btnAddHygiene_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(eHygiene.Text))
            {
                string nom = pMasc.SelectedItem.ToString();
                Mascotas mascota = App.SQLiteDBMascota.GetMascotasByNameAsync(nom).Result;
                App.SQLiteDBHigiene.SaveHigieneAsync(new Higiene()
                {
                    Higienes = eHygiene.Text,
                    IdMascota = mascota.Nombre
                });
            }
        }

        private void btnDeleteHygiene_Clicked(object sender, EventArgs e)
        {
            if (lvHygiene.SelectedItem != null)
            {
                App.SQLiteDBHigiene.DeleteHigieneAsync((Higiene)lvHygiene.SelectedItem);
            }
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
                    byte[] img = await ImagePicker.PickPost();
                    await App.SQLiteDBMascota.SaveMascotaAsync(new Mascotas()
                    {
                        Nombre = result,
                        Imagen = img
                    });
                    obtenerNombreMascotas();
                }
            }
        }

        private void clearLists()
        {
            
        }
        private void pMasc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombreMascota = pMasc.SelectedItem.ToString();
            obtenerDietasMascota(nombreMascota);
            obtenerEjerciciosMascota(nombreMascota);
            obtenerHygieneMascota(nombreMascota);
        }
    }
}