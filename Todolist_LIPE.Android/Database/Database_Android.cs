using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using Todolist_LIPE.Data.Base;
using Todolist_LIPE.Droid.Database;
using Xamarin.Forms;

[assembly: Dependency(typeof(Database_Android))]
namespace Todolist_LIPE.Droid.Database
{
    class Database_Android : IDatabase
    {
        public Database_Android() { }
        public SQLiteAsyncConnection DBConnection()
        {
            var filename = "DBpath.db3";
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var databasepath = Path.Combine(folder, filename);
            var connection = new SQLiteAsyncConnection(databasepath);
            return connection;
        }
    }
}