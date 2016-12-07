using NotiFact.Database;
using NotiFact.UWP;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_UWP))]

namespace NotiFact.UWP
{
// ...
    public class SQLite_UWP : ISQLite
    {
        public SQLite_UWP() { }
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "NotiFact.db3";
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
            var sqlLitePlatForm = new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT();
            var conn = new SQLiteConnection(sqlLitePlatForm,path);
            return conn;
        }
    }
}
