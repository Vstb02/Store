using AutoMapper;
using Store.Application.Models.Contacts;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Common.MappingProfiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<CreateContactDto, Contact>();

            CreateMap<UpdateContactDto, Contact>();

            CreateMap<Contact, ContactDto>();
        }
    }
}
