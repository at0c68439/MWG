using NWG.View;
using Xamarin.Forms;

namespace NWG
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login());
            ((NavigationPage)MainPage).BarBackgroundColor = Color.FromHex("#0C60A6");
            ((NavigationPage)MainPage).BarTextColor = Color.White;

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
