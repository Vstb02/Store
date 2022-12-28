using AutoMapper;
using Store.Domain.Entities;
using Store.WebAPI.Models.Products;

namespace Store.WebAPI.MappingProfile
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductImage, ProductImageDto>().ReverseMap();

            CreateMap<CreateProductDto, Product>()
                .ForMember(x => x.ProductImages, opt => opt.MapFrom(src => src.ProductImages));

            CreateMap<ProductImageDto, ProductImage>();

            CreateMap<UpdateProductDto, Product>()
                .ForMember(x => x.ProductImages, opt => opt.MapFrom(src => src.ProductImages));

            CreateMap<ProductDto, Product>()
                .ForMember(x => x.ProductImages, opt => opt.MapFrom(src => src.ProductImages));

            CreateMap<Product, ProductDto>()
                .ForMember(x => x.ProductImages, opt => opt.MapFrom(src => src.ProductImages));
        }
    }
}
