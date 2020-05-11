

using SQLite;

namespace Todolist_LIPE.Models
{
    public class Tasks : IObject
    { 
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string TaskName { get; set; }
        public string TaskDetail { get; set; }
        public bool Delete { get; set; }
    } 
}
