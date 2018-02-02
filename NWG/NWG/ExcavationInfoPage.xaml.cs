using System;
using System.Collections.Generic;
using NWG.Helpers;
using NWG.View;
using Xamarin.Forms;

namespace NWG
{
    public partial class ExcavationInfoPage : ContentPage
    {
        public ExcavationInfoPage()
        {
            InitializeComponent();
            LengthEntry.Keyboard = Keyboard.Numeric;
            WidthEntry.Keyboard = Keyboard.Numeric;
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

        private void SelectGenericListValue(List<string> genericList)
        {
            if (genericList != null)
            {
                GenericListSelectorPage objCarryOutActivityListFilter = new GenericListSelectorPage(genericList);

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
    }
}
