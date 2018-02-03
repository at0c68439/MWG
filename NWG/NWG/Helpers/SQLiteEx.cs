using System;
using System.Collections.Generic;
using NWG.Interfaces;
using NWG.Model;
using SQLite.Net;
using Xamarin.Forms;

namespace NWG.Helpers
{
    public class SQLiteEx
    {
        public class DataAccess
        {
            SQLiteConnection dbConn;
            public DataAccess()
            {
                dbConn = DependencyService.Get<ISQLite>().GetConnection();
                // create the table(s)
                dbConn.CreateTable<NewActivityModel>();
            }
            public List<NewActivityModel> GetAllEmployees()
            {
                return dbConn.Query<NewActivityModel>("Select * From [NewActivity]");
            }
            public int SaveNewActivity(NewActivityModel aNewActivity)
            {
                return dbConn.Insert(aNewActivity);
            }
            public int DeleteEmployee(NewActivityModel aEmployee)
            {
                return dbConn.Delete(aEmployee);
            }
            public int EditEmployee(NewActivityModel aEmployee)
            {
                return dbConn.Update(aEmployee);
            }
        }
    }
}
