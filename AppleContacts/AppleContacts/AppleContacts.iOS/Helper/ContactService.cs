using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppleContacts.Interfaces;
using AppleContacts.iOS.Helper;
using AppleContacts.Models;
using Contacts;
using Foundation;
using UIKit;
[assembly:Xamarin.Forms.Dependency(typeof(ContactService))]
namespace AppleContacts.iOS.Helper
{
    public class ContactService : IContactService
    {
        public IEnumerable<PhoneContact> GetAllContact()
        {
            var keysToFetch = new[] {CNContactKey.GivenName,CNContactKey.FamilyName,CNContactKey.PhoneNumbers };
            NSError error;
            var contactList = new List<CNContact>();

            using (var store = new CNContactStore())
            {
                var allContainers = store.GetContainers(null, out error);
                foreach(var container in allContainers)
                {
                    try
                    {
                        using (var predicate = CNContact.GetPredicateForContactsInContainer(container.Identifier))
                        {
                            var containerResults = store.GetUnifiedContacts(predicate, keysToFetch, out error);
                            contactList.AddRange(containerResults);
                        }
                    }
                    catch (Exception)
                    {
                        // ignore missed contacts from errors
                        throw;
                    }
                }
            }
            var contacts = new List<PhoneContact>();
            foreach(var item in contactList)
            {
                var numbers = item.PhoneNumbers;
                if(numbers!=null)
                {
                    foreach(var item2 in numbers)
                    {
                        contacts.Add(new PhoneContact {
                            FirstName = item.GivenName,
                            LastName = item.FamilyName,
                            PhoneNumber = item2.Value.StringValue
                        });
                    }
                }
            }
            return contacts;
        }
    }
}