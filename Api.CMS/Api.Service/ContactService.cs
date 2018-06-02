using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Api.Service
{
    public class ContactService : IContactService
    {
        //private string serviceUrl = ServiceConfiguration.apiHostingUrl; //"http://localhost:57562/api/Contact/";
        private IServiceHandler _service;
        public ContactService(IServiceHandler service)
        { 
            _service = service;
        }
        public async Task<IEnumerable<Contact>> GetContacts(string serviceUrl)
        { 
            var response = _service.Get(serviceUrl + "GetContacts", null);
            var data = await response.Result.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<Contact>>(data);
            return result;
        }

       public  async Task<Contact> CreateContact(string serviceUrl, Contact contact)
        {
            var contactData = JsonConvert.SerializeObject(contact);
            var response = _service.Post(serviceUrl + "CreateContact", contactData);
            var data = await response.Result.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Contact>(data);
            return result;
        }

        public async  Task<Contact> UpdateContact(string serviceUrl, Contact contact)
        {
            var contactData = JsonConvert.SerializeObject(contact);
            var response = _service.Put(serviceUrl + "UpdateContact", contactData);
            var data = await response.Result.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Contact>(data);
            return result;
        }

        public  async Task<int> DeleteContact(string serviceUrl, int id)
        {
            //var contactData = JsonConvert.SerializeObject(contact);
            var response = _service.Delete(serviceUrl + "DeleteContact", Convert.ToString(id));
            var data = await response.Result.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<int>(data);
            return result;
        }
    }
}
