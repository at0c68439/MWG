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
    }
}
