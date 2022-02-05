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
using System.Text.RegularExpressions;

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
            if (FieldsCorrect())
            {
                User user = new RegisterUser()
                {
                    Login = txtUser.Text,
                    Email = txtEmail.Text,
                    Pwd = txtPwd.Text
                };
                object obj = ConnectionHelper.SendUser(user);
                if (obj is User && ((User)obj).Id != 0)
                {
                    DisplayAlert(AppResources.Success, AppResources.SuccessRegister, AppResources.Back);
                    App.Current.MainPage = new NavigationPage(new Login());
                }
                else
                {
                    DisplayAlert(AppResources.ErrorTitle, AppResources.RegisterError, AppResources.Back);
                }
            }
            else
            {
                DisplayAlert(AppResources.ErrorTitle, AppResources.IncorrectRegisterData, AppResources.Back);
            }
        }

        private bool FieldsCorrect()
        {
            if (!FieldVerifier.VerifyTextField(txtUser.Text)) return false;
            try
            {
                System.Net.Mail.MailAddress mail = new System.Net.Mail.MailAddress(txtEmail.Text);
            }catch { return false; }

            if (!FieldVerifier.VerifyPassword(txtPwd.Text)) return false;
            if (!txtRepPwd.Text.Equals(txtPwd.Text)) return false;
            return true;
        }
    }
}