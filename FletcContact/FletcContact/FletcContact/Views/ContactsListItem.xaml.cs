using FletcContact.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FletcContact.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsListItem : ContentPage
    {
        public ContactsListItem()
        {
            InitializeComponent();
        }
        
        async void PickButtonClicked(object sender,EventArgs e)
        {
            var ContactsList = await DependencyService.Get<IContacts>().GetDeviceContactAsync();
            listView.ItemsSource = ContactsList;
        }
    }
}