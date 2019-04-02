using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HavaDurumu
{
    public class RestService
    {
		HttpClient _client;

		public RestService()
		{
			_client = new HttpClient();
		}

		public async Task<WeatherData> GetWeatherDataAsync(string uri)
		{
			WeatherData weatherData = null;

			try
			{
				HttpResponseMessage response = await _client.GetAsync(uri);
				if(response.IsSuccessStatusCode)
				{
					string content = await response.Content.ReadAsStringAsync();
					weatherData = JsonConvert.DeserializeObject<WeatherData>(content);
				}
			}
			catch (Exception ex)
			{

				Debug.WriteLine("\t ERROR:" + ex.Message);
			}

			return weatherData;
		}
    }
}
