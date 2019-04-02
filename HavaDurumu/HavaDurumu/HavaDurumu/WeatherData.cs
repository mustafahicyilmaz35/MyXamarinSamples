using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace HavaDurumu
{
    public class WeatherData
    {
		[JsonProperty("name")]
		public string Title { get; set; }

		[JsonProperty("weather")]
		public Weather[] Weather { get; set; }

		[JsonProperty("main")]
		public Main Main { get; set; }
		
		[JsonProperty("visibility")]
		public long Visibility { get; set; }

		[JsonProperty("wind")]
		public Wind Wind { get; set; }
	}

	public class Main
	{
		[JsonProperty("temp")]
		public double Temperature { get; set; }
		

		[JsonProperty("humidty")]
		public long Humidity { get; set; }
		
	}

	public class Weather
	{
		[JsonProperty("main")]
		public string Visibility { get; set; }
	}

	public class Wind
	{
		[JsonProperty("speed")]
		public double Speed { get; set; }
	}
}
