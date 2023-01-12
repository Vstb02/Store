using AutoMapper;
using Store.Application.Models.Filters;
using Store.Domain.Filters;
using Store.Domain.Filters.Products;

namespace Store.Application.Common.MappingProfiles
{
    public class FilterProfile : Profile
    {
        public FilterProfile()
        {
            CreateMap<FilterPagingDto, FilterPaging>();
            CreateMap<ProductFilterDto, ProductFilter>();
        }
    }
}
