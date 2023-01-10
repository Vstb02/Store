using AutoMapper;
using Store.Application.Models.Filters;
using Store.Domain.Filters;

namespace Store.Application.Common.MappingProfiles
{
    public class FilterProfile : Profile
    {
        public FilterProfile()
        {
            CreateMap<FilterPagingDto, FilterPaging>();
        }
    }
}
