using System;

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
            if ((username.Text == "dmouser1" && password.Text == "dmouser@123") || (username.Text == "nwgc" && password.Text == "nwg@123"))
            {
                
            }
        }
    }
}
