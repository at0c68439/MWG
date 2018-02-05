using NWG.Interfaces;
using NWG.Model;
using NWG.View;
using Xamarin.Forms;
using static NWG.Helpers.SQLiteEx;

namespace NWG
{
    public partial class App : Application
    {
        static DataAccess dbUtils;

        public static bool IsLogin { get; set; } = false;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login());
            ((NavigationPage)MainPage).BarBackgroundColor = Color.FromHex("#0C60A6");
            ((NavigationPage)MainPage).BarTextColor = Color.White;

        }

        public static DataAccess DAUtil
        {
            get
            {
                if (dbUtils == null)
                {
                    dbUtils = new DataAccess();
                }
                return dbUtils;
            }
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
