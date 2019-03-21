using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinSqlitepcl.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PersonUpdateView : ContentPage
	{
		private int personID;

		public PersonUpdateView(int id):this()
		{
			personID = id;
		}

		public PersonUpdateView ()
		{
			InitializeComponent ();
		}

		private async void onApproveUpdate(object sender, EventArgs e)
		{
			await App.Database.SavePersonAsync(new Models.Person { ID=personID, Name = enty_updt_name.Text, Age = int.Parse(entry_updt_age.Text) });
			await DisplayAlert("Uyarı", "Veritabanı güncellendi", "OK");
			await Navigation.PopAsync();

		}
	}
}