using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HavaDurumu
{
	public partial class MainPage : ContentPage
	{
		RestService _restService;

		public MainPage()
		{
			InitializeComponent();
			_restService = new RestService(); 
		}

		private async void onButtonClicked(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(cityEntry.Text))
			{
				WeatherData weatherData = await _restService.GetWeatherDataAsync(GenerateRequestUri(Constants.Constants.OpenWeatherMapEndPoint));
				BindingContext = weatherData;
			}
		}

		private string GenerateRequestUri(string endPoint)
		{
			string requestUri = endPoint;
			requestUri += $"?q={cityEntry.Text}";
			requestUri += "&units=metric"; //"&units=imperial"
			requestUri += $"&APPID={Constants.Constants.OpenWeatherMapApiKey}";
			return requestUri;
		}
	}
}
