using Store.Application.Models.Raitings;
using Store.Application.Models.Ratings;

namespace Store.Application.Interfaces
{
    public interface IRatingService
    {
        Task<ProductRatingDto> GetProductRating(Guid productId,
                                                CancellationToken cancellationToken = default);
        Task<RatingDto> SetRating(string buyerId,
                                  CreateRatingDto ratingDto,
                                  Guid productId,
                                  CancellationToken cancellationToken = default);
    }
}
