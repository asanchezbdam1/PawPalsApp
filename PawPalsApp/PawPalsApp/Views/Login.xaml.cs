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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnRegister_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
            Navigation.PushAsync(new Register());
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            User user = new User()
            {
                Login = txtUser.Text,
                Pwd = txtPwd.Text
            };
            object res = ConnectionHelper.Login(user);
            if (res is User)
            {
                ((App)Application.Current).User = res as User;
            }

        }
    }
}