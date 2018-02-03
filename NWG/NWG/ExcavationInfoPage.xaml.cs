using System;
using System.Collections.Generic;
using NWG.Helpers;
using NWG.Model;
using NWG.View;
using NWG.ViewModel;
using Xamarin.Forms;

namespace NWG
{
    public partial class ExcavationInfoPage : ContentPage
    {
        NewActivityViewModel newActivityVM;
        public ExcavationInfoPage()
        {
            InitializeComponent();
            LengthEntry.Keyboard = Keyboard.Numeric;
            WidthEntry.Keyboard = Keyboard.Numeric;
            DepthEntry.Keyboard = Keyboard.Numeric;
             newActivityVM = new NewActivityViewModel();

            var vList = App.DAUtil.GetAllEmployees();          

            //DatabaseHelper dbHelper = new DatabaseHelper();
            //var storedActivity = dbHelper.GetFilteredCustomers();

            BindingContext = newActivityVM;
        }      
        private void OnLocationTapped(object sender, EventArgs e)
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
            else
            {

            } 
        }

        private void OnColourChooseTapped(object sender, EventArgs e)
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
            else
            {

            } 
        }

        private void OnSurfaceSelectTapped(object sender, EventArgs e)
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
            else
            {

            } 
        }

        private void OnMaterialSelectTapped(object sender, EventArgs e)
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
            else
            {

            } 
        }

        private void OnSubmitClicked (object sender, EventArgs e)
        {
            NewActivityModel newActivityModel = new NewActivityModel();

            newActivityModel.Location = LocationEntry.Text;
            newActivityModel.Colour = ColourSelect.Text;
            newActivityModel.Length = LengthEntry.Text;
            newActivityModel.Width = WidthEntry.Text;
            newActivityModel.Depth = DepthEntry.Text;
            newActivityModel.Status = "Complete";
            newActivityModel.Surface = SurfaceEntry.Text;
            newActivityModel.PublicOrPrivate = PublicEntry.Text;
            newActivityModel.IsSiteCleared = true;
            newActivityModel.IsSpoilRemoved = false;
            newActivityModel.Comments = CommentsEntry.Text;
            newActivityModel.MaterialDescription = MaterialSelect.Text;
            newActivityModel.CaptureImage = "";
            newActivityModel.GeoLocation = "Lat-12, Long-12";


            App.DAUtil.SaveNewActivity(newActivityModel);

            //DatabaseHelper dataBaseHelper = new DatabaseHelper(newActivityModel);
            //dataBaseHelper.AddNewActivity((newActivityModel));

        }

        private void OnCompleteTapped(object sender, EventArgs e)
        {
            newActivityVM.CompleteColor = Color.Green;
            newActivityVM.TemporaryLabelColor = Color.Blue;
            newActivityVM.AwaitinglabelColor = Color.Blue;
            newActivityVM.BackfilledLabelColor = Color.Blue;
        }   
        private void OnTemporaryLabelTapped(object sender, EventArgs e)
        {
            newActivityVM.CompleteColor = Color.Blue;
            newActivityVM.TemporaryLabelColor = Color.Green;
            newActivityVM.AwaitinglabelColor = Color.Blue;
            newActivityVM.BackfilledLabelColor = Color.Blue;
        }   
        private void OnAwaitinglabelTapped(object sender, EventArgs e)
        {
            newActivityVM.CompleteColor = Color.Blue;
            newActivityVM.TemporaryLabelColor = Color.Blue;
            newActivityVM.AwaitinglabelColor = Color.Green;
            newActivityVM.BackfilledLabelColor = Color.Blue;
        }   
        private void OnBackfilledLabelTapped(object sender, EventArgs e)
        {
            newActivityVM.CompleteColor = Color.Blue;
            newActivityVM.TemporaryLabelColor = Color.Blue;
            newActivityVM.AwaitinglabelColor = Color.Blue;
            newActivityVM.BackfilledLabelColor = Color.Green;
        }   
    }
}
