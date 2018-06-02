using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Database
{
    public interface IContactRepository : IDisposable
    {
         
            IEnumerable<Contact> GetContacts();
            Contact GetContactByID(int contactId);
            void CreateContact(Contact contact);
            void DeleteContact(int ContactID);
            void UpdateContact(Contact contact);
            void Save();
       
    }
}
