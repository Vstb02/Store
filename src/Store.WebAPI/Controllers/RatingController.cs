using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces;
using Store.Application.Models.Raitings;
using Store.Application.Models.Ratings;
using Store.Domain.Entities;

namespace Store.WebAPI.Controllers
{
    public class RatingController : ApiControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        /// <summary>
        /// Получение рейтинга товара
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>ProductRatingDto</returns>
        /// <response code="200">Success</response>
        /// <response code="404">NotFound</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        public async Task<IActionResult> GetProductRating(Guid productId)
        {
            var result = await _ratingService.GetProductRating(productId);

            return Ok(result);
        }

        /// <summary>
        /// Добавление рейтинга для товара
        /// </summary>
        /// <param name="rating"></param>
        /// <param name="productId"></param>
        /// <returns>RatingDto</returns>
        /// <response code="200">Success</response>
        /// <response code="404">NotFound</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        public async Task<IActionResult> AddRating(CreateRatingDto rating, Guid productId)
        {
            var result = await _ratingService.AddRating(UserId, rating, productId);

            return Ok(result);
        }

        /// <summary>
        /// Изменение рейтинга товара
        /// </summary>
        /// <param name="rating"></param>
        /// <param name="ratingId"></param>
        /// <returns>RatingDto</returns>
        /// <response code="200">Success</response>
        /// <response code="404">NotFound</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        public async Task<IActionResult> Setrating(CreateRatingDto rating, Guid ratingId)
        {
            var result = await _ratingService.SetRating(UserId, rating, ratingId);

            return Ok(result);
        }
    }
}
