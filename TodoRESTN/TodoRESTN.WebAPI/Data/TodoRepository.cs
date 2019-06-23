using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoRESTN.WebAPI.Models;

namespace TodoRESTN.WebAPI.Data
{
    public class TodoRepository : ITodoRepository
    {
        List<TodoItem> _todoList;

        public TodoRepository()
        {
            InitalizeData();
        }


        public IEnumerable<TodoItem> GetAll => _todoList;

        public void Delete(string id)
        {
            var todoItem = this.Find(id);
            _todoList.Remove(todoItem);
        }

        public bool DoesItemExist(string id)
        {
            return _todoList.Any(x => x.ID == id);
        }

        public TodoItem Find(string id)
        {
            return _todoList.FirstOrDefault(x => x.ID == id);
        }

        public void Insert(TodoItem item)
        {
            _todoList.Add(item);
        }

        public void Update(TodoItem item)
        {
            var todoItem = this.Find(item.ID);
            var index = _todoList.IndexOf(todoItem);
            _todoList.RemoveAt(index);
            _todoList.Insert(index, item);
        }


        void InitalizeData()
        {
            _todoList = new List<TodoItem>();

            var todoItem1 = new TodoItem
            {
                ID = "6bb8a868-dba1-4f1a-93b7-24ebce87e243",
                Name = "Learn app development",
                Notes = "Attend Xamarin University",
                Done = true
            };

            var todoItem2 = new TodoItem
            {
                ID = "b94afb54-a1cb-4313-8af3-b7511551b33b",
                Name = "Develop apps",
                Notes = "Use Xamarin Studio/Visual Studio",
                Done = false
            };

            var todoItem3 = new TodoItem
            {
                ID = "ecfa6f80-3671-4911-aabe-63cc442c1ecf",
                Name = "Publish apps",
                Notes = "All app stores",
                Done = false,
            };

            _todoList.Add(todoItem1);
            _todoList.Add(todoItem2);
            _todoList.Add(todoItem3);
        }
    }
}
