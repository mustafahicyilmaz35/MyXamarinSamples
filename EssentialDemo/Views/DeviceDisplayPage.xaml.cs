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
	public partial class DeviceDisplayPage : ContentPage
	{
		public DeviceDisplayPage ()
		{
			InitializeComponent ();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			var metrics = DeviceDisplay.MainDisplayInfo;

			OrientationLabel.Text = metrics.Orientation.ToString();
			RotationLabel.Text = metrics.Rotation.ToString();
			ScreenWidthLabel.Text = metrics.Width.ToString();
			ScreenHeightLabel.Text = metrics.Height.ToString();
			DensityLabel.Text = metrics.Density.ToString();
		}
	}
}