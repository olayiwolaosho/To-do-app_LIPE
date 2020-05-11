using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Todolist_LIPE.Models;

namespace Todolist_LIPE.Data
{
    public interface IDatabaseRepo
    {
         Task<IEnumerable<T>> GetAllObjects<T>() where T : new();
        Task<int> SaveObject<T>(T obj) where T : IObject, new();
        Task<int> DeleteObject<T>(T obj) where T : IObject, new();
    }
}
