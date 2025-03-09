using System.IO;
using SQLite;

namespace TodoApp.Data
{
    public static class Constants
    {
        public const string DatabaseFilename = "TodoSQLite.db3";
        
        public const SQLiteOpenFlags Flags =
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache;
        
        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    }
}
