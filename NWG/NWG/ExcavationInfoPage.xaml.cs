using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NWG.Helpers;
using NWG.Model;
using NWG.View;
using NWG.ViewModel;
using Plugin.Geolocator;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;


namespace NWG
{
    public partial class ExcavationInfoPage : ContentPage
    {
        NewActivityViewModel newActivityVM;
        string role = Settings.Role.ToString();
        private string _groupId;
        NewActivityModel _selectedNewActivityModel;
        bool isValidate = true;
        byte[] image1,image2;
        int imageCount;
        public ExcavationInfoPage(string groupId = "1", NewActivityModel selectedNewActivityModel = null)

        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");

            LengthEntry.Keyboard = Keyboard.Numeric;
            WidthEntry.Keyboard = Keyboard.Numeric;
            DepthEntry.Keyboard = Keyboard.Numeric;
            newActivityVM = new NewActivityViewModel();

            _selectedNewActivityModel = selectedNewActivityModel;

            if (_selectedNewActivityModel != null)
            {

                LoadIntialDataForNwgc(_selectedNewActivityModel);    
            }
            _groupId = groupId;
            BindingContext = newActivityVM;
        }    

        private void LoadIntialDataForNwgc(NewActivityModel newActivity)
        {
            if (role != "nwgc")
            {
                SubmitButton.Text = "Submit";


            } else {
                SubmitButton.Text = "Complete";
                LengthEntry.IsEnabled = false;
                CaptureImage.IsEnabled = false;
                WidthEntry.IsEnabled = false;
                DepthEntry.IsEnabled = false;
                SiteButton.IsEnabled = false;
                SpoilButton.IsEnabled = false;
                comments.IsEnabled = false;
            }
            LocationEntry.Text = newActivity.Location;
            ColourSelect.Text = newActivity.Colour;
            LengthEntry.Text = newActivity.Length;
            WidthEntry.Text = newActivity.Width;
            DepthEntry.Text = newActivity.Depth;
            StatusSelect.Text = newActivity.Status;
            SurfaceSelect.Text = newActivity.Surface;
            PublicSelect.Text = newActivity.PublicOrPrivate;
            SiteButton.IsToggled = newActivity.IsSiteCleared;
            SpoilButton.IsToggled = newActivity.IsSpoilRemoved;
            comments.Text = newActivity.Comments;
            MaterialSelect.Text = newActivity.MaterialDescription;
            GeoLocation.Text = newActivity.GeoLocation;
            image1 = newActivity.CaptureImage1;
            image2 = newActivity.CaptureImage2;
        }

        private void OnLocationTapped(object sender, EventArgs e)
        {
            if(role != "nwgc")
            {
                var locationList = MetaDataForDropDown.LocationList();
                if (locationList != null)
                {
                    GenericListSelectorPage objCarryOutActivityListFilter = new GenericListSelectorPage(locationList);

                    objCarryOutActivityListFilter.pickerHandler += (pickersender, pickerargs) =>
                    {
                        LocationEntry.Text = pickerargs.pickerValue;
                    };
                    Navigation.PushAsync(objCarryOutActivityListFilter);
                }    
            }
        }

        private void OnColourChooseTapped(object sender, EventArgs e)
        {
            if (role != "nwgc")
            {
                var colorList = MetaDataForDropDown.ColorList();
                if (colorList != null)
                {
                    GenericListSelectorPage objCarryOutActivityListFilter = new GenericListSelectorPage(colorList);

                    objCarryOutActivityListFilter.pickerHandler += (pickersender, pickerargs) =>
                    {
                        ColourSelect.Text = pickerargs.pickerValue;
                    };
                    Navigation.PushAsync(objCarryOutActivityListFilter);
                }
            }
        }

        private void OnSurfaceSelectTapped(object sender, EventArgs e)
        {
            if (role != "nwgc")
            {
                var surfaceList = MetaDataForDropDown.SurfaceList();
                if (surfaceList != null)
                {
                    GenericListSelectorPage objCarryOutActivityListFilter = new GenericListSelectorPage(surfaceList);

                    objCarryOutActivityListFilter.pickerHandler += (pickersender, pickerargs) =>
                    {
                        SurfaceSelect.Text = pickerargs.pickerValue;
                    };
                    Navigation.PushAsync(objCarryOutActivityListFilter);
                }
            }
        }

