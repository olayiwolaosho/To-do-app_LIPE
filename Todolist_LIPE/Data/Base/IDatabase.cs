using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Todolist_LIPE.Data.Base
{
    public interface IDatabase
    {
        /// <summary>
        /// using dependency injection(DI) to acquire a connection to your SQLite database the .NET Standard way 
        /// </summary>
        /// <returns></returns>
        SQLiteAsyncConnection DBConnection();
    }
}
