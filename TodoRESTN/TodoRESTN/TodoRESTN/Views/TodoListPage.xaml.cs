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
    public partial class TodoListPage : ContentPage
    {


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await  App.database.GetAll();
        }

        public TodoListPage()
        {
            InitializeComponent();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodoItemPage(true)
            {
                BindingContext = new TodoItem
                {
                    ID = Guid.NewGuid().ToString()
                }
            });
        }

        void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new TodoItemPage {

                BindingContext = e.SelectedItem as TodoItem

            });
        }
    }
}