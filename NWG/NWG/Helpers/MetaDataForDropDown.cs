using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace NWG.Helpers
{
    public static class MetaDataForDropDown
    {
        public static List<string> LocationList()
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

        public static List<string> ColorList()
        {
            List<string> locationList = new List<string>();
            locationList.Add("BLACK");
            locationList.Add("BROWN");
            locationList.Add("GREEN");
            locationList.Add("N/A");
            locationList.Add("OTHER");
            locationList.Add("RED");
            locationList.Add("YELLOW");
           
            return locationList;
        }

        public static List<string> SurfaceList()
        {
            List<string> locationList = new List<string>();
            locationList.Add("ANTI-SKID");
            locationList.Add("BITMAC");
            locationList.Add("BLOCK PAVING");
            locationList.Add("CONCRETE");
            locationList.Add("CRAZY PAVING");
            locationList.Add("DBM");
          
            return locationList;
        }

        public static List<string> MaterialList()
        {
            List<string> locationList = new List<string>();
            locationList.Add("ANTI-SKID");
            locationList.Add("BITMAC");
            locationList.Add("BLOCK PAVING");
            locationList.Add("CONCRETE");
            locationList.Add("CRAZY PAVING");
            locationList.Add("DBM");
            locationList.Add("DISABLED RAMP");
            locationList.Add("HRA");
            locationList.Add("OTHER");
            locationList.Add("FLAGS");
            locationList.Add("OTHER");
            locationList.Add("GARDEN");
            locationList.Add("GRASS");
            locationList.Add("REINF CONCRETE");
            locationList.Add("SLABS");
            locationList.Add("SMA");
            locationList.Add("TARMAC");
            locationList.Add("TRAFFIC SENSORS");
            locationList.Add("UNMADE");
            locationList.Add("VERGE");
            locationList.Add("GRAVEL");

            return locationList;
        }

        public static List<string> StatusSelect()
        {
            List<string> statusList = new List<string>();
            statusList.Add("Complete");
            statusList.Add("Temporary Backfill");
            statusList.Add("Awaiting Backfill");
            statusList.Add("Backfilled");         

            return statusList;
        }

        public static List<string> PublicSelect()
        {
            List<string> publicList = new List<string>();
            publicList.Add("Public");
            publicList.Add("Private");

            return publicList;
        }

    }
}

