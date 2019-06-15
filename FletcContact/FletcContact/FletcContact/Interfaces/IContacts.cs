using FletcContact.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FletcContact.Interfaces
{
    public interface IContacts
    {
        Task<List<ContactList>> GetDeviceContactAsync();
    }
}
