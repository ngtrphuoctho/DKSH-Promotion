using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
// ...
public class SQLite_Android : DKSH_Promotion.ISQLite
{
    public SQLite_Android() { }
    public SQLite.SQLiteConnection GetConnection()
    {
        var sqliteFilename = "DPDatabase.db3";
        string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
        var path = Path.Combine(documentsPath, sqliteFilename);
        // Create the connection
        var conn = new SQLite.SQLiteConnection(path);
        // Return the database connection
        return conn;
    }
}

