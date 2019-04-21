using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EssentialDemo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BateryPage : ContentPage
	{
		public BateryPage ()
		{
			InitializeComponent ();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			BatteryLevelLabel.Text = Battery.ChargeLevel.ToString();
			BateryStateLabel.Text = Battery.State.ToString();
			BatteryPoweSourceLabel.Text = Battery.PowerSource.ToString();
		}
	}
}