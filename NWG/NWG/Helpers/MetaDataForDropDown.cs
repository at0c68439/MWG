using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace NWG.Helpers
{
    public static class MetaDataForDropDown
    {
        public static List<string> LocationData()
        {
            List<string> locationList = new List<string>();
            locationList.Add("BACK YARD/GARDEN");
            locationList.Add("BACKLANE");
            locationList.Add("BUS LANE");
            locationList.Add("CYCLEPATH");
            locationList.Add("CARRIAGEWAY");
            locationList.Add("DRIVEWAY");
            locationList.Add("FIELD");
            locationList.Add("FRONT GARDEN");
            locationList.Add("FOOTWAY");
            locationList.Add("NWL LAND");
            locationList.Add("OTHER");
            locationList.Add("BUS LANE");
            locationList.Add("PEDESTRIANISED AREAS");
            locationList.Add("PARKING BAY");
            locationList.Add("CAR PARK - COUNCIL");
            locationList.Add("CAR PARK - PRIVATE");
            locationList.Add("VERGE");

            return locationList;
        }
    }
}

