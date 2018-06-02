using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ContactModel =Web.CMS.Areas.Contact.Models;
using Api.Service;

namespace Web.CMS.Areas.Contact.Controllers
{
    public class ContactController : Controller
    {
        private IContactService _service;
       
        public ContactController(IContactService service)
        { 
            _service = service;            
        }
        // GET: Contact
        public async Task<ViewResult> Index()
        {
           var response = await _service.GetContacts(ServiceConfiguration.serviceUrl);
           var list = new List<ContactModel.Contact>();
           foreach(var item in response)
            {
                list.Add(new ContactModel.Contact() { Id = item.Id, FirstName = item.FirstName, LastName = item.LastName, Email = item.Email, PhoneNumber =item.PhoneNumber,  SelectedStatus = (item.Status==1?"Active": "Inactive") });
            }
            return View("Index", list);
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contact/Create
        [HttpGet]
        public ViewResult Create()
        {
            return View("Create", new ContactModel.Contact());
        }

        // POST: Contact/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ContactModel.Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var serviceContact = new Api.Service.Contact()
                    {
                        FirstName = contact.FirstName,
                        LastName = contact.LastName,
                        Email = contact.Email,
                        PhoneNumber = Convert.ToInt64(contact.PhoneNumber),
                        Status = Convert.ToInt32(contact.SelectedStatus)
                    };

                    var response = await _service.CreateContact(ServiceConfiguration.serviceUrl, serviceContact);
                    return RedirectToAction(nameof(Index));
                }
               
                return View("Create", contact);
            }
            catch
            {
                return View("Create", contact);
            }
        }

        // GET: Contact/Edit/5
        public async Task<ViewResult> Edit(int id)
        {
            var response = await _service.GetContacts(ServiceConfiguration.serviceUrl);
            var contact = response.Where(r => r.Id == id).FirstOrDefault();
            var serviceContact = new ContactModel.Contact()
            {
                Id = id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber,
                SelectedStatus = Convert.ToString(contact.Status)
            };
            
            return View("Edit", serviceContact);
        }

        // POST: Contact/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ContactModel.Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var serviceContact = new Api.Service.Contact()
                    {
                        Id = id,
                        FirstName = contact.FirstName,
                        LastName = contact.LastName,
                        Email = contact.Email,
                        PhoneNumber = Convert.ToInt64(contact.PhoneNumber),
                        Status = Convert.ToInt32(contact.SelectedStatus)
                    };               

                    var response = await _service.UpdateContact(ServiceConfiguration.serviceUrl, serviceContact);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            } 
            catch
            {
                return View();
            }
        }

        // GET: Contact/Delete/5
        public async Task<ViewResult> Delete(int id)
        { 
            var result =  _service.DeleteContact(ServiceConfiguration.serviceUrl, id);
            var response = await _service.GetContacts(ServiceConfiguration.serviceUrl);
            var list = new List<ContactModel.Contact>();
            foreach (var item in response)
            {
                list.Add(new ContactModel.Contact() { Id = item.Id, FirstName = item.FirstName, LastName = item.LastName, Email = item.Email, PhoneNumber = item.PhoneNumber, SelectedStatus = (item.Status == 1 ? "Active" : "Inactive") });
            }
            return View("Index", list);
             
        }
         
    }
}