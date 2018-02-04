using System;
using NWG.Helpers;
using Xamarin.Forms;

namespace NWG.View
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this,false);
            NavigationPage.SetBackButtonTitle(this, "");

        }
        protected void btn_loginclicked(object sender, EventArgs e)
        {

            var accountList = new UserManager().getAllUser();

            if (string.IsNullOrEmpty(username.Text) && string.IsNullOrEmpty(password.Text))
            {
                DisplayAlert("Required", "Please enter username and password", "OK");
            }
            else if (string.IsNullOrEmpty(username.Text))
            {

                DisplayAlert("Required", "Please enter username", "OK");

            }
            else if (string.IsNullOrEmpty(password.Text))
            {

                DisplayAlert("Required", "Please enter password", "OK");
            }
            else
            {
                var account = accountList.Find((it) => it.UserName.Equals(username.Text.Trim().ToString()) && it.Password.Equals(password.Text.Trim().ToString()));

                if (account != null)
                {
                    Settings.UserName = account.UserName;
                    Settings.Password = account.Password;
                    Settings.Role = account.Role;

                    Navigation.PushAsync(new Dashboard());
                }
                else
                {

                    DisplayAlert("Authentication Failed", "Please enter correct password", "OK");
                }
            }
           
        }
    }
}
