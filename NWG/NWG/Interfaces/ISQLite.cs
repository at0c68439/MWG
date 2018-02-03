using System;
using SQLite;

namespace NWG.Interfaces
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
