using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoRESTN.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoRESTN.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoItemPage : ContentPage
    {
        bool isNewItem;

        public TodoItemPage(bool isNew = false)
        {
            InitializeComponent();
            isNewItem = isNew;
            
        }

       async void OnSaveClicked(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            await App.database.SaveItem(todoItem,isNewItem);
            await Navigation.PopAsync();

        }
        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            await App.database.DeleteItem(todoItem);
            await Navigation.PopAsync();
        }
        async void OnCancelDeleted(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}