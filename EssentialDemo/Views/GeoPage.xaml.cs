using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EssentialDemo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GeoPage : ContentPage
	{
		public GeoPage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}

		async void onGeoButtonClicked(object sender, EventArgs e)
		{
			try
			{
				var location = await Geolocation.GetLastKnownLocationAsync();
				if(location != null)
				{
					lbl_Latitude.Text = "Latitude: " + location.Latitude.ToString();
					lbl_Aptitude.Text = "Longtude:" + location.Longitude.ToString();
				}
			}
			catch (FeatureNotSupportedException ex)
			{

				await DisplayAlert("Failed", ex.Message, "OK");
			}
			catch(PermissionException ex)
			{
				await DisplayAlert("Failed", ex.Message, "OK");
			}
			catch(Exception ex)
			{
				await DisplayAlert("Faied", ex.Message, "OK");
			}
		}
	}
}