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

        /// <summary>
        /// Carga las mascotas de la tabla en un picker para
        /// poder ser elegidas, en caso de que no haya ninguna se
        /// pedira una
        /// </summary>
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

        /// <summary>
        /// Obtiene los nombres que seran posteriormente cargados al picker
        /// </summary>
        /// <param name="mascotas"></param>
        /// <returns></returns>
        private List<string> obtenerNombres(List<Mascotas> mascotas)
        {
            List<string> nombres = new List<string>();
            foreach (Mascotas mascota in mascotas)
            {
                nombres.Add(mascota.Nombre);
            }
            return nombres;
        }

        /// <summary>
        /// Obtiene las dietas correspondientes a la mascota elegida y 
        /// las carga en un listview
        /// </summary>
        /// <param name="nombreMascota"></param>
        private async void obtenerDietasMascota(string nombreMascota)
        {
            var dietas = App.SQLiteDBDieta.GetDietaByMascotaAsync(nombreMascota).Result;
            if (dietas != null)
            {
                lvDiets.ItemsSource = dietas;
            }
        }

        /// <summary>
        /// Obtiene los ejercicios correspondientes a la mascota elegida y 
        /// las carga en un listview
        /// </summary>
        /// <param name="nombreMascota"></param>
        private async void obtenerEjerciciosMascota(string nombreMascota)
        {
            var ejercicios = App.SQLiteDBEjercicio.GetEjercicioByMascotaAsync(nombreMascota).Result;
            if (ejercicios != null)
            {
                lvExercises.ItemsSource = ejercicios;
            }
        }

        /// <summary>
        /// Obtiene las higienes correspondientes a la mascota elegida y 
        /// las carga en un listview
        /// </summary>
        /// <param name="nombreMascota"></param>
        private async void obtenerHygieneMascota(string nombreMascota)
        {
            var higienes = App.SQLiteDBHigiene.GetHigieneByMascotaAsync(nombreMascota).Result;
            if (higienes != null)
            {
                lvHygiene.ItemsSource = higienes;
            }
        }

        /// <summary>
        /// Añade una nueva dieta a la mascota escrita por el 
        /// usuario y se le pide una confirmacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddDiet_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(eDiet.Text))
            {
                string nom = pMasc.SelectedItem.ToString();
                if (nom != null)
                {
                    Mascotas mascota = App.SQLiteDBMascota.GetMascotasByNameAsync(nom).Result;
                    App.SQLiteDBDieta.SaveDietaAsync(new Dieta()
                    { 
                        Dietas = eDiet.Text,
                        IdMascota = mascota.Nombre
                    });
                    DisplayAlert("Confirm", AppResources.Add, AppResources.Back);
                }
                
            }
        }
        /// <summary>
        /// Elimina la dieta seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteDiet_Clicked(object sender, EventArgs e)
        {
            if (lvDiets.SelectedItem != null)
            {
                App.SQLiteDBDieta.DeleteDietaAsync((Dieta)lvDiets.SelectedItem);
            }
        }

        /// <summary>
        /// Añade un nuevo ejercicio a la mascota escrita por el 
        /// usuario y se le pide una confirmacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddexercise_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(eExercise.Text))
            {
                string nom = pMasc.SelectedItem.ToString();
                if (nom != null)
                {
                    Mascotas mascota = App.SQLiteDBMascota.GetMascotasByNameAsync(nom).Result;
                    App.SQLiteDBEjercicio.SaveEjercicioAsync(new Ejercicios()
                    {
                        Ejercicio = eExercise.Text,
                        IdMascota = mascota.Nombre
                    });
                    DisplayAlert("Confirm", AppResources.Add, AppResources.Back);
                }  
            }
        }

        /// <summary>
        /// Elimina el ejercicio seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteexercise_Clicked(object sender, EventArgs e)
        {
            if (lvExercises.SelectedItem != null)
            {
                App.SQLiteDBEjercicio.DeleteEjercicioAsync((Ejercicios)lvExercises.SelectedItem);
            } 
        }

        /// <summary>
        /// Añade una nueva higiene a la mascota escrita por el 
        /// usuario y se le pide una confirmacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddHygiene_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(eHygiene.Text))
            {
                string nom = pMasc.SelectedItem.ToString();
                if (nom != null)
                {
                    Mascotas mascota = App.SQLiteDBMascota.GetMascotasByNameAsync(nom).Result;
                    App.SQLiteDBHigiene.SaveHigieneAsync(new Higiene()
                    {
                        Higienes = eHygiene.Text,
                        IdMascota = mascota.Nombre
                    });
                    DisplayAlert("Confirm", AppResources.Add, AppResources.Back);
                }
                
            }
        }

        /// <summary>
        /// Elimina la higiene sleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteHygiene_Clicked(object sender, EventArgs e)
        {
            if (lvHygiene.SelectedItem != null)
            {
                App.SQLiteDBHigiene.DeleteHigieneAsync((Higiene)lvHygiene.SelectedItem);
            }
        }


        /// <summary>
        /// Llama al metodo añadirMascotaAsync()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAñadirMascota_Clicked(object sender, EventArgs e)
        {
            añadirMascotaAsync();
        }

        /// <summary>
        /// Metodo que abre ventanas al usuario para que añada una mascota a la tabla y actualiza el picker
        /// </summary>
        /// <returns></returns>
        private async Task añadirMascotaAsync()
        {
            string result = await DisplayPromptAsync("Mascota", "Escribe el nombre de tu mascota", "OK", AppResources.Back);
            if (!String.IsNullOrWhiteSpace(result))
            {
                string action = await DisplayActionSheet(AppResources.SavePho, AppResources.Back, null, "Photo");
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

        /// <summary>
        /// Cada vez que el picker de mascotas cambie se cargara al pagina 
        /// en base a la mascota seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pMasc_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mascotas = App.SQLiteDBMascota.GetMascotasAsync().Result;
            string nombreMascota = pMasc.SelectedItem.ToString();
            foreach (Mascotas masc in mascotas)
            {
                if (masc.Nombre.Equals(nombreMascota))
                {
                    cpContenido.BindingContext = masc;
                    break;
                }
            }
            
            obtenerDietasMascota(nombreMascota);
            obtenerEjerciciosMascota(nombreMascota);
            //obtenerHygieneMascota(nombreMascota);
        }
    }
}