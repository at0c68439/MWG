using System;
using SQLite.Net;

namespace NWG.Interfaces
{
    public interface ISQLite
    {
         SQLiteConnection GetConnection();
    }
}
