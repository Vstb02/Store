using AutoMapper;
using Store.Domain.Entities;

namespace Store.Application.Common.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<BasketItem, OrderItem>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
