using AutoMapper;
using Store.Domain.Entities;
using Store.WebAPI.Models.Categories;

namespace Store.WebAPI.MappingProfile
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
