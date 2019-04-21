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
	public partial class DeviceInfoPage : ContentPage
	{
		public DeviceInfoPage ()
		{
			InitializeComponent ();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			DeviceLAbel.Text = DeviceInfo.Model;
			ManufacturerLabel.Text = DeviceInfo.Manufacturer;
			DeviceNameLabel.Text = DeviceInfo.Name;
			VersionLabel.Text = DeviceInfo.VersionString;
			PlatformLabel.Text = DeviceInfo.Platform.ToString();
			IdiomLabel.Text = DeviceInfo.Idiom.ToString();
			DeviceTypeLabel.Text = DeviceInfo.DeviceType.ToString();
		}
	}
}