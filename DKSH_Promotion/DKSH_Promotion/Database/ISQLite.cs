using System;
using SQLite;

namespace DKSH_Promotion
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}