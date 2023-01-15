using AutoMapper;
using Store.Application.Models.Favorites;
using Store.Domain.Entities;

namespace Store.Application.Common.MappingProfiles
{
    public class FavoriteProfile : Profile
    {
        public FavoriteProfile()
        {
            CreateMap<Product, FavoriteItemDto>();
        }
    }
}
