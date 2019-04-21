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
	public partial class EmailPage : ContentPage
	{
		public EmailPage()
		{
			InitializeComponent();
		}

		private async void onSendButtonClicked(object sender, EventArgs e)
		{
			if(string.IsNullOrEmpty(ToEntry.Text))
			{
				await DisplayAlert("Email", "Please provide a recipient","OK");
				return;
			}
			if(string.IsNullOrEmpty(SubjectEntry.Text))
			{
				await DisplayAlert("Email", "Please provide a subject", "OK");
				return;
			}
			if(string.IsNullOrEmpty(MessageEditor.Text))
			{
				await DisplayAlert("Email", "Please provide a Message","OK");
				return;
			}

			try
			{
				var message = new EmailMessage
				{
					To = new List<string> { ToEntry.Text },
					Subject = SubjectEntry.Text,
					Body = MessageEditor.Text
				};

				await Email.ComposeAsync(message);
			}
			catch (Exception ex)
			{

				await DisplayAlert("Email", $"Something went to wrong when sending the mail: {ex}", "OK");
			}
		}
	}
}