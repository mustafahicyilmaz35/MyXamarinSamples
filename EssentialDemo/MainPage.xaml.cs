using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EssentialDemo.Views;
using Xamarin.Forms;

namespace EssentialDemo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private void AppInfoButtonClick(object sender, EventArgs e)
		{
			Navigation.PushAsync(new AppInfoPage());
		}
		private void BatteryButtonClick(object sender, EventArgs e)
		{
			Navigation.PushAsync(new BateryPage());
		}

		private void DeviceDisplayInfoClicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new DeviceDisplayPage());
		}

		private void DeviceInfoButtonClicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new DeviceInfoPage());
		}

		private void CallingButtonClicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new PhoneDialer());
		}

		private void EmailButtonClicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new EmailPage());
		}
		private void SendSmsButtonClicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new SmsPage());
		}
		private void GeoButtonClicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new GeoPage());
		}
	}
}
