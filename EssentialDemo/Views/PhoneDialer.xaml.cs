using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace EssentialDemo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PhoneDialer : ContentPage
	{
		public PhoneDialer ()
		{
			InitializeComponent ();
		}

		private async void PhoneDialerButtonClicek(object sender, EventArgs e)
		{
			if(!string.IsNullOrEmpty(enrtyNum.Text))
			{
				await Call(enrtyNum.Text);
			}
		}
		 
		public async Task Call(string number)
		{
			try
			{
				Xamarin.Essentials.PhoneDialer.Open(number);

			}
			catch (FeatureNotSupportedException ex)
			{

				enrtyNum.Text = "Phone Dialer is not supporting this device";
			}
			catch(Exception ex)
			{
				throw;
			}
			
		}
	}
}