        private void OnMaterialSelectTapped(object sender, EventArgs e)
        {
            if (role != "nwgc")
            {
                var materialList = MetaDataForDropDown.MaterialList();
                if (materialList != null)
                {
                    GenericListSelectorPage objCarryOutActivityListFilter = new GenericListSelectorPage(materialList);

                    objCarryOutActivityListFilter.pickerHandler += (pickersender, pickerargs) =>
                    {
                        MaterialSelect.Text = pickerargs.pickerValue;
                    };
                    Navigation.PushAsync(objCarryOutActivityListFilter);
                }
            } 
        }

        private void OnPublicOrPrivateTapped(object sender, EventArgs e)
        {
            if (role != "nwgc")
            {
                var materialList = MetaDataForDropDown.PublicSelect();
                if (materialList != null)
                {
                    GenericListSelectorPage objCarryOutActivityListFilter = new GenericListSelectorPage(materialList);

                    objCarryOutActivityListFilter.pickerHandler += (pickersender, pickerargs) =>
                    {
                        PublicSelect.Text = pickerargs.pickerValue;
                    };
                    Navigation.PushAsync(objCarryOutActivityListFilter);
                }
            }
        }

        private void OnStatusTapped(object sender, EventArgs e)
        {
            if (role != "nwgc")
            {
                var materialList = MetaDataForDropDown.StatusSelect();
                if (materialList != null)
                {
                    GenericListSelectorPage objCarryOutActivityListFilter = new GenericListSelectorPage(materialList);

                    objCarryOutActivityListFilter.pickerHandler += (pickersender, pickerargs) =>
                    {
                        StatusSelect.Text = pickerargs.pickerValue;
                    };
                    Navigation.PushAsync(objCarryOutActivityListFilter);
                }
            }
        }

        async void CurrentLocation_Clicked(object sender, EventArgs e)
        {
            if(role == "dmo" && IsLocationAvailable())
            {
                var position = await CrossGeolocator.Current.GetPositionAsync();             
                GeoLocation.Text = $"Lat:{Math.Round(position.Latitude, 2)},Long:{Math.Round(position.Longitude, 2)}";
            }
        }

        void ViewImage_Clicked(object sender, EventArgs e)
        {
            List<byte[]> imageBytes = new List<byte[]>();
            imageBytes.Add(image1);
            imageBytes.Add((image2));
            Navigation.PushAsync((new ViewImage(imageBytes)));
        }

