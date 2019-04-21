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
	public partial class SmsPage : ContentPage
	{
		public SmsPage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}

		async void onSmsButtonClicked(object sender, EventArgs e)
		{
			if(!string.IsNullOrEmpty(entry_textNumber.Text))
			{
				await SendSms(enrty_textMessage.Text,entry_textNumber.Text);
			}
		}

		private async Task SendSms(string messageText, string recipient)
		{
			try
			{
				var message = new SmsMessage(messageText, recipient);
				await Sms.ComposeAsync(message);
			}
			catch (FeatureNotSupportedException ex)
			{

				await DisplayAlert("Failed", "This device is not supported SMS", "OK");
			}
			catch(Exception ex)
			{
				await DisplayAlert("Failed", ex.Message, "OK");
			}
		}
	}
}