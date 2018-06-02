using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.BusinessLogic;
using Models = Api.Controllers;
using Newtonsoft.Json;

namespace Api.Controllers
{
     
[Route("api/[controller]/[action]")]
    public class ContactController : Controller
    {
        private IContactManager _manager;
        public ContactController(IContactManager manager)
        {
            _manager = manager;
        }
         

        [HttpGet]
        public IEnumerable<Contact> GetContacts()
        { 
            var list =  _manager.GetContacts();
            var contacts = new List<Models.Contact>();
            if (list != null && list.Any())
            {
                foreach (var item in list)
                {
                    contacts.Add(new Models.Contact
                    {
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Email = item.Email,
                        PhoneNumber = item.PhoneNumber,
                        Id = item.Id,
                        Status = item.SelectedStatus
                    });
                }
            }
            return contacts;
        }
         

        // POST: api/Sample
        [HttpPost]
        public Api.BusinessLogic.Contact CreateContact([FromBody]string value)
        {
            var contact = JsonConvert.DeserializeObject<Contact>(value);
            var serviceContact = new Api.BusinessLogic.Contact()
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber,
                SelectedStatus = contact.Status
            };

            var result =  _manager.CreateContact(serviceContact);
            return result;
        }
        
        // PUT: api/Sample/5
        [HttpPut]
        public Api.BusinessLogic.Contact UpdateContact([FromBody]string value)
        {
            var contact = JsonConvert.DeserializeObject<Contact>(value);
            var serviceContact = new Api.BusinessLogic.Contact()
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber,
                SelectedStatus = contact.Status
            };

            var result = _manager.UpdateContact(serviceContact);
            return result;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public int DeleteContact(int id)
        {
            if (id > 0)
            {
                _manager.DeleteContact(id);
            }

            return id;
        }
    }
}
