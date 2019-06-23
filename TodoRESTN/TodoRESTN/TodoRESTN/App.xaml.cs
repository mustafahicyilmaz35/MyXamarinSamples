using System;
using TodoRESTN.Data;
using TodoRESTN.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoRESTN
{
    public partial class App : Application
    {

        public static TodoItemManager database { get; private set; }

        public App()
        {
            //InitializeComponent();
            database  = new TodoItemManager(new RestService());

            MainPage = new NavigationPage(new TodoListPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
