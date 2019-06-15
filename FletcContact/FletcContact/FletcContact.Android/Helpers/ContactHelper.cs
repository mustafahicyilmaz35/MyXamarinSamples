using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FletcContact.Droid.Helpers;
using FletcContact.Interfaces;
using FletcContact.Models;


[assembly:Xamarin.Forms.Dependency(typeof(ContactHelper))]
namespace FletcContact.Droid.Helpers
{
    public class ContactHelper : IContacts
    {
        [Obsolete]
        public async Task<List<ContactList>> GetDeviceContactAsync()
        {
            ContactList selectedContact = new ContactList();
            List<ContactList> contactList = new List<ContactList>();
            var uri = ContactsContract.CommonDataKinds.Phone.ContentUri;
            string[] projection = { ContactsContract.Contacts.InterfaceConsts.Id, ContactsContract.Contacts.InterfaceConsts.DisplayName, ContactsContract.CommonDataKinds.Phone.Number };
            var cursor = Xamarin.Forms.Forms.Context.ContentResolver.Query(uri, projection, null, null, null);
            if (cursor.MoveToFirst())
            {
                do
                {
                    contactList.Add(new ContactList()
                    {
                        DisplayName = cursor.GetString(cursor.GetColumnIndex(projection[1]))
                    });
                } while (cursor.MoveToNext());
            }
            return contactList;
        }

        private object ManageQuery(Android.Net.Uri uri, string[] projection,object p1, object p2, object p3)
        {
            throw new NotImplementedException();
        }
    }
}