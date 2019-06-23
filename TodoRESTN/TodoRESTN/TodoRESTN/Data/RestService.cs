using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TodoRESTN.Models;

namespace TodoRESTN.Data
{


    public class RestService : IRestService
    {

        HttpClient _client;

        public List<TodoItem> Items { get; private set; }

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task DeleteTodoItemAsync(string id)
        {
            var uri = new Uri(string.Format("http://your-ip/api/todoitem/{0}",id));
            try
            {
                var response = await _client.DeleteAsync(uri);
                if(response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("\t Delete Succesfully");
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine("/tERROR " + ex.Message);
            }
        }

        public async Task<List<TodoItem>> RefreshDataAsync()
        {
            try
            {
                Items = new List<TodoItem>();
                var uri = new Uri("http://your-ip/api/todoitem/");
                var response = await _client.GetAsync(uri);
                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<TodoItem>>(content);

                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine("/tERROR" + ex.Message);
            }
            return Items;
        }

        public async Task SaveTodoItemAsync(TodoItem item, bool isNewItem)
        {
            var uri = new Uri("http://your-ip/api/todoitem/");
            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                if(isNewItem)
                {
                    response = await _client.PostAsync(uri, content);
                }
                else
                {
                    response = await _client.PutAsync(uri, content);
                }

                if(response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("/t Post succesfully");
                }


            }
            catch (Exception ex)
            {

                Debug.WriteLine("\t ERROR " + ex.Message);
            }
        }


    }
}
