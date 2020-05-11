using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using SQLite;
using Todolist_LIPE.Data.Base;
using Todolist_LIPE.iOS.Database;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(Database_iOS))]
namespace Todolist_LIPE.iOS.Database
{
    class Database_iOS : IDatabase
    {
        public SQLiteAsyncConnection DBConnection()
        {
            var filename = "DBpath.db3";
            var folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string libraryfolder = Path.Combine(folder, "..", "Library");
            var path = Path.Combine(libraryfolder, filename);
            var connection = new SQLiteAsyncConnection(path);
            return connection;
        }
    }
}