using AutoMapper;
using Store.Application.Models.Baskets;
using Store.Application.Models.Products;
using Store.Domain.Entities;

namespace Store.Application.Common.MappingProfiles
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<Product, BasketItem>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<BasketItem, BasketItemDto>()
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(x => x.Description, opt => opt.MapFrom(src => src.Product.Description))
                .ForMember(x => x.Status, opt => opt.MapFrom(src => src.Product.Status))
                .ForMember(x => x.MainImageUri, opt => opt.MapFrom(src => src.Product.MainImageUri))
                .ForMember(x => x.Discount, opt => opt.MapFrom(src => src.Product.Discount));
        }
    }
}
