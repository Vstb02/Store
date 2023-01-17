using AutoMapper;
using Store.Application.Models.Brands;
using Store.Domain.Entities;

namespace Store.Application.Common.MappingProfiles
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<CreateBrandDto, Brand>();

            CreateMap<Brand, BrandDto>().ReverseMap();

            CreateMap<UpdateBrandDto, Brand>();
        }
    }
}
