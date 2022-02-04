using CrossClasses;
using PawPalsApp.Classes;
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
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
            Navigation.PushAsync(new Login());
        }

        private void btnRegister_Clicked(object sender, EventArgs e)
        {
            User user = new RegisterUser()
            {
                Login = txtUser.Text,
                Email = txtEmail.Text,
                Pwd = txtPwd.Text
            };
            object obj = ConnectionHelper.SendUser(user);
            if (obj is User)
            {
                user = obj as User;
                DisplayAlert("Registrado", user.Login, "Atrás");
            }

        }
    }
}