using CrossClasses;
using PawPalsApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawPalsApp.Resx;
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
            if (FieldVerifier.VerifyTextField(txtUser.Text) &&
                FieldVerifier.VerifyPassword(txtPwd.Text))
            {
                User user = new LoginUser()
                {
                    Login = txtUser.Text,
                    Pwd = txtPwd.Text
                };
                object res = ConnectionHelper.SendUser(user);
                if (res is User && ((User)res).Id != 0)
                {
                    ((App)Application.Current).User = res as User;
                    App.Current.MainPage = new NavigationPage(new PaginaMenu());
                }
                else
                {
                    DisplayAlert(AppResources.ErrorTitle, AppResources.LoginError, AppResources.Back);
                }
            }
            else
            {
                DisplayAlert(AppResources.ErrorTitle, AppResources.IncorrectLoginData, AppResources.Back);
            }

        }
    }
}