        void OnCancelClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }


        public bool IsLocationAvailable()
        {
            if (!Plugin.Geolocator.CrossGeolocator.IsSupported)
                return false;
            return CrossGeolocator.Current.IsGeolocationAvailable;
        } 

        private void OnSubmitClicked (object sender, EventArgs e)
        {
            isValidate = true;
            NewActivityModel newActivityModel = new NewActivityModel();


            if (role == "dmo")
            {
                SubmitValidation();
            }

            newActivityModel.GroupId = _groupId;
            newActivityModel.Location = LocationEntry.Text;
            newActivityModel.Colour = ColourSelect.Text;
            newActivityModel.Length = LengthEntry.Text;
            newActivityModel.Width = WidthEntry.Text;
            newActivityModel.Depth = DepthEntry.Text;
            newActivityModel.Status = StatusSelect.Text;
            newActivityModel.Surface = SurfaceSelect.Text;
            newActivityModel.PublicOrPrivate = PublicSelect.Text;
            newActivityModel.IsSiteCleared = SiteButton.IsToggled;
            newActivityModel.IsSpoilRemoved = SpoilButton.IsToggled;
            newActivityModel.Comments = comments.Text;
            newActivityModel.MaterialDescription = MaterialSelect.Text;
            newActivityModel.CaptureImage1 = image1;
            newActivityModel.CaptureImage2 = image2;
            newActivityModel.GeoLocation = GeoLocation.Text;

            newActivityModel.IsReviewed = role == "nwgc" ? true : false;

            if (isValidate)
            {
                if (_selectedNewActivityModel != null)
                {
                    newActivityModel.Id = _selectedNewActivityModel.Id;
                        App.DAUtil.EditEmployee(newActivityModel);
                }
                else
                {
                    App.DAUtil.SaveNewActivity(newActivityModel);
                }
                Navigation.PopAsync();
            }

        }

        private void SubmitValidation()
        {
            if (string.IsNullOrEmpty(LocationEntry.Text))
            {
                isValidate = false;
                DisplayAlert("Validation Failed", "Please select location", "OK");
            }
            else if (string.IsNullOrEmpty(ColourSelect.Text))
            {
                isValidate = false;
                DisplayAlert("Validation Failed", "Please select Colour", "OK");
            }
            else if (string.IsNullOrEmpty(LengthEntry.Text))
            {
                isValidate = false;
                DisplayAlert("Validation Failed", "Please Enter Length", "OK");
            }
            else if (string.IsNullOrEmpty(WidthEntry.Text))
            {
                isValidate = false;
                DisplayAlert("Validation Failed", "Please Enter Width", "OK");
            }
            else if (string.IsNullOrEmpty(DepthEntry.Text))
            {
                isValidate = false;
                DisplayAlert("Validation Failed", "Please Enter Depth", "OK");
            }  
            else if (LocationEntry.Text == "Choose Status")
            {
                isValidate = false;
                DisplayAlert("Validation Failed", "Please select Status", "OK");
            }
            else if (string.IsNullOrEmpty(SurfaceSelect.Text))
            {
                isValidate = false;
                DisplayAlert("Validation Failed", "Please select Surface", "OK");
            }
            else if (string.IsNullOrEmpty(PublicSelect.Text))
            {
                isValidate = false;
                DisplayAlert("Validation Failed", "Please select Public/Private", "OK");
            }
            else if (string.IsNullOrEmpty(MaterialSelect.Text))
            {
                isValidate = false;
                DisplayAlert("Validation Failed", "Please select Material Description", "OK");
            }           
        }

        void Logout_Button_Clicked(object sender, System.EventArgs e)
        {
            App.IsLogin = false;
            Navigation.PopToRootAsync();
        }

        async void OnCameraTapped(object sender, System.EventArgs e)
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                Directory = "NWG",
                SaveToAlbum = false,
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                PhotoSize = PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 2000,
                DefaultCamera = CameraDevice.Rear,
                Name = "p1e1i1.png"


            });

            if (file == null)
                return;
           
            var stream = file.GetStream();
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                if (image1 == null)
                {
                    image1 = memoryStream.ToArray();
                    await DisplayAlert("Success", "Image Saved Successfully", "OK");
                }

                else if (image2 == null)
                {
                    image2 = memoryStream.ToArray();
                    await DisplayAlert("Success", "Image Saved Successfully", "OK");
                }

                else
                    await DisplayAlert("Warning", "only two photographs are allowed", "OK");
            }
        }      

        private void OnCompleteTapped(object sender, EventArgs e)
        {
            newActivityVM.CompleteColor = Color.Green;
            newActivityVM.TemporaryLabelColor = Color.FromHex("#9F9F9F");;
            newActivityVM.AwaitinglabelColor = Color.FromHex("#9F9F9F");;
            newActivityVM.BackfilledLabelColor = Color.FromHex("#9F9F9F");;

            BindingContext = newActivityVM;
        }   
        private void OnTemporaryLabelTapped(object sender, EventArgs e)
        {
            newActivityVM.CompleteColor = Color.FromHex("#9F9F9F");;
            newActivityVM.TemporaryLabelColor = Color.Green;
            newActivityVM.AwaitinglabelColor = Color.FromHex("#9F9F9F");;
            newActivityVM.BackfilledLabelColor = Color.FromHex("#9F9F9F");;

            BindingContext = newActivityVM;
        }   
        private void OnAwaitinglabelTapped(object sender, EventArgs e)
        {
            newActivityVM.CompleteColor = Color.FromHex("#9F9F9F");
            newActivityVM.TemporaryLabelColor = Color.FromHex("#9F9F9F");
            newActivityVM.AwaitinglabelColor = Color.Green;
            newActivityVM.BackfilledLabelColor = Color.FromHex("#9F9F9F");

            BindingContext = newActivityVM;
        }   
        private void OnBackfilledLabelTapped(object sender, EventArgs e)
        {
            newActivityVM.CompleteColor = Color.FromHex("#9F9F9F");
            newActivityVM.TemporaryLabelColor = Color.FromHex("#9F9F9F");
            newActivityVM.AwaitinglabelColor = Color.FromHex("#9F9F9F");
            newActivityVM.BackfilledLabelColor = Color.Green;

            BindingContext = newActivityVM;
        }  
           
    }
}
