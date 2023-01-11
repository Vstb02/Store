using AutoMapper;
using Store.Application.Models.Brands;
using Store.Application.Models.Products;
using Store.Domain.Entities;

namespace Store.Application.Common.MappingProfile
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

            CreateMap<Brand, BrandDto>();

            CreateMap<Product, ProductDto>()
                .ForMember(x => x.ProductImages, opt => opt.MapFrom(src => src.ProductImages))
                .ForMember(x => x.Brand, opt => opt.MapFrom(src => src.Brand));
        }
    }
}
