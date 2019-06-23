using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoRESTN.Models;

namespace TodoRESTN.Data
{
    public class TodoItemManager
    {
        IRestService _restService;
        public TodoItemManager(IRestService restService)
        {
            _restService = restService;
        }

        public Task<List<TodoItem>> GetAll()
        {
            return _restService.RefreshDataAsync();
        }

        public Task SaveItem(TodoItem item, bool isNew=false)
        {
           return  _restService.SaveTodoItemAsync(item, isNew);
        }

        public Task DeleteItem(TodoItem item)
        {
            return _restService.DeleteTodoItemAsync(item.ID);
        }


    }
}
