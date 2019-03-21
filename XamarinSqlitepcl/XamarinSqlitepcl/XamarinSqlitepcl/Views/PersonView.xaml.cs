using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinSqlitepcl.Models;

namespace XamarinSqlitepcl.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PersonView : ContentPage
	{


		private int selectedPersonId;

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			lst_Person.ItemsSource = await App.Database.GetPeopleAsync();
		}

		private void onItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			Person selectedPerson = e.SelectedItem as Person;
			selectedPersonId = selectedPerson.ID;
		}

		private async void OnAddButtonClicked(object sender, EventArgs e)
		{
			if(!string.IsNullOrWhiteSpace(nameEntry.Text) && !string.IsNullOrWhiteSpace(ageEntry.Text))
			{
				await App.Database.SavePersonAsync(new Person { Name = nameEntry.Text, Age=int.Parse(ageEntry.Text) });

				nameEntry.Text = ageEntry.Text = string.Empty;
				lst_Person.ItemsSource = await App.Database.GetPeopleAsync();
			}
		}
		private async void OnUpdateButtonClicked(object sender, EventArgs e)
		{

			//var id = ((sender as Button).BindingContext as Person).ID;
			await App.Database.SavePersonAsync(new Person { ID=selectedPersonId, Name = nameEntry.Text, Age = int.Parse(ageEntry.Text) });

			
			lst_Person.ItemsSource = await App.Database.GetPeopleAsync();
			
		}

		private async void onDeleteClicked(object sender, EventArgs e)
		{
			await App.Database.DeleteAsync(new Person {ID = selectedPersonId });
			lst_Person.ItemsSource = await App.Database.GetPeopleAsync();
		}

		

		public PersonView ()
		{
			InitializeComponent ();
		}
	}
}