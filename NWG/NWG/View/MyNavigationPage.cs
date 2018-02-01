using System;

using Xamarin.Forms;

namespace NWG.View
{
    public class MyNavigationPage : ContentPage
    {
        public MyNavigationPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

