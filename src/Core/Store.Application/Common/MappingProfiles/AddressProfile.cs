using AutoMapper;
using Store.Application.Models.Addresses;
using Store.Domain.Entities;

namespace Store.Application.Common.MappingProfiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressDto>();

            CreateMap<CreateAddressDto, Address>();

            CreateMap<UpdateAddressDto, Address>();
        }
    }
}
