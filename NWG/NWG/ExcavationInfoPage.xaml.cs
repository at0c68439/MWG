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
        }      
        private void OnLocationTapped(object sender, EventArgs e)
        {
            try
            {
                var locationList = MetaDataForDropDown.LocationData();

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
            catch(Exception ex)
            {
                
            }           
        }
    }
}
