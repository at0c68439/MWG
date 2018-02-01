using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NWG.View
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();

            Navigation.PushAsync(new Dashboard());
            NavigationPage.SetBackButtonTitle(this, "");

        }
        protected void btn_loginclicked(object sender, EventArgs e)
        {
            if ((username.Text == "dmouser1" && password.Text == "dmouser@123") || (username.Text == "nwgc" && password.Text == "nwg@123"))
            {
                
            }
        }
    }
}
