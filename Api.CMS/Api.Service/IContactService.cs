using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetContacts(string url);

        Task<Contact> CreateContact(string url, Contact contact);

        Task<Contact> UpdateContact(string url, Contact contact);

        Task<int> DeleteContact(string url, int id);
    }
}
