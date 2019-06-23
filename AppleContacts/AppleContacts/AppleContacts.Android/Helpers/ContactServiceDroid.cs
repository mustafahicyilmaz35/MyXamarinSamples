using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppleContacts.Droid.Helpers;
using AppleContacts.Interfaces;
using AppleContacts.Models;

[assembly:Xamarin.Forms.Dependency(typeof(ContactServiceDroid))]
namespace AppleContacts.Droid.Helpers
{
    public class ContactServiceDroid : IContactService
    {
        [Obsolete]
        public IEnumerable<PhoneContact> GetAllContact()
        {
            PhoneContact selectedContact = new PhoneContact();
            List<PhoneContact> contactList = new List<PhoneContact>();
            var uri = ContactsContract.CommonDataKinds.Phone.ContentUri;
            string[] projection = { ContactsContract.Contacts.InterfaceConsts.Id, ContactsContract.Contacts.InterfaceConsts.DisplayName, ContactsContract.CommonDataKinds.Phone.Number };
            var cursor = Xamarin.Forms.Forms.Context.ContentResolver.Query(uri, projection, null, null, null);
            if (cursor.MoveToFirst())
            {
                do
                {
                    contactList.Add(new PhoneContact()
                    {
                        FirstName = cursor.GetString(cursor.GetColumnIndex(projection[1])),
                        PhoneNumber = cursor.GetString(cursor.GetColumnIndex(projection[2]))
                        
                    });
                } while (cursor.MoveToNext());
            }
            return contactList;

        }
    }
}