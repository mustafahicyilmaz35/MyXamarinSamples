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
	public partial class AppInfoPage : ContentPage
	{
		public AppInfoPage ()
		{
			InitializeComponent ();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			AppNameLabel.Text = AppInfo.Name;
			PackageNameLabel.Text = AppInfo.PackageName;
			VersionLabel.Text = AppInfo.VersionString;
			BuildLabel.Text = AppInfo.BuildString;
			
		}
	}
}