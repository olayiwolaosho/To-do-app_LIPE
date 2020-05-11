using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Todolist_LIPE.Data.Base;
using Todolist_LIPE.Models;
using Xamarin.Forms;

namespace Todolist_LIPE.Data
{
    public class DatabaseRepo 
    {
        protected SQLiteAsyncConnection database;

        public DatabaseRepo()
        {
            database = DependencyService.Get<IDatabase>().DBConnection();
            database.CreateTableAsync<Tasks>();
        }

        public async Task<IEnumerable<T>> GetAllObjects<T>() where T : new()
        {
            return await database.Table<T>().ToListAsync();
        }

        public async Task<int> SaveObject<T>(T obj) where T : IObject, new()
        {

            if (obj.ID != 0)
            {
                await database.UpdateAsync(obj);
                return obj.ID;
            }
            else
            {
                return await database.InsertAsync(obj);
            }

        }  
        public async Task<int> DeleteObject<T>(T obj) where T : IObject, new()
        {

           return await database.DeleteAsync(obj.ID);

        }
    }
}
