using AutoMapper;
using Store.Application.Models.Contacts;
using Store.Domain.Entities;

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
