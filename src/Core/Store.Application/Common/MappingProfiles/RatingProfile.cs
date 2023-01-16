using AutoMapper;
using Store.Application.Models.Raitings;
using Store.Application.Models.Ratings;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Common.MappingProfiles
{
    public class RatingProfile : Profile
    {
        public RatingProfile()
        {
            CreateMap<Rating, RatingDto>();
            CreateMap<CreateRatingDto, Rating>();
        }
    }
}
