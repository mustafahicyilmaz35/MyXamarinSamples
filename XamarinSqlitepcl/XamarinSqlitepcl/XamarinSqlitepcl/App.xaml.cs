﻿using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinSqlitepcl.DataAccess;
using XamarinSqlitepcl.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinSqlitepcl
{
	public partial class App : Application
	{
		static Database database;

		public static Database Database
		{
			get
			{
				if(database == null)
				{
					database = new Database(Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));
				}
				return database;
			}
		}

		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new PersonView());
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
