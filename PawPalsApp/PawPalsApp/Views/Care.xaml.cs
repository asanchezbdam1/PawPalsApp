using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawPalsApp.Classes;
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
            //obtenerDatos();
        }

        private async void obtenerDatos()
        {
            //Obtención de datos
            var mascotas = await App.SQLiteDB.GetMascotasAsync();
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
                Mascotas mascota = App.SQLiteDB.GetMascotasByNameAsync(nom).Result;
                mascota.Dieta.Add(eDiet.Text);
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
                Mascotas mascota = App.SQLiteDB.GetMascotasByNameAsync(nom).Result;
                mascota.Ejercicios.Add(eExercise.Text);
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
                Mascotas mascota = App.SQLiteDB.GetMascotasByNameAsync(nom).Result;
                mascota.Higiene.Add(eHygiene.Text);
            }
        }

        private void btnDeleteHygiene_Clicked(object sender, EventArgs e)
        {

        }
    }
}