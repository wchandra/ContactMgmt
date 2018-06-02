using System;
using System.Collections.Generic;
using System.Text;

namespace Api.BusinessLogic
{
    public interface IContactManager
    {
         IEnumerable<Contact> GetContacts();

         Contact CreateContact(Contact contact);

         Contact UpdateContact(Contact contact);

        int DeleteContact(int id);
    }
}
