using AutoMapper;
using Store.Application.Models.Categories;
using Store.Domain.Entities;

namespace Store.Application.Common.MappingProfile
{
    public class CategoryProfile : Profile 
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryDto, ProductCategory>();

            CreateMap<CategoryDto, ProductCategory>().ReverseMap();

            CreateMap<UpdateCategoryDto, ProductCategory>();
        }
    }
}
