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
            Navigation.PushAsync(new Dashboard());

            var accountList = new UserManager().getAllUser();
            var account = accountList.Find((it) => it.UserName.Equals(username.Text.Trim().ToString()) && it.Password.Equals(password.Text.Trim().ToString()));

            if (account != null)
            {
                Settings.UserName = account.UserName;
                Settings.Password = account.Password;
                Settings.Role = account.Role;
            }
            else {
                
                DisplayAlert("Authentication Failed", "Please Enter Correct Password","OK");
            }
        }
    }
}
