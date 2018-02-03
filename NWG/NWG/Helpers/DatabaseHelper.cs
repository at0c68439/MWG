using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using NWG.Interfaces;
using NWG.Model;
using SQLite;
using Xamarin.Forms;

namespace NWG.Helpers
{
    public class DatabaseHelper
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();
        public ObservableCollection<NewActivityModel> newActivityModel { get; set; }

        public DatabaseHelper()
        {
            
        }

        public void AddNewActivity(NewActivityModel newActivity)
        {
            database = DependencyService.Get<IDatabaseConnection>().DbConnection();
            database.CreateTable<NewActivityModel>();
            this.newActivityModel =
                    new ObservableCollection<NewActivityModel>(database.Table<NewActivityModel>());
            // If the table is empty, initialize the collection
            if (!database.Table<NewActivityModel>().Any())
            {
                AddNewActivity(newActivity);
            }

            this.newActivityModel.
                Add(new NewActivityModel
                {
                    Id = newActivity.Id,
                Colour = newActivity.Colour,
                Length = newActivity.Length,
                Width = newActivity.Width,
                Depth = newActivity.Depth,
                Status = newActivity.Status,
                Surface = newActivity.Surface,
                PublicOrPrivate = newActivity.PublicOrPrivate,
                IsSiteCleared = newActivity.IsSiteCleared,
                IsSpoilRemoved = newActivity.IsSpoilRemoved,
                Comments = newActivity.Comments,
                MaterialDescription = newActivity.MaterialDescription,
                CaptureImage = newActivity.CaptureImage,
                GeoLocation = newActivity.GeoLocation
              });       
        }

        public IEnumerable<NewActivityModel> GetFilteredCustomers()
        {
            // Use locks to avoid database collitions
            lock (collisionLock)
            {
                var query = from cust in database.Table<NewActivityModel>()                          
                            select cust;
                return query.AsEnumerable();
            }
        }
        public List<NewActivityModel> GetAllEmployees()
        {
            database = DependencyService.Get<IDatabaseConnection>().DbConnection();
            return database.Query<NewActivityModel>("Select * From [NewActivityModel]");
        }


    }
}
