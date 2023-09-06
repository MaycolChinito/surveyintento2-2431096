using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace surveyintento2
{
    public static class Constants
    {
        public const string DatabaseFilename = "TodoSQLite.db3";

        public const SQLite.SQLiteOpenFlags flags =
            //open the database in read/write mode 
            SQLite.SQLiteOpenFlags.ReadWrite |
            //create the database if it doesn´t exist 
            SQLite.SQLiteOpenFlags.Create |
            //enable mutli-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory,DatabaseFilename);
      
    }
}
