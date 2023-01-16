using Store.Application.Models.Raitings;
using Store.Application.Models.Ratings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Interfaces
{
    public interface IRatingService
    {
        Task<RatingDto> SetRating(string buyerId,
                                  CreateRatingDto ratingDto,
                                  Guid ratingId,
                                  CancellationToken cancellationToken = default);
        Task<ProductRatingDto> GetProductRating(Guid productId,
                                                CancellationToken cancellationToken = default);
        Task<RatingDto> AddRating(string buyerId,
                                  CreateRatingDto ratingDto,
                                  Guid productId,
                                  CancellationToken cancellationToken = default);
    }
}
