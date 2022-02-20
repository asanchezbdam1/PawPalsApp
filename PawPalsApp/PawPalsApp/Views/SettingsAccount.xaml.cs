﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PawPalsApp.Resx;

namespace PawPalsApp.Views
{
    /// <summary>
    /// Esta página te da la opción de eliminar
    /// tu cuenta
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsAccount : ContentPage
    {
        public SettingsAccount()
        {
            InitializeComponent();
            frDeleteclic();
        }
        /// <summary>
        /// Método que borrará la cuenta con la que
        /// se ha iniciado sesión en la aplicación
        /// </summary>
        private void frDeleteclic()
        {
            frDelete.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(async () =>
                {
                    string action = await DisplayActionSheet(AppResources.DelQuestion, "Cancel", "Delete");
                    if (action.Equals("Delete"))
                    {
                        await Launcher.OpenAsync(new System.Uri("https://youtu.be/tATp1zHDo9g"));
                    }
                })
            });
        }
    }
}