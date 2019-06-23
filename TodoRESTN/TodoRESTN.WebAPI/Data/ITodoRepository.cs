using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoRESTN.WebAPI.Models;

namespace TodoRESTN.WebAPI.Data
{
    public interface ITodoRepository
    {
        bool DoesItemExist(string id);
        TodoItem Find(string id);
        void Insert(TodoItem item);
        void Update(TodoItem item);
        void Delete(string id);
        IEnumerable<TodoItem> GetAll { get; }
    }
}
