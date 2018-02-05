using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;

namespace NWG.View
{
    public partial class ViewImage : ContentPage
    {
        public ViewImage(List<byte[]> imageBytes)
        {
            InitializeComponent();

            if (imageBytes[0] == null && imageBytes[1] == null)
            {
                NoImageFoundLbl.IsVisible = true;
            }
            if (imageBytes[0] != null)
            {
                NoImageFoundLbl.IsVisible = false;
                image1.Source = ImageSource.FromStream(() => new MemoryStream(imageBytes[0]));
            }
            if (imageBytes[1] != null)
            {
                image2.Source = ImageSource.FromStream(() => new MemoryStream(imageBytes[1]));
            }
        }

        async void Logout_Button_Clicked(object sender, System.EventArgs e)
        {
            App.IsLogin = false;
            await Navigation.PopToRootAsync();
        }

    }
}
