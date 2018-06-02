using System;
using System.Collections.Generic;
using System.Text;
using Api.Database;
using Models = Api.BusinessLogic;

namespace Api.BusinessLogic
{
    public class ContactManager : IContactManager
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public ContactManager()
        {

        }

        public IEnumerable<Models.Contact> GetContacts()
        {
            var list = unitOfWork.ContactRepository.Get();
            var contacts = new List<Models.Contact>();
            var statuslist = unitOfWork.StatusRepository.Get();
                      
            foreach (var item in list)
            {
                contacts.Add(new Models.Contact
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    PhoneNumber = item.PhoneNumber,
                    Id = item.Id,
                    SelectedStatus = item.Status                   
                });
            }

            return contacts;
        }

        public Contact CreateContact(Contact contact)
        {
            var dbcontact = MapBusinessObjectToDbEntity(contact);
            unitOfWork.ContactRepository.Create(dbcontact);
            unitOfWork.Save();
            return contact;
        }

        public Contact UpdateContact(Contact contact)
        {
            var dbcontact = MapBusinessObjectToDbEntity(contact);
            unitOfWork.ContactRepository.Update(dbcontact);
            unitOfWork.Save();
            return contact;
        }

        public int DeleteContact(int id)
        {             
            unitOfWork.ContactRepository.Delete(id);
            unitOfWork.Save();
            return id;
        }

        private Api.Database.Contact MapBusinessObjectToDbEntity(Api.BusinessLogic.Contact sourceContact)
        {
            var destContact = new Api.Database.Contact();
            destContact.Id = sourceContact.Id;
            destContact.FirstName = sourceContact.FirstName;
            destContact.LastName = sourceContact.LastName;
            destContact.Email = sourceContact.Email;
            destContact.PhoneNumber = sourceContact.PhoneNumber;
            destContact.Status = sourceContact.SelectedStatus;
            return destContact;
        }

        private Api.BusinessLogic.Contact MapDbEntityToBusinessObject(Api.Database.Contact sourceContact)
        {
            var destContact = new Api.BusinessLogic.Contact();
            destContact.Id = sourceContact.Id;
            destContact.FirstName = sourceContact.FirstName;
            destContact.LastName = sourceContact.LastName;
            destContact.Email = sourceContact.Email;
            destContact.PhoneNumber = sourceContact.PhoneNumber;
            destContact.SelectedStatus = sourceContact.Status;
            return destContact;
        }

    }
}
