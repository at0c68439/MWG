using System;

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
            
        }
    }
}
