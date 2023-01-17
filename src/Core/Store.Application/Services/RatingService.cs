using AutoMapper;
using Store.Application.Common.Exceptions;
using Store.Application.Interfaces;
using Store.Application.Models.Raitings;
using Store.Application.Models.Ratings;
using Store.Domain.Entities;
using Store.Domain.Interfaces;

namespace Store.Application.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public RatingService(IRatingRepository ratingRepository,
                             IMapper mapper,
                             IProductRepository productRepository)
        {
            _ratingRepository = ratingRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<ProductRatingDto> GetProductRating(Guid productId, CancellationToken cancellationToken = default)
        {
            var existingProduct = await _productRepository.GetById(productId, cancellationToken);

            if (existingProduct is null)
            {
                throw new NotFoundException("Товра не найден");
            }

            var productRatings = await _ratingRepository.GetByProductId(productId, cancellationToken);

            var totalRating = Math.Round((double)productRatings.Sum(x => x.Value) / productRatings.Count(), 1);

            var result = new ProductRatingDto { ProductId = productId, TotalValue = totalRating };

            return result;
        }

        public async Task<RatingDto> AddRating(string buyerId,
                                    CreateRatingDto ratingDto,
                                    Guid productId,
                                    CancellationToken cancellationToken = default)
        {
            var existingProduct = await _productRepository.GetById(productId);

            if (existingProduct is null)
            {
                throw new NotFoundException("Товар не найден");
            }

            var existingRating = _ratingRepository.GetByBuyerId(buyerId, cancellationToken);

            if (existingRating is not null)
            {
                throw new DuplicateException("Оценка уже установлена");
            }

            var rating = _mapper.Map<Rating>(ratingDto);
            rating.AuthorId = buyerId;
            rating.ProductId = existingProduct.Id;

            rating = await _ratingRepository.Create(rating, cancellationToken);

            var result = _mapper.Map<RatingDto>(rating);

            return result;
            
        }

        public async Task<RatingDto> SetRating(string buyerId,
                                    CreateRatingDto ratingDto,
                                    Guid ratingId,
                                    CancellationToken cancellationToken = default)
        {
            var existingRating = await _ratingRepository.GetById(ratingId);

            if (existingRating is null)
            {
                throw new NotFoundException("Рейтинг еще не установлен");
            }

            existingRating.Value = ratingDto.Value;

            await _ratingRepository.Update(existingRating);

            var result = _mapper.Map<RatingDto>(existingRating);

            return result;
        }
    }
}
