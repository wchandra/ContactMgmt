using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Web.CMS.Areas.Contact.Models;
namespace Web.CMS
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Api.Service.Contact, Contact>();
        }
    }


}
