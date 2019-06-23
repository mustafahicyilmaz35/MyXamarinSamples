using AppleContacts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppleContacts.Interfaces
{
    public interface IContactService
    {
        IEnumerable<PhoneContact> GetAllContact();
    }
